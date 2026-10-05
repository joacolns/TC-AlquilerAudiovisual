using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using BE;
using DAL;
using SERVICE;

namespace BLL
{
    public class ReservaBLL
    {
        private readonly ReservaMapper mapper = new ReservaMapper();
        private readonly Seguridad seguridad = new Seguridad();
        private readonly ClienteBLL clientes = new ClienteBLL();
        private readonly EquipoBLL equipos = new EquipoBLL();

        public decimal Cotizar(Reserva reserva)
        {
            Autorizar("Reserva.Cotizar");
            if (reserva == null || reserva.Hasta <= reserva.Desde || reserva.Equipos == null || reserva.Equipos.Count == 0)
                throw new ArgumentException("Elegí fechas y al menos una unidad.");
            List<Equipo> disponibles = equipos.ListarDisponibles(reserva.Desde, reserva.Hasta);
            List<Equipo> seleccion = new List<Equipo>();
            decimal tarifa = 0, reposicion = 0;
            foreach (Equipo solicitado in reserva.Equipos)
            {
                if (solicitado == null) throw new ArgumentException("La selección contiene una unidad inválida.");
                foreach (Equipo repetido in seleccion) if (repetido.Id == solicitado.Id) throw new ArgumentException("Una unidad está repetida.");
                Equipo encontrado = null;
                foreach (Equipo disponible in disponibles) if (disponible.Id == solicitado.Id) { encontrado = disponible; break; }
                if (encontrado == null) throw new InvalidOperationException("Una unidad ya no está disponible para esas fechas.");
                seleccion.Add(encontrado);
                tarifa += encontrado.TarifaDiaria;
                reposicion += encontrado.ValorReposicion;
            }
            decimal dias = decimal.Ceiling((reserva.Hasta - reserva.Desde).Ticks / (decimal)TimeSpan.TicksPerDay);
            reserva.Equipos = seleccion;
            reserva.Importe = decimal.Round(tarifa * dias, 2, MidpointRounding.AwayFromZero);
            reserva.Sena = decimal.Round(reserva.Importe * Porcentaje("PorcentajeSena"), 2, MidpointRounding.AwayFromZero);
            reserva.Garantia = decimal.Round(reposicion * Porcentaje("PorcentajeGarantia"), 2, MidpointRounding.AwayFromZero);
            return reserva.Importe;
        }

        public int Solicitar(Reserva reserva)
        {
            Autorizar("Reserva.Solicitar");
            if (reserva == null || reserva.Id != 0) throw new ArgumentException("Elegí equipos y fechas para una nueva solicitud.");
            // La identidad procede de la sesión, nunca del cliente enviado por el formulario.
            List<Cliente> propios = clientes.Listar();
            if (propios.Count != 1) throw new InvalidOperationException("Tu cuenta debe tener una ficha de cliente registrada.");
            reserva.Cliente = propios[0]; reserva.ClienteId = propios[0].Id;
            Cotizar(reserva);
            ReservaBuilder builder = new ReservaBuilder();
            builder.ConCliente(reserva.Cliente);
            foreach (Equipo equipo in reserva.Equipos) builder.ConEquipo(equipo);
            builder.ConFechas(reserva.Desde, reserva.Hasta);
            Reserva solicitud = builder.Construir();
            solicitud.Importe = reserva.Importe;
            solicitud.Estado = "Pendiente";
            solicitud.Id = mapper.Insertar(solicitud);
            reserva.Id = solicitud.Id; reserva.Estado = "Pendiente";
            reserva.Sena = 0; reserva.Garantia = 0;
            return solicitud.Id;
        }

        public int Confirmar(Reserva reserva)
        {
            Autorizar("Reserva.Confirmar");
            if (reserva == null || reserva.Id <= 0) throw new ArgumentException("Seleccioná una solicitud pendiente.");
            decimal senaRecibida = reserva.Sena, garantiaRecibida = reserva.Garantia;
            Reserva solicitud = mapper.Buscar(reserva.Id);
            if (solicitud == null || solicitud.Estado != "Pendiente") throw new InvalidOperationException("La solicitud no existe o ya fue aceptada.");
            if (!clientes.ValidarCliente(solicitud.ClienteId, solicitud.Desde, solicitud.Hasta))
                throw new InvalidOperationException("El cliente no está habilitado: verificá cuenta, antecedentes y seguro vigente.");
            Cotizar(solicitud);
            if (senaRecibida != solicitud.Sena || garantiaRecibida != solicitud.Garantia)
                throw new InvalidOperationException("La seña y la garantía recibidas deben coincidir con la cotización actual.");
            ReservaBuilder builder = new ReservaBuilder();
            builder.ConCliente(solicitud.Cliente);
            foreach (Equipo equipo in solicitud.Equipos) builder.ConEquipo(equipo);
            builder.ConFechas(solicitud.Desde, solicitud.Hasta);
            Reserva nueva = builder.Construir();
            nueva.Id = solicitud.Id; nueva.Estado = "Firme";
            nueva.Importe = solicitud.Importe; nueva.Sena = senaRecibida; nueva.Garantia = garantiaRecibida;
            if (!mapper.Confirmar(nueva)) throw new InvalidOperationException("La solicitud ya fue procesada.");
            reserva.Id = nueva.Id; reserva.Estado = nueva.Estado;
            return nueva.Id;
        }

        public bool RegistrarEntrega(int reservaId)
        {
            Autorizar("Reserva.Entregar");
            Reserva reserva = mapper.Buscar(reservaId);
            if (reserva == null || reserva.Estado != "Firme") return false;
            return mapper.RegistrarEntrega(reservaId);
        }

        public List<Reserva> Listar()
        {
            Autorizar("Reserva.Consultar");
            Usuario usuario = SesionSingleton.Instancia.UsuarioActual;
            if (usuario.Rol != "Cliente") return mapper.Listar(null);
            List<Cliente> propios = clientes.Listar();
            if (propios.Count == 0) return new List<Reserva>();
            return mapper.Listar(propios[0].Id);
        }

        private decimal Porcentaje(string clave)
        {
            decimal valor;
            if (!decimal.TryParse(ConfigurationManager.AppSettings[clave], NumberStyles.Number, CultureInfo.InvariantCulture, out valor) || valor < 0 || valor > 1)
                throw new InvalidOperationException("Revisá los porcentajes de seña y garantía en App.config.");
            return valor;
        }
        private void Autorizar(string codigo)
        {
            if (!seguridad.TienePermiso(codigo)) throw new UnauthorizedAccessException("No tenés permiso para esta operación de reservas.");
        }
    }
}

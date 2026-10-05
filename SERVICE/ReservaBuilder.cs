using System;
using System.Collections.Generic;
using BE;

namespace SERVICE
{
    public class ReservaBuilder
    {
        private readonly Reserva reserva = new Reserva { Equipos = new List<Equipo>() };

        public ReservaBuilder ConCliente(Cliente cliente)
        {
            if (cliente == null || cliente.Id <= 0) throw new ArgumentException("Seleccioná un cliente.");
            reserva.ClienteId = cliente.Id;
            reserva.Cliente = cliente;
            return this;
        }

        public ReservaBuilder ConEquipo(Equipo equipo)
        {
            if (equipo == null || equipo.Id <= 0) throw new ArgumentException("Seleccioná un equipo válido.");
            foreach (Equipo existente in reserva.Equipos)
                if (existente.Id == equipo.Id) throw new ArgumentException("La misma unidad no puede agregarse dos veces.");
            reserva.Equipos.Add(equipo);
            return this;
        }

        public ReservaBuilder ConFechas(DateTime desde, DateTime hasta)
        {
            if (hasta <= desde) throw new ArgumentException("La fecha final debe ser posterior a la inicial.");
            reserva.Desde = desde;
            reserva.Hasta = hasta;
            return this;
        }

        public Reserva Construir()
        {
            if (reserva.ClienteId <= 0 || reserva.Equipos.Count == 0 || reserva.Hasta <= reserva.Desde)
                throw new InvalidOperationException("Completá cliente, equipos y fechas de la reserva.");
            reserva.Estado = "Pendiente";
            return reserva;
        }
    }
}

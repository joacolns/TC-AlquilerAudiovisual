using System;
using System.Collections.Generic;
using BE;
using DAL;
using SERVICE;

namespace BLL
{
	public class EquipoBLL
	{
		private readonly EquipoMapper mapper = new EquipoMapper();
		private readonly Seguridad seguridad = new Seguridad();

		public int Guardar(Equipo equipo)
		{
			Autorizar("Equipo.Guardar");

			if (equipo == null
				|| string.IsNullOrWhiteSpace(equipo.CodigoInventario)
				|| equipo.CodigoInventario.Length > 30
				|| string.IsNullOrWhiteSpace(equipo.Serie)
				|| equipo.Serie.Length > 80
				|| string.IsNullOrWhiteSpace(equipo.Categoria)
				|| equipo.Categoria.Length > 50
				|| string.IsNullOrWhiteSpace(equipo.Marca)
				|| equipo.Marca.Length > 50
				|| string.IsNullOrWhiteSpace(equipo.Modelo)
				|| equipo.Modelo.Length > 80
				|| equipo.Descripcion == null
				|| equipo.Descripcion.Length > 300
				|| equipo.TarifaDiaria <= 0
				|| equipo.ValorReposicion <= 0
				|| equipo.DiasReacondicionamiento < 0
				|| equipo.DiasReacondicionamiento > 365)
			{
				throw new ArgumentException("Completá los datos de la unidad, importes positivos y días entre 0 y 365.");
			}

			// Alquilado y ConIncidencia se asignan en sus procesos, no desde el catálogo.
			if (equipo.Estado != "Disponible" && equipo.Estado != "Baja")
			{
				throw new ArgumentException("Desde stock elegí Disponible o Baja.");
			}

			if (equipo.Seguro != null && equipo.Seguro.Id <= 0)
			{
				throw new ArgumentException("Seleccioná una póliza registrada o sin seguro.");
			}

			if (equipo.Id == 0)
			{
				equipo.Id = mapper.Insertar(equipo);
			}
			else if (!mapper.Actualizar(equipo))
			{
				throw new InvalidOperationException("La unidad no existe.");
			}

			return equipo.Id;
		}

		public List<Equipo> Listar()
		{
			Autorizar("Equipo.Consultar");
			return FiltrarSeguros(mapper.Listar());
		}

		public List<Equipo> ListarDisponibles(DateTime desde, DateTime hasta)
		{
			Autorizar("Equipo.Consultar");

			if (hasta <= desde || hasta > DateTime.MaxValue.AddDays(-366))
			{
				throw new ArgumentException("Ingresá un período válido: hasta posterior a desde.");
			}

			return FiltrarSeguros(mapper.ListarDisponibles(desde, hasta));
		}

		private List<Equipo> FiltrarSeguros(List<Equipo> lista)
		{
			Usuario usuario = SesionSingleton.Instancia.UsuarioActual;

			foreach (Equipo equipo in lista)
			{
				if (usuario.Rol == "Tecnico"
					|| (usuario.Rol == "Cliente"
						&& equipo.Seguro != null
						&& equipo.Seguro.Cliente.UsuarioId != usuario.Id))
				{
					equipo.Seguro = null;
				}
			}

			return lista;
		}

		private void Autorizar(string codigo)
		{
			if (!seguridad.TienePermiso(codigo))
			{
				throw new UnauthorizedAccessException("No tenés permiso para esta operación de equipos.");
			}
		}
	}
}

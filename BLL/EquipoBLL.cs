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
		private readonly UsuarioMapper usuarios = new UsuarioMapper();

		public int Guardar(Equipo equipo)
		{
			return Guardar(equipo, null);
		}

		// "original" es la unidad tal como la vio quien edita: si cambió en la base, no se pisa el trabajo de otra persona.
		public int Guardar(Equipo equipo, Equipo original)
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
				throw new ArgumentException("Completá los datos de la unidad y los importes positivos de tarifa y reposición.");
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

			if (equipo.Id != 0 && original != null)
			{
				Equipo actual = mapper.Listar().Find(delegate(Equipo e) { return e.Id == equipo.Id; });

				if (actual == null)
				{
					throw new InvalidOperationException("La unidad ya no existe. Actualizá el inventario.");
				}

				if (actual.Estado != original.Estado
					|| actual.TarifaDiaria != original.TarifaDiaria
					|| actual.ValorReposicion != original.ValorReposicion
					|| actual.CodigoInventario != original.CodigoInventario
					|| actual.Serie != original.Serie
					|| actual.Categoria != original.Categoria
					|| actual.Marca != original.Marca
					|| actual.Modelo != original.Modelo
					|| actual.Descripcion != original.Descripcion
					|| actual.DiasReacondicionamiento != original.DiasReacondicionamiento)
				{
					throw new InvalidOperationException(
						"La unidad " + actual.CodigoInventario + " cambió mientras la editabas (otra persona la modificó o cambió su estado). Actualizá el inventario y volvé a intentar."
					);
				}
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

		// Lo que se ofrece al cliente: oculta también las unidades que otra solicitud pendiente ya tomó.
		public List<Equipo> ListarLibres(DateTime desde, DateTime hasta)
		{
			Autorizar("Equipo.Consultar");

			if (hasta <= desde || hasta > DateTime.MaxValue.AddDays(-366))
			{
				throw new ArgumentException("Ingresá un período válido: hasta posterior a desde.");
			}

			return FiltrarSeguros(mapper.ListarLibres(desde, hasta));
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
			Seguro propio = null;

			if (usuario.Rol == "Cliente")
			{
				propio = usuarios.BuscarSeguro(usuario.Id);
			}

			foreach (Equipo equipo in lista)
			{
				if (usuario.Rol == "Cliente")
				{
					equipo.Seguro = propio;
				}
				else if (usuario.Rol == "Tecnico")
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

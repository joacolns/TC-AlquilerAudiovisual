using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
	public class DevolucionMapper : Mapper<Devolucion>
	{
		private readonly ReservaMapper reservas = new ReservaMapper();

		public override int Insertar(Devolucion devolucion)
		{
			return acceso.Escribir(
				"sp_Devolucion_Insertar",
				new List<SqlParameter>
				{
					new SqlParameter("@ReservaId", SqlDbType.Int)
					{
						Value = devolucion.ReservaId
					},
					new SqlParameter("@Fecha", SqlDbType.DateTime2)
					{
						Value = devolucion.Fecha
					},
					new SqlParameter("@Conforme", SqlDbType.Bit)
					{
						Value = devolucion.Conforme
					},
					new SqlParameter("@ClientePresente", SqlDbType.Bit)
					{
						Value = devolucion.ClientePresente
					},
					new SqlParameter("@Observaciones", SqlDbType.NVarChar, 500)
					{
						Value = devolucion.Observaciones
					},
					new SqlParameter("@GarantiaAplicada", SqlDbType.Decimal)
					{
						Precision = 18,
						Scale = 2,
						Value = devolucion.GarantiaAplicada
					},
					new SqlParameter("@GarantiaDevuelta", SqlDbType.Decimal)
					{
						Precision = 18,
						Scale = 2,
						Value = devolucion.GarantiaDevuelta
					},
					new SqlParameter("@SaldoPendiente", SqlDbType.Decimal)
					{
						Precision = 18,
						Scale = 2,
						Value = devolucion.SaldoPendiente
					}
				}
			);
		}

		public Devolucion Buscar(int devolucionId)
		{
			DataTable tabla = acceso.Leer(
				"sp_Devolucion_Buscar",
				new List<SqlParameter>
				{
					new SqlParameter("@DevolucionId", SqlDbType.Int)
					{
						Value = devolucionId
					}
				}
			);

			if (tabla.Rows.Count == 0)
			{
				return null;
			}

			return Mapear(tabla.Rows[0]);
		}

		public List<Devolucion> Listar()
		{
			DataTable tabla = acceso.Leer("sp_Devolucion_Listar", new List<SqlParameter>());
			List<Devolucion> lista = new List<Devolucion>();

			foreach (DataRow fila in tabla.Rows)
			{
				lista.Add(Mapear(fila));
			}

			return lista;
		}

		public int RegistrarIncidencia(Incidencia incidencia)
		{
			return acceso.Escribir(
				"sp_Incidencia_Insertar",
				new List<SqlParameter>
				{
					new SqlParameter("@DevolucionId", SqlDbType.Int)
					{
						Value = incidencia.DevolucionId
					},
					new SqlParameter("@EquipoId", SqlDbType.Int)
					{
						Value = incidencia.EquipoId
					},
					new SqlParameter("@Tipo", SqlDbType.NVarChar, 25)
					{
						Value = incidencia.Tipo
					},
					new SqlParameter("@Descripcion", SqlDbType.NVarChar, 500)
					{
						Value = incidencia.Descripcion
					},
					new SqlParameter("@Cargo", SqlDbType.Decimal)
					{
						Precision = 18,
						Scale = 2,
						Value = incidencia.Cargo
					}
				}
			);
		}

		public List<Incidencia> ListarIncidencias(int? devolucionId)
		{
			object valorId;

			if (devolucionId.HasValue)
			{
				valorId = devolucionId.Value;
			}
			else
			{
				valorId = DBNull.Value;
			}

			DataTable tabla = acceso.Leer(
				"sp_Incidencia_Listar",
				new List<SqlParameter>
				{
					new SqlParameter("@DevolucionId", SqlDbType.Int)
					{
						Value = valorId
					}
				}
			);
			List<Incidencia> lista = new List<Incidencia>();

			foreach (DataRow fila in tabla.Rows)
			{
				Devolucion devolucion = Buscar(Convert.ToInt32(fila["DevolucionId"]));
				int equipoId = Convert.ToInt32(fila["EquipoId"]);
				Equipo equipo = null;

				foreach (Equipo unidad in devolucion.Reserva.Equipos)
				{
					if (unidad.Id == equipoId)
					{
						equipo = unidad;
						break;
					}
				}

				Incidencia incidencia = new Incidencia
				{
					Id = Convert.ToInt32(fila["Id"]),
					DevolucionId = devolucion.Id,
					Devolucion = devolucion,
					EquipoId = equipoId,
					Equipo = equipo,
					Tipo = Convert.ToString(fila["Tipo"]),
					Descripcion = Convert.ToString(fila["Descripcion"]),
					CargoBase = Convert.ToDecimal(fila["CargoBase"]),
					DescuentoSeguro = Convert.ToDecimal(fila["DescuentoSeguro"]),
					Cargo = Convert.ToDecimal(fila["Cargo"]),
					Estado = Convert.ToString(fila["Estado"])
				};
				if (fila["FechaAltaTecnica"] != DBNull.Value)
				{
					incidencia.FechaAltaTecnica = Convert.ToDateTime(fila["FechaAltaTecnica"]);
				}

				lista.Add(incidencia);
			}

			return lista;
		}

		public bool Finalizar(int devolucionId)
		{
			return acceso.Escribir(
				"sp_Devolucion_Finalizar",
				new List<SqlParameter>
				{
					new SqlParameter("@DevolucionId", SqlDbType.Int)
					{
						Value = devolucionId
					}
				}
			) == 1;
		}

		public bool DarAltaTecnica(int incidenciaId)
		{
			return acceso.Escribir(
				"sp_Incidencia_AltaTecnica",
				new List<SqlParameter>
				{
					new SqlParameter("@IncidenciaId", SqlDbType.Int)
					{
						Value = incidenciaId
					}
				}
			) == 1;
		}

		private Devolucion Mapear(DataRow fila)
		{
			int reservaId = Convert.ToInt32(fila["ReservaId"]);
			return new Devolucion
			{
				Id = Convert.ToInt32(fila["Id"]),
				ReservaId = reservaId,
				Reserva = reservas.Buscar(reservaId),
				Fecha = Convert.ToDateTime(fila["Fecha"]),
				Conforme = Convert.ToBoolean(fila["Conforme"]),
				ClientePresente = Convert.ToBoolean(fila["ClientePresente"]),
				Finalizada = Convert.ToBoolean(fila["Finalizada"]),
				Observaciones = Convert.ToString(fila["Observaciones"]),
				GarantiaAplicada = Convert.ToDecimal(fila["GarantiaAplicada"]),
				GarantiaDevuelta = Convert.ToDecimal(fila["GarantiaDevuelta"]),
				SaldoPendiente = Convert.ToDecimal(fila["SaldoPendiente"])
			};
		}
	}
}

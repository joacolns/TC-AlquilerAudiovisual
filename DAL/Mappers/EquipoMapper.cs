using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
	public class EquipoMapper : Mapper<Equipo>
	{
		public override int Insertar(Equipo equipo)
		{
			return acceso.Escribir("sp_Equipo_Insertar", Parametros(equipo, false));
		}

		public bool Actualizar(Equipo equipo)
		{
			return acceso.Escribir("sp_Equipo_Actualizar", Parametros(equipo, true)) == 1;
		}

		public List<Equipo> Listar()
		{
			return Mapear(acceso.Leer("sp_Equipo_Listar", new List<SqlParameter>()));
		}

		public List<Equipo> ListarDisponibles(DateTime desde, DateTime hasta)
		{
			return Mapear(
				acceso.Leer(
					"sp_Equipo_Disponibles",
					new List<SqlParameter>
					{
						new SqlParameter("@Desde", SqlDbType.DateTime2)
						{
							Value = desde
						},
						new SqlParameter("@Hasta", SqlDbType.DateTime2)
						{
							Value = hasta
						}
					}
				)
			);
		}

		private List<SqlParameter> Parametros(Equipo equipo, bool incluirId)
		{
			object seguroId;

			if (equipo.Seguro == null)
			{
				seguroId = DBNull.Value;
			}
			else
			{
				seguroId = equipo.Seguro.Id;
			}

			List<SqlParameter> parametros = new List<SqlParameter>
			{
				new SqlParameter("@SeguroId", SqlDbType.Int)
				{
					Value = seguroId
				},
				new SqlParameter("@CodigoInventario", SqlDbType.NVarChar, 30)
				{
					Value = equipo.CodigoInventario
				},
				new SqlParameter("@Serie", SqlDbType.NVarChar, 80)
				{
					Value = equipo.Serie
				},
				new SqlParameter("@Categoria", SqlDbType.NVarChar, 50)
				{
					Value = equipo.Categoria
				},
				new SqlParameter("@Marca", SqlDbType.NVarChar, 50)
				{
					Value = equipo.Marca
				},
				new SqlParameter("@Modelo", SqlDbType.NVarChar, 80)
				{
					Value = equipo.Modelo
				},
				new SqlParameter("@Descripcion", SqlDbType.NVarChar, 300)
				{
					Value = equipo.Descripcion
				},
				new SqlParameter("@Estado", SqlDbType.NVarChar, 25)
				{
					Value = equipo.Estado
				},
				new SqlParameter("@TarifaDiaria", SqlDbType.Decimal)
				{
					Precision = 18,
					Scale = 2,
					Value = equipo.TarifaDiaria
				},
				new SqlParameter("@ValorReposicion", SqlDbType.Decimal)
				{
					Precision = 18,
					Scale = 2,
					Value = equipo.ValorReposicion
				},
				new SqlParameter("@DiasReacondicionamiento", SqlDbType.Int)
				{
					Value = equipo.DiasReacondicionamiento
				}
			};
			if (incluirId)
			{
				parametros.Add(new SqlParameter("@Id", SqlDbType.Int)
				{
					Value = equipo.Id
				});
			}

			return parametros;
		}

		private List<Equipo> Mapear(DataTable tabla)
		{
			List<Equipo> equipos = new List<Equipo>();

			foreach (DataRow fila in tabla.Rows)
			{
				equipos.Add(
					new Equipo
					{
						Id = Convert.ToInt32(fila["Id"]),
						Seguro = MapearSeguro(fila),
						CodigoInventario = Convert.ToString(fila["CodigoInventario"]),
						Serie = Convert.ToString(fila["Serie"]),
						Categoria = Convert.ToString(fila["Categoria"]),
						Marca = Convert.ToString(fila["Marca"]),
						Modelo = Convert.ToString(fila["Modelo"]),
						Descripcion = Convert.ToString(fila["Descripcion"]),
						Estado = Convert.ToString(fila["Estado"]),
						TarifaDiaria = Convert.ToDecimal(fila["TarifaDiaria"]),
						ValorReposicion = Convert.ToDecimal(fila["ValorReposicion"]),
						DiasReacondicionamiento = Convert.ToInt32(fila["DiasReacondicionamiento"])
					}
				);
			}

			return equipos;
		}

		private Seguro MapearSeguro(DataRow fila)
		{
			if (fila["SeguroId"] == DBNull.Value)
			{
				return null;
			}

			Cliente cliente = new Cliente
			{
				Id = Convert.ToInt32(fila["SeguroClienteId"]),
				UsuarioId = Convert.ToInt32(fila["UsuarioId"]),
				Nombre = Convert.ToString(fila["Nombre"]),
				DniCuit = Convert.ToString(fila["DniCuit"]),
				Telefono = Convert.ToString(fila["Telefono"]),
				Email = Convert.ToString(fila["Email"]),
				Antecedentes = Convert.ToString(fila["Antecedentes"]),
				Usuario = new Usuario
				{
					Id = Convert.ToInt32(fila["UsuarioId"]),
					NombreUsuario = Convert.ToString(fila["NombreUsuario"]),
					Rol = Convert.ToString(fila["Rol"]),
					Activo = Convert.ToBoolean(fila["Activo"])
				}
			};
			return new Seguro
			{
				Id = Convert.ToInt32(fila["SeguroId"]),
				ClienteId = cliente.Id,
				Cliente = cliente,
				Tipo = Convert.ToString(fila["TipoSeguro"]),
				Detalle = Convert.ToString(fila["DetalleSeguro"]),
				Poliza = Convert.ToString(fila["Poliza"]),
				Aseguradora = Convert.ToString(fila["Aseguradora"]),
				Desde = Convert.ToDateTime(fila["SeguroDesde"]),
				Hasta = Convert.ToDateTime(fila["SeguroHasta"]),
				Cobertura = Convert.ToDecimal(fila["CoberturaSeguro"])
			};
		}
	}
}

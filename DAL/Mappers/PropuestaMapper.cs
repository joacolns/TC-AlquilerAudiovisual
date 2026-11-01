using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
	public class PropuestaMapper : Mapper<PropuestaGuardada>
	{
		public override int Insertar(PropuestaGuardada propuesta)
		{
			BriefProduccion b = propuesta.Brief;
			List<SqlParameter> parametros = new List<SqlParameter>
			{
				new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = propuesta.UsuarioId },
				new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = propuesta.Nombre },
				new SqlParameter("@Variante", SqlDbType.NVarChar, 20) { Value = propuesta.Variante },
				new SqlParameter("@Total", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = propuesta.Total },
				new SqlParameter("@TipoPieza", SqlDbType.NVarChar, 50) { Value = b.TipoPieza },
				new SqlParameter("@Presupuesto", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = b.Presupuesto },
				new SqlParameter("@Desde", SqlDbType.DateTime2) { Value = b.Desde },
				new SqlParameter("@Hasta", SqlDbType.DateTime2) { Value = b.Hasta },
				new SqlParameter("@Personas", SqlDbType.Int) { Value = b.Personas },
				new SqlParameter("@Camaras", SqlDbType.Int) { Value = b.Camaras },
				new SqlParameter("@Locacion", SqlDbType.NVarChar, 20) { Value = b.Locacion },
				new SqlParameter("@Luz", SqlDbType.NVarChar, 20) { Value = b.Luz },
				new SqlParameter("@HorasJornada", SqlDbType.Int) { Value = b.HorasJornada },
				new SqlParameter("@CamaraEnMovimiento", SqlDbType.Bit) { Value = b.CamaraEnMovimiento },
				new SqlParameter("@SonidoDirecto", SqlDbType.Bit) { Value = b.SonidoDirecto },
				new SqlParameter("@Monitoreo", SqlDbType.Bit) { Value = b.Monitoreo },
				new SqlParameter("@LookCinematografico", SqlDbType.Bit) { Value = b.LookCinematografico }
			};
			return acceso.Escribir("sp_Propuesta_Guardar", parametros);
		}

		public List<PropuestaGuardada> Listar(int usuarioId)
		{
			DataTable tabla = acceso.Leer(
				"sp_Propuesta_Listar",
				new List<SqlParameter> { new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = usuarioId } }
			);
			List<PropuestaGuardada> lista = new List<PropuestaGuardada>();

			foreach (DataRow f in tabla.Rows)
			{
				lista.Add(
					new PropuestaGuardada
					{
						Id = Convert.ToInt32(f["Id"]),
						UsuarioId = Convert.ToInt32(f["UsuarioId"]),
						Nombre = Convert.ToString(f["Nombre"]),
						Creada = Convert.ToDateTime(f["Creada"]),
						Variante = Convert.ToString(f["Variante"]),
						Total = Convert.ToDecimal(f["Total"]),
						Brief = new BriefProduccion
						{
							TipoPieza = Convert.ToString(f["TipoPieza"]),
							Presupuesto = Convert.ToDecimal(f["Presupuesto"]),
							Desde = Convert.ToDateTime(f["Desde"]),
							Hasta = Convert.ToDateTime(f["Hasta"]),
							Personas = Convert.ToInt32(f["Personas"]),
							Camaras = Convert.ToInt32(f["Camaras"]),
							Locacion = Convert.ToString(f["Locacion"]),
							Luz = Convert.ToString(f["Luz"]),
							HorasJornada = Convert.ToInt32(f["HorasJornada"]),
							CamaraEnMovimiento = Convert.ToBoolean(f["CamaraEnMovimiento"]),
							SonidoDirecto = Convert.ToBoolean(f["SonidoDirecto"]),
							Monitoreo = Convert.ToBoolean(f["Monitoreo"]),
							LookCinematografico = Convert.ToBoolean(f["LookCinematografico"])
						}
					}
				);
			}

			return lista;
		}

		public bool Eliminar(int id, int usuarioId)
		{
			return acceso.Escribir(
				"sp_Propuesta_Eliminar",
				new List<SqlParameter>
				{
					new SqlParameter("@Id", SqlDbType.Int) { Value = id },
					new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = usuarioId }
				}
			) == 1;
		}
	}
}

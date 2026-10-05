using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using BE;

namespace DAL
{
	public class ReservaMapper : Mapper<Reserva>
	{
		public override int Insertar(Reserva reserva)
		{
			List<SqlParameter> parametros = Parametros(reserva);
			parametros.Add(new SqlParameter("@UsuarioId", SqlDbType.Int)
			{
				Value = reserva.Cliente.UsuarioId
			});
			return acceso.Escribir("sp_Reserva_Insertar", parametros);
		}

		public bool Confirmar(Reserva reserva)
		{
			List<SqlParameter> parametros = Parametros(reserva);
			parametros.Add(new SqlParameter("@ReservaId", SqlDbType.Int)
			{
				Value = reserva.Id
			});
			return acceso.Escribir("sp_Reserva_Confirmar", parametros) == 1;
		}

		public bool Pagar(int reservaId, int usuarioId)
		{
			return acceso.Escribir(
				"sp_Reserva_Pagar",
				new List<SqlParameter>
				{
					new SqlParameter("@ReservaId", SqlDbType.Int)
					{
						Value = reservaId
					},
					new SqlParameter("@UsuarioId", SqlDbType.Int)
					{
						Value = usuarioId
					}
				}
			) == 1;
		}

		public bool Rechazar(int reservaId)
		{
			return acceso.Escribir(
				"sp_Reserva_Rechazar",
				new List<SqlParameter>
				{
					new SqlParameter("@ReservaId", SqlDbType.Int)
					{
						Value = reservaId
					}
				}
			) == 1;
		}

		private List<SqlParameter> Parametros(Reserva reserva)
		{
			DataTable unidades = new DataTable();
			unidades.Columns.Add("EquipoId", typeof(int));
			unidades.Columns.Add("TarifaDiaria", typeof(decimal));
			unidades.Columns.Add("ValorReposicion", typeof(decimal));
			unidades.Columns.Add("DiasReacondicionamiento", typeof(int));
			unidades.Columns.Add("SeguroId", typeof(int));
			unidades.Columns.Add("CoberturaSeguro", typeof(decimal));

			foreach (Equipo equipo in reserva.Equipos)
			{
				object seguroId;
				decimal coberturaSeguro;

				if (equipo.Seguro == null)
				{
					seguroId = DBNull.Value;
					coberturaSeguro = 0;
				}
				else
				{
					seguroId = equipo.Seguro.Id;
					coberturaSeguro = equipo.Seguro.Cobertura;
				}

				unidades.Rows.Add(
					equipo.Id,
					equipo.TarifaDiaria,
					equipo.ValorReposicion,
					equipo.DiasReacondicionamiento,
					seguroId,
					coberturaSeguro
				);
			}

			SqlParameter equipos = new SqlParameter("@Equipos", SqlDbType.Structured)
			{
				TypeName = "dbo.ReservaEquipoEntrada",
				Value = unidades
			};
			return new List<SqlParameter>
			{
				new SqlParameter("@ClienteId", SqlDbType.Int)
				{
					Value = reserva.ClienteId
				},
				new SqlParameter("@Desde", SqlDbType.DateTime2)
				{
					Value = reserva.Desde
				},
				new SqlParameter("@Hasta", SqlDbType.DateTime2)
				{
					Value = reserva.Hasta
				},
				new SqlParameter("@Importe", SqlDbType.Decimal)
				{
					Precision = 18,
					Scale = 2,
					Value = reserva.Importe
				},
				new SqlParameter("@SenaRequerida", SqlDbType.Decimal)
				{
					Precision = 18,
					Scale = 2,
					Value = reserva.SenaRequerida
				},
				new SqlParameter("@GarantiaRequerida", SqlDbType.Decimal)
				{
					Precision = 18,
					Scale = 2,
					Value = reserva.GarantiaRequerida
				},
				new SqlParameter("@PorcentajeSena", SqlDbType.Decimal)
				{
					Precision = 5,
					Scale = 4,
					Value = LeerPorcentaje("PorcentajeSena")
				},
				new SqlParameter("@PorcentajeGarantia", SqlDbType.Decimal)
				{
					Precision = 5,
					Scale = 4,
					Value = LeerPorcentaje("PorcentajeGarantia")
				},
				equipos
			};
		}

		public Reserva Buscar(int reservaId)
		{
			List<Reserva> reservas = Mapear(
				acceso.Leer(
					"sp_Reserva_Buscar",
					new List<SqlParameter>
					{
						new SqlParameter("@ReservaId", SqlDbType.Int)
						{
							Value = reservaId
						}
					}
				)
			);

			if (reservas.Count == 0)
			{
				return null;
			}
			else
			{
				return reservas[0];
			}
		}

		public List<Reserva> Listar(int? clienteId)
		{
			object valorClienteId;

			if (clienteId.HasValue)
			{
				valorClienteId = clienteId.Value;
			}
			else
			{
				valorClienteId = DBNull.Value;
			}

			return Mapear(
				acceso.Leer(
					"sp_Reserva_Listar",
					new List<SqlParameter>
					{
						new SqlParameter("@ClienteId", SqlDbType.Int)
						{
							Value = valorClienteId
						}
					}
				)
			);
		}

		public bool RegistrarEntrega(int reservaId)
		{
			return acceso.Escribir(
				"sp_Reserva_RegistrarEntrega",
				new List<SqlParameter>
				{
					new SqlParameter("@ReservaId", SqlDbType.Int)
					{
						Value = reservaId
					}
				}
			) == 1;
		}

		private decimal LeerPorcentaje(string nombre)
		{
			string valor = ConfigurationManager.AppSettings[nombre];
			return decimal.Parse(valor, CultureInfo.InvariantCulture);
		}

		private List<Reserva> Mapear(DataTable tabla)
		{
			List<Reserva> reservas = new List<Reserva>();
			Reserva actual = null;
			// Los SP ordenan por Id de reserva/unidad; no hace falta Dictionary.
			foreach (DataRow fila in tabla.Rows)
			{
				int id = Convert.ToInt32(fila["Id"]);

				if (actual == null || actual.Id != id)
				{
					actual = new Reserva
					{
						Id = id,
						ClienteId = Convert.ToInt32(fila["ClienteId"]),
						Cliente = new Cliente
						{
							Id = Convert.ToInt32(fila["ClienteId"]),
							UsuarioId = Convert.ToInt32(fila["ReservaUsuarioId"]),
							Nombre = Convert.ToString(fila["ClienteNombre"]),
							DniCuit = Convert.ToString(fila["ClienteDniCuit"]),
							Telefono = Convert.ToString(fila["ClienteTelefono"]),
							Email = Convert.ToString(fila["ClienteEmail"]),
							Antecedentes = Convert.ToString(fila["ClienteAntecedentes"]),
							Usuario = new Usuario
							{
								Id = Convert.ToInt32(fila["ReservaUsuarioId"]),
								NombreUsuario = Convert.ToString(fila["ReservaNombreUsuario"]),
								Rol = Convert.ToString(fila["ReservaRol"]),
								Activo = Convert.ToBoolean(fila["ReservaActivo"]),
								TipoSeguro = Convert.ToString(fila["ClienteTipoSeguro"])
							}
						},
						Desde = Convert.ToDateTime(fila["Desde"]),
						Hasta = Convert.ToDateTime(fila["Hasta"]),
						Importe = Convert.ToDecimal(fila["Importe"]),
						SenaRequerida = Convert.ToDecimal(fila["SenaRequerida"]),
						GarantiaRequerida = Convert.ToDecimal(fila["GarantiaRequerida"]),
						Sena = Convert.ToDecimal(fila["Sena"]),
						Garantia = Convert.ToDecimal(fila["Garantia"]),
						Estado = Convert.ToString(fila["Estado"]),
						NumeroContrato = Convert.ToString(fila["NumeroContrato"]),
						NumeroRemito = Convert.ToString(fila["NumeroRemito"]),
						ContratoFirmado = Convert.ToBoolean(fila["ContratoFirmado"]),
						Equipos = new List<Equipo>()
					};
					reservas.Add(actual);
				}

				actual.Equipos.Add(
					new Equipo
					{
						Id = Convert.ToInt32(fila["EquipoId"]),
						Seguro = MapearSeguro(fila),
						CodigoInventario = Convert.ToString(fila["CodigoInventario"]),
						Serie = Convert.ToString(fila["Serie"]),
						Categoria = Convert.ToString(fila["Categoria"]),
						Marca = Convert.ToString(fila["Marca"]),
						Modelo = Convert.ToString(fila["Modelo"]),
						Descripcion = Convert.ToString(fila["Descripcion"]),
						Estado = Convert.ToString(fila["EstadoEquipo"]),
						TarifaDiaria = Convert.ToDecimal(fila["TarifaDiaria"]),
						ValorReposicion = Convert.ToDecimal(fila["ValorReposicion"]),
						DiasReacondicionamiento = Convert.ToInt32(fila["DiasReacondicionamiento"])
					}
				);
			}

			return reservas;
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

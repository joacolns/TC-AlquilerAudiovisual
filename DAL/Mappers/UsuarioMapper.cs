using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
	public class UsuarioMapper : Mapper<Usuario>
	{
		public override int Insertar(Usuario usuario)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
			{
				new SqlParameter("@NombreUsuario", SqlDbType.NVarChar, 50)
				{
					Value = usuario.NombreUsuario
				},
				new SqlParameter("@Hash", SqlDbType.VarBinary, 32)
				{
					Value = usuario.Hash
				},
				new SqlParameter("@Sal", SqlDbType.VarBinary, 16)
				{
					Value = usuario.Sal
				},
				new SqlParameter("@Rol", SqlDbType.NVarChar, 25)
				{
					Value = usuario.Rol
				},
				new SqlParameter("@Activo", SqlDbType.Bit)
				{
					Value = usuario.Activo
				},
				new SqlParameter("@TipoSeguro", SqlDbType.NVarChar, 25)
				{
					Value = usuario.TipoSeguro
				}
			};
			return acceso.Escribir("sp_Usuario_Insertar", parametros);
		}

		public Usuario Buscar(string nombre)
		{
			DataTable tabla = acceso.Leer(
				"sp_Usuario_Buscar",
				new List<SqlParameter>
				{
					new SqlParameter("@NombreUsuario", SqlDbType.NVarChar, 50)
					{
						Value = nombre
					}
				}
			);

			if (tabla.Rows.Count == 0)
			{
				return null;
			}

			Usuario usuario = Mapear(tabla.Rows[0]);
			usuario.Hash = (byte[])tabla.Rows[0]["Hash"];
			usuario.Sal = (byte[])tabla.Rows[0]["Sal"];
			return usuario;
		}

		public bool ConfigurarSeguro(int usuarioId, string tipo)
		{
			return acceso.Escribir(
				"sp_Usuario_ConfigurarSeguro",
				new List<SqlParameter>
				{
					new SqlParameter("@UsuarioId", SqlDbType.Int)
					{
						Value = usuarioId
					},
					new SqlParameter("@TipoSeguro", SqlDbType.NVarChar, 25)
					{
						Value = tipo
					}
				}
			) == 1;
		}

		public Seguro BuscarSeguro(int usuarioId)
		{
			DataTable tabla = acceso.Leer(
				"sp_Usuario_Seguro",
				new List<SqlParameter>
				{
					new SqlParameter("@UsuarioId", SqlDbType.Int)
					{
						Value = usuarioId
					}
				}
			);

			if (tabla.Rows.Count == 0)
			{
				return null;
			}

			return Mapear(tabla.Rows[0]).Seguro;
		}

		public bool CambiarClave(int usuarioId, byte[] hash, byte[] sal)
		{
			return acceso.Escribir(
				"sp_Usuario_CambiarClave",
				new List<SqlParameter>
				{
					new SqlParameter("@UsuarioId", SqlDbType.Int)
					{
						Value = usuarioId
					},
					new SqlParameter("@Hash", SqlDbType.VarBinary, 32)
					{
						Value = hash
					},
					new SqlParameter("@Sal", SqlDbType.VarBinary, 16)
					{
						Value = sal
					}
				}
			) == 1;
		}

		public bool AsignarRol(int usuarioId, string rol)
		{
			return acceso.Escribir(
				"sp_Usuario_AsignarRol",
				new List<SqlParameter>
				{
					new SqlParameter("@UsuarioId", SqlDbType.Int)
					{
						Value = usuarioId
					},
					new SqlParameter("@Rol", SqlDbType.NVarChar, 25)
					{
						Value = rol
					}
				}
			) == 1;
		}

		public List<Usuario> Listar()
		{
			DataTable tabla = acceso.Leer("sp_Usuario_Listar", new List<SqlParameter>());
			List<Usuario> usuarios = new List<Usuario>();

			foreach (DataRow fila in tabla.Rows)
			{
				usuarios.Add(Mapear(fila));
			}

			return usuarios;
		}

		private Usuario Mapear(DataRow fila)
		{
			Usuario usuario = new Usuario
			{
				Id = Convert.ToInt32(fila["Id"]),
				NombreUsuario = Convert.ToString(fila["NombreUsuario"]),
				Rol = Convert.ToString(fila["Rol"]),
				Activo = Convert.ToBoolean(fila["Activo"]),
				TipoSeguro = Convert.ToString(fila["TipoSeguro"])
			};
			if (fila["SeguroId"] != DBNull.Value)
			{
				usuario.SeguroId = Convert.ToInt32(fila["SeguroId"]);
			}

			if (fila["SeguroClienteId"] != DBNull.Value)
			{
				usuario.Seguro = new Seguro
				{
					Id = usuario.SeguroId.Value,
					ClienteId = Convert.ToInt32(fila["SeguroClienteId"]),
					Tipo = Convert.ToString(fila["SeguroTipo"]),
					Detalle = Convert.ToString(fila["SeguroDetalle"]),
					Poliza = Convert.ToString(fila["SeguroPoliza"]),
					Aseguradora = Convert.ToString(fila["SeguroAseguradora"]),
					Desde = Convert.ToDateTime(fila["SeguroDesde"]),
					Hasta = Convert.ToDateTime(fila["SeguroHasta"]),
					Cobertura = Convert.ToDecimal(fila["SeguroCobertura"]),
					Cliente = new Cliente
					{
						Id = Convert.ToInt32(fila["SeguroClienteId"]),
						UsuarioId = usuario.Id,
						Nombre = Convert.ToString(fila["SeguroNombre"]),
						DniCuit = Convert.ToString(fila["SeguroDniCuit"]),
						Telefono = Convert.ToString(fila["SeguroTelefono"]),
						Email = Convert.ToString(fila["SeguroEmail"]),
						Antecedentes = Convert.ToString(fila["SeguroAntecedentes"]),
						Usuario = new Usuario
						{
							Id = usuario.Id,
							NombreUsuario = usuario.NombreUsuario,
							Rol = usuario.Rol,
							Activo = usuario.Activo
						}
					}
				};
			}

			return usuario;
		}
	}
}

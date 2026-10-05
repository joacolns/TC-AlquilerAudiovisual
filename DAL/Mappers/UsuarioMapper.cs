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
			return new Usuario
			{
				Id = Convert.ToInt32(fila["Id"]),
				NombreUsuario = Convert.ToString(fila["NombreUsuario"]),
				Rol = Convert.ToString(fila["Rol"]),
				Activo = Convert.ToBoolean(fila["Activo"])
			};
		}
	}
}

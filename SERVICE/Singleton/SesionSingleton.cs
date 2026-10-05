using System;
using BE;

namespace SERVICE
{
	public sealed class SesionSingleton
	{
		private static readonly SesionSingleton instancia = new SesionSingleton();
		public static SesionSingleton Instancia
		{
			get
			{
				return instancia;
			}
		}

		public Usuario UsuarioActual { get; private set; }
		public Rol Permisos { get; private set; }

		private SesionSingleton()
		{
		}

		public void Iniciar(Usuario usuario, Rol permisos)
		{
			if (usuario == null || !usuario.Activo || permisos == null)
			{
				throw new ArgumentException("No se puede iniciar una sesión sin usuario activo y permisos.");
			}

			// La sesión no conserva el material criptográfico recuperado para verificar el login.
			UsuarioActual = new Usuario
			{
				Id = usuario.Id,
				NombreUsuario = usuario.NombreUsuario,
				Rol = usuario.Rol,
				Activo = usuario.Activo
			};
			Permisos = permisos;
		}

		public void Cerrar()
		{
			UsuarioActual = null;
			Permisos = null;
		}
	}
}

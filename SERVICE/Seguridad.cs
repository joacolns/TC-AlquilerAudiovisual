using System;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using BE;

namespace SERVICE
{
	public class Seguridad
	{
		// Formato único de esta entrega: PBKDF2-SHA256, sal de 16 y hash de 32 bytes.
		private const int Iteraciones = 600000;
		[DllImport("bcrypt.dll", CharSet = CharSet.Unicode)]
		private static extern int BCryptOpenAlgorithmProvider(out IntPtr algoritmo, string nombre, string proveedor, uint opciones);
		[DllImport("bcrypt.dll")]
		private static extern int BCryptDeriveKeyPBKDF2(IntPtr algoritmo, byte[] clave, uint longitudClave, byte[] sal, uint longitudSal, ulong iteraciones, [Out] byte[] hash, uint longitudHash, uint opciones);
		[DllImport("bcrypt.dll")]
		private static extern int BCryptCloseAlgorithmProvider(IntPtr algoritmo, uint opciones);

		public byte[] CrearSal()
		{
			byte[] sal = new byte[16];

			using (RandomNumberGenerator generador = RandomNumberGenerator.Create())
			{
				generador.GetBytes(sal);
			}

			return sal;
		}

		public byte[] Hashear(string clave, byte[] sal)
		{
			if (string.IsNullOrEmpty(clave) || sal == null || sal.Length != 16)
			{
				throw new ArgumentException("La contraseña y su sal son obligatorias.");
			}

			// Windows calcula el mismo PBKDF2-SHA256 sin el costo de iterar en código administrado.
			IntPtr algoritmo;
			int estado = BCryptOpenAlgorithmProvider(out algoritmo, "SHA256", null, 0x00000008);

			if (estado != 0)
			{
				throw new CryptographicException("No se pudo iniciar la protección de la contraseña.");
			}

			byte[] texto = Encoding.UTF8.GetBytes(clave);

			try
			{
				byte[] hash = new byte[32];
				estado = BCryptDeriveKeyPBKDF2(
					algoritmo,
					texto,
					(uint)texto.Length,
					sal,
					(uint)sal.Length,
					Iteraciones,
					hash,
					(uint)hash.Length,
					0
				);

				if (estado != 0)
				{
					throw new CryptographicException("No se pudo proteger la contraseña.");
				}

				return hash;
			}
			finally
			{
				Array.Clear(texto, 0, texto.Length);
				BCryptCloseAlgorithmProvider(algoritmo, 0);
			}
		}

		public bool Verificar(string clave, Usuario usuario)
		{
			if (string.IsNullOrEmpty(clave)
				|| usuario == null
				|| usuario.Sal == null
				|| usuario.Sal.Length != 16
				|| usuario.Hash == null
				|| usuario.Hash.Length != 32)
			{
				return false;
			}

			byte[] calculado = Hashear(clave, usuario.Sal);
			int diferencia = 0;

			for (int i = 0; i < calculado.Length; i++)
			{
				diferencia |= calculado[i] ^ usuario.Hash[i];
			}

			return diferencia == 0;
		}

		public bool TienePermiso(string codigo)
		{
			SesionSingleton sesion = SesionSingleton.Instancia;
			return sesion.UsuarioActual != null && sesion.UsuarioActual.Activo && sesion.Permisos != null && sesion.Permisos.Permite(codigo);
		}
	}
}

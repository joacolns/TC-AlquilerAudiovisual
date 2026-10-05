using System;
using System.Security.Cryptography;
using BE;

namespace SERVICE
{
    public class Seguridad
    {
        // Formato único de esta entrega: PBKDF2-SHA256, sal de 16 y hash de 32 bytes.
        private const int Iteraciones = 600000;

        public byte[] CrearSal()
        {
            byte[] sal = new byte[16];
            using (RandomNumberGenerator generador = RandomNumberGenerator.Create()) generador.GetBytes(sal);
            return sal;
        }

        public byte[] Hashear(string clave, byte[] sal)
        {
            if (string.IsNullOrEmpty(clave) || sal == null || sal.Length != 16)
                throw new ArgumentException("La contraseña y su sal son obligatorias.");
            using (Rfc2898DeriveBytes derivacion = new Rfc2898DeriveBytes(clave, sal, Iteraciones, HashAlgorithmName.SHA256))
                return derivacion.GetBytes(32);
        }

        public bool Verificar(string clave, Usuario usuario)
        {
            if (string.IsNullOrEmpty(clave) || usuario == null || usuario.Sal == null ||
                usuario.Sal.Length != 16 || usuario.Hash == null || usuario.Hash.Length != 32) return false;
            byte[] calculado = Hashear(clave, usuario.Sal);
            int diferencia = 0;
            for (int i = 0; i < calculado.Length; i++) diferencia |= calculado[i] ^ usuario.Hash[i];
            return diferencia == 0;
        }

        public bool TienePermiso(string codigo)
        {
            SesionSingleton sesion = SesionSingleton.Instancia;
            return sesion.UsuarioActual != null && sesion.UsuarioActual.Activo &&
                sesion.Permisos != null && sesion.Permisos.Permite(codigo);
        }
    }
}

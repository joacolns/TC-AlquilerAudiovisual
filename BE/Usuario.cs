namespace BE
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Sal { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}

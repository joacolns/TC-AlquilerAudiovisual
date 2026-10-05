namespace BE
{
    public class Equipo
    {
        public int Id { get; set; }
        public Seguro Seguro { get; set; }
        public string CodigoInventario { get; set; }
        public string Serie { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public decimal TarifaDiaria { get; set; }
        public decimal ValorReposicion { get; set; }
        public int DiasReacondicionamiento { get; set; }
    }
}

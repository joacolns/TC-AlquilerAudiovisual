using System;

namespace BE
{
    public class Seguro
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Poliza { get; set; }
        public string Aseguradora { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public decimal Cobertura { get; set; }
    }
}

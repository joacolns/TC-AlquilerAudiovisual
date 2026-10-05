namespace SERVICE
{
    public abstract class ComponentePermiso
    {
        public string Codigo { get; set; }
        public abstract bool Permite(string codigo);
    }
}

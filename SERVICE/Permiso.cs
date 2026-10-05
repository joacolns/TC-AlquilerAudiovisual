using System;

namespace SERVICE
{
    public class Permiso : ComponentePermiso
    {
        public override bool Permite(string codigo)
        {
            return !string.IsNullOrWhiteSpace(codigo) &&
                string.Equals(Codigo, codigo, StringComparison.Ordinal);
        }
    }
}

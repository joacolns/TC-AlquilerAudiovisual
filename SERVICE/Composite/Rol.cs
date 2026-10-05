using System;
using System.Collections.Generic;

namespace SERVICE
{
	public class Rol : ComponentePermiso
	{
		private readonly List<ComponentePermiso> permisos = new List<ComponentePermiso>();

		public void Agregar(ComponentePermiso permiso)
		{
			if (permiso == null)
			{
				throw new ArgumentNullException("permiso");
			}

			if (ReferenceEquals(this, permiso))
			{
				throw new ArgumentException("Un rol no puede contenerse.");
			}

			foreach (ComponentePermiso existente in permisos)
			{
				if (existente.Codigo == permiso.Codigo)
				{
					return;
				}
			}

			permisos.Add(permiso);
		}

		public void Quitar(ComponentePermiso permiso)
		{
			permisos.Remove(permiso);
		}

		public override bool Permite(string codigo)
		{
			foreach (ComponentePermiso permiso in permisos)
			{
				if (permiso.Permite(codigo))
				{
					return true;
				}
			}

			return false;
		}
	}
}

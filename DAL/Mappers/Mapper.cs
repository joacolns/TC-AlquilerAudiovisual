namespace DAL
{
	public abstract class Mapper<T>
	{
		protected readonly Acceso acceso = new Acceso();
		public abstract int Insertar(T objeto);
	}
}

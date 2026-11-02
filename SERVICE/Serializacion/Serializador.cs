using System.IO;

namespace SERVICE
{
	// Contrato común de serialización, siguiendo el ejemplo de TD Unidad 4.
	public abstract class Serializador
	{
		public abstract void Serializar(Stream destino, object objeto);
		public abstract object Deserializar(Stream origen);
	}
}

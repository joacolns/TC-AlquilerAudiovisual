using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SERVICE
{
	public class XmlSerializador<T> : Serializador
	{
		public override void Serializar(Stream destino, object objeto)
		{
			if (destino == null) throw new ArgumentNullException("destino");
			if (!(objeto is T)) throw new ArgumentException("El objeto no corresponde al tipo del serializador.", "objeto");
			XmlSerializer serializador = new XmlSerializer(typeof(T));
			XmlWriterSettings opciones = new XmlWriterSettings { Indent = true, CloseOutput = false };
			using (XmlWriter escritor = XmlWriter.Create(destino, opciones))
			{
				serializador.Serialize(escritor, objeto);
			}
		}

		public override object Deserializar(Stream origen)
		{
			if (origen == null) throw new ArgumentNullException("origen");
			XmlReaderSettings opciones = new XmlReaderSettings
			{
				DtdProcessing = DtdProcessing.Prohibit,
				XmlResolver = null,
				MaxCharactersInDocument = 1048576,
				CloseInput = false
			};
			using (XmlReader lector = XmlReader.Create(origen, opciones))
			{
				return new XmlSerializer(typeof(T)).Deserialize(lector);
			}
		}
	}
}

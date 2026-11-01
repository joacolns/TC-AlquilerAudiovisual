using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BE;
using DAL;
using SERVICE;

namespace BLL
{
	// N03: interpreta el brief de una producción y arma propuestas con equipos realmente disponibles en las fechas.
	public class AsesorBLL
	{
		private readonly EquipoMapper mapper = new EquipoMapper();
		private readonly PropuestaMapper propuestas = new PropuestaMapper();
		private readonly UsuarioMapper usuarios = new UsuarioMapper();
		private readonly Seguridad seguridad = new Seguridad();

		// Un casillero de la propuesta: un rol a cubrir, los equipos que lo cumplen y el elegido.
		private class Casillero
		{
			public string Rol;
			public List<Equipo> Elegibles;
			public Equipo Elegido;
			public Func<Equipo, double> Puntaje;
			public bool Reemplazable;
		}

		public ResultadoAsesoramiento Proponer(BriefProduccion brief)
		{
			Autorizar();
			Normalizar(brief);
			Validar(brief);
			int dias = Dias(brief);
			List<Equipo> disponibles = mapper.ListarParaAsesor(brief.Desde, brief.Hasta);
			ResultadoAsesoramiento resultado = new ResultadoAsesoramiento();
			resultado.Lectura = Interpretar(brief, dias);
			resultado.Recomendada = Armar(brief, disponibles, dias, false);
			resultado.Economica = Armar(brief, disponibles, dias, true);
			resultado.Complementos = Complementos(brief, disponibles, resultado.Recomendada, dias);

			if (resultado.Recomendada.Total == resultado.Economica.Total)
			{
				resultado.Economica.Notas.Add("La recomendada ya es la opción más económica que cumple con el brief.");
			}
			else
			{
				resultado.Economica.Notas.Add(
					"Ahorrás ARS "
						+ (resultado.Recomendada.Total - resultado.Economica.Total).ToString("N2")
						+ " respecto de la recomendada; lo que resignás está en la última columna."
				);
			}

			return resultado;
		}

		private void Validar(BriefProduccion brief)
		{
			if (brief == null)
			{
				throw new ArgumentException("Completá el relevamiento de la producción.");
			}

			if (brief.Presupuesto <= 0)
			{
				throw new ArgumentException("Ingresá el presupuesto disponible para el alquiler.");
			}

			if (brief.Hasta <= brief.Desde)
			{
				throw new ArgumentException("La fecha final debe ser posterior a la de inicio.");
			}

			if (brief.Desde.Date < DateTime.Today)
			{
				throw new ArgumentException("La fecha de inicio no puede ser anterior a hoy.");
			}

			if (brief.Personas < 1 || brief.Personas > 20 || brief.Camaras < 1 || brief.Camaras > 3 || brief.HorasJornada < 1 || brief.HorasJornada > 24)
			{
				throw new ArgumentException("Revisá la cantidad de personas (1 a 20), cámaras (1 a 3) y horas de jornada (1 a 24).");
			}
		}

		private void Normalizar(BriefProduccion brief)
		{
			if (brief != null)
			{
				brief.Desde = new DateTime(brief.Desde.Ticks - brief.Desde.Ticks % TimeSpan.TicksPerMinute);
				brief.Hasta = new DateTime(brief.Hasta.Ticks - brief.Hasta.Ticks % TimeSpan.TicksPerMinute);
			}
		}

		private int Dias(BriefProduccion brief)
		{
			int dias = (int)Math.Ceiling((brief.Hasta - brief.Desde).TotalDays);

			if (dias < 1)
			{
				dias = 1;
			}

			return dias;
		}

		// ---- Etiquetas de cada equipo (Equipo.Etiquetas: "clave:valor;etiqueta;...")

		private bool Tiene(Equipo equipo, string etiqueta)
		{
			if (equipo == null || equipo.Etiquetas == null)
			{
				return false;
			}

			foreach (string token in equipo.Etiquetas.Split(';'))
			{
				if (token == etiqueta)
				{
					return true;
				}
			}

			return false;
		}

		private string Texto(Equipo equipo, string clave)
		{
			if (equipo == null || equipo.Etiquetas == null)
			{
				return null;
			}

			foreach (string token in equipo.Etiquetas.Split(';'))
			{
				if (token.StartsWith(clave + ":"))
				{
					return token.Substring(clave.Length + 1);
				}
			}

			return null;
		}

		private double Valor(Equipo equipo, string clave)
		{
			string texto = Texto(equipo, clave);
			double valor;

			if (texto != null && double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out valor))
			{
				return valor;
			}

			return 0;
		}

		private string NombreGama(int gama)
		{
			if (gama >= 3)
			{
				return "Profesional";
			}

			if (gama == 2)
			{
				return "Media";
			}

			return "Económica";
		}

		// ---- Lectura técnica del brief

		private bool EsCine(BriefProduccion b)
		{
			return b.LookCinematografico
				|| b.TipoPieza == "Ficción / cortometraje"
				|| b.TipoPieza == "Publicidad / spot"
				|| b.TipoPieza == "Videoclip";
		}

		private bool UsaBoom(BriefProduccion b)
		{
			return b.Personas > 2 || b.TipoPieza == "Ficción / cortometraje";
		}

		private List<string> Interpretar(BriefProduccion b, int dias)
		{
			List<string> lectura = new List<string>();
			lectura.Add(b.TipoPieza + " · " + b.Personas + " persona(s) · " + b.Camaras + " cámara(s) · " + dias + " día(s) de alquiler.");

			if (b.Luz == "Escasa")
			{
				lectura.Add("Luz escasa: se exige una cámara de alta sensibilidad y luces de mayor potencia.");
			}
			else if (b.Luz == "Media")
			{
				lectura.Add("Luz media: se prefieren cámaras con buen desempeño en baja luz.");
			}
			else
			{
				lectura.Add("Buena luz disponible: alcanzan luces de apoyo y reflectores.");
			}

			if (b.Locacion == "Exterior")
			{
				lectura.Add("Exterior: se agregan rebotes y se prefieren equipos aptos para exterior.");
			}

			if (EsCine(b))
			{
				lectura.Add("Look cinematográfico: se priorizan cámaras de cine y ópticas luminosas.");
			}

			if (b.CamaraEnMovimiento)
			{
				lectura.Add("Cámara en movimiento: el estabilizador debe soportar el peso de cámara + lente.");
			}

			if (b.SonidoDirecto)
			{
				if (UsaBoom(b))
				{
					lectura.Add("Sonido directo con varias voces o ficción: micrófono shotgun con pértiga y grabador.");
				}
				else
				{
					lectura.Add("Sonido directo: micrófonos inalámbricos para cubrir a las " + b.Personas + " persona(s).");
				}
			}

			if (b.HorasJornada >= 8)
			{
				lectura.Add("Jornada de " + b.HorasJornada + " horas: se incluye energía de respaldo.");
			}

			return lectura;
		}

		// ---- Armado de una propuesta

		private List<Equipo> Ordenar(List<Equipo> candidatos, bool economica, Func<Equipo, double> puntaje)
		{
			List<Equipo> lista = new List<Equipo>(candidatos);
			lista.Sort(
				delegate(Equipo a, Equipo b)
				{
					int orden;

					if (economica)
					{
						orden = a.TarifaDiaria.CompareTo(b.TarifaDiaria);

						if (orden == 0)
						{
							orden = puntaje(b).CompareTo(puntaje(a));
						}
					}
					else
					{
						orden = puntaje(b).CompareTo(puntaje(a));

						if (orden == 0)
						{
							orden = a.TarifaDiaria.CompareTo(b.TarifaDiaria);
						}
					}

					if (orden == 0)
					{
						orden = a.Id.CompareTo(b.Id);
					}

					return orden;
				}
			);
			return lista;
		}

		private List<Equipo> Categoria(List<Equipo> disponibles, string categoria)
		{
			List<Equipo> lista = new List<Equipo>();

			foreach (Equipo equipo in disponibles)
			{
				if (equipo.Categoria == categoria)
				{
					lista.Add(equipo);
				}
			}

			return lista;
		}

		private List<Equipo> Con(List<Equipo> origen, string etiqueta)
		{
			List<Equipo> lista = new List<Equipo>();

			foreach (Equipo equipo in origen)
			{
				if (Tiene(equipo, etiqueta))
				{
					lista.Add(equipo);
				}
			}

			return lista;
		}

		// Toma hasta "cantidad" equipos distintos del orden indicado y los registra como casilleros.
		private void Tomar(
			List<Casillero> casilleros,
			HashSet<int> usados,
			List<Equipo> elegibles,
			int cantidad,
			bool economica,
			Func<Equipo, double> puntaje,
			string rol,
			bool reemplazable
		)
		{
			int tomados = 0;

			foreach (Equipo equipo in Ordenar(elegibles, economica, puntaje))
			{
				if (tomados >= cantidad)
				{
					break;
				}

				if (usados.Contains(equipo.Id))
				{
					continue;
				}

				usados.Add(equipo.Id);
				tomados++;
				string nombre = rol;

				if (cantidad > 1)
				{
					nombre = rol + " " + tomados;
				}

				casilleros.Add(
					new Casillero
					{
						Rol = nombre,
						Elegibles = elegibles,
						Elegido = equipo,
						Puntaje = puntaje,
						Reemplazable = reemplazable
					}
				);
			}
		}

		private Propuesta Armar(BriefProduccion b, List<Equipo> disponibles, int dias, bool economica)
		{
			List<Casillero> casilleros = new List<Casillero>();
			List<string> notas = new List<string>();
			HashSet<int> usados = new HashSet<int>();
			bool cine = EsCine(b);
			bool bajaLuz = b.Luz == "Escasa";

			// 1. Cámaras: sensibilidad según la luz, look de cine y peso si se mueve.
			List<Equipo> camaras = Categoria(disponibles, "Cámara");
			List<Equipo> aptas = bajaLuz ? Con(camaras, "baja-luz") : camaras;

			if (aptas.Count == 0)
			{
				aptas = camaras;

				if (bajaLuz && camaras.Count > 0)
				{
					notas.Add("No hay una cámara de alta sensibilidad disponible en esas fechas: con luz escasa necesitarás más iluminación.");
				}
			}

			Func<Equipo, double> puntajeCamara = delegate(Equipo e)
			{
				double p = e.Gama * 10;

				if (cine && Tiene(e, "cine"))
				{
					p += 8;
				}

				if (b.Luz == "Media" && Tiene(e, "baja-luz"))
				{
					p += 4;
				}

				if (bajaLuz && Tiene(e, "baja-luz-extrema"))
				{
					p += 5;
				}

				if (b.CamaraEnMovimiento && Valor(e, "peso") <= 0.75)
				{
					p += 3;
				}

				if (b.Locacion == "Exterior" && Tiene(e, "nd-interno"))
				{
					p += 3;
				}

				return p;
			};

			List<Equipo> ordenCamaras = Ordenar(aptas, economica, puntajeCamara);
			List<Equipo> camarasElegidas = new List<Equipo>();

			if (ordenCamaras.Count > 0)
			{
				// El principal debe poder completar la cantidad pedida con unidades compatibles, si existe alguno.
				Equipo principal = ordenCamaras[0];

				foreach (Equipo candidato in ordenCamaras)
				{
					int compatibles = 0;

					foreach (Equipo otro in ordenCamaras)
					{
						bool mismoModelo = otro.Marca == candidato.Marca && otro.Modelo == candidato.Modelo;

						if (mismoModelo || Texto(otro, "montura") == Texto(candidato, "montura"))
						{
							compatibles++;
						}
					}

					if (compatibles >= b.Camaras)
					{
						principal = candidato;
						break;
					}
				}

				// Varias cámaras: mismo modelo y, si faltan unidades, misma montura (óptica y colorimetría compatibles).
				foreach (Equipo e in ordenCamaras)
				{
					if (camarasElegidas.Count < b.Camaras && e.Marca == principal.Marca && e.Modelo == principal.Modelo)
					{
						camarasElegidas.Add(e);
					}
				}

				foreach (Equipo e in ordenCamaras)
				{
					if (camarasElegidas.Count < b.Camaras && !camarasElegidas.Contains(e) && Texto(e, "montura") == Texto(principal, "montura"))
					{
						camarasElegidas.Add(e);
					}
				}

				if (camarasElegidas.Count < b.Camaras)
				{
					notas.Add("Solo hay " + camarasElegidas.Count + " cámara(s) compatible(s) disponible(s) para pedir " + b.Camaras + ".");
				}
			}
			else
			{
				notas.Add("No hay cámaras disponibles en esas fechas.");
			}

			for (int i = 0; i < camarasElegidas.Count; i++)
			{
				Equipo camara = camarasElegidas[i];
				usados.Add(camara.Id);
				string montura = Texto(camara, "montura");
				List<Equipo> mismaMontura = new List<Equipo>();

				foreach (Equipo e in aptas)
				{
					if (Texto(e, "montura") == montura)
					{
						mismaMontura.Add(e);
					}
				}

				casilleros.Add(
					new Casillero
					{
						Rol = camarasElegidas.Count > 1 ? "Cámara " + (i + 1) : "Cámara",
						Elegibles = mismaMontura,
						Elegido = camara,
						Puntaje = puntajeCamara,
						Reemplazable = true
					}
				);
			}

			// 2. Lentes compatibles con la montura de cada cámara.
			Func<Equipo, double> puntajeLente = delegate(Equipo e)
			{
				double p = e.Gama * 6;

				if (b.TipoPieza == "Entrevista / documental" && Tiene(e, "fijo"))
				{
					p += 6;
				}

				if (cine && Tiene(e, "cine"))
				{
					p += 8;
				}

				if (cine && (Tiene(e, "f1.8") || Tiene(e, "t1.5")))
				{
					p += 3;
				}

				if (b.TipoPieza == "Evento / social" && Tiene(e, "zoom"))
				{
					p += 8;
				}

				if (b.Locacion == "Interior" && Tiene(e, "angular"))
				{
					p += 4;
				}

				return p;
			};
			List<Equipo> lentes = Categoria(disponibles, "Lente");
			List<Equipo> lentesElegidos = new List<Equipo>();

			foreach (Equipo camara in camarasElegidas)
			{
				string montura = Texto(camara, "montura");

				if (montura == null || montura == "kit")
				{
					continue;
				}

				List<Equipo> compatibles = new List<Equipo>();

				foreach (Equipo l in lentes)
				{
					if (Texto(l, "montura") == montura)
					{
						compatibles.Add(l);
					}
				}

				int antes = casilleros.Count;
				Tomar(casilleros, usados, compatibles, 1, economica, puntajeLente, camarasElegidas.Count > 1 ? "Lente " + (lentesElegidos.Count + 1) : "Lente", true);

				if (casilleros.Count > antes)
				{
					lentesElegidos.Add(casilleros[casilleros.Count - 1].Elegido);
				}
				else
				{
					notas.Add("No hay lentes disponibles con montura " + montura + " para esas fechas.");
				}
			}

			// 3. Soportes: estabilizador si hay movimiento (según el peso del conjunto) y trípode para tomas fijas.
			double peso = 0;

			if (camarasElegidas.Count > 0)
			{
				peso = Valor(camarasElegidas[0], "peso");
			}

			if (lentesElegidos.Count > 0)
			{
				peso += Valor(lentesElegidos[0], "peso");
			}

			double necesario = peso + 0.3;

			if (b.CamaraEnMovimiento)
			{
				List<Equipo> gimbals = Con(Categoria(disponibles, "Estabilizador"), "gimbal");
				List<Equipo> soportan = new List<Equipo>();

				foreach (Equipo g in gimbals)
				{
					if (Valor(g, "carga") >= necesario)
					{
						soportan.Add(g);
					}
				}

				if (soportan.Count == 0 && gimbals.Count > 0)
				{
					soportan = gimbals;
					notas.Add("Ningún estabilizador disponible soporta con holgura el peso de la cámara y el lente elegidos (" + necesario.ToString("0.0", CultureInfo.InvariantCulture) + " kg).");
				}

				Func<Equipo, double> puntajeGimbal = delegate(Equipo e)
				{
					return e.Gama * 10 + Valor(e, "carga");
				};
				Tomar(casilleros, usados, soportan, 1, economica, puntajeGimbal, "Estabilizador", true);
			}

			List<Equipo> tripodes = Con(Categoria(disponibles, "Soporte"), "tripode");
			List<Equipo> firmes = new List<Equipo>();

			foreach (Equipo t in tripodes)
			{
				if (Valor(t, "carga") >= necesario)
				{
					firmes.Add(t);
				}
			}

			if (firmes.Count == 0)
			{
				firmes = tripodes;
			}

			Tomar(casilleros, usados, firmes, Math.Min(b.Camaras, 2), economica, delegate(Equipo e) { return e.Gama * 10 + Valor(e, "carga"); }, "Trípode", true);

			// 4. Iluminación: cantidad según personas; potencia según luz y locación.
			int luces = b.Personas <= 1 ? 2 : (b.Personas <= 3 ? 3 : 4);

			if (b.Luz == "Buena" && b.Locacion == "Exterior")
			{
				luces = 1;
			}

			List<Equipo> iluminacion = Categoria(disponibles, "Iluminación");
			List<Equipo> principales = new List<Equipo>();
			List<Equipo> todasKey = new List<Equipo>();

			foreach (Equipo l in iluminacion)
			{
				if (Tiene(l, "luz:key") || Tiene(l, "luz:panel"))
				{
					todasKey.Add(l);
				}
			}

			foreach (Equipo l in todasKey)
			{
				bool potente = Valor(l, "potencia") >= 100;

				if ((bajaLuz && b.Locacion != "Exterior" && potente) || (b.Locacion == "Exterior" && b.Luz != "Buena" && Tiene(l, "exterior")))
				{
					principales.Add(l);
				}
			}

			if (principales.Count == 0)
			{
				principales = todasKey;

				if (bajaLuz && todasKey.Count > 0 && Con(todasKey, "alta-potencia").Count == 0 && luces > 0)
				{
					notas.Add("No hay luces de alta potencia disponibles: con luz escasa el resultado dependerá de la sensibilidad de la cámara.");
				}
			}

			Func<Equipo, double> puntajeLuz = delegate(Equipo e)
			{
				double p = e.Gama * 10 + Valor(e, "potencia") / 50.0;

				if (cine && Tiene(e, "luz:panel"))
				{
					p += 4;
				}

				return p;
			};
			int antesLuces = casilleros.Count;
			Tomar(casilleros, usados, principales, 1, economica, puntajeLuz, "Luz principal", true);

			if (luces > 1)
			{
				Tomar(casilleros, usados, todasKey, luces - 1, economica, puntajeLuz, "Luz de relleno", true);
			}

			if (casilleros.Count - antesLuces < luces)
			{
				notas.Add("Solo se consiguieron " + (casilleros.Count - antesLuces) + " luz/luces de las " + luces + " recomendadas para el set.");
			}

			if (b.Locacion != "Interior")
			{
				Tomar(casilleros, usados, Con(iluminacion, "luz:reflector"), 1, economica, delegate(Equipo e) { return e.Gama; }, "Rebote", false);
			}

			if (!economica && (cine || b.TipoPieza == "Entrevista / documental"))
			{
				Tomar(casilleros, usados, Con(iluminacion, "luz:difusor"), 1, false, delegate(Equipo e) { return e.Gama; }, "Difusor", true);
			}

			// 5. Sonido directo.
			if (b.SonidoDirecto)
			{
				List<Equipo> audio = Categoria(disponibles, "Audio");

				if (UsaBoom(b))
				{
					Func<Equipo, double> puntajeBoom = delegate(Equipo e)
					{
						double p = e.Gama * 10;

						if (b.Locacion == "Exterior" && Tiene(e, "exterior"))
						{
							p += 5;
						}

						return p;
					};
					Tomar(casilleros, usados, Con(audio, "audio:boom"), 1, economica, puntajeBoom, "Micrófono shotgun", true);
					Tomar(casilleros, usados, Con(audio, "audio:pertiga"), 1, economica, delegate(Equipo e) { return e.Gama; }, "Pértiga", true);
					Tomar(casilleros, usados, Con(audio, "audio:grabador"), 1, economica, delegate(Equipo e) { return e.Gama; }, "Grabador de audio", true);
				}
				else
				{
					// Cubre a cada persona: se suman equipos hasta alcanzar la cantidad de voces.
					List<Equipo> lavs = Con(audio, "audio:lavalier");
					List<Equipo> orden = new List<Equipo>(lavs);
					orden.Sort(
						delegate(Equipo x, Equipo y)
						{
							double cx = Math.Max(1, Valor(x, "cubre"));
							double cy = Math.Max(1, Valor(y, "cubre"));
							int c;

							if (economica)
							{
								c = ((double)x.TarifaDiaria / cx).CompareTo((double)y.TarifaDiaria / cy);
							}
							else
							{
								c = y.Gama.CompareTo(x.Gama);

								if (c == 0)
								{
									c = ((double)x.TarifaDiaria / cx).CompareTo((double)y.TarifaDiaria / cy);
								}
							}

							return c != 0 ? c : x.Id.CompareTo(y.Id);
						}
					);
					int cubiertas = 0;
					int n = 0;

					foreach (Equipo l in orden)
					{
						if (cubiertas >= b.Personas)
						{
							break;
						}

						usados.Add(l.Id);
						n++;
						cubiertas += (int)Math.Max(1, Valor(l, "cubre"));
						casilleros.Add(
							new Casillero
							{
								Rol = "Micrófono inalámbrico " + n,
								Elegibles = lavs,
								Elegido = l,
								Puntaje = delegate(Equipo e) { return e.Gama; },
								Reemplazable = true
							}
						);
					}

					if (cubiertas < b.Personas)
					{
						notas.Add("Con el sonido disponible se cubren " + cubiertas + " de las " + b.Personas + " voces.");
					}
				}
			}

			// 6. Monitoreo y energía.
			if (b.Monitoreo)
			{
				Tomar(
					casilleros,
					usados,
					Categoria(disponibles, "Monitor"),
					1,
					economica,
					delegate(Equipo e) { return e.Gama * 10 + (b.Locacion == "Exterior" && Tiene(e, "exterior") ? 6 : 0); },
					"Monitor de set",
					true
				);
			}

			if (b.HorasJornada >= 8)
			{
				Tomar(casilleros, usados, Categoria(disponibles, "Energía"), b.HorasJornada > 12 ? 2 : 1, economica, delegate(Equipo e) { return e.Gama; }, "Energía de respaldo", true);
			}

			// Ajuste al presupuesto: se baja de gama primero donde más se ahorra, sin romper los requisitos.
			if (!economica)
			{
				AjustarPresupuesto(casilleros, usados, b.Presupuesto, dias, notas);
			}

			Propuesta propuesta = new Propuesta();
			propuesta.Nombre = economica ? "Alternativa económica" : "Configuración recomendada";
			propuesta.Dias = dias;
			propuesta.Presupuesto = b.Presupuesto;
			propuesta.Lineas = new List<LineaPropuesta>();

			foreach (Casillero c in casilleros)
			{
				propuesta.Lineas.Add(Linea(c.Rol, c.Elegido, dias));
				propuesta.Total += c.Elegido.TarifaDiaria * dias;
			}

			if (propuesta.Lineas.Count == 0)
			{
				notas.Add("No hay equipamiento disponible para esas fechas.");
			}

			if (propuesta.DentroDePresupuesto)
			{
				notas.Add("Dentro del presupuesto: sobran ARS " + (-propuesta.Desvio).ToString("N2") + ".");
			}
			else
			{
				notas.Add(
					"Excede el presupuesto declarado en ARS "
						+ propuesta.Desvio.ToString("N2")
						+ ". Probá la alternativa económica o reducí días, cámaras o requisitos para ajustarlo."
				);
			}

			propuesta.Lineas = Ordenar(propuesta.Lineas);
			propuesta.Notas = notas;
			Condiciones(b, propuesta);
			return propuesta;
		}

		// ---- Secciones y condiciones de reserva

		private int OrdenSeccion(string categoria)
		{
			string[] orden = { "Cámara", "Lente", "Estabilizador", "Soporte", "Iluminación", "Audio", "Monitor", "Energía" };
			int indice = Array.IndexOf(orden, categoria);

			if (indice < 0)
			{
				return orden.Length;
			}

			return indice;
		}

		private string NombreSeccion(string categoria)
		{
			switch (categoria)
			{
				case "Cámara":
					return "Cámaras";
				case "Lente":
					return "Lentes";
				case "Estabilizador":
					return "Estabilizadores";
				case "Soporte":
					return "Soportes";
				case "Monitor":
					return "Monitores";
				default:
					return categoria;
			}
		}

		private List<LineaPropuesta> Ordenar(List<LineaPropuesta> lineas)
		{
			return lineas.OrderBy(delegate(LineaPropuesta l) { return OrdenSeccion(l.Equipo.Categoria); }).ToList();
		}

		// Seña con la misma regla de la reserva real, y la cobertura del seguro del usuario.
		private void Condiciones(BriefProduccion b, Propuesta propuesta)
		{
			propuesta.SenaRequerida = 0;
			propuesta.Seguro = "";

			if (propuesta.Lineas.Count == 0)
			{
				return;
			}

			try
			{
				Reserva consulta = new Reserva { Desde = b.Desde, Hasta = b.Hasta, Equipos = new List<Equipo>() };

				foreach (LineaPropuesta l in propuesta.Lineas)
				{
					consulta.Equipos.Add(l.Equipo);
				}

				new ReservaBLL().CalcularImportes(consulta);
				propuesta.SenaRequerida = consulta.SenaRequerida;
			}
			catch (Exception)
			{
				propuesta.SenaRequerida = 0;
			}

			Usuario sesion = SesionSingleton.Instancia.UsuarioActual;
			Seguro seguro = sesion == null ? null : usuarios.BuscarSeguro(sesion.Id);

			if (seguro != null && seguro.Desde <= b.Desde && seguro.Hasta >= b.Hasta)
			{
				propuesta.Seguro = "Seguro " + (seguro.Tipo == "Basico" ? "Básico" : seguro.Tipo) + " vigente: " + seguro.Detalle + " Tope ARS " + seguro.Cobertura.ToString("N2") + " por unidad.";
			}
			else if (seguro != null)
			{
				propuesta.Seguro = "Tu póliza " + (seguro.Tipo == "Basico" ? "Básico" : seguro.Tipo) + " no cubre todas las fechas del rodaje: ante daños pagarías el cargo completo.";
			}
			else
			{
				propuesta.Seguro = "Sin seguro: ante daños o faltantes pagás el cargo completo.";
			}
		}

		// Suma los complementos elegidos a una propuesta y recalcula total, seña y seguro.
		public Propuesta Combinar(BriefProduccion brief, Propuesta baseP, List<LineaPropuesta> extras)
		{
			Propuesta p = new Propuesta
			{
				Nombre = baseP.Nombre,
				Dias = baseP.Dias,
				Presupuesto = baseP.Presupuesto,
				Notas = new List<string>(),
				Lineas = new List<LineaPropuesta>(baseP.Lineas)
			};

			foreach (string nota in baseP.Notas)
			{
				if (!nota.StartsWith("Dentro del presupuesto") && !nota.StartsWith("Excede el presupuesto"))
				{
					p.Notas.Add(nota);
				}
			}

			if (extras != null)
			{
				p.Lineas.AddRange(extras);
			}

			p.Lineas = Ordenar(p.Lineas);

			foreach (LineaPropuesta l in p.Lineas)
			{
				p.Total += l.Subtotal;
			}

			if (p.DentroDePresupuesto)
			{
				p.Notas.Add("Dentro del presupuesto: sobran ARS " + (-p.Desvio).ToString("N2") + ".");
			}
			else
			{
				p.Notas.Add("Excede el presupuesto declarado en ARS " + p.Desvio.ToString("N2") + ".");
			}

			Condiciones(brief, p);
			return p;
		}

		// ---- Propuestas guardadas

		public int Guardar(string nombre, string variante, decimal total, BriefProduccion brief)
		{
			Autorizar();

			if (string.IsNullOrWhiteSpace(nombre) || nombre.Trim().Length > 100)
			{
				throw new ArgumentException("Poné un nombre de hasta 100 caracteres para guardar la propuesta.");
			}

			Validar(brief);
			return propuestas.Insertar(
				new PropuestaGuardada
				{
					UsuarioId = SesionSingleton.Instancia.UsuarioActual.Id,
					Nombre = nombre.Trim(),
					Variante = variante == "Economica" ? "Economica" : "Recomendada",
					Total = total,
					Brief = brief
				}
			);
		}

		public List<PropuestaGuardada> ListarGuardadas()
		{
			Autorizar();
			return propuestas.Listar(SesionSingleton.Instancia.UsuarioActual.Id);
		}

		public bool EliminarGuardada(int id)
		{
			Autorizar();
			return propuestas.Eliminar(id, SesionSingleton.Instancia.UsuarioActual.Id);
		}

		private void Autorizar()
		{
			if (!seguridad.TienePermiso("Asesoramiento.Consultar"))
			{
				throw new UnauthorizedAccessException("No tenés permiso para usar el asesoramiento técnico.");
			}
		}

		private void AjustarPresupuesto(List<Casillero> casilleros, HashSet<int> usados, decimal presupuesto, int dias, List<string> notas)
		{
			bool bajo = false;

			for (int vuelta = 0; vuelta < 50; vuelta++)
			{
				decimal total = 0;

				foreach (Casillero c in casilleros)
				{
					total += c.Elegido.TarifaDiaria * dias;
				}

				if (total <= presupuesto)
				{
					break;
				}

				Casillero mejor = null;
				Equipo reemplazo = null;
				decimal ahorro = 0;

				foreach (Casillero c in casilleros)
				{
					if (!c.Reemplazable)
					{
						continue;
					}

					Equipo alternativa = null;

					foreach (Equipo e in Ordenar(c.Elegibles, false, c.Puntaje))
					{
						if (!usados.Contains(e.Id) && e.TarifaDiaria < c.Elegido.TarifaDiaria)
						{
							alternativa = e;
							break;
						}
					}

					if (alternativa != null && c.Elegido.TarifaDiaria - alternativa.TarifaDiaria > ahorro)
					{
						ahorro = c.Elegido.TarifaDiaria - alternativa.TarifaDiaria;
						mejor = c;
						reemplazo = alternativa;
					}
				}

				if (mejor == null)
				{
					// Sin más rubros para bajar de gama: se quita lo prescindible (el difusor).
					Casillero prescindible = casilleros.Find(delegate(Casillero c) { return c.Rol == "Difusor"; });

					if (prescindible == null)
					{
						break;
					}

					usados.Remove(prescindible.Elegido.Id);
					casilleros.Remove(prescindible);
					notas.Add("Se quitó el difusor para acercarse al presupuesto; queda disponible entre los complementos.");
					continue;
				}

				usados.Remove(mejor.Elegido.Id);
				usados.Add(reemplazo.Id);
				mejor.Elegido = reemplazo;
				bajo = true;
			}

			if (bajo)
			{
				notas.Add("Para respetar tu presupuesto se bajó de gama en algunos rubros; el detalle de lo que se resigna está en cada línea.");
			}
		}

		private LineaPropuesta Linea(string rol, Equipo equipo, int dias)
		{
			return new LineaPropuesta
			{
				Rol = rol,
				Seccion = NombreSeccion(equipo.Categoria),
				Equipo = equipo,
				Detalle = equipo.Marca + " " + equipo.Modelo + " (" + equipo.CodigoInventario + ")",
				Gama = NombreGama(equipo.Gama),
				Tarifa = equipo.TarifaDiaria,
				Subtotal = equipo.TarifaDiaria * dias,
				Aporta = equipo.Ventaja,
				Resigna = equipo.Limitacion
			};
		}

		// ---- Complementos opcionales: lo que suma valor y no está en la configuración recomendada.

		private List<LineaPropuesta> Complementos(BriefProduccion b, List<Equipo> disponibles, Propuesta recomendada, int dias)
		{
			HashSet<int> enUso = new HashSet<int>();

			foreach (LineaPropuesta l in recomendada.Lineas)
			{
				enUso.Add(l.Equipo.Id);
			}

			List<Equipo> libres = new List<Equipo>();

			foreach (Equipo e in disponibles)
			{
				if (!enUso.Contains(e.Id))
				{
					libres.Add(e);
				}
			}

			bool cine = EsCine(b);
			List<KeyValuePair<int, LineaPropuesta>> ofertas = new List<KeyValuePair<int, LineaPropuesta>>();
			Equipo cam = null;
			Equipo lente = null;

			foreach (LineaPropuesta l in recomendada.Lineas)
			{
				if (cam == null && l.Equipo.Categoria == "Cámara")
				{
					cam = l.Equipo;
				}

				if (lente == null && l.Equipo.Categoria == "Lente")
				{
					lente = l.Equipo;
				}
			}

			Func<string, string, int, Func<Equipo, bool>, int> agregar = delegate(string rol, string motivo, int relevancia, Func<Equipo, bool> filtro)
			{
				Equipo mejor = null;

				foreach (Equipo e in libres)
				{
					if (filtro(e) && (mejor == null || e.Gama > mejor.Gama || (e.Gama == mejor.Gama && e.TarifaDiaria < mejor.TarifaDiaria)))
					{
						mejor = e;
					}
				}

				if (mejor != null)
				{
					LineaPropuesta linea = Linea("Opcional · " + rol, mejor, dias);
					linea.Aporta = motivo + " " + mejor.Ventaja;
					ofertas.Add(new KeyValuePair<int, LineaPropuesta>(relevancia, linea));
					libres.Remove(mejor);
				}

				return 0;
			};

			if (!b.Monitoreo)
			{
				agregar("Monitor", "Permite revisar foco y exposición en el set.", cine ? 8 : 5, delegate(Equipo e) { return Tiene(e, "monitor"); });
			}

			if (b.HorasJornada < 8)
			{
				agregar("Energía", "Respaldo por si la jornada se extiende.", 3, delegate(Equipo e) { return Tiene(e, "energia"); });
			}

			if (!b.CamaraEnMovimiento && (cine || b.TipoPieza == "Entrevista / documental"))
			{
				agregar("Slider", "Suma movimiento suave a planos que de otro modo serían estáticos.", cine ? 6 : 4, delegate(Equipo e) { return Tiene(e, "slider"); });
			}

			if (!b.CamaraEnMovimiento && (b.TipoPieza == "Videoclip" || b.TipoPieza == "Evento / social"))
			{
				agregar("Estabilizador", "Permite tomas en movimiento que dan dinamismo.", 5, delegate(Equipo e) { return Tiene(e, "gimbal"); });
			}

			if (b.TipoPieza == "Videoclip" || b.TipoPieza == "Publicidad / spot")
			{
				agregar("Luz de color", "Aporta color y atmósfera al fondo.", 5, delegate(Equipo e) { return Tiene(e, "luz:efecto"); });
			}

			agregar("Luz adicional", "Da más control para separar sujeto y fondo.", 4, delegate(Equipo e) { return Tiene(e, "luz:key") || Tiene(e, "luz:panel"); });

			if (cine && lente != null)
			{
				string montura = Texto(lente, "montura");
				agregar(
					"Segundo lente",
					"Una focal distinta amplía las opciones de encuadre.",
					6,
					delegate(Equipo e) { return e.Categoria == "Lente" && Texto(e, "montura") == montura && (Tiene(e, "fijo") != Tiene(lente, "fijo")); }
				);
			}

			if (b.SonidoDirecto && !UsaBoom(b))
			{
				agregar("Grabador de audio", "Respaldo del sonido ante fallas de la transmisión inalámbrica.", 4, delegate(Equipo e) { return Tiene(e, "audio:grabador"); });
			}

			if (!recomendada.Lineas.Exists(delegate(LineaPropuesta l) { return Tiene(l.Equipo, "luz:difusor"); }))
			{
				agregar("Difusor", "Suaviza la luz y favorece los rostros.", 5, delegate(Equipo e) { return Tiene(e, "luz:difusor"); });
			}

			ofertas.Sort(delegate(KeyValuePair<int, LineaPropuesta> x, KeyValuePair<int, LineaPropuesta> y) { return y.Key.CompareTo(x.Key); });
			List<LineaPropuesta> resultado = new List<LineaPropuesta>();

			foreach (KeyValuePair<int, LineaPropuesta> oferta in ofertas)
			{
				resultado.Add(oferta.Value);
			}

			return Ordenar(resultado);
		}
	}
}

using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.ComponentModel.Design;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICE;
class Verificar
{
 static int casos;
 static void Exigir(bool c,string n) { if(!c)throw new Exception(n); Console.WriteLine("OK "+n);casos++; }
 static void Rechaza(Action a,string n) { bool fallo=false;try{a();}catch{fallo=true;}Exigir(fallo,n); }
 [STAThread] static void Main(string[] args)
 {
  var b=new BriefProduccion{TipoPieza="Streaming / podcast",Presupuesto=123456.78m,Desde=DateTime.Today.AddDays(3).AddHours(9),Hasta=DateTime.Today.AddDays(5).AddHours(18),Personas=4,Camaras=2,Locacion="Mixta",Luz="Escasa",HorasJornada=10,CamaraEnMovimiento=true,SonidoDirecto=true,Monitoreo=true,LookCinematografico=true};
  var xml=new XmlSerializador<BriefProduccion>();
  using(var s=new MemoryStream()){
   xml.Serializar(s,b);Exigir(s.CanRead,"stream permanece abierto al serializar");s.Position=0;
   var copia=(BriefProduccion)xml.Deserializar(s);
   foreach(var p in typeof(BriefProduccion).GetProperties())Exigir(object.Equals(p.GetValue(b,null),p.GetValue(copia,null)),"ida y vuelta "+p.Name);
   Exigir(!object.ReferenceEquals(b,copia),"instancia independiente");Exigir(s.CanRead,"stream permanece abierto al deserializar");
  }
  foreach(var contenido in new[]{"<otro/>","<BriefProduccion>","<!DOCTYPE x [<!ENTITY e SYSTEM 'file:///no-leer'>]><BriefProduccion><TipoPieza>&e;</TipoPieza></BriefProduccion>"})
   Rechaza(delegate{using(var s=new MemoryStream(Encoding.UTF8.GetBytes(contenido)))xml.Deserializar(s);},"XML inválido o DTD rechazado");
  var bll=new AsesorBLL();SesionSingleton.Instancia.Cerrar();
  Rechaza(delegate{bll.ExportarBrief(b,args[0]);},"exportación exige permiso");
  var permisos=new Rol{Codigo="Cliente"};permisos.Agregar(new Permiso{Codigo="Asesoramiento.Consultar"});
  SesionSingleton.Instancia.Iniciar(new Usuario{Id=999,Activo=true,Rol="Cliente"},permisos);
  bll.ExportarBrief(b,args[0]);var cargado=bll.ImportarBrief(args[0]);Exigir(cargado.Presupuesto==b.Presupuesto,"integración BLL archivo XML");
  string original=File.ReadAllText(args[0]);File.WriteAllText(args[0],original.Replace("<Personas>4</Personas>","<Personas>21</Personas>"));
  Rechaza(delegate{bll.ImportarBrief(args[0]);},"rangos inválidos rechazados antes de aplicar al formulario");
  File.WriteAllText(args[0],original.Replace("Streaming / podcast","Tipo inventado"));Rechaza(delegate{bll.ImportarBrief(args[0]);},"opciones desconocidas rechazadas");File.WriteAllText(args[0],original);
  SesionSingleton.Instancia.Cerrar();
  foreach(string name in new[]{"Login","MenuPrincipal","Reservas","Devoluciones","Asesor","Clientes","Usuarios"}){
   Type t=typeof(GUI.LoginForm).Assembly.GetType("GUI."+name+"Form");
   using(var surface=new DesignSurface()){
    surface.BeginLoad(t);Exigir(surface.IsLoaded,"DesignSurface "+name);
    var host=(IDesignerHost)surface.GetService(typeof(IDesignerHost));
    var form=(Form)host.RootComponent;
    t.GetMethod(name+"Form_Load",BindingFlags.Instance|BindingFlags.NonPublic).Invoke(form,new object[]{form,EventArgs.Empty});
    Exigir(!form.IsDisposed,"Load en diseño sin sesión ni SQL "+name);
   }
  }
  Console.WriteLine("TOTAL "+casos+" verificaciones correctas");
 }
}

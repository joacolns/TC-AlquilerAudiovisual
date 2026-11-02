# Verificacion de serializacion y formularios

Desde PowerShell, con Visual Studio y .NET Framework 4.7.2 instalados:

```powershell
./Verificacion/Verificar.ps1 -Configuracion Debug
```

Compila GUI y sus dependencias y ejecuta 37 comprobaciones. Usa un directorio temporal nuevo para el XML. No requiere una sesion real ni escribe en SQL Server. Las credenciales no se utilizan.

Comprueba las 13 propiedades del brief en una conversion de ida y vuelta, conservacion de los streams, rechazo de XML invalido y DTD, permisos, validacion de rangos y opciones, y carga de los siete formularios con DesignSurface.

DesignSurface verifica la construccion de los controles y los manejadores Load en modo diseño. No reproduce el analizador CodeDOM ni el estado de cache de una instancia de Visual Studio. La confirmacion del error EnsureDocument exige abrir los diseñadores en ese entorno.

Estos archivos no se incluyen en los proyectos de la aplicacion ni en sus diagramas de clases.

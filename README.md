# Alquiler audiovisual — ENTREGA1 (N01)

Aplicación académica en C# / .NET Framework 4.7.2, WinForms y SQL Server.
Capas: GUI, BLL, BE, DAL y SERVICE. BE contiene solo propiedades.

Builder sigue el ejemplo `patrones/builder.jpg`: `DirectorReserva` ordena la construcción mediante `ReservaBuilder` abstracto; `ReservaBuilderConcreto` construye el producto `Reserva`. `ReservaBLL` usa el Director al solicitar y confirmar, y conserva las reglas de negocio y la persistencia.

El código usa tabulaciones de ancho 4, llaves en líneas separadas y bloques `if`/`else` explícitos. `.editorconfig` mantiene este estilo en Visual Studio y desactiva las sugerencias para convertir esos bloques en ternarios.

## Preparar y abrir

Requisitos: Visual Studio 2022 con desarrollo de escritorio .NET y targeting pack 4.7.2, SQL Server local `.` con autenticación Windows y `sqlcmd`.

Desde esta carpeta:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\Inicializar-N01.ps1
.\GUI\bin\Debug\GUI.exe
```

También podés abrir `TC-AlquilerAudiovisual.sln`, seleccionar GUI como proyecto de inicio y ejecutar con F5.
El script crea la base/tablas faltantes, actualiza los procedimientos y agrega los ejemplos que aún no existen. Conserva registros y contraseñas existentes. `-SinDatosDemo` aplica solo la estructura.

## Editar los formularios en Visual Studio

En `GUI/Forms`, seleccioná el archivo del formulario (por ejemplo `ReservasForm.cs`) y pulsá **Shift+F7**, o clic derecho → **Ver diseñador**. Si tenías abierto el diseñador antes de este cambio, cerrá esa pestaña y volvé a abrirla. Si Visual Studio pide recargar el proyecto, aceptá la recarga.

Los cinco formularios tienen `.cs`, `.Designer.cs` y `.resx`: los controles, propiedades y eventos se pueden editar desde el diseñador visual, y el comportamiento queda en el `.cs`. En el editor se muestran todos los controles; al ejecutar se aplican los permisos del usuario. Login tiene las pestañas Acceso y Menú para editar ambas vistas; al ejecutar muestra la vista correspondiente a la sesión.

## Cuentas de ejemplo

| Usuario | Contraseña inicial | Rol |
|---|---|---|
| admin | Admin123! | Administrador |
| stock | Stock123! | EncargadoStock |
| cliente | Cliente123! | Cliente |
| tecnico | Tecnico123! | Tecnico |

Estas cuentas son ejemplos locales. SQL guarda hash PBKDF2-SHA256 de 32 bytes y sal aleatoria de 16 bytes; 600.000 iteraciones, centralizadas en `SERVICE/Seguridad.cs`. La clave solo se utiliza para generar/verificar el hash. Los listados y la sesión no exponen hash ni sal.

## Probar N01: cliente solicita, stock acepta

1. Ingresá como `cliente` / `Cliente123!`. Abrí **Solicitudes, reservas y entrega**.
2. En **Elegir equipos y enviar**, elegí las fechas, consultá disponibles y marcá una o varias unidades. La lista muestra inventario, marca/modelo y tarifa diaria.
3. Podés **Cotizar** y después **Enviar solicitud a stock**. La cuenta usa su propia ficha. Se guarda como **Pendiente**, sin bloquear equipos y sin registrar pagos.
4. En **Solicitudes y reservas**, el cliente ve sus solicitudes y su estado. Antes de la aceptación todavía no hay reserva firme.
5. Ingresá como `stock` / `Stock123!` (el gerente de stock al que se refiere el usuario). Seleccioná la solicitud Pendiente y usá **Cotizar solicitud**. Revisá cliente, seguro, fechas, unidades e importes. El administrador también está autorizado.
6. Registrá la seña y garantía efectivamente recibidas y pulsá **Aceptar solicitud**. Para DEMO-001 por 24 horas: total ARS 15.000, seña ARS 4.500, garantía ARS 100.000. Las condiciones económicas anteriores se conservan.
7. La **misma solicitud**, con el mismo número, cambia a **Firme** y bloquea las unidades. SQL vuelve a comprobar todo de manera atómica. Si hay solape, seguro inválido o importes incorrectos, sigue Pendiente.
8. Para la entrega, seleccioná esa reserva Firme, cotejá cada unidad con el cliente, obtené las firmas físicas, marcá ambos controles y registrá la entrega. Se guardan contrato `C-<Id>` y remito `R-<Id>`, y las unidades quedan Alquiladas.
9. Volvé a la cuenta `cliente` y actualizá la lista para ver Firme o Entregada.

Dos solicitudes pendientes pueden pedir la misma unidad/fecha: solo las aceptadas bloquean. Al aceptar la primera, la segunda tendrá que resolver la falta de disponibilidad. No hay notificación por correo: la solicitud aparece en el listado de stock.

Para un cliente nuevo, `admin` crea primero su cuenta con rol Cliente, luego su ficha y póliza. `stock` asigna esa póliza a cada unidad desde Equipos. `Equipo.Seguro` es opcional en el catálogo, pero obligatorio y del cliente correcto al confirmar. Una misma póliza cubre varias unidades; la cobertura indicada es por unidad.

## Reglas y alcance

- Cotizar no guarda ni bloquea. Enviar guarda Pendiente sin bloquear. Aceptar recalcula con tarifas actuales y vuelve a comprobar todo en una transacción SQL.
- Intervalos `[Desde, Hasta)`; fracciones de 24 horas se cobran como día completo. ARS y dos decimales. Seña 30% del importe, garantía 20% de reposición; porcentajes en `GUI/App.config`.
- Se respeta el día de reacondicionamiento por unidad, incluso entre reservas consecutivas. Las unidades con alquiler vencido sin devolución no se ofrecen.
- Una reserva guarda precios, reposición, reacondicionamiento y cobertura pactados. Editar el catálogo no cambia esos valores. Una póliza con alquiler pendiente no se edita.
- Cliente envía sus solicitudes. Stock administra equipos y acepta solicitudes/opera entregas; admin también. Técnico consulta catálogo. Los controles BLL aplican permisos además de los botones.
- Esta entrega llega hasta la entrega de equipos. La devolución, incidencias y alta técnica corresponden a N02, aún pendiente. Por eso un equipo entregado continúa alquilado y no hay botón para liberarlo desde stock.

Diagramas actuales en `../../Diagramas/`; contrato en `../../specs/001-integrador-alquiler-av/diseno-simple.md`. Los métodos públicos de N01 corresponden a las clases y secuencias aprobadas. DOCX sin cambios.

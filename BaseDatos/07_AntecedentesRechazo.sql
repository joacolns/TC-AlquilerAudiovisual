SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
USE [TC-AlquilerAudiovisual];
GO
-- Conservar la marca anterior para no perder avisos históricos sin detalle.
-- Los nuevos antecedentes se obtienen de las incidencias, sin duplicar registros.
IF NOT EXISTS
(
 SELECT 1 FROM sys.default_constraints dc JOIN sys.columns c
 ON c.object_id=dc.parent_object_id AND c.column_id=dc.parent_column_id
 WHERE dc.parent_object_id=OBJECT_ID(N'dbo.Cliente') AND c.name=N'AntecedenteNegativo'
)
 ALTER TABLE dbo.Cliente ADD CONSTRAINT DF_Cliente_AntecedenteAnterior DEFAULT 0 FOR AntecedenteNegativo;
GO
IF COL_LENGTH(N'dbo.Incidencia',N'MostrarEnAntecedentes') IS NULL
 ALTER TABLE dbo.Incidencia ADD MostrarEnAntecedentes bit NOT NULL
 CONSTRAINT DF_Incidencia_MostrarEnAntecedentes DEFAULT 1 WITH VALUES;
GO
CREATE OR ALTER FUNCTION dbo.HistorialCliente(@ClienteId int)
RETURNS nvarchar(max)
AS
BEGIN
 DECLARE @Historial nvarchar(max);
 SELECT @Historial=STRING_AGG(CONVERT(nvarchar(max),
  CONVERT(nvarchar(10),d.Fecha,103)+N' · Reserva '+CONVERT(nvarchar(20),r.Id)
  +N' · '+e.CodigoInventario+N' · '
  +CASE i.Tipo WHEN N'DañoReparable' THEN N'Daño reparable' WHEN N'DañoTotal' THEN N'Daño total' ELSE i.Tipo END
  +N': '+i.Descripcion+N' · Cargo ARS '+CONVERT(nvarchar(30),i.Cargo)),NCHAR(13)+NCHAR(10))
  WITHIN GROUP(ORDER BY d.Fecha DESC,i.Id DESC)
 FROM dbo.Incidencia i JOIN dbo.Devolucion d ON d.Id=i.DevolucionId
 JOIN dbo.Reserva r ON r.Id=d.ReservaId JOIN dbo.Equipo e ON e.Id=i.EquipoId
 WHERE r.ClienteId=@ClienteId AND i.MostrarEnAntecedentes=1;
 IF @Historial IS NULL AND EXISTS(SELECT 1 FROM dbo.Cliente WHERE Id=@ClienteId AND AntecedenteNegativo=1)
  SET @Historial=N'Aviso anterior de antecedente negativo, sin incidente detallado registrado.';
 RETURN ISNULL(@Historial,N'');
END;
GO
CREATE OR ALTER VIEW dbo.vCliente AS
 SELECT c.Id,c.UsuarioId,c.DniCuit,c.Nombre,c.Telefono,c.Email,
 dbo.HistorialCliente(c.Id) Antecedentes,u.NombreUsuario,u.Rol,u.Activo
 FROM dbo.Cliente c JOIN dbo.Usuario u ON u.Id=c.UsuarioId;
GO
CREATE OR ALTER VIEW dbo.vEquipo AS
 SELECT e.*,s.ClienteId SeguroClienteId,s.Poliza,s.Aseguradora,s.Desde SeguroDesde,s.Hasta SeguroHasta,
 s.Tipo TipoSeguro,s.Detalle DetalleSeguro,s.Cobertura CoberturaSeguro,
 c.UsuarioId,c.Nombre,c.DniCuit,c.Telefono,c.Email,dbo.HistorialCliente(c.Id) Antecedentes,u.NombreUsuario,u.Rol,u.Activo
 FROM dbo.Equipo e LEFT JOIN dbo.Seguro s ON s.Id=e.SeguroId
 LEFT JOIN dbo.Cliente c ON c.Id=s.ClienteId LEFT JOIN dbo.Usuario u ON u.Id=c.UsuarioId;
GO
CREATE OR ALTER VIEW dbo.vReserva AS
 SELECT r.*,c.Nombre ClienteNombre,c.DniCuit ClienteDniCuit,c.Telefono ClienteTelefono,c.Email ClienteEmail,
 dbo.HistorialCliente(c.Id) ClienteAntecedentes,c.UsuarioId ReservaUsuarioId,u.NombreUsuario ReservaNombreUsuario,u.Rol ReservaRol,u.Activo ReservaActivo,
 re.EquipoId,e.CodigoInventario,e.Serie,e.Categoria,e.Marca,e.Modelo,e.Descripcion,e.Estado EstadoEquipo,
 re.TarifaDiaria,re.ValorReposicion,re.DiasReacondicionamiento,re.SeguroId,
 CASE WHEN re.SeguroId IS NULL THEN CONVERT(decimal(18,2),0) ELSE re.CoberturaSeguro END CoberturaSeguro,
 sc.Id SeguroClienteId,re.PolizaSeguro Poliza,re.AseguradoraSeguro Aseguradora,re.DesdeSeguro SeguroDesde,re.HastaSeguro SeguroHasta,
 re.TipoSeguro,re.DetalleSeguro,sc.UsuarioId,sc.Nombre,sc.DniCuit,sc.Telefono,sc.Email,
 dbo.HistorialCliente(sc.Id) Antecedentes,su.NombreUsuario,su.Rol,su.Activo
 FROM dbo.Reserva r JOIN dbo.Cliente c ON c.Id=r.ClienteId JOIN dbo.Usuario u ON u.Id=c.UsuarioId
 JOIN dbo.ReservaEquipo re ON re.ReservaId=r.Id JOIN dbo.Equipo e ON e.Id=re.EquipoId
 LEFT JOIN dbo.Cliente sc ON sc.Id=r.ClienteId AND re.SeguroId IS NOT NULL LEFT JOIN dbo.Usuario su ON su.Id=sc.UsuarioId;
GO
CREATE OR ALTER VIEW dbo.vUsuario AS
 SELECT u.Id,u.NombreUsuario,u.Rol,u.Activo,u.TipoSeguro,u.SeguroId,
 s.ClienteId SeguroClienteId,s.Tipo SeguroTipo,s.Detalle SeguroDetalle,s.Poliza SeguroPoliza,
 s.Aseguradora SeguroAseguradora,s.Desde SeguroDesde,s.Hasta SeguroHasta,s.Cobertura SeguroCobertura,
 c.Nombre SeguroNombre,c.DniCuit SeguroDniCuit,c.Telefono SeguroTelefono,c.Email SeguroEmail,
 dbo.HistorialCliente(c.Id) SeguroAntecedentes
 FROM dbo.Usuario u LEFT JOIN dbo.Cliente c ON c.UsuarioId=u.Id
 LEFT JOIN dbo.Seguro s ON s.Id=u.SeguroId AND s.ClienteId=c.Id AND u.TipoSeguro<>N'SinSeguro';
GO
-- El rechazo conserva la solicitud y sus unidades para consultar su resultado.
IF EXISTS(SELECT 1 FROM sys.check_constraints WHERE name=N'CK_Reserva_EstadoSolicitud' AND parent_object_id=OBJECT_ID(N'dbo.Reserva'))
 ALTER TABLE dbo.Reserva DROP CONSTRAINT CK_Reserva_EstadoSolicitud;
ALTER TABLE dbo.Reserva WITH CHECK ADD CONSTRAINT CK_Reserva_EstadoSolicitud
 CHECK(Estado IN(N'Pendiente',N'Rechazada',N'Aceptada',N'Firme',N'Entregada',N'ConIncidencia',N'Cerrada'));
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Rechazar @ReservaId int,@Resultado int OUTPUT AS
BEGIN
 SET NOCOUNT ON;
 UPDATE dbo.Reserva SET Estado=N'Rechazada' WHERE Id=@ReservaId AND Estado=N'Pendiente';
 SET @Resultado=@@ROWCOUNT;
END;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET ARITHABORT ON;
SET NUMERIC_ROUNDABORT OFF;
USE [TC-AlquilerAudiovisual];
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Buscar @NombreUsuario nvarchar(50) AS
 BEGIN SET NOCOUNT ON; SELECT Id,NombreUsuario,Hash,Sal,Rol,Activo FROM dbo.Usuario WHERE NombreUsuario=@NombreUsuario; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Listar AS
 BEGIN SET NOCOUNT ON; SELECT Id,NombreUsuario,Rol,Activo FROM dbo.Usuario ORDER BY NombreUsuario; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Insertar
 @NombreUsuario nvarchar(50),@Hash varbinary(32),@Sal varbinary(16),@Rol nvarchar(25),@Activo bit,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON;
 INSERT dbo.Usuario(NombreUsuario,Hash,Sal,Rol,Activo) VALUES(@NombreUsuario,@Hash,@Sal,@Rol,@Activo);
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY()); END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_AsignarRol @UsuarioId int,@Rol nvarchar(25),@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON;
 IF @Rol NOT IN(N'Administrador',N'Cliente',N'EncargadoStock',N'Tecnico') THROW 50001,N'Rol no válido.',1;
 IF @Rol<>N'Cliente' AND EXISTS(SELECT 1 FROM dbo.Cliente WHERE UsuarioId=@UsuarioId)
   THROW 50002,N'La cuenta tiene una ficha de cliente; debe conservar el rol Cliente.',1;
 UPDATE dbo.Usuario SET Rol=@Rol WHERE Id=@UsuarioId;
 SET @Resultado=CASE WHEN @@ROWCOUNT=1 THEN 1 ELSE 0 END; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Cliente_Insertar
 @UsuarioId int,@DniCuit nvarchar(13),@Nombre nvarchar(100),@Telefono nvarchar(30),@Email nvarchar(150),@AntecedenteNegativo bit,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON;
 IF NOT EXISTS(SELECT 1 FROM dbo.Usuario WHERE Id=@UsuarioId AND Rol=N'Cliente' AND Activo=1)
   THROW 50003,N'Seleccioná una cuenta activa con rol Cliente.',1;
 INSERT dbo.Cliente(UsuarioId,DniCuit,Nombre,Telefono,Email,AntecedenteNegativo) VALUES(@UsuarioId,@DniCuit,@Nombre,@Telefono,@Email,@AntecedenteNegativo);
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY()); END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Cliente_Buscar @ClienteId int AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.vCliente WHERE Id=@ClienteId; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Cliente_Listar @UsuarioId int=NULL AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.vCliente WHERE @UsuarioId IS NULL OR UsuarioId=@UsuarioId ORDER BY Nombre; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Seguro_ListarPorCliente @ClienteId int AS
 BEGIN SET NOCOUNT ON;
 SELECT s.*,c.UsuarioId,c.Nombre,c.DniCuit,c.Telefono,c.Email,c.AntecedenteNegativo,c.NombreUsuario,c.Rol,c.Activo
 FROM dbo.Seguro s JOIN dbo.vCliente c ON c.Id=s.ClienteId WHERE s.ClienteId=@ClienteId ORDER BY s.Id; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Seguro_Guardar
 @Id int,@ClienteId int,@Poliza nvarchar(50),@Aseguradora nvarchar(100),@Desde datetime2,@Hasta datetime2,@Cobertura decimal(18,2),@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 BEGIN TRY
 BEGIN TRANSACTION;
 IF @Hasta<=@Desde OR @Cobertura<=0 THROW 50004,N'Vigencia o cobertura no válida.',1;
 IF @Id=0 BEGIN
   INSERT dbo.Seguro(ClienteId,Poliza,Aseguradora,Desde,Hasta,Cobertura) VALUES(@ClienteId,@Poliza,@Aseguradora,@Desde,@Hasta,@Cobertura);
   SET @Resultado=CONVERT(int,SCOPE_IDENTITY());
 END ELSE BEGIN
   DECLARE @Bloqueo int; SELECT @Bloqueo=Id FROM dbo.Seguro WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id;
   IF @Bloqueo IS NULL THROW 50005,N'La póliza no existe.',1;
   IF EXISTS(SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id=re.ReservaId WHERE re.SeguroId=@Id AND r.Estado IN(N'Firme',N'Entregada',N'ConIncidencia'))
     THROW 50006,N'La póliza tiene alquileres pendientes; conservá sus condiciones y registrá otra póliza.',1;
   UPDATE dbo.Seguro SET ClienteId=@ClienteId,Poliza=@Poliza,Aseguradora=@Aseguradora,Desde=@Desde,Hasta=@Hasta,Cobertura=@Cobertura WHERE Id=@Id;
   SET @Resultado=@Id;
 END;
 COMMIT; END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_Listar AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.vEquipo ORDER BY CodigoInventario; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_Disponibles @Desde datetime2,@Hasta datetime2 AS
 BEGIN SET NOCOUNT ON; SELECT e.* FROM dbo.vEquipo e JOIN dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=e.Id ORDER BY e.CodigoInventario; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_Insertar
 @SeguroId int=NULL,@CodigoInventario nvarchar(30),@Serie nvarchar(80),@Categoria nvarchar(50),@Marca nvarchar(50),@Modelo nvarchar(80),
 @Descripcion nvarchar(300),@Estado nvarchar(25),@TarifaDiaria decimal(18,2),@ValorReposicion decimal(18,2),@DiasReacondicionamiento int,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON;
 IF @Estado NOT IN(N'Disponible',N'Baja') THROW 50007,N'Estado no válido para alta de stock.',1;
 INSERT dbo.Equipo(SeguroId,CodigoInventario,Serie,Categoria,Marca,Modelo,Descripcion,Estado,TarifaDiaria,ValorReposicion,DiasReacondicionamiento)
 VALUES(@SeguroId,@CodigoInventario,@Serie,@Categoria,@Marca,@Modelo,@Descripcion,@Estado,@TarifaDiaria,@ValorReposicion,@DiasReacondicionamiento);
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY()); END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_Actualizar
 @Id int,@SeguroId int=NULL,@CodigoInventario nvarchar(30),@Serie nvarchar(80),@Categoria nvarchar(50),@Marca nvarchar(50),@Modelo nvarchar(80),
 @Descripcion nvarchar(300),@Estado nvarchar(25),@TarifaDiaria decimal(18,2),@ValorReposicion decimal(18,2),@DiasReacondicionamiento int,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 BEGIN TRY BEGIN TRANSACTION;
 DECLARE @EstadoActual nvarchar(25);
 SELECT @EstadoActual=Estado FROM dbo.Equipo WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id;
 IF @Estado NOT IN(N'Disponible',N'Baja') THROW 50008,N'Estado no válido para mantenimiento de stock.',1;
 IF @EstadoActual IN(N'Alquilado',N'ConIncidencia') THROW 50009,N'La unidad está fuera de depósito. Su estado se cambia desde entrega/devolución.',1;
 IF @Estado=N'Baja' AND EXISTS(SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id=re.ReservaId WHERE re.EquipoId=@Id AND r.Estado IN(N'Firme',N'Entregada',N'ConIncidencia'))
   THROW 50010,N'La unidad tiene compromisos pendientes y no puede darse de baja.',1;
 UPDATE dbo.Equipo SET SeguroId=@SeguroId,CodigoInventario=@CodigoInventario,Serie=@Serie,Categoria=@Categoria,Marca=@Marca,Modelo=@Modelo,
 Descripcion=@Descripcion,Estado=@Estado,TarifaDiaria=@TarifaDiaria,ValorReposicion=@ValorReposicion,DiasReacondicionamiento=@DiasReacondicionamiento WHERE Id=@Id;
 SET @Resultado=CASE WHEN @@ROWCOUNT=1 THEN 1 ELSE 0 END;
 COMMIT; END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Buscar @ReservaId int AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.vReserva WHERE Id=@ReservaId ORDER BY Id,EquipoId; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Listar @ClienteId int=NULL AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.vReserva WHERE @ClienteId IS NULL OR ClienteId=@ClienteId ORDER BY Id,EquipoId; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Insertar
 @UsuarioId int,@ClienteId int,@Desde datetime2,@Hasta datetime2,@Importe decimal(18,2),@Sena decimal(18,2),@Garantia decimal(18,2),
 @PorcentajeSena decimal(5,4),@PorcentajeGarantia decimal(5,4),@Equipos dbo.ReservaEquipoEntrada READONLY,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
 BEGIN TRY BEGIN TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM dbo.Cliente c JOIN dbo.Usuario u ON u.Id=c.UsuarioId
   WHERE c.Id=@ClienteId AND c.UsuarioId=@UsuarioId AND u.Activo=1 AND u.Rol=N'Cliente')
   THROW 50024,N'La solicitud debe pertenecer a una cuenta de cliente activa.',1;
 IF @Hasta<=@Desde OR @Hasta>CONVERT(datetime2,'9998-01-01') OR NOT EXISTS(SELECT 1 FROM @Equipos)
   THROW 50025,N'Elegí equipos y un período válido.',1;
 IF (SELECT COUNT(*) FROM @Equipos)<>(SELECT COUNT(*) FROM @Equipos x JOIN dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=x.EquipoId)
   THROW 50026,N'Una unidad ya no está disponible. Volvé a consultar.',1;
 DECLARE @Dias decimal(18,0)=CEILING((CONVERT(decimal(28,0),DATEDIFF_BIG(SECOND,@Desde,@Hasta))*10000000+(DATEPART(NANOSECOND,@Hasta)-DATEPART(NANOSECOND,@Desde))/100)/864000000000.0);
 DECLARE @Total decimal(18,2);
 SELECT @Total=ROUND(SUM(e.TarifaDiaria)*@Dias,2) FROM dbo.Equipo e JOIN @Equipos x ON x.EquipoId=e.Id;
 IF @Importe<>@Total THROW 50027,N'Cambió la tarifa: volvé a cotizar antes de enviar.',1;
 INSERT dbo.Reserva(ClienteId,Desde,Hasta,Importe,Sena,Garantia,Estado)
 VALUES(@ClienteId,@Desde,@Hasta,@Total,0,0,N'Pendiente');
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY());
 INSERT dbo.ReservaEquipo(ReservaId,EquipoId,SeguroId,CoberturaSeguro,TarifaDiaria,ValorReposicion,DiasReacondicionamiento)
 SELECT @Resultado,e.Id,s.Id,ISNULL(s.Cobertura,0),e.TarifaDiaria,e.ValorReposicion,e.DiasReacondicionamiento
 FROM dbo.Equipo e JOIN @Equipos x ON x.EquipoId=e.Id LEFT JOIN dbo.Seguro s ON s.Id=e.SeguroId AND s.ClienteId=@ClienteId;
 COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Confirmar
 @ReservaId int, @ClienteId int,@Desde datetime2,@Hasta datetime2,@Importe decimal(18,2),@Sena decimal(18,2),@Garantia decimal(18,2),
 @PorcentajeSena decimal(5,4),@PorcentajeGarantia decimal(5,4),@Equipos dbo.ReservaEquipoEntrada READONLY,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
 BEGIN TRY BEGIN TRANSACTION;
 DECLARE @EstadoSolicitud nvarchar(25),@ClienteSolicitud int,@DesdeSolicitud datetime2,@HastaSolicitud datetime2;
 SELECT @EstadoSolicitud=Estado,@ClienteSolicitud=ClienteId,@DesdeSolicitud=Desde,@HastaSolicitud=Hasta
 FROM dbo.Reserva WITH(UPDLOCK,HOLDLOCK) WHERE Id=@ReservaId;
 IF @EstadoSolicitud IS NULL OR @EstadoSolicitud<>N'Pendiente' THROW 50021,N'La solicitud no existe o ya fue aceptada.',1;
 IF @ClienteSolicitud<>@ClienteId OR @DesdeSolicitud<>@Desde OR @HastaSolicitud<>@Hasta
   THROW 50022,N'La aprobación debe conservar el cliente y las fechas de la solicitud.',1;
 IF EXISTS(SELECT EquipoId FROM @Equipos EXCEPT SELECT EquipoId FROM dbo.ReservaEquipo WHERE ReservaId=@ReservaId)
 OR EXISTS(SELECT EquipoId FROM dbo.ReservaEquipo WHERE ReservaId=@ReservaId EXCEPT SELECT EquipoId FROM @Equipos)
   THROW 50023,N'La aprobación debe conservar los equipos solicitados.',1;
 IF @Hasta<=@Desde OR @Hasta>CONVERT(datetime2,'9998-01-01') OR NOT EXISTS(SELECT 1 FROM @Equipos)
   THROW 50011,N'Completá fechas y unidades de la reserva.',1;
 IF @PorcentajeSena NOT BETWEEN 0 AND 1 OR @PorcentajeGarantia NOT BETWEEN 0 AND 1 THROW 50012,N'Porcentajes no válidos.',1;
 IF NOT EXISTS(SELECT 1 FROM dbo.Cliente c WITH(HOLDLOCK) JOIN dbo.Usuario u WITH(HOLDLOCK) ON u.Id=c.UsuarioId
   WHERE c.Id=@ClienteId AND c.AntecedenteNegativo=0 AND u.Activo=1 AND u.Rol=N'Cliente')
   THROW 50013,N'El cliente no está habilitado.',1;
 -- Every confirmation locks physical units before testing the date range.
 DECLARE @Bloqueo bigint;
 SELECT @Bloqueo=SUM(CONVERT(bigint,e.Id)) FROM dbo.Equipo e WITH(UPDLOCK,HOLDLOCK) JOIN @Equipos x ON x.EquipoId=e.Id;
 IF (SELECT COUNT(*) FROM @Equipos)<>(SELECT COUNT(*) FROM dbo.Equipo e JOIN @Equipos x ON x.EquipoId=e.Id)
   THROW 50014,N'Una unidad no existe.',1;
 IF EXISTS(SELECT 1 FROM @Equipos x JOIN dbo.Equipo e ON e.Id=x.EquipoId LEFT JOIN dbo.Seguro s WITH(HOLDLOCK) ON s.Id=e.SeguroId
   WHERE s.Id IS NULL OR s.ClienteId<>@ClienteId OR s.Desde>@Desde OR s.Hasta<@Hasta OR s.Cobertura<=0)
   THROW 50015,N'Cada unidad debe tener Seguro del cliente vigente para todo el alquiler.',1;
 IF EXISTS(SELECT 1 FROM @Equipos x JOIN dbo.Equipo e ON e.Id=x.EquipoId JOIN dbo.Seguro s ON s.Id=e.SeguroId
   WHERE x.TarifaDiaria<>e.TarifaDiaria OR x.ValorReposicion<>e.ValorReposicion OR x.DiasReacondicionamiento<>e.DiasReacondicionamiento
   OR x.SeguroId IS NULL OR x.SeguroId<>e.SeguroId OR x.CoberturaSeguro<>s.Cobertura)
   THROW 50016,N'Cambió el catálogo o la cobertura: volvé a cotizar.',1;
 IF (SELECT COUNT(*) FROM @Equipos)<>(SELECT COUNT(*) FROM @Equipos x JOIN dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=x.EquipoId)
   THROW 50017,N'Una unidad ya está ocupada o bloqueada, incluido el reacondicionamiento.',1;
 DECLARE @Dias decimal(18,0)=CEILING((CONVERT(decimal(28,0),DATEDIFF_BIG(SECOND,@Desde,@Hasta))*10000000+(DATEPART(NANOSECOND,@Hasta)-DATEPART(NANOSECOND,@Desde))/100)/864000000000.0);
 DECLARE @Total decimal(18,2),@Reposicion decimal(18,2);
 SELECT @Total=ROUND(SUM(e.TarifaDiaria)*@Dias,2),@Reposicion=SUM(e.ValorReposicion) FROM dbo.Equipo e JOIN @Equipos x ON x.EquipoId=e.Id;
 IF @Importe<>@Total OR @Sena<>ROUND(@Total*@PorcentajeSena,2) OR @Garantia<>ROUND(@Reposicion*@PorcentajeGarantia,2)
   THROW 50018,N'Importe, seña o garantía no coinciden con la cotización actual.',1;
 UPDATE dbo.Reserva SET Importe=@Importe,Sena=@Sena,Garantia=@Garantia,Estado=N'Firme' WHERE Id=@ReservaId;
 UPDATE re SET SeguroId=e.SeguroId,CoberturaSeguro=s.Cobertura,TarifaDiaria=e.TarifaDiaria,
 ValorReposicion=e.ValorReposicion,DiasReacondicionamiento=e.DiasReacondicionamiento
 FROM dbo.ReservaEquipo re JOIN dbo.Equipo e ON e.Id=re.EquipoId JOIN dbo.Seguro s ON s.Id=e.SeguroId
 WHERE re.ReservaId=@ReservaId;
 SET @Resultado=1;
 COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_RegistrarEntrega @ReservaId int,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON; SET @Resultado=0;
 BEGIN TRY BEGIN TRANSACTION;
 DECLARE @Estado nvarchar(25);
 SELECT @Estado=Estado FROM dbo.Reserva WITH(UPDLOCK,HOLDLOCK) WHERE Id=@ReservaId;
 IF @Estado=N'Firme' BEGIN
 DECLARE @Bloqueo bigint;
 SELECT @Bloqueo=SUM(CONVERT(bigint,e.Id)) FROM dbo.Equipo e WITH(UPDLOCK,HOLDLOCK) JOIN dbo.ReservaEquipo re ON re.EquipoId=e.Id WHERE re.ReservaId=@ReservaId;
 IF EXISTS(SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Equipo e ON e.Id=re.EquipoId WHERE re.ReservaId=@ReservaId AND e.Estado<>N'Disponible')
   THROW 50019,N'Una unidad no está disponible físicamente para entrega.',1;
 IF EXISTS(SELECT 1 FROM dbo.ReservaEquipo actual JOIN dbo.ReservaEquipo otra ON otra.EquipoId=actual.EquipoId
   JOIN dbo.Reserva r ON r.Id=otra.ReservaId WHERE actual.ReservaId=@ReservaId AND r.Estado=N'Entregada')
   THROW 50020,N'Una unidad sigue en otro alquiler.',1;
 UPDATE re SET EstadoEntrega=e.Estado FROM dbo.ReservaEquipo re JOIN dbo.Equipo e ON e.Id=re.EquipoId WHERE re.ReservaId=@ReservaId;
 UPDATE dbo.Reserva SET Estado=N'Entregada',ContratoFirmado=1,NumeroContrato=N'C-'+CONVERT(nvarchar(20),Id),NumeroRemito=N'R-'+CONVERT(nvarchar(20),Id) WHERE Id=@ReservaId;
 UPDATE e SET Estado=N'Alquilado' FROM dbo.Equipo e JOIN dbo.ReservaEquipo re ON re.EquipoId=e.Id WHERE re.ReservaId=@ReservaId;
 SET @Resultado=1; END;
 COMMIT; END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO

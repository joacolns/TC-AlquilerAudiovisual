-- Base completa de TC-AlquilerAudiovisual: esquema, procedimientos y datos actuales.
-- Para restaurar sobre una base existente, cambie @RecrearBaseExistente a 1.
-- La restauracion elimina permanentemente la base existente con el mismo nombre.
USE [master];
GO
DECLARE @RecrearBaseExistente bit = 0;
IF DB_ID(N'TC-AlquilerAudiovisual') IS NOT NULL
BEGIN
    IF @RecrearBaseExistente = 0 THROW 51000, N'La base TC-AlquilerAudiovisual ya existe. Revise la variable @RecrearBaseExistente antes de continuar.', 1;
    ALTER DATABASE [TC-AlquilerAudiovisual] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [TC-AlquilerAudiovisual];
END;
IF DB_ID(N'TC-AlquilerAudiovisual') IS NULL CREATE DATABASE [TC-AlquilerAudiovisual];
GO
-- ===== Fuente: 01_Base.sql =====
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET ARITHABORT ON;
SET NUMERIC_ROUNDABORT OFF;
USE master;
GO
IF DB_ID(N'TC-AlquilerAudiovisual') IS NULL CREATE DATABASE [TC-AlquilerAudiovisual];
GO
USE [TC-AlquilerAudiovisual];
GO
IF OBJECT_ID(N'dbo.Usuario', N'U') IS NULL
CREATE TABLE dbo.Usuario (
 Id int IDENTITY PRIMARY KEY, NombreUsuario nvarchar(50) NOT NULL UNIQUE,
 Hash varbinary(32) NOT NULL CHECK(DATALENGTH(Hash)=32), Sal varbinary(16) NOT NULL CHECK(DATALENGTH(Sal)=16),
 Rol nvarchar(25) NOT NULL CHECK(Rol IN(N'Cliente',N'Administrador',N'Tecnico',N'EncargadoStock')),
 Activo bit NOT NULL
);
IF OBJECT_ID(N'dbo.Cliente', N'U') IS NULL
CREATE TABLE dbo.Cliente (
 Id int IDENTITY PRIMARY KEY, UsuarioId int NOT NULL UNIQUE REFERENCES dbo.Usuario(Id),
 DniCuit nvarchar(13) NOT NULL UNIQUE, Nombre nvarchar(100) NOT NULL,
 Telefono nvarchar(30) NOT NULL, Email nvarchar(150) NOT NULL, AntecedenteNegativo bit NOT NULL
);
IF OBJECT_ID(N'dbo.Seguro', N'U') IS NULL
CREATE TABLE dbo.Seguro (
 Id int IDENTITY PRIMARY KEY, ClienteId int NOT NULL REFERENCES dbo.Cliente(Id),
 Poliza nvarchar(50) NOT NULL, Aseguradora nvarchar(100) NOT NULL,
 Desde datetime2 NOT NULL, Hasta datetime2 NOT NULL, Cobertura decimal(18,2) NOT NULL CHECK(Cobertura>0),
 CHECK(Hasta>Desde), UNIQUE(ClienteId,Poliza,Aseguradora)
);
IF OBJECT_ID(N'dbo.Equipo', N'U') IS NULL
CREATE TABLE dbo.Equipo (
 Id int IDENTITY PRIMARY KEY, SeguroId int NULL REFERENCES dbo.Seguro(Id),
 CodigoInventario nvarchar(30) NOT NULL UNIQUE, Serie nvarchar(80) NOT NULL,
 Categoria nvarchar(50) NOT NULL, Marca nvarchar(50) NOT NULL, Modelo nvarchar(80) NOT NULL,
 Descripcion nvarchar(300) NOT NULL,
 Estado nvarchar(25) NOT NULL CHECK(Estado IN(N'Disponible',N'Alquilado',N'ConIncidencia',N'Baja')),
 TarifaDiaria decimal(18,2) NOT NULL CHECK(TarifaDiaria>0), ValorReposicion decimal(18,2) NOT NULL CHECK(ValorReposicion>0),
 DiasReacondicionamiento int NOT NULL CHECK(DiasReacondicionamiento BETWEEN 0 AND 365)
);
IF OBJECT_ID(N'dbo.Reserva', N'U') IS NULL
CREATE TABLE dbo.Reserva (
 Id int IDENTITY PRIMARY KEY, ClienteId int NOT NULL REFERENCES dbo.Cliente(Id),
 Desde datetime2 NOT NULL, Hasta datetime2 NOT NULL, CHECK(Hasta>Desde),
 Importe decimal(18,2) NOT NULL CHECK(Importe>=0), Sena decimal(18,2) NOT NULL CHECK(Sena>=0),
 Garantia decimal(18,2) NOT NULL CHECK(Garantia>=0),
 Estado nvarchar(25) NOT NULL CHECK(Estado IN(N'Firme',N'Entregada',N'ConIncidencia',N'Cerrada')),
 NumeroContrato nvarchar(30) NULL, NumeroRemito nvarchar(30) NULL, ContratoFirmado bit NOT NULL DEFAULT 0
);
IF OBJECT_ID(N'dbo.ReservaEquipo', N'U') IS NULL
CREATE TABLE dbo.ReservaEquipo (
 ReservaId int NOT NULL REFERENCES dbo.Reserva(Id), EquipoId int NOT NULL REFERENCES dbo.Equipo(Id),
 SeguroId int NOT NULL REFERENCES dbo.Seguro(Id), CoberturaSeguro decimal(18,2) NOT NULL CHECK(CoberturaSeguro>0),
 TarifaDiaria decimal(18,2) NOT NULL CHECK(TarifaDiaria>0), ValorReposicion decimal(18,2) NOT NULL CHECK(ValorReposicion>0),
 DiasReacondicionamiento int NOT NULL CHECK(DiasReacondicionamiento BETWEEN 0 AND 365), EstadoEntrega nvarchar(25) NULL,
 PRIMARY KEY(ReservaId,EquipoId)
);
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name=N'IX_ReservaEquipo_Equipo' AND object_id=OBJECT_ID('dbo.ReservaEquipo'))
 CREATE INDEX IX_ReservaEquipo_Equipo ON dbo.ReservaEquipo(EquipoId,ReservaId);
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name=N'UX_Reserva_Contrato' AND object_id=OBJECT_ID('dbo.Reserva'))
 CREATE UNIQUE INDEX UX_Reserva_Contrato ON dbo.Reserva(NumeroContrato) WHERE NumeroContrato IS NOT NULL;
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name=N'UX_Reserva_Remito' AND object_id=OBJECT_ID('dbo.Reserva'))
 CREATE UNIQUE INDEX UX_Reserva_Remito ON dbo.Reserva(NumeroRemito) WHERE NumeroRemito IS NOT NULL;
GO
IF TYPE_ID(N'dbo.ReservaEquipoEntrada') IS NULL
 EXEC(N'CREATE TYPE dbo.ReservaEquipoEntrada AS TABLE(EquipoId int PRIMARY KEY, TarifaDiaria decimal(18,2), ValorReposicion decimal(18,2), DiasReacondicionamiento int, SeguroId int NULL, CoberturaSeguro decimal(18,2))');
GO
-- Read views only hydrate properties. No credentials are exposed in these joins.
CREATE OR ALTER VIEW dbo.vCliente AS
 SELECT c.*,u.NombreUsuario,u.Rol,u.Activo FROM dbo.Cliente c JOIN dbo.Usuario u ON u.Id=c.UsuarioId;
GO
CREATE OR ALTER VIEW dbo.vEquipo AS
 SELECT e.*,s.ClienteId SeguroClienteId,s.Poliza,s.Aseguradora,s.Desde SeguroDesde,s.Hasta SeguroHasta,
 s.Cobertura CoberturaSeguro,c.UsuarioId,c.Nombre,c.DniCuit,c.Telefono,c.Email,c.AntecedenteNegativo,u.NombreUsuario,u.Rol,u.Activo
 FROM dbo.Equipo e LEFT JOIN dbo.Seguro s ON s.Id=e.SeguroId
 LEFT JOIN dbo.Cliente c ON c.Id=s.ClienteId LEFT JOIN dbo.Usuario u ON u.Id=c.UsuarioId;
GO
CREATE OR ALTER VIEW dbo.vReserva AS
 SELECT r.*,c.Nombre ClienteNombre,c.DniCuit ClienteDniCuit,c.Telefono ClienteTelefono,c.Email ClienteEmail,
 c.AntecedenteNegativo ClienteAntecedente,c.UsuarioId ReservaUsuarioId,u.NombreUsuario ReservaNombreUsuario,u.Rol ReservaRol,u.Activo ReservaActivo,
 re.EquipoId,e.CodigoInventario,e.Serie,e.Categoria,e.Marca,e.Modelo,e.Descripcion,e.Estado EstadoEquipo,
 re.TarifaDiaria,re.ValorReposicion,re.DiasReacondicionamiento,s.Id SeguroId,
 CASE WHEN s.Id IS NULL THEN CONVERT(decimal(18,2),0) ELSE re.CoberturaSeguro END CoberturaSeguro,
 s.ClienteId SeguroClienteId,s.Poliza,s.Aseguradora,s.Desde SeguroDesde,s.Hasta SeguroHasta,
 sc.UsuarioId,sc.Nombre,sc.DniCuit,sc.Telefono,sc.Email,sc.AntecedenteNegativo,su.NombreUsuario,su.Rol,su.Activo
 FROM dbo.Reserva r JOIN dbo.Cliente c ON c.Id=r.ClienteId JOIN dbo.Usuario u ON u.Id=c.UsuarioId
 JOIN dbo.ReservaEquipo re ON re.ReservaId=r.Id JOIN dbo.Equipo e ON e.Id=re.EquipoId
 LEFT JOIN dbo.Seguro s ON s.Id=re.SeguroId AND s.ClienteId=r.ClienteId
 LEFT JOIN dbo.Cliente sc ON sc.Id=s.ClienteId LEFT JOIN dbo.Usuario su ON su.Id=sc.UsuarioId;
GO
CREATE OR ALTER FUNCTION dbo.EquiposDisponibles(@Desde datetime2,@Hasta datetime2)
RETURNS TABLE AS RETURN (
 SELECT e.Id FROM dbo.Equipo e
 WHERE @Hasta>@Desde AND e.Estado IN(N'Disponible',N'Alquilado')
 AND NOT EXISTS(SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id=re.ReservaId
   WHERE re.EquipoId=e.Id AND r.Estado=N'Entregada' AND r.Hasta<=SYSDATETIME())
 AND NOT EXISTS(SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id=re.ReservaId
   WHERE re.EquipoId=e.Id AND r.Estado IN(N'Firme',N'Entregada')
   AND @Desde<DATEADD(DAY,re.DiasReacondicionamiento,r.Hasta)
   AND r.Desde<DATEADD(DAY,e.DiasReacondicionamiento,@Hasta))
);
GO
-- ===== Fuente: 02_Solicitudes.sql =====
-- Compatible migration: existing firm reservations and their snapshots are preserved.
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET ARITHABORT ON;
SET NUMERIC_ROUNDABORT OFF;
USE [TC-AlquilerAudiovisual];
GO
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.Reserva') AND name=N'CK_Reserva_EstadoSolicitud')
BEGIN
 DECLARE @ddlEstado nvarchar(max)=N'';
 SELECT @ddlEstado=@ddlEstado+N'ALTER TABLE dbo.Reserva DROP CONSTRAINT '+QUOTENAME(name)+N';'
 FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.Reserva')
 AND parent_column_id=COLUMNPROPERTY(OBJECT_ID(N'dbo.Reserva'),N'Estado',N'ColumnId');
 IF @ddlEstado<>N'' EXEC sys.sp_executesql @ddlEstado;
 ALTER TABLE dbo.Reserva WITH CHECK ADD CONSTRAINT CK_Reserva_EstadoSolicitud
 CHECK(Estado IN(N'Pendiente',N'Rechazada',N'Aceptada',N'Firme',N'Entregada',N'ConIncidencia',N'Cerrada'));
END;
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.ReservaEquipo') AND name=N'CK_ReservaEquipo_CoberturaSolicitud')
BEGIN
 DECLARE @ddlCobertura nvarchar(max)=N'';
 SELECT @ddlCobertura=@ddlCobertura+N'ALTER TABLE dbo.ReservaEquipo DROP CONSTRAINT '+QUOTENAME(name)+N';'
 FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.ReservaEquipo')
 AND parent_column_id=COLUMNPROPERTY(OBJECT_ID(N'dbo.ReservaEquipo'),N'CoberturaSeguro',N'ColumnId');
 IF @ddlCobertura<>N'' EXEC sys.sp_executesql @ddlCobertura;
 ALTER TABLE dbo.ReservaEquipo WITH CHECK ADD CONSTRAINT CK_ReservaEquipo_CoberturaSolicitud CHECK(CoberturaSeguro>=0);
END;
IF EXISTS(SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID(N'dbo.ReservaEquipo') AND name=N'SeguroId' AND is_nullable=0)
 ALTER TABLE dbo.ReservaEquipo ALTER COLUMN SeguroId int NULL;
GO
-- ===== Fuente: 04_Devoluciones.sql =====
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET ARITHABORT ON;
SET NUMERIC_ROUNDABORT OFF;
USE [TC-AlquilerAudiovisual];
GO
IF OBJECT_ID(N'dbo.Devolucion', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Devolucion
	(
		Id int IDENTITY PRIMARY KEY,
		ReservaId int NOT NULL UNIQUE REFERENCES dbo.Reserva(Id),
		Fecha datetime2 NOT NULL,
		Conforme bit NOT NULL,
		ClientePresente bit NOT NULL,
		Finalizada bit NOT NULL DEFAULT 0,
		Observaciones nvarchar(500) NOT NULL,
		GarantiaAplicada decimal(18,2) NOT NULL CHECK (GarantiaAplicada >= 0),
		GarantiaDevuelta decimal(18,2) NOT NULL CHECK (GarantiaDevuelta >= 0),
		SaldoPendiente decimal(18,2) NOT NULL CHECK (SaldoPendiente >= 0),
		CHECK (Conforme = 0 OR Finalizada = 1)
	);
END;
IF OBJECT_ID(N'dbo.Incidencia', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Incidencia
	(
		Id int IDENTITY PRIMARY KEY,
		DevolucionId int NOT NULL REFERENCES dbo.Devolucion(Id),
		EquipoId int NOT NULL REFERENCES dbo.Equipo(Id),
		Tipo nvarchar(25) NOT NULL CHECK (Tipo IN (N'Atraso', N'Faltante', N'DañoReparable', N'DañoTotal')),
		Descripcion nvarchar(500) NOT NULL,
		Cargo decimal(18,2) NOT NULL CHECK (Cargo >= 0),
		Estado nvarchar(25) NOT NULL CHECK (Estado IN (N'Abierta', N'Cerrada')),
		FechaAltaTecnica datetime2 NULL,
		UNIQUE (DevolucionId, EquipoId, Tipo),
		CHECK ((Estado = N'Abierta' AND FechaAltaTecnica IS NULL)
			OR (Estado = N'Cerrada' AND FechaAltaTecnica IS NOT NULL))
	);
	CREATE INDEX IX_Incidencia_EquipoEstado ON dbo.Incidencia(EquipoId, Estado);
END;
GO
CREATE OR ALTER FUNCTION dbo.EquiposDisponibles(@Desde datetime2, @Hasta datetime2)
RETURNS TABLE AS RETURN
(
	SELECT e.Id
	FROM dbo.Equipo e
	WHERE @Hasta > @Desde
		AND e.Estado IN (N'Disponible', N'Alquilado')
		AND NOT EXISTS
		(
			SELECT 1 FROM dbo.Incidencia i WHERE i.EquipoId = e.Id AND i.Estado = N'Abierta'
		)
		AND NOT EXISTS
		(
			SELECT 1
			FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id = re.ReservaId
			WHERE re.EquipoId = e.Id AND r.Estado = N'Entregada' AND r.Hasta <= SYSDATETIME()
		)
		AND NOT EXISTS
		(
			SELECT 1
			FROM dbo.ReservaEquipo re JOIN dbo.Devolucion d ON d.ReservaId = re.ReservaId
			WHERE re.EquipoId = e.Id AND d.Finalizada = 0
		)
		AND NOT EXISTS
		(
			SELECT 1
			FROM dbo.ReservaEquipo re
			JOIN dbo.Reserva r ON r.Id = re.ReservaId
			LEFT JOIN dbo.Devolucion d ON d.ReservaId = r.Id
			WHERE re.EquipoId = e.Id AND r.Estado IN (N'Aceptada', N'Firme', N'Entregada', N'ConIncidencia', N'Cerrada')
				-- Una devolución finalizada libera el período anterior. Las incidencias abiertas bloquean arriba.
				AND (d.Id IS NULL OR d.Finalizada = 0)
				AND @Desde < DATEADD(DAY, re.DiasReacondicionamiento,
					CASE WHEN d.Fecha > r.Hasta THEN d.Fecha ELSE r.Hasta END)
				AND r.Desde < DATEADD(DAY, e.DiasReacondicionamiento, @Hasta)
		)
);
GO

IF COL_LENGTH('dbo.Incidencia','CargoBase') IS NULL
 ALTER TABLE dbo.Incidencia ADD CargoBase decimal(18,2) NOT NULL CONSTRAINT DF_Incidencia_CargoBase DEFAULT 0 WITH VALUES;
IF COL_LENGTH('dbo.Incidencia','DescuentoSeguro') IS NULL
 ALTER TABLE dbo.Incidencia ADD DescuentoSeguro decimal(18,2) NOT NULL CONSTRAINT DF_Incidencia_DescuentoSeguro DEFAULT 0 WITH VALUES;
GO
-- Completar el desglose histórico sin recalcular el cargo ya registrado.
UPDATE dbo.Incidencia SET CargoBase = Cargo
WHERE CargoBase = 0 AND DescuentoSeguro = 0 AND Cargo > 0;
GO
-- ===== Fuente: 05_Seguros.sql =====
USE [TC-AlquilerAudiovisual];
GO
IF COL_LENGTH('dbo.Seguro','Tipo') IS NULL
 ALTER TABLE dbo.Seguro ADD Tipo nvarchar(25) NOT NULL CONSTRAINT DF_Seguro_Tipo DEFAULT N'Basico' WITH VALUES;
IF COL_LENGTH('dbo.Seguro','Detalle') IS NULL
 ALTER TABLE dbo.Seguro ADD Detalle nvarchar(500) NOT NULL CONSTRAINT DF_Seguro_Detalle
 DEFAULT N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.' WITH VALUES;
IF COL_LENGTH('dbo.ReservaEquipo','TipoSeguro') IS NULL
 ALTER TABLE dbo.ReservaEquipo ADD TipoSeguro nvarchar(25) NULL;
IF COL_LENGTH('dbo.ReservaEquipo','DetalleSeguro') IS NULL
 ALTER TABLE dbo.ReservaEquipo ADD DetalleSeguro nvarchar(500) NULL;
IF COL_LENGTH('dbo.ReservaEquipo','PolizaSeguro') IS NULL
 ALTER TABLE dbo.ReservaEquipo ADD PolizaSeguro nvarchar(50) NULL;
IF COL_LENGTH('dbo.ReservaEquipo','AseguradoraSeguro') IS NULL
 ALTER TABLE dbo.ReservaEquipo ADD AseguradoraSeguro nvarchar(100) NULL;
IF COL_LENGTH('dbo.ReservaEquipo','DesdeSeguro') IS NULL
 ALTER TABLE dbo.ReservaEquipo ADD DesdeSeguro datetime2 NULL;
IF COL_LENGTH('dbo.ReservaEquipo','HastaSeguro') IS NULL
 ALTER TABLE dbo.ReservaEquipo ADD HastaSeguro datetime2 NULL;
GO
UPDATE re SET TipoSeguro=s.Tipo,DetalleSeguro=s.Detalle
FROM dbo.ReservaEquipo re JOIN dbo.Seguro s ON s.Id=re.SeguroId WHERE re.TipoSeguro IS NULL;
UPDATE re SET PolizaSeguro=s.Poliza,AseguradoraSeguro=s.Aseguradora,DesdeSeguro=s.Desde,HastaSeguro=s.Hasta
FROM dbo.ReservaEquipo re JOIN dbo.Seguro s ON s.Id=re.SeguroId WHERE re.DesdeSeguro IS NULL;
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE name='CK_Seguro_Tipo')
 ALTER TABLE dbo.Seguro ADD CONSTRAINT CK_Seguro_Tipo CHECK(Tipo IN(N'Basico',N'Intermedio',N'Completo'));
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE name='CK_Seguro_Detalle')
 ALTER TABLE dbo.Seguro ADD CONSTRAINT CK_Seguro_Detalle CHECK(LEN(LTRIM(RTRIM(Detalle)))>0);
GO
CREATE OR ALTER VIEW dbo.vEquipo AS
 SELECT e.*,s.ClienteId SeguroClienteId,s.Poliza,s.Aseguradora,s.Desde SeguroDesde,s.Hasta SeguroHasta,
 s.Tipo TipoSeguro,s.Detalle DetalleSeguro,s.Cobertura CoberturaSeguro,c.UsuarioId,c.Nombre,c.DniCuit,c.Telefono,c.Email,c.AntecedenteNegativo,u.NombreUsuario,u.Rol,u.Activo
 FROM dbo.Equipo e LEFT JOIN dbo.Seguro s ON s.Id=e.SeguroId
 LEFT JOIN dbo.Cliente c ON c.Id=s.ClienteId LEFT JOIN dbo.Usuario u ON u.Id=c.UsuarioId;
GO
CREATE OR ALTER VIEW dbo.vReserva AS
 SELECT r.*,c.Nombre ClienteNombre,c.DniCuit ClienteDniCuit,c.Telefono ClienteTelefono,c.Email ClienteEmail,
 c.AntecedenteNegativo ClienteAntecedente,c.UsuarioId ReservaUsuarioId,u.NombreUsuario ReservaNombreUsuario,u.Rol ReservaRol,u.Activo ReservaActivo,
 re.EquipoId,e.CodigoInventario,e.Serie,e.Categoria,e.Marca,e.Modelo,e.Descripcion,e.Estado EstadoEquipo,
 re.TarifaDiaria,re.ValorReposicion,re.DiasReacondicionamiento,re.SeguroId,
 CASE WHEN re.SeguroId IS NULL THEN CONVERT(decimal(18,2),0) ELSE re.CoberturaSeguro END CoberturaSeguro,
 sc.Id SeguroClienteId,re.PolizaSeguro Poliza,re.AseguradoraSeguro Aseguradora,re.DesdeSeguro SeguroDesde,re.HastaSeguro SeguroHasta,
 re.TipoSeguro,re.DetalleSeguro,sc.UsuarioId,sc.Nombre,sc.DniCuit,sc.Telefono,sc.Email,sc.AntecedenteNegativo,su.NombreUsuario,su.Rol,su.Activo
 FROM dbo.Reserva r JOIN dbo.Cliente c ON c.Id=r.ClienteId JOIN dbo.Usuario u ON u.Id=c.UsuarioId
 JOIN dbo.ReservaEquipo re ON re.ReservaId=r.Id JOIN dbo.Equipo e ON e.Id=re.EquipoId
 LEFT JOIN dbo.Cliente sc ON sc.Id=r.ClienteId AND re.SeguroId IS NOT NULL LEFT JOIN dbo.Usuario su ON su.Id=sc.UsuarioId;
GO
-- ===== Fuente: 06_SeguroUsuario.sql =====
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
USE [TC-AlquilerAudiovisual];
GO
IF COL_LENGTH('dbo.Usuario','TipoSeguro') IS NULL
 ALTER TABLE dbo.Usuario ADD TipoSeguro nvarchar(25) NOT NULL CONSTRAINT DF_Usuario_TipoSeguro DEFAULT N'SinSeguro' WITH VALUES;
IF COL_LENGTH('dbo.Usuario','SeguroId') IS NULL
 ALTER TABLE dbo.Usuario ADD SeguroId int NULL;
GO
-- Adoptar las pólizas existentes una sola vez, sin alterar reservas pactadas.
IF NOT EXISTS(SELECT 1 FROM sys.foreign_keys WHERE name=N'FK_Usuario_Seguro')
BEGIN
 UPDATE u SET SeguroId=s.Id,TipoSeguro=s.Tipo
 FROM dbo.Usuario u JOIN dbo.Cliente c ON c.UsuarioId=u.Id
 CROSS APPLY (SELECT TOP (1) Id,Tipo FROM dbo.Seguro WHERE ClienteId=c.Id ORDER BY Id DESC) s
 WHERE u.Rol IN(N'Cliente',N'Administrador');
 ALTER TABLE dbo.Usuario ADD CONSTRAINT FK_Usuario_Seguro FOREIGN KEY(SeguroId) REFERENCES dbo.Seguro(Id);
END;
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE name=N'CK_Usuario_TipoSeguro')
 ALTER TABLE dbo.Usuario ADD CONSTRAINT CK_Usuario_TipoSeguro CHECK(TipoSeguro IN(N'SinSeguro',N'Basico',N'Intermedio',N'Completo'));
GO
CREATE OR ALTER VIEW dbo.vUsuario AS
 SELECT u.Id,u.NombreUsuario,u.Rol,u.Activo,u.TipoSeguro,u.SeguroId,
 s.ClienteId SeguroClienteId,s.Tipo SeguroTipo,s.Detalle SeguroDetalle,s.Poliza SeguroPoliza,
 s.Aseguradora SeguroAseguradora,s.Desde SeguroDesde,s.Hasta SeguroHasta,s.Cobertura SeguroCobertura,
 c.Nombre SeguroNombre,c.DniCuit SeguroDniCuit,c.Telefono SeguroTelefono,c.Email SeguroEmail,c.AntecedenteNegativo SeguroAntecedente
 FROM dbo.Usuario u LEFT JOIN dbo.Cliente c ON c.UsuarioId=u.Id
 LEFT JOIN dbo.Seguro s ON s.Id=u.SeguroId AND s.ClienteId=c.Id AND u.TipoSeguro<>N'SinSeguro';
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_ConfigurarSeguro
 @UsuarioId int,@TipoSeguro nvarchar(25),@Resultado int OUTPUT AS
BEGIN
 SET NOCOUNT ON;
 SET XACT_ABORT ON;
 SET @Resultado=0;
 BEGIN TRY
  BEGIN TRANSACTION;
  DECLARE @Rol nvarchar(25),@SeguroActual int,@TipoActual nvarchar(25),@ClienteId int;
  SELECT @Rol=Rol,@SeguroActual=SeguroId,@TipoActual=TipoSeguro FROM dbo.Usuario WITH(UPDLOCK,HOLDLOCK) WHERE Id=@UsuarioId;
  IF @Rol IS NULL THROW 50030,N'El usuario no existe.',1;
  IF @TipoSeguro IS NULL OR @TipoSeguro NOT IN(N'SinSeguro',N'Basico',N'Intermedio',N'Completo')
   THROW 50031,N'Elegí Sin seguro, Básico, Intermedio o Completo.',1;
  IF @Rol NOT IN(N'Cliente',N'Administrador') AND @TipoSeguro<>N'SinSeguro'
   THROW 50032,N'El seguro de alquiler corresponde a cuentas Cliente o Administrador.',1;
  SELECT @ClienteId=Id FROM dbo.Cliente WHERE UsuarioId=@UsuarioId;
  IF @TipoSeguro=N'SinSeguro' OR @ClienteId IS NULL
   UPDATE dbo.Usuario SET TipoSeguro=@TipoSeguro,SeguroId=NULL WHERE Id=@UsuarioId;
  ELSE IF @TipoActual=@TipoSeguro AND EXISTS(SELECT 1 FROM dbo.Seguro WHERE Id=@SeguroActual AND ClienteId=@ClienteId AND Tipo=@TipoSeguro)
   UPDATE dbo.Usuario SET TipoSeguro=@TipoSeguro WHERE Id=@UsuarioId;
  ELSE
  BEGIN
   DECLARE @SeguroId int,@Poliza nvarchar(50)=N'USUARIO-'+CONVERT(nvarchar(20),@UsuarioId),@Detalle nvarchar(500);
   IF @TipoSeguro=N'Basico'
    SET @Detalle=N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.';
   ELSE IF @TipoSeguro=N'Intermedio'
    SET @Detalle=N'Cubre el 50% del daño reparable o total hasta el tope por unidad. No cubre atraso ni faltantes.';
   ELSE
    SET @Detalle=N'Cubre el 80% de daños y faltantes hasta el tope por unidad. No cubre atrasos.';
   SELECT @SeguroId=Id FROM dbo.Seguro WITH(UPDLOCK,HOLDLOCK)
    WHERE ClienteId=@ClienteId AND Poliza=@Poliza AND Aseguradora=N'Seguro académico';
   IF @SeguroId IS NULL
   BEGIN
    INSERT dbo.Seguro(ClienteId,Poliza,Aseguradora,Desde,Hasta,Cobertura,Tipo,Detalle)
     VALUES(@ClienteId,@Poliza,N'Seguro académico',CONVERT(date,SYSDATETIME()),DATEADD(YEAR,2,CONVERT(date,SYSDATETIME())),500000,@TipoSeguro,@Detalle);
    SET @SeguroId=CONVERT(int,SCOPE_IDENTITY());
   END
   ELSE
    UPDATE dbo.Seguro SET Tipo=@TipoSeguro,Detalle=@Detalle WHERE Id=@SeguroId;
   UPDATE dbo.Usuario SET TipoSeguro=@TipoSeguro,SeguroId=@SeguroId WHERE Id=@UsuarioId;
  END;
  SET @Resultado=1;
  COMMIT;
 END TRY
 BEGIN CATCH
  IF @@TRANCOUNT>0 ROLLBACK;
  THROW;
 END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Seguro @UsuarioId int AS
BEGIN
 SET NOCOUNT ON;
 SELECT * FROM dbo.vUsuario WHERE Id=@UsuarioId AND Rol IN(N'Cliente',N'Administrador');
END;
GO
-- ===== Fuente: 07_AntecedentesRechazo.sql =====
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
-- ===== Fuente: 08_PagoCliente.sql =====
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
USE [TC-AlquilerAudiovisual];
GO
IF COL_LENGTH('dbo.Reserva','SenaRequerida') IS NULL
 ALTER TABLE dbo.Reserva ADD SenaRequerida decimal(18,2) NOT NULL CONSTRAINT DF_Reserva_SenaRequerida DEFAULT 0 WITH VALUES;
IF COL_LENGTH('dbo.Reserva','GarantiaRequerida') IS NULL
 ALTER TABLE dbo.Reserva ADD GarantiaRequerida decimal(18,2) NOT NULL CONSTRAINT DF_Reserva_GarantiaRequerida DEFAULT 0 WITH VALUES;
GO
-- Recuperar importes pactados de reservas anteriores, sin modificar sus pagos.
UPDATE dbo.Reserva SET SenaRequerida=Sena
 WHERE Estado IN(N'Firme',N'Entregada',N'ConIncidencia',N'Cerrada') AND SenaRequerida=0 AND Sena>0;
UPDATE dbo.Reserva SET GarantiaRequerida=Garantia
 WHERE Estado IN(N'Firme',N'Entregada',N'ConIncidencia',N'Cerrada') AND GarantiaRequerida=0 AND Garantia>0;
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE name=N'CK_Reserva_ImportesRequeridos')
 ALTER TABLE dbo.Reserva WITH CHECK ADD CONSTRAINT CK_Reserva_ImportesRequeridos
 CHECK(SenaRequerida>=0 AND GarantiaRequerida>=0);
EXEC sys.sp_refreshview N'dbo.vReserva';
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Pagar @ReservaId int,@UsuarioId int,@Resultado int OUTPUT AS
BEGIN
 SET NOCOUNT ON;
 SET XACT_ABORT ON;
 SET @Resultado=0;
 BEGIN TRY
  BEGIN TRANSACTION;
  DECLARE @Estado nvarchar(25),@ClienteId int;
  SELECT @Estado=Estado,@ClienteId=ClienteId FROM dbo.Reserva WITH(UPDLOCK,HOLDLOCK) WHERE Id=@ReservaId;
  IF @Estado IS NULL OR @Estado<>N'Aceptada'
   THROW 50201,N'Solo se puede pagar una solicitud aceptada y pendiente de pago.',1;
  IF NOT EXISTS(SELECT 1 FROM dbo.Cliente c JOIN dbo.Usuario u ON u.Id=c.UsuarioId
   WHERE c.Id=@ClienteId AND u.Id=@UsuarioId AND u.Rol IN(N'Cliente',N'Administrador') AND u.Activo=1)
   THROW 50202,N'Solo el cliente de la solicitud puede pagarla.',1;
  -- El importe procede de lo aceptado por stock; no se toma desde el formulario.
  UPDATE dbo.Reserva SET Sena=SenaRequerida,Garantia=GarantiaRequerida,Estado=N'Firme' WHERE Id=@ReservaId;
  SET @Resultado=1;
  COMMIT;
 END TRY
 BEGIN CATCH
  IF @@TRANCOUNT>0 ROLLBACK;
  THROW;
 END CATCH;
END;
GO
-- ===== Fuente: 09_EliminarAntecedentes.sql =====
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
USE [TC-AlquilerAudiovisual];
GO
CREATE OR ALTER PROCEDURE dbo.sp_Cliente_EliminarAntecedentes
 @ClienteId int,
 @UsuarioId int,
 @Resultado int OUTPUT
AS
BEGIN
 SET NOCOUNT ON;
 SET XACT_ABORT ON;
 SET @Resultado=0;

 BEGIN TRY
  BEGIN TRANSACTION;

  IF NOT EXISTS
  (
   SELECT 1 FROM dbo.Usuario WITH (UPDLOCK,HOLDLOCK)
   WHERE Id=@UsuarioId AND Rol=N'Administrador' AND Activo=1
  )
   THROW 50001,N'Solo el administrador puede eliminar antecedentes.',1;

  IF EXISTS(SELECT 1 FROM dbo.Cliente WITH (UPDLOCK,HOLDLOCK) WHERE Id=@ClienteId)
  BEGIN
   -- Mantener las incidencias, cargos y reparaciones del alquiler.
   UPDATE i SET MostrarEnAntecedentes=0
   FROM dbo.Incidencia i
   JOIN dbo.Devolucion d ON d.Id=i.DevolucionId
   JOIN dbo.Reserva r ON r.Id=d.ReservaId
   WHERE r.ClienteId=@ClienteId AND i.MostrarEnAntecedentes=1;

   UPDATE dbo.Cliente SET AntecedenteNegativo=0 WHERE Id=@ClienteId;
   SET @Resultado=1;
  END;

  COMMIT TRANSACTION;
 END TRY
 BEGIN CATCH
  IF @@TRANCOUNT>0 ROLLBACK TRANSACTION;
  THROW;
 END CATCH;
END;
GO
-- ===== Fuente: 03_StoredProcedures/N01.sql =====
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
 BEGIN SET NOCOUNT ON; SELECT v.*,u.Hash,u.Sal FROM dbo.vUsuario v JOIN dbo.Usuario u ON u.Id=v.Id WHERE v.NombreUsuario=@NombreUsuario; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Listar AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.vUsuario ORDER BY NombreUsuario; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_CambiarClave
 @UsuarioId int,@Hash varbinary(32),@Sal varbinary(16),@Resultado int OUTPUT AS
BEGIN
	SET NOCOUNT ON;
	IF @Hash IS NULL OR DATALENGTH(@Hash)<>32 OR @Sal IS NULL OR DATALENGTH(@Sal)<>16
		THROW 50029,N'Hash o sal de contraseña no válidos.',1;
	SET @Resultado=0;
	UPDATE dbo.Usuario SET Hash=@Hash,Sal=@Sal WHERE Id=@UsuarioId;
	IF @@ROWCOUNT=1 SET @Resultado=1;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Insertar
 @NombreUsuario nvarchar(50),@Hash varbinary(32),@Sal varbinary(16),@Rol nvarchar(25),@Activo bit,@Resultado int OUTPUT,@TipoSeguro nvarchar(25)=N'SinSeguro' AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 BEGIN TRY
 BEGIN TRANSACTION;
 INSERT dbo.Usuario(NombreUsuario,Hash,Sal,Rol,Activo,TipoSeguro) VALUES(@NombreUsuario,@Hash,@Sal,@Rol,@Activo,@TipoSeguro);
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY());
 DECLARE @SeguroResultado int;
 EXEC dbo.sp_Usuario_ConfigurarSeguro @Resultado,@TipoSeguro,@SeguroResultado OUTPUT;
 COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_AsignarRol @UsuarioId int,@Rol nvarchar(25),@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON;
 IF @Rol NOT IN(N'Administrador',N'Cliente',N'EncargadoStock',N'Tecnico') THROW 50001,N'Rol no válido.',1;
 IF @Rol NOT IN(N'Cliente',N'Administrador') AND EXISTS(SELECT 1 FROM dbo.Cliente WHERE UsuarioId=@UsuarioId)
   THROW 50002,N'La cuenta tiene una ficha de cliente; debe conservar el rol Cliente o Administrador.',1;
 UPDATE dbo.Usuario SET Rol=@Rol WHERE Id=@UsuarioId;
 SET @Resultado=CASE WHEN @@ROWCOUNT=1 THEN 1 ELSE 0 END;
 IF @Rol NOT IN(N'Cliente',N'Administrador') UPDATE dbo.Usuario SET TipoSeguro=N'SinSeguro',SeguroId=NULL WHERE Id=@UsuarioId;
 END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Cliente_Insertar
 @UsuarioId int,@DniCuit nvarchar(13),@Nombre nvarchar(100),@Telefono nvarchar(30),@Email nvarchar(150),@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 BEGIN TRY
 BEGIN TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM dbo.Usuario WHERE Id=@UsuarioId AND Rol IN(N'Cliente',N'Administrador') AND Activo=1)
   THROW 50003,N'Seleccioná una cuenta activa con rol Cliente o Administrador.',1;
 INSERT dbo.Cliente(UsuarioId,DniCuit,Nombre,Telefono,Email) VALUES(@UsuarioId,@DniCuit,@Nombre,@Telefono,@Email);
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY());
 DECLARE @TipoSeguro nvarchar(25),@SeguroResultado int;
 SELECT @TipoSeguro=TipoSeguro FROM dbo.Usuario WHERE Id=@UsuarioId;
 EXEC dbo.sp_Usuario_ConfigurarSeguro @UsuarioId,@TipoSeguro,@SeguroResultado OUTPUT;
 COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Cliente_Buscar @ClienteId int AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.vCliente WHERE Id=@ClienteId; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Cliente_Listar @UsuarioId int=NULL AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.vCliente WHERE @UsuarioId IS NULL OR UsuarioId=@UsuarioId ORDER BY Nombre; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Seguro_ListarPorCliente @ClienteId int AS
 BEGIN SET NOCOUNT ON;
 SELECT s.*,c.UsuarioId,c.Nombre,c.DniCuit,c.Telefono,c.Email,c.Antecedentes,c.NombreUsuario,c.Rol,c.Activo
 FROM dbo.Seguro s JOIN dbo.vCliente c ON c.Id=s.ClienteId WHERE s.ClienteId=@ClienteId ORDER BY s.Id; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Seguro_Guardar
 @Id int,@ClienteId int,@Poliza nvarchar(50),@Aseguradora nvarchar(100),@Desde datetime2,@Hasta datetime2,@Cobertura decimal(18,2),@Tipo nvarchar(25),@Detalle nvarchar(500),@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 BEGIN TRY
 BEGIN TRANSACTION;
 DECLARE @SeguroUsuarioId int;
 SELECT @SeguroUsuarioId=u.Id FROM dbo.Usuario u WITH(UPDLOCK,HOLDLOCK) JOIN dbo.Cliente c ON c.UsuarioId=u.Id WHERE c.Id=@ClienteId;
 IF @Tipo IS NULL OR @Tipo NOT IN(N'Basico',N'Intermedio',N'Completo') OR @Detalle IS NULL OR LEN(LTRIM(RTRIM(@Detalle)))=0 THROW 50028,N'Completá tipo y detalle de seguro.',1;
 IF @Hasta<=@Desde OR @Cobertura<=0 THROW 50004,N'Vigencia o cobertura no válida.',1;
 IF @Id=0 BEGIN
   INSERT dbo.Seguro(ClienteId,Poliza,Aseguradora,Desde,Hasta,Cobertura,Tipo,Detalle) VALUES(@ClienteId,@Poliza,@Aseguradora,@Desde,@Hasta,@Cobertura,@Tipo,@Detalle);
   SET @Resultado=CONVERT(int,SCOPE_IDENTITY());
 END ELSE BEGIN
   DECLARE @Bloqueo int; SELECT @Bloqueo=Id FROM dbo.Seguro WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id;
   IF @Bloqueo IS NULL THROW 50005,N'La póliza no existe.',1;
   UPDATE dbo.Seguro SET Tipo=@Tipo,Detalle=@Detalle,ClienteId=@ClienteId,Poliza=@Poliza,Aseguradora=@Aseguradora,Desde=@Desde,Hasta=@Hasta,Cobertura=@Cobertura WHERE Id=@Id;
   SET @Resultado=@Id;
 END;
 UPDATE dbo.Usuario SET TipoSeguro=N'SinSeguro',SeguroId=NULL WHERE SeguroId=@Resultado AND Id<>@SeguroUsuarioId;
 UPDATE dbo.Usuario SET TipoSeguro=@Tipo,SeguroId=@Resultado WHERE Id=@SeguroUsuarioId;
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
 IF @Estado=N'Baja' AND EXISTS(SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id=re.ReservaId WHERE re.EquipoId=@Id AND r.Estado IN(N'Aceptada',N'Firme',N'Entregada',N'ConIncidencia'))
   THROW 50010,N'La unidad tiene compromisos pendientes y no puede darse de baja.',1;
 UPDATE dbo.Equipo SET SeguroId=@SeguroId,CodigoInventario=@CodigoInventario,Serie=@Serie,Categoria=@Categoria,Marca=@Marca,Modelo=@Modelo,
 Descripcion=@Descripcion,Estado=@Estado,TarifaDiaria=@TarifaDiaria,ValorReposicion=@ValorReposicion,DiasReacondicionamiento=@DiasReacondicionamiento WHERE Id=@Id;
 SET @Resultado=CASE WHEN @@ROWCOUNT=1 THEN 1 ELSE 0 END;
 COMMIT; END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Buscar @ReservaId int AS
 BEGIN SET NOCOUNT ON; SELECT v.*,u.TipoSeguro ClienteTipoSeguro FROM dbo.vReserva v JOIN dbo.Usuario u ON u.Id=v.ReservaUsuarioId WHERE v.Id=@ReservaId ORDER BY v.Id,v.EquipoId; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Listar @ClienteId int=NULL AS
 BEGIN SET NOCOUNT ON; SELECT v.*,u.TipoSeguro ClienteTipoSeguro FROM dbo.vReserva v JOIN dbo.Usuario u ON u.Id=v.ReservaUsuarioId WHERE @ClienteId IS NULL OR v.ClienteId=@ClienteId ORDER BY v.Id,v.EquipoId; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Insertar
 @UsuarioId int,@ClienteId int,@Desde datetime2,@Hasta datetime2,@Importe decimal(18,2),@SenaRequerida decimal(18,2),@GarantiaRequerida decimal(18,2),
 @PorcentajeSena decimal(5,4),@PorcentajeGarantia decimal(5,4),@Equipos dbo.ReservaEquipoEntrada READONLY,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
 BEGIN TRY BEGIN TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM dbo.Cliente c JOIN dbo.Usuario u ON u.Id=c.UsuarioId
   WHERE c.Id=@ClienteId AND c.UsuarioId=@UsuarioId AND u.Activo=1 AND u.Rol IN(N'Cliente',N'Administrador'))
   THROW 50024,N'La solicitud debe pertenecer a una cuenta de cliente activa.',1;
 IF @Hasta<=@Desde OR @Hasta>CONVERT(datetime2,'9998-01-01') OR NOT EXISTS(SELECT 1 FROM @Equipos)
   THROW 50025,N'Elegí equipos y un período válido.',1;
 IF (SELECT COUNT(*) FROM @Equipos)<>(SELECT COUNT(*) FROM @Equipos x JOIN dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=x.EquipoId)
   THROW 50026,N'Una unidad ya no está disponible. Volvé a consultar.',1;
 DECLARE @Dias decimal(18,0)=CEILING((CONVERT(decimal(28,0),DATEDIFF_BIG(SECOND,@Desde,@Hasta))*10000000+(DATEPART(NANOSECOND,@Hasta)-DATEPART(NANOSECOND,@Desde))/100)/864000000000.0);
 DECLARE @Total decimal(18,2);
 SELECT @Total=ROUND(SUM(e.TarifaDiaria)*@Dias,2) FROM dbo.Equipo e JOIN @Equipos x ON x.EquipoId=e.Id;
 IF @Importe<>@Total THROW 50027,N'Cambió la tarifa: volvé a cotizar antes de enviar.',1;
 INSERT dbo.Reserva(ClienteId,Desde,Hasta,Importe,Sena,Garantia,SenaRequerida,GarantiaRequerida,Estado)
 VALUES(@ClienteId,@Desde,@Hasta,@Total,0,0,@SenaRequerida,@GarantiaRequerida,N'Pendiente');
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY());
 INSERT dbo.ReservaEquipo(ReservaId,EquipoId,SeguroId,CoberturaSeguro,TarifaDiaria,ValorReposicion,DiasReacondicionamiento,TipoSeguro,DetalleSeguro,PolizaSeguro,AseguradoraSeguro,DesdeSeguro,HastaSeguro)
 SELECT @Resultado,e.Id,s.Id,ISNULL(s.Cobertura,0),e.TarifaDiaria,e.ValorReposicion,e.DiasReacondicionamiento,s.Tipo,s.Detalle,s.Poliza,s.Aseguradora,s.Desde,s.Hasta
 FROM dbo.Equipo e JOIN @Equipos x ON x.EquipoId=e.Id
 JOIN dbo.Cliente c ON c.Id=@ClienteId JOIN dbo.Usuario u ON u.Id=c.UsuarioId
 LEFT JOIN dbo.Seguro s ON s.Id=u.SeguroId AND u.TipoSeguro<>N'SinSeguro' AND s.Tipo=u.TipoSeguro
  AND s.ClienteId=@ClienteId AND s.Desde<=@Desde AND s.Hasta>=@Hasta;
 COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Confirmar
 @ReservaId int, @ClienteId int,@Desde datetime2,@Hasta datetime2,@Importe decimal(18,2),@SenaRequerida decimal(18,2),@GarantiaRequerida decimal(18,2),
 @PorcentajeSena decimal(5,4),@PorcentajeGarantia decimal(5,4),@Equipos dbo.ReservaEquipoEntrada READONLY,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
 BEGIN TRY BEGIN TRANSACTION;
 DECLARE @EstadoSolicitud nvarchar(25),@ClienteSolicitud int,@DesdeSolicitud datetime2,@HastaSolicitud datetime2;
 SELECT @EstadoSolicitud=Estado,@ClienteSolicitud=ClienteId,@DesdeSolicitud=Desde,@HastaSolicitud=Hasta
 FROM dbo.Reserva WITH(UPDLOCK,HOLDLOCK) WHERE Id=@ReservaId;
 IF @EstadoSolicitud IS NULL OR @EstadoSolicitud<>N'Pendiente' THROW 50021,N'La solicitud no existe o ya fue procesada.',1;
 IF @ClienteSolicitud<>@ClienteId OR @DesdeSolicitud<>@Desde OR @HastaSolicitud<>@Hasta
   THROW 50022,N'La aprobación debe conservar el cliente y las fechas de la solicitud.',1;
 IF EXISTS(SELECT EquipoId FROM @Equipos EXCEPT SELECT EquipoId FROM dbo.ReservaEquipo WHERE ReservaId=@ReservaId)
 OR EXISTS(SELECT EquipoId FROM dbo.ReservaEquipo WHERE ReservaId=@ReservaId EXCEPT SELECT EquipoId FROM @Equipos)
   THROW 50023,N'La aprobación debe conservar los equipos solicitados.',1;
 IF @Hasta<=@Desde OR @Hasta>CONVERT(datetime2,'9998-01-01') OR NOT EXISTS(SELECT 1 FROM @Equipos)
   THROW 50011,N'Completá fechas y unidades de la reserva.',1;
 IF @PorcentajeSena NOT BETWEEN 0 AND 1 OR @PorcentajeGarantia NOT BETWEEN 0 AND 1 THROW 50012,N'Porcentajes no válidos.',1;
 IF NOT EXISTS(SELECT 1 FROM dbo.Cliente c WITH(HOLDLOCK) JOIN dbo.Usuario u WITH(HOLDLOCK) ON u.Id=c.UsuarioId
   WHERE c.Id=@ClienteId AND u.Activo=1 AND u.Rol IN(N'Cliente',N'Administrador'))
   THROW 50013,N'El cliente no está habilitado.',1;
 -- Every confirmation locks physical units before testing the date range.
 DECLARE @Bloqueo bigint;
 SELECT @Bloqueo=SUM(CONVERT(bigint,e.Id)) FROM dbo.Equipo e WITH(UPDLOCK,HOLDLOCK) JOIN @Equipos x ON x.EquipoId=e.Id;
 IF (SELECT COUNT(*) FROM @Equipos)<>(SELECT COUNT(*) FROM dbo.Equipo e JOIN @Equipos x ON x.EquipoId=e.Id)
   THROW 50014,N'Una unidad no existe.',1;
 IF EXISTS(SELECT 1 FROM @Equipos x JOIN dbo.Equipo e ON e.Id=x.EquipoId
   JOIN dbo.Cliente c ON c.Id=@ClienteId JOIN dbo.Usuario u ON u.Id=c.UsuarioId
   LEFT JOIN dbo.Seguro s WITH(HOLDLOCK) ON s.Id=u.SeguroId AND u.TipoSeguro<>N'SinSeguro' AND s.Tipo=u.TipoSeguro
    AND s.ClienteId=@ClienteId AND s.Desde<=@Desde AND s.Hasta>=@Hasta
   WHERE x.TarifaDiaria<>e.TarifaDiaria OR x.ValorReposicion<>e.ValorReposicion OR x.DiasReacondicionamiento<>e.DiasReacondicionamiento
   OR ISNULL(x.SeguroId,0)<>ISNULL(s.Id,0) OR x.CoberturaSeguro<>ISNULL(s.Cobertura,0))
   THROW 50016,N'Cambió el catálogo o la cobertura: volvé a cotizar.',1;
 IF (SELECT COUNT(*) FROM @Equipos)<>(SELECT COUNT(*) FROM @Equipos x JOIN dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=x.EquipoId)
   THROW 50017,N'Una unidad ya está ocupada o bloqueada, incluido el reacondicionamiento.',1;
 DECLARE @Dias decimal(18,0)=CEILING((CONVERT(decimal(28,0),DATEDIFF_BIG(SECOND,@Desde,@Hasta))*10000000+(DATEPART(NANOSECOND,@Hasta)-DATEPART(NANOSECOND,@Desde))/100)/864000000000.0);
 DECLARE @Total decimal(18,2),@Reposicion decimal(18,2);
 SELECT @Total=ROUND(SUM(e.TarifaDiaria)*@Dias,2),@Reposicion=SUM(e.ValorReposicion) FROM dbo.Equipo e JOIN @Equipos x ON x.EquipoId=e.Id;
 IF @Importe<>@Total OR @SenaRequerida<>ROUND(@Total*@PorcentajeSena,2) OR @GarantiaRequerida<>ROUND(@Reposicion*@PorcentajeGarantia,2)
   THROW 50018,N'Importe o seña no coinciden con la cotización actual.',1;
 UPDATE dbo.Reserva SET Importe=@Importe,SenaRequerida=@SenaRequerida,GarantiaRequerida=@GarantiaRequerida,Sena=0,Garantia=0,Estado=N'Aceptada' WHERE Id=@ReservaId;
 UPDATE re SET SeguroId=s.Id,CoberturaSeguro=ISNULL(s.Cobertura,0),TipoSeguro=s.Tipo,DetalleSeguro=s.Detalle,
 PolizaSeguro=s.Poliza,AseguradoraSeguro=s.Aseguradora,DesdeSeguro=s.Desde,HastaSeguro=s.Hasta,TarifaDiaria=e.TarifaDiaria,
 ValorReposicion=e.ValorReposicion,DiasReacondicionamiento=e.DiasReacondicionamiento
 FROM dbo.ReservaEquipo re JOIN dbo.Equipo e ON e.Id=re.EquipoId
 JOIN dbo.Cliente c ON c.Id=@ClienteId JOIN dbo.Usuario u ON u.Id=c.UsuarioId
 LEFT JOIN dbo.Seguro s ON s.Id=u.SeguroId AND u.TipoSeguro<>N'SinSeguro' AND s.Tipo=u.TipoSeguro
  AND s.ClienteId=@ClienteId AND s.Desde<=@Desde AND s.Hasta>=@Hasta
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
 IF EXISTS(SELECT 1 FROM dbo.Reserva WHERE Id=@ReservaId AND (Sena<>SenaRequerida OR Garantia<>GarantiaRequerida))
   THROW 50203,N'El cliente debe pagar la seña antes de la entrega.',1;
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
-- ===== Fuente: 03_StoredProcedures/N02.sql =====
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET ARITHABORT ON;
SET NUMERIC_ROUNDABORT OFF;
USE [TC-AlquilerAudiovisual];
GO
CREATE OR ALTER PROCEDURE dbo.sp_Devolucion_Buscar @DevolucionId int AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Devolucion WHERE Id = @DevolucionId;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Devolucion_Listar AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Devolucion ORDER BY Id DESC;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Incidencia_Listar @DevolucionId int = NULL AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM dbo.Incidencia WHERE @DevolucionId IS NULL OR DevolucionId = @DevolucionId ORDER BY Id DESC;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Devolucion_Insertar
	@ReservaId int, @Fecha datetime2, @Conforme bit, @ClientePresente bit, @Observaciones nvarchar(500),
	@GarantiaAplicada decimal(18,2), @GarantiaDevuelta decimal(18,2), @SaldoPendiente decimal(18,2),
	@Resultado int OUTPUT AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @Estado nvarchar(25), @Desde datetime2, @Hasta datetime2, @Garantia decimal(18,2);
		SELECT @Estado = Estado, @Desde = Desde, @Hasta = Hasta, @Garantia = Garantia
		FROM dbo.Reserva WITH (UPDLOCK, HOLDLOCK) WHERE Id = @ReservaId;
		IF @Estado IS NULL OR @Estado <> N'Entregada'
			THROW 50101, N'La reserva no está entregada o ya tiene devolución.', 1;
		IF EXISTS (SELECT 1 FROM dbo.Devolucion WHERE ReservaId = @ReservaId)
			THROW 50102, N'Esta reserva ya tiene una devolución.', 1;
		IF @Fecha < @Desde OR @Fecha > DATEADD(MINUTE, 5, SYSDATETIME())
			THROW 50103, N'La fecha de devolución no es válida.', 1;
		IF @Conforme = 1 AND @Fecha > @Hasta
			THROW 50104, N'Hay atraso. Registrá una devolución con incidencias.', 1;
		IF @Conforme = 0 AND @ClientePresente = 0
			THROW 50105, N'El cliente debe estar presente para registrar las incidencias.', 1;
		IF @Observaciones IS NULL
			THROW 50106, N'Completá las observaciones de devolución.', 1;
		DECLARE @Bloqueo bigint;
		SELECT @Bloqueo = SUM(CONVERT(bigint, e.Id))
		FROM dbo.Equipo e WITH (UPDLOCK, HOLDLOCK)
		JOIN dbo.ReservaEquipo re ON re.EquipoId = e.Id WHERE re.ReservaId = @ReservaId;
		IF @Bloqueo IS NULL OR EXISTS
		(
			SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Equipo e ON e.Id = re.EquipoId
			WHERE re.ReservaId = @ReservaId AND (re.EstadoEntrega IS NULL OR re.EstadoEntrega <> N'Disponible' OR e.Estado <> N'Alquilado')
		)
			THROW 50107, N'Las unidades no coinciden con la entrega registrada en el remito.', 1;
		IF @GarantiaAplicada <> 0 OR @SaldoPendiente <> 0
			OR (@Conforme = 1 AND @GarantiaDevuelta <> @Garantia)
			OR (@Conforme = 0 AND @GarantiaDevuelta <> 0)
			THROW 50108, N'Los importes no corresponden al resultado de la devolución.', 1;

		INSERT dbo.Devolucion(ReservaId, Fecha, Conforme, ClientePresente, Finalizada, Observaciones,
			GarantiaAplicada, GarantiaDevuelta, SaldoPendiente)
		VALUES (@ReservaId, @Fecha, @Conforme, @ClientePresente, @Conforme, @Observaciones,
			@GarantiaAplicada, @GarantiaDevuelta, @SaldoPendiente);
		SET @Resultado = CONVERT(int, SCOPE_IDENTITY());
		IF @Conforme = 1
		BEGIN
			UPDATE dbo.Reserva SET Estado = N'Cerrada' WHERE Id = @ReservaId;
			UPDATE e SET Estado = N'Disponible'
			FROM dbo.Equipo e JOIN dbo.ReservaEquipo re ON re.EquipoId = e.Id WHERE re.ReservaId = @ReservaId;
		END
		ELSE
		BEGIN
			UPDATE dbo.Reserva SET Estado = N'ConIncidencia' WHERE Id = @ReservaId;
			-- Toda unidad queda bloqueada hasta terminar de registrar los hallazgos.
			UPDATE e SET Estado = N'ConIncidencia'
			FROM dbo.Equipo e JOIN dbo.ReservaEquipo re ON re.EquipoId = e.Id WHERE re.ReservaId = @ReservaId;
		END;
		COMMIT;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK;
		THROW;
	END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Incidencia_Insertar
	@DevolucionId int, @EquipoId int, @Tipo nvarchar(25), @Descripcion nvarchar(500),
	@Cargo decimal(18,2), @Resultado int OUTPUT AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @ReservaId int, @Fecha datetime2, @Finalizada bit, @Conforme bit, @Presente bit;
		SELECT @ReservaId = ReservaId FROM dbo.Devolucion WHERE Id = @DevolucionId;
		DECLARE @Estado nvarchar(25), @Hasta datetime2, @Desde datetime2, @Garantia decimal(18,2), @ClienteId int;
		SELECT @Estado = Estado, @Hasta = Hasta, @Desde = Desde, @Garantia = Garantia, @ClienteId = ClienteId
		FROM dbo.Reserva WITH (UPDLOCK, HOLDLOCK) WHERE Id = @ReservaId;
		SELECT @Fecha = Fecha, @Finalizada = Finalizada, @Conforme = Conforme, @Presente = ClientePresente
		FROM dbo.Devolucion WITH (UPDLOCK, HOLDLOCK) WHERE Id = @DevolucionId;
		IF @Estado IS NULL OR @Estado <> N'ConIncidencia' OR @Finalizada = 1 OR @Conforme = 1 OR @Presente = 0
			THROW 50109, N'La inspección no existe, ya finalizó o no tiene al cliente presente.', 1;
		IF @Tipo NOT IN (N'Atraso', N'Faltante', N'DañoReparable', N'DañoTotal') OR LEN(LTRIM(RTRIM(@Descripcion))) = 0 OR @Descripcion IS NULL
			THROW 50110, N'Tipo o descripción de incidencia no válidos.', 1;
		DECLARE @Tarifa decimal(18,2), @Reposicion decimal(18,2), @Cobertura decimal(18,2), @TipoSeguro nvarchar(25);
		SELECT @Tarifa = re.TarifaDiaria, @Reposicion = re.ValorReposicion,
			@TipoSeguro = re.TipoSeguro,
			@Cobertura = CASE WHEN re.SeguroId IS NOT NULL AND re.DesdeSeguro <= @Desde AND re.HastaSeguro >= @Hasta THEN re.CoberturaSeguro ELSE 0 END
		FROM dbo.ReservaEquipo re JOIN dbo.Equipo e WITH (UPDLOCK, HOLDLOCK) ON e.Id = re.EquipoId
		WHERE re.ReservaId = @ReservaId AND re.EquipoId = @EquipoId;
		IF @Tarifa IS NULL THROW 50111, N'La unidad no pertenece al remito de esta reserva.', 1;
		IF EXISTS (SELECT 1 FROM dbo.Incidencia WHERE DevolucionId = @DevolucionId AND EquipoId = @EquipoId AND Tipo = @Tipo)
			THROW 50112, N'Esta unidad ya tiene una incidencia de ese tipo.', 1;
		IF @Tipo <> N'Atraso' AND EXISTS
		(
			SELECT 1 FROM dbo.Incidencia WHERE DevolucionId = @DevolucionId AND EquipoId = @EquipoId AND Tipo <> N'Atraso'
		)
			THROW 50113, N'Clasificá el hallazgo físico de la unidad con un único tipo. El atraso puede registrarse aparte.', 1;
		DECLARE @CargoCalculado decimal(18,2), @CargoBase decimal(18,2), @Descuento decimal(18,2) = 0;
		IF @Tipo = N'Atraso'
		BEGIN
			IF @Fecha <= @Hasta THROW 50114, N'La devolución no tiene atraso.', 1;
			DECLARE @Dias decimal(18,0) = CEILING((CONVERT(decimal(28,0), DATEDIFF_BIG(SECOND, @Hasta, @Fecha)) * 10000000
				+ (DATEPART(NANOSECOND, @Fecha) - DATEPART(NANOSECOND, @Hasta)) / 100) / 864000000000.0);
			DECLARE @DiasAlquiler decimal(18,0) = CEILING((CONVERT(decimal(28,0), DATEDIFF_BIG(SECOND, @Desde, @Hasta)) * 10000000
				+ (DATEPART(NANOSECOND, @Hasta) - DATEPART(NANOSECOND, @Desde)) / 100) / 864000000000.0);
			SET @CargoBase = ROUND(@Dias * ROUND(@DiasAlquiler * @Tarifa, 2) * 0.10, 2);
		END
		ELSE
		BEGIN
			SET @CargoBase = ROUND(@Reposicion * CASE WHEN @Tipo=N'DañoReparable' THEN 0.20 WHEN @Tipo=N'DañoTotal' THEN 0.80 ELSE 1 END, 2);
			DECLARE @Porcentaje decimal(3,2) = 0;
			IF @TipoSeguro=N'Basico' AND @Tipo=N'DañoReparable' SET @Porcentaje=0.25;
			ELSE IF @TipoSeguro=N'Intermedio' AND @Tipo IN(N'DañoReparable',N'DañoTotal') SET @Porcentaje=0.50;
			ELSE IF @TipoSeguro=N'Completo' SET @Porcentaje=0.80;
			SET @Descuento = ROUND(CASE WHEN @CargoBase*@Porcentaje < @Cobertura THEN @CargoBase*@Porcentaje ELSE @Cobertura END, 2);
		END;
		SET @CargoCalculado = @CargoBase - @Descuento;
		IF @Cargo IS NULL OR @Cargo <> @CargoCalculado
			THROW 50115, N'El cargo no coincide con las condiciones pactadas.', 1;
		INSERT dbo.Incidencia(DevolucionId, EquipoId, Tipo, Descripcion, CargoBase, DescuentoSeguro, Cargo, Estado)
		VALUES (@DevolucionId, @EquipoId, @Tipo, @Descripcion, @CargoBase, @Descuento, @CargoCalculado, N'Abierta');
		SET @Resultado = CONVERT(int, SCOPE_IDENTITY());
		UPDATE dbo.Equipo SET Estado = N'ConIncidencia' WHERE Id = @EquipoId;
		DECLARE @Total decimal(18,2);
		SELECT @Total = SUM(Cargo) FROM dbo.Incidencia WHERE DevolucionId = @DevolucionId;
		UPDATE dbo.Devolucion SET
			GarantiaAplicada = CASE WHEN @Total < @Garantia THEN @Total ELSE @Garantia END,
			GarantiaDevuelta = CASE WHEN @Total < @Garantia THEN @Garantia - @Total ELSE 0 END,
			SaldoPendiente = CASE WHEN @Total > @Garantia THEN @Total - @Garantia ELSE 0 END
		WHERE Id = @DevolucionId;
		COMMIT;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK;
		THROW;
	END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Devolucion_Finalizar @DevolucionId int, @Resultado int OUTPUT AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	SET @Resultado = 0;
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @ReservaId int, @Finalizada bit, @Fecha datetime2, @Hasta datetime2;
		SELECT @ReservaId = ReservaId FROM dbo.Devolucion WHERE Id = @DevolucionId;
		SELECT @Hasta = Hasta FROM dbo.Reserva WITH (UPDLOCK, HOLDLOCK) WHERE Id = @ReservaId;
		SELECT @Finalizada = Finalizada, @Fecha = Fecha
		FROM dbo.Devolucion WITH (UPDLOCK, HOLDLOCK) WHERE Id = @DevolucionId;
		IF @Finalizada IS NULL THROW 50116, N'La devolución no existe.', 1;
		IF @Finalizada = 0
		BEGIN
			IF NOT EXISTS (SELECT 1 FROM dbo.Incidencia WHERE DevolucionId = @DevolucionId)
				THROW 50117, N'Registrá los hallazgos antes de finalizar la inspección.', 1;
			IF @Fecha > @Hasta AND EXISTS
			(
				SELECT 1 FROM dbo.ReservaEquipo re WHERE re.ReservaId = @ReservaId AND NOT EXISTS
				(SELECT 1 FROM dbo.Incidencia i WHERE i.DevolucionId = @DevolucionId AND i.EquipoId = re.EquipoId AND i.Tipo = N'Atraso')
			)
				THROW 50118, N'Registrá el atraso de cada unidad del remito antes de finalizar.', 1;
			UPDATE dbo.Devolucion SET Finalizada = 1 WHERE Id = @DevolucionId;
			UPDATE e SET Estado = N'Disponible'
			FROM dbo.Equipo e JOIN dbo.ReservaEquipo re ON re.EquipoId = e.Id
			WHERE re.ReservaId = @ReservaId
				AND NOT EXISTS (SELECT 1 FROM dbo.Incidencia i WHERE i.EquipoId = e.Id AND i.Estado = N'Abierta')
				AND NOT EXISTS
				(SELECT 1 FROM dbo.ReservaEquipo otra JOIN dbo.Reserva r ON r.Id = otra.ReservaId WHERE otra.EquipoId = e.Id AND r.Estado = N'Entregada');
			SET @Resultado = 1;
		END;
		COMMIT;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK;
		THROW;
	END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Incidencia_AltaTecnica @IncidenciaId int, @Resultado int OUTPUT AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	SET @Resultado = 0;
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @ReservaId int, @DevolucionId int, @EquipoId int, @Finalizada bit;
		SELECT @DevolucionId = i.DevolucionId, @ReservaId = d.ReservaId
		FROM dbo.Incidencia i JOIN dbo.Devolucion d ON d.Id = i.DevolucionId WHERE i.Id = @IncidenciaId;
		DECLARE @EstadoReserva nvarchar(25), @EstadoIncidencia nvarchar(25);
		SELECT @EstadoReserva = Estado FROM dbo.Reserva WITH (UPDLOCK, HOLDLOCK) WHERE Id = @ReservaId;
		SELECT @Finalizada = Finalizada FROM dbo.Devolucion WITH (UPDLOCK, HOLDLOCK) WHERE Id = @DevolucionId;
		SELECT @EquipoId = EquipoId, @EstadoIncidencia = Estado
		FROM dbo.Incidencia WITH (UPDLOCK, HOLDLOCK) WHERE Id = @IncidenciaId;
		IF @EstadoIncidencia = N'Abierta'
		BEGIN
			IF @Finalizada = 0 THROW 50119, N'Stock debe finalizar la inspección antes del alta técnica.', 1;
			UPDATE dbo.Incidencia SET Estado = N'Cerrada', FechaAltaTecnica = SYSDATETIME() WHERE Id = @IncidenciaId;
			IF NOT EXISTS (SELECT 1 FROM dbo.Incidencia WHERE EquipoId = @EquipoId AND Estado = N'Abierta')
				AND NOT EXISTS
				(SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id = re.ReservaId WHERE re.EquipoId = @EquipoId AND r.Estado = N'Entregada')
				UPDATE dbo.Equipo SET Estado = N'Disponible' WHERE Id = @EquipoId;
			IF NOT EXISTS (SELECT 1 FROM dbo.Incidencia WHERE DevolucionId = @DevolucionId AND Estado = N'Abierta')
				UPDATE dbo.Reserva SET Estado = N'Cerrada' WHERE Id = @ReservaId;
			SET @Resultado = 1;
		END;
		COMMIT;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK;
		THROW;
	END CATCH;
END;
GO
-- Replaces the N01 delivery operation while keeping its signature and record format.
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_RegistrarEntrega @ReservaId int, @Resultado int OUTPUT AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	SET @Resultado = 0;
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @Estado nvarchar(25);
		SELECT @Estado = Estado FROM dbo.Reserva WITH (UPDLOCK, HOLDLOCK) WHERE Id = @ReservaId;
		IF @Estado = N'Firme'
		BEGIN
			IF EXISTS(SELECT 1 FROM dbo.Reserva WHERE Id=@ReservaId AND (Sena<>SenaRequerida OR Garantia<>GarantiaRequerida))
				THROW 50203,N'El cliente debe pagar la seña antes de la entrega.',1;
			DECLARE @Bloqueo bigint;
			SELECT @Bloqueo = SUM(CONVERT(bigint, e.Id)) FROM dbo.Equipo e WITH (UPDLOCK, HOLDLOCK)
			JOIN dbo.ReservaEquipo re ON re.EquipoId = e.Id WHERE re.ReservaId = @ReservaId;
			IF EXISTS (SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Equipo e ON e.Id = re.EquipoId WHERE re.ReservaId = @ReservaId AND e.Estado <> N'Disponible')
				THROW 50019, N'Una unidad no está disponible físicamente para entrega.', 1;
			IF EXISTS
			(
				SELECT 1 FROM dbo.ReservaEquipo actual JOIN dbo.ReservaEquipo otra ON otra.EquipoId = actual.EquipoId
				JOIN dbo.Reserva r ON r.Id = otra.ReservaId WHERE actual.ReservaId = @ReservaId AND r.Estado = N'Entregada'
			)
				THROW 50020, N'Una unidad sigue en otro alquiler.', 1;
			IF EXISTS
			(
				SELECT 1 FROM dbo.ReservaEquipo actual JOIN dbo.ReservaEquipo anterior ON anterior.EquipoId = actual.EquipoId
				JOIN dbo.Reserva r ON r.Id = anterior.ReservaId JOIN dbo.Devolucion d ON d.ReservaId = r.Id
				WHERE actual.ReservaId = @ReservaId AND d.Finalizada = 0
			)
				THROW 50121, N'Una unidad todavía tiene una inspección pendiente de finalizar.', 1;
			UPDATE re SET EstadoEntrega = e.Estado FROM dbo.ReservaEquipo re JOIN dbo.Equipo e ON e.Id = re.EquipoId WHERE re.ReservaId = @ReservaId;
			UPDATE dbo.Reserva SET Estado = N'Entregada', ContratoFirmado = 1,
				NumeroContrato = N'C-' + CONVERT(nvarchar(20), Id), NumeroRemito = N'R-' + CONVERT(nvarchar(20), Id) WHERE Id = @ReservaId;
			UPDATE e SET Estado = N'Alquilado' FROM dbo.Equipo e JOIN dbo.ReservaEquipo re ON re.EquipoId = e.Id WHERE re.ReservaId = @ReservaId;
			SET @Resultado = 1;
		END;
		COMMIT;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0 ROLLBACK;
		THROW;
	END CATCH;
END;
GO
-- ===== Fuente: 09_DatosPersonales.sql =====
USE [TC-AlquilerAudiovisual];
GO
-- Todo usuario (incluido el administrador) tiene nombre, correo, teléfono y DNI/CUIT obligatorios.
IF COL_LENGTH(N'dbo.Usuario',N'Nombre') IS NULL
 ALTER TABLE dbo.Usuario ADD Nombre nvarchar(100) NULL,DniCuit nvarchar(13) NULL,Telefono nvarchar(30) NULL,Email nvarchar(150) NULL;
GO
-- Los usuarios existentes sin datos reciben valores de ejemplo para poder exigir la restricción.
UPDATE u SET
 Nombre=ISNULL(NULLIF(LTRIM(RTRIM(u.Nombre)),N''),c.Nombre),
 DniCuit=ISNULL(NULLIF(LTRIM(RTRIM(u.DniCuit)),N''),c.DniCuit),
 Telefono=ISNULL(NULLIF(LTRIM(RTRIM(u.Telefono)),N''),c.Telefono),
 Email=ISNULL(NULLIF(LTRIM(RTRIM(u.Email)),N''),c.Email)
FROM dbo.Usuario u LEFT JOIN dbo.Cliente c ON c.UsuarioId=u.Id;
UPDATE dbo.Usuario SET
 Nombre=ISNULL(NULLIF(LTRIM(RTRIM(Nombre)),N''),NombreUsuario),
 DniCuit=ISNULL(NULLIF(LTRIM(RTRIM(DniCuit)),N''),CONVERT(nvarchar(13),20000000+Id)),
 Telefono=ISNULL(NULLIF(LTRIM(RTRIM(Telefono)),N''),N'1100000000'),
 Email=ISNULL(NULLIF(LTRIM(RTRIM(Email)),N''),NombreUsuario+N'@foco.com');
GO
IF EXISTS(SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID(N'dbo.Usuario') AND name=N'Nombre' AND is_nullable=1)
BEGIN
 ALTER TABLE dbo.Usuario ALTER COLUMN Nombre nvarchar(100) NOT NULL;
 ALTER TABLE dbo.Usuario ALTER COLUMN DniCuit nvarchar(13) NOT NULL;
 ALTER TABLE dbo.Usuario ALTER COLUMN Telefono nvarchar(30) NOT NULL;
 ALTER TABLE dbo.Usuario ALTER COLUMN Email nvarchar(150) NOT NULL;
END;
GO
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE name=N'CK_Usuario_DatosPersonales')
 ALTER TABLE dbo.Usuario ADD CONSTRAINT CK_Usuario_DatosPersonales CHECK(
  LEN(LTRIM(RTRIM(Nombre)))>0 AND LEN(LTRIM(RTRIM(DniCuit)))>0 AND LEN(LTRIM(RTRIM(Telefono)))>0 AND LEN(LTRIM(RTRIM(Email)))>0);
GO
CREATE OR ALTER VIEW dbo.vUsuario AS
 SELECT u.Id,u.NombreUsuario,u.Rol,u.Activo,u.TipoSeguro,u.SeguroId,u.Nombre,u.DniCuit,u.Telefono,u.Email,
 s.ClienteId SeguroClienteId,s.Tipo SeguroTipo,s.Detalle SeguroDetalle,s.Poliza SeguroPoliza,
 s.Aseguradora SeguroAseguradora,s.Desde SeguroDesde,s.Hasta SeguroHasta,s.Cobertura SeguroCobertura,
 c.Nombre SeguroNombre,c.DniCuit SeguroDniCuit,c.Telefono SeguroTelefono,c.Email SeguroEmail,
 dbo.HistorialCliente(c.Id) SeguroAntecedentes
 FROM dbo.Usuario u LEFT JOIN dbo.Cliente c ON c.UsuarioId=u.Id
 LEFT JOIN dbo.Seguro s ON s.Id=u.SeguroId AND s.ClienteId=c.Id AND u.TipoSeguro<>N'SinSeguro';
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Insertar
 @NombreUsuario nvarchar(50),@Hash varbinary(32),@Sal varbinary(16),@Rol nvarchar(25),@Activo bit,@Resultado int OUTPUT,@TipoSeguro nvarchar(25)=N'SinSeguro',
 @Nombre nvarchar(100)=NULL,@DniCuit nvarchar(13)=NULL,@Telefono nvarchar(30)=NULL,@Email nvarchar(150)=NULL AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 BEGIN TRY
 BEGIN TRANSACTION;
 IF NULLIF(LTRIM(RTRIM(@Nombre)),N'') IS NULL OR NULLIF(LTRIM(RTRIM(@DniCuit)),N'') IS NULL
  OR NULLIF(LTRIM(RTRIM(@Telefono)),N'') IS NULL OR NULLIF(LTRIM(RTRIM(@Email)),N'') IS NULL
  THROW 50040,N'Nombre, correo, teléfono y DNI/CUIT son obligatorios.',1;
 INSERT dbo.Usuario(NombreUsuario,Hash,Sal,Rol,Activo,TipoSeguro,Nombre,DniCuit,Telefono,Email)
  VALUES(@NombreUsuario,@Hash,@Sal,@Rol,@Activo,@TipoSeguro,@Nombre,@DniCuit,@Telefono,@Email);
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY());
 DECLARE @SeguroResultado int;
 EXEC dbo.sp_Usuario_ConfigurarSeguro @Resultado,@TipoSeguro,@SeguroResultado OUTPUT;
 COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
-- ===== Fuente: 10_FichaAutomatica.sql =====
USE [TC-AlquilerAudiovisual];
GO
-- Alta automática de la ficha de cliente para cuentas Cliente y Administrador.
INSERT dbo.Cliente(UsuarioId,DniCuit,Nombre,Telefono,Email)
 SELECT u.Id,u.DniCuit,u.Nombre,u.Telefono,u.Email FROM dbo.Usuario u
 WHERE u.Rol IN(N'Cliente',N'Administrador') AND NOT EXISTS(SELECT 1 FROM dbo.Cliente c WHERE c.UsuarioId=u.Id);
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_AsignarRol @UsuarioId int,@Rol nvarchar(25),@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON;
 IF @Rol NOT IN(N'Administrador',N'Cliente',N'EncargadoStock',N'Tecnico') THROW 50001,N'Rol no válido.',1;
 IF @Rol NOT IN(N'Cliente',N'Administrador') AND EXISTS(SELECT 1 FROM dbo.Cliente WHERE UsuarioId=@UsuarioId)
   THROW 50002,N'La cuenta tiene una ficha de cliente; debe conservar el rol Cliente o Administrador.',1;
 UPDATE dbo.Usuario SET Rol=@Rol WHERE Id=@UsuarioId;
 SET @Resultado=CASE WHEN @@ROWCOUNT=1 THEN 1 ELSE 0 END;
 IF @Rol NOT IN(N'Cliente',N'Administrador') UPDATE dbo.Usuario SET TipoSeguro=N'SinSeguro',SeguroId=NULL WHERE Id=@UsuarioId;
 -- Las cuentas Cliente y Administrador siempre tienen ficha de cliente, completada con sus datos personales.
 IF @Rol IN(N'Cliente',N'Administrador') AND NOT EXISTS(SELECT 1 FROM dbo.Cliente WHERE UsuarioId=@UsuarioId)
  INSERT dbo.Cliente(UsuarioId,DniCuit,Nombre,Telefono,Email) SELECT Id,DniCuit,Nombre,Telefono,Email FROM dbo.Usuario WHERE Id=@UsuarioId;
 END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Usuario_Insertar
 @NombreUsuario nvarchar(50),@Hash varbinary(32),@Sal varbinary(16),@Rol nvarchar(25),@Activo bit,@Resultado int OUTPUT,@TipoSeguro nvarchar(25)=N'SinSeguro',
 @Nombre nvarchar(100)=NULL,@DniCuit nvarchar(13)=NULL,@Telefono nvarchar(30)=NULL,@Email nvarchar(150)=NULL AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 BEGIN TRY
 BEGIN TRANSACTION;
 IF NULLIF(LTRIM(RTRIM(@Nombre)),N'') IS NULL OR NULLIF(LTRIM(RTRIM(@DniCuit)),N'') IS NULL
  OR NULLIF(LTRIM(RTRIM(@Telefono)),N'') IS NULL OR NULLIF(LTRIM(RTRIM(@Email)),N'') IS NULL
  THROW 50040,N'Nombre, correo, teléfono y DNI/CUIT son obligatorios.',1;
 INSERT dbo.Usuario(NombreUsuario,Hash,Sal,Rol,Activo,TipoSeguro,Nombre,DniCuit,Telefono,Email)
  VALUES(@NombreUsuario,@Hash,@Sal,@Rol,@Activo,@TipoSeguro,@Nombre,@DniCuit,@Telefono,@Email);
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY());
 -- Las cuentas Cliente y Administrador nacen con su ficha de cliente, tomada de los datos personales.
 IF @Rol IN(N'Cliente',N'Administrador')
  INSERT dbo.Cliente(UsuarioId,DniCuit,Nombre,Telefono,Email) VALUES(@Resultado,@DniCuit,@Nombre,@Telefono,@Email);
 DECLARE @SeguroResultado int;
 EXEC dbo.sp_Usuario_ConfigurarSeguro @Resultado,@TipoSeguro,@SeguroResultado OUTPUT;
 COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH; END;
GO
-- ===== Fuente: 11_Asesoramiento.sql =====
USE [TC-AlquilerAudiovisual];
GO
-- Asesoramiento técnico (N03): perfil de cada equipo y más inventario para armar propuestas.
IF OBJECT_ID(N'dbo.EquipoPerfil',N'U') IS NULL
 CREATE TABLE dbo.EquipoPerfil(EquipoId int NOT NULL PRIMARY KEY REFERENCES dbo.Equipo(Id),
  Gama tinyint NOT NULL CHECK(Gama BETWEEN 1 AND 3),Etiquetas nvarchar(300) NOT NULL,
  Ventaja nvarchar(300) NOT NULL,Limitacion nvarchar(300) NOT NULL);
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_DisponiblesAsesor @Desde datetime2,@Hasta datetime2 AS
 BEGIN SET NOCOUNT ON;
 SELECT e.*,p.Gama,p.Etiquetas,p.Ventaja,p.Limitacion FROM dbo.vEquipo e
 JOIN dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=e.Id JOIN dbo.EquipoPerfil p ON p.EquipoId=e.Id
 ORDER BY e.Categoria,e.CodigoInventario; END;
GO
-- ===== Fuente: 12_PropuestasGuardadas.sql =====
USE [TC-AlquilerAudiovisual];
GO
-- Propuestas del asesor de rodaje guardadas por cada usuario (brief + variante elegida) para retomarlas después.
IF OBJECT_ID(N'dbo.PropuestaGuardada',N'U') IS NULL
 CREATE TABLE dbo.PropuestaGuardada(
  Id int IDENTITY PRIMARY KEY,UsuarioId int NOT NULL REFERENCES dbo.Usuario(Id),
  Nombre nvarchar(100) NOT NULL CHECK(LEN(LTRIM(RTRIM(Nombre)))>0),Creada datetime2 NOT NULL DEFAULT SYSDATETIME(),
  Variante nvarchar(20) NOT NULL CHECK(Variante IN(N'Recomendada',N'Economica')),Total decimal(18,2) NOT NULL,
  TipoPieza nvarchar(50) NOT NULL,Presupuesto decimal(18,2) NOT NULL,Desde datetime2 NOT NULL,Hasta datetime2 NOT NULL,
  Personas int NOT NULL,Camaras int NOT NULL,Locacion nvarchar(20) NOT NULL,Luz nvarchar(20) NOT NULL,HorasJornada int NOT NULL,
  CamaraEnMovimiento bit NOT NULL,SonidoDirecto bit NOT NULL,Monitoreo bit NOT NULL,LookCinematografico bit NOT NULL);
GO
CREATE OR ALTER PROCEDURE dbo.sp_Propuesta_Guardar
 @UsuarioId int,@Nombre nvarchar(100),@Variante nvarchar(20),@Total decimal(18,2),@TipoPieza nvarchar(50),@Presupuesto decimal(18,2),
 @Desde datetime2,@Hasta datetime2,@Personas int,@Camaras int,@Locacion nvarchar(20),@Luz nvarchar(20),@HorasJornada int,
 @CamaraEnMovimiento bit,@SonidoDirecto bit,@Monitoreo bit,@LookCinematografico bit,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON;
 INSERT dbo.PropuestaGuardada(UsuarioId,Nombre,Variante,Total,TipoPieza,Presupuesto,Desde,Hasta,Personas,Camaras,Locacion,Luz,HorasJornada,
  CamaraEnMovimiento,SonidoDirecto,Monitoreo,LookCinematografico)
 VALUES(@UsuarioId,LTRIM(RTRIM(@Nombre)),@Variante,@Total,@TipoPieza,@Presupuesto,@Desde,@Hasta,@Personas,@Camaras,@Locacion,@Luz,@HorasJornada,
  @CamaraEnMovimiento,@SonidoDirecto,@Monitoreo,@LookCinematografico);
 SET @Resultado=CONVERT(int,SCOPE_IDENTITY()); END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Propuesta_Listar @UsuarioId int AS
 BEGIN SET NOCOUNT ON; SELECT * FROM dbo.PropuestaGuardada WHERE UsuarioId=@UsuarioId ORDER BY Creada DESC,Id DESC; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Propuesta_Eliminar @Id int,@UsuarioId int,@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; DELETE dbo.PropuestaGuardada WHERE Id=@Id AND UsuarioId=@UsuarioId; SET @Resultado=@@ROWCOUNT; END;
GO
-- ===== Fuente: 13_SinGarantia.sql =====
USE [TC-AlquilerAudiovisual];
GO
-- El sistema ya no maneja garantía: solo seña y el seguro predefinido del cliente.
-- Las columnas de garantía se conservan en 0 por compatibilidad; los cargos de una devolución quedan como saldo pendiente.
UPDATE dbo.Reserva SET GarantiaRequerida=0,Garantia=0 WHERE GarantiaRequerida<>0 OR Garantia<>0;
UPDATE dbo.Devolucion SET GarantiaAplicada=0,GarantiaDevuelta=0 WHERE GarantiaAplicada<>0 OR GarantiaDevuelta<>0;
GO
DECLARE @nombre sysname,@def nvarchar(max);
DECLARE c CURSOR LOCAL FAST_FORWARD FOR
 SELECT OBJECT_NAME(object_id),definition FROM sys.sql_modules
 WHERE object_id IN(OBJECT_ID(N'dbo.sp_Reserva_RegistrarEntrega'),OBJECT_ID(N'dbo.sp_Reserva_Confirmar'))
 AND (definition LIKE N'%la seña y la garantía antes%' OR definition LIKE N'%seña o garantía no coinciden%');
OPEN c; FETCH NEXT FROM c INTO @nombre,@def;
WHILE @@FETCH_STATUS=0
BEGIN
 SET @def=REPLACE(@def,N'la seña y la garantía antes',N'la seña antes');
 SET @def=REPLACE(@def,N'Importe, seña o garantía no coinciden',N'Importe o seña no coinciden');
 SET @def=N'ALTER '+SUBSTRING(@def,CHARINDEX(N'PROCEDURE',@def),LEN(@def));
 EXEC(@def);
 FETCH NEXT FROM c INTO @nombre,@def;
END;
CLOSE c; DEALLOCATE c;
GO
-- ===== Fuente: 14_EquiposLibres.sql =====
USE [TC-AlquilerAudiovisual];
GO
-- Un equipo con una solicitud pendiente en esas fechas ya "fue tomado": no se ofrece en el catálogo ni se recomienda.
-- EquiposDisponibles (solo compromisos firmes) se conserva para que stock pueda aceptar una solicitud pendiente.
CREATE OR ALTER FUNCTION dbo.EquiposLibres(@Desde datetime2,@Hasta datetime2)
RETURNS TABLE AS RETURN
(
 SELECT d.Id FROM dbo.EquiposDisponibles(@Desde,@Hasta) d JOIN dbo.Equipo e ON e.Id=d.Id
 WHERE NOT EXISTS(
  SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id=re.ReservaId
  WHERE re.EquipoId=e.Id AND r.Estado=N'Pendiente'
   AND @Desde<DATEADD(DAY,re.DiasReacondicionamiento,r.Hasta)
   AND r.Desde<DATEADD(DAY,e.DiasReacondicionamiento,@Hasta))
);
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_Libres @Desde datetime2,@Hasta datetime2 AS
 BEGIN SET NOCOUNT ON; SELECT e.* FROM dbo.vEquipo e JOIN dbo.EquiposLibres(@Desde,@Hasta) d ON d.Id=e.Id ORDER BY e.CodigoInventario; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_DisponiblesAsesor @Desde datetime2,@Hasta datetime2 AS
 BEGIN SET NOCOUNT ON;
 -- Las unidades cargadas sin perfil técnico igual se consideran (gama económica, sin etiquetas).
 SELECT e.*,ISNULL(p.Gama,1) Gama,ISNULL(p.Etiquetas,N'') Etiquetas,
  ISNULL(p.Ventaja,N'Unidad del inventario sin perfil técnico cargado.') Ventaja,
  ISNULL(p.Limitacion,N'Sin datos técnicos para comparar.') Limitacion FROM dbo.vEquipo e
 JOIN dbo.EquiposLibres(@Desde,@Hasta) d ON d.Id=e.Id LEFT JOIN dbo.EquipoPerfil p ON p.EquipoId=e.Id
 ORDER BY e.Categoria,e.CodigoInventario; END;
GO
-- Una solicitud nueva no puede tomar una unidad que ya tiene otra solicitud pendiente en esas fechas.
DECLARE @def nvarchar(max)=OBJECT_DEFINITION(OBJECT_ID(N'dbo.sp_Reserva_Insertar'));
IF @def LIKE N'%dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=x.EquipoId%'
BEGIN
 SET @def=REPLACE(@def,N'dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=x.EquipoId',N'dbo.EquiposLibres(@Desde,@Hasta) d ON d.Id=x.EquipoId');
 SET @def=N'ALTER '+SUBSTRING(@def,CHARINDEX(N'PROCEDURE',@def),LEN(@def));
 EXEC(@def);
END;
GO
-- ===== Fuente: 15_Cancelacion.sql =====
USE [TC-AlquilerAudiovisual];
GO
-- El cliente puede cancelar su pedido mientras esté pendiente de revisión o aceptado sin pagar.
IF EXISTS(SELECT 1 FROM sys.check_constraints WHERE name=N'CK_Reserva_EstadoSolicitud' AND parent_object_id=OBJECT_ID(N'dbo.Reserva'))
 ALTER TABLE dbo.Reserva DROP CONSTRAINT CK_Reserva_EstadoSolicitud;
ALTER TABLE dbo.Reserva WITH CHECK ADD CONSTRAINT CK_Reserva_EstadoSolicitud
 CHECK(Estado IN(N'Pendiente',N'Rechazada',N'Cancelada',N'Aceptada',N'Firme',N'Entregada',N'ConIncidencia',N'Cerrada'));
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Cancelar @ReservaId int,@UsuarioId int,@Resultado int OUTPUT AS
BEGIN
 SET NOCOUNT ON;
 -- La condición de estado va en el UPDATE: si otra persona la procesó antes, no se cancela nada.
 UPDATE r SET Estado=N'Cancelada'
 FROM dbo.Reserva r JOIN dbo.Cliente c ON c.Id=r.ClienteId
 WHERE r.Id=@ReservaId AND c.UsuarioId=@UsuarioId AND r.Estado IN(N'Pendiente',N'Aceptada');
 SET @Resultado=@@ROWCOUNT;
END;
GO
USE [TC-AlquilerAudiovisual];
GO
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO
-- ===== Datos actuales =====
SET NOCOUNT ON;
-- dbo.Usuario (4 filas)
SET IDENTITY_INSERT dbo.[Usuario] ON;
INSERT dbo.[Usuario] ([Id],[NombreUsuario],[Hash],[Sal],[Rol],[Activo],[TipoSeguro],[SeguroId],[Nombre],[DniCuit],[Telefono],[Email]) VALUES (1,N'admin',0xF0493C516849A667512771A051E949E042E20025DD577287B71C938F4E5A0521,0x5B755B3F00770928AD6D03C22FDF070A,N'Administrador',1,N'Basico',NULL,N'admin',N'20000001',N'1100000000',N'admin@foco.com');
INSERT dbo.[Usuario] ([Id],[NombreUsuario],[Hash],[Sal],[Rol],[Activo],[TipoSeguro],[SeguroId],[Nombre],[DniCuit],[Telefono],[Email]) VALUES (2,N'stock',0xB97961485EFC244879136C11E9DC35981DA05A044ABB681FE03884F62CAC481D,0xD7CDB1D4C8FD4C5546E85EA75D33E52F,N'EncargadoStock',1,N'SinSeguro',NULL,N'stock',N'20000002',N'1100000000',N'stock@foco.com');
INSERT dbo.[Usuario] ([Id],[NombreUsuario],[Hash],[Sal],[Rol],[Activo],[TipoSeguro],[SeguroId],[Nombre],[DniCuit],[Telefono],[Email]) VALUES (3,N'cliente',0xD700D7BC119716E30001B63AEDA403E261220CEF4DD0B8AA32544728EEF1E390,0xF34D9C61069F2C4663AF4739E1465403,N'Cliente',1,N'Basico',NULL,N'cliente',N'20000003',N'1100000000',N'cliente@foco.com');
INSERT dbo.[Usuario] ([Id],[NombreUsuario],[Hash],[Sal],[Rol],[Activo],[TipoSeguro],[SeguroId],[Nombre],[DniCuit],[Telefono],[Email]) VALUES (4,N'tecnico',0xB330F18E614EA7E5124F5D114FBF48EA88E31C74AC20F7EF23B911D469F757B5,0x2053A80D05254300A82C0AFE91F7B050,N'Tecnico',1,N'SinSeguro',NULL,N'tecnico',N'20000004',N'1100000000',N'tecnico@foco.com');
SET IDENTITY_INSERT dbo.[Usuario] OFF;
-- dbo.Cliente (2 filas)
SET IDENTITY_INSERT dbo.[Cliente] ON;
INSERT dbo.[Cliente] ([Id],[UsuarioId],[DniCuit],[Nombre],[Telefono],[Email],[AntecedenteNegativo]) VALUES (1,1,N'20000001',N'admin',N'1100000000',N'admin@foco.com',0);
INSERT dbo.[Cliente] ([Id],[UsuarioId],[DniCuit],[Nombre],[Telefono],[Email],[AntecedenteNegativo]) VALUES (2,3,N'20000003',N'cliente',N'1100000000',N'cliente@foco.com',0);
SET IDENTITY_INSERT dbo.[Cliente] OFF;
-- dbo.Seguro (2 filas)
SET IDENTITY_INSERT dbo.[Seguro] ON;
INSERT dbo.[Seguro] ([Id],[ClienteId],[Poliza],[Aseguradora],[Desde],[Hasta],[Cobertura],[Tipo],[Detalle]) VALUES (3,1,N'USUARIO-1',N'Seguro académico',CONVERT(datetime2,'2026-11-01T00:00:00.0000000',126),CONVERT(datetime2,'2028-11-01T00:00:00.0000000',126),500000.00,N'Basico',N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.');
INSERT dbo.[Seguro] ([Id],[ClienteId],[Poliza],[Aseguradora],[Desde],[Hasta],[Cobertura],[Tipo],[Detalle]) VALUES (5,2,N'USUARIO-3',N'Seguro académico',CONVERT(datetime2,'2026-11-01T00:00:00.0000000',126),CONVERT(datetime2,'2028-11-01T00:00:00.0000000',126),500000.00,N'Basico',N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.');
SET IDENTITY_INSERT dbo.[Seguro] OFF;
UPDATE dbo.[Usuario] SET [SeguroId]=3 WHERE [Id]=1;
UPDATE dbo.[Usuario] SET [SeguroId]=5 WHERE [Id]=3;
-- dbo.Equipo (51 filas)
SET IDENTITY_INSERT dbo.[Equipo] ON;
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (1,NULL,N'DEMO-001',N'SERIE-DEMO-1',N'Cámara',N'Ejemplo',N'Cámara 4K',N'Camara',N'Disponible',15000.00,500000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (2,NULL,N'DEMO-002',N'SERIE-DEMO-2',N'Iluminación',N'Ejemplo',N'Panel LED',N'Panel LED',N'Disponible',5000.00,150000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (3,NULL,N'DEMO-003',N'SERIE-DEMO-3',N'Audio',N'Ejemplo',N'Micrófono',N'Unidad para la entrega académica N01',N'Disponible',3000.00,80000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (4,NULL,N'CAM-001',N'SN-CAM-001',N'Cámara',N'Sony',N'Alpha a6700',N'Sony Alpha a6700',N'Disponible',18000.00,1500000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (5,NULL,N'CAM-002',N'SN-CAM-002',N'Cámara',N'Sony',N'Alpha a7 IV',N'Sony Alpha a7 IV',N'Disponible',28000.00,2800000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (6,NULL,N'CAM-003',N'SN-CAM-003',N'Cámara',N'Sony',N'Alpha a7S III',N'Sony Alpha a7S III',N'Disponible',48000.00,4800000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (7,NULL,N'CAM-004',N'SN-CAM-004',N'Cámara',N'Sony',N'FX3 Cinema Line',N'Sony FX3 Cinema Line',N'Disponible',45000.00,5200000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (8,NULL,N'CAM-005',N'SN-CAM-005',N'Cámara',N'Canon',N'EOS R6 Mark II',N'Canon EOS R6 Mark II',N'Disponible',30000.00,3000000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (9,NULL,N'CAM-006',N'SN-CAM-006',N'Cámara',N'Canon',N'EOS C70',N'Canon EOS C70',N'Disponible',55000.00,6500000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (10,NULL,N'CAM-007',N'SN-CAM-007',N'Cámara',N'Blackmagic',N'Pocket Cinema 6K Pro',N'Blackmagic Pocket Cinema 6K Pro',N'Disponible',32000.00,3500000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (11,NULL,N'LEN-001',N'SN-LEN-001',N'Lente',N'Sony',N'FE 24-70mm f/2.8 GM II',N'Sony FE 24-70mm f/2.8 GM II',N'Disponible',14000.00,2400000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (12,NULL,N'LEN-002',N'SN-LEN-002',N'Lente',N'Sony',N'FE 50mm f/1.8',N'Sony FE 50mm f/1.8',N'Disponible',5000.00,350000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (13,NULL,N'LEN-003',N'SN-LEN-003',N'Lente',N'Sony',N'FE 16-35mm f/2.8 GM',N'Sony FE 16-35mm f/2.8 GM',N'Disponible',13000.00,2600000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (14,NULL,N'LEN-004',N'SN-LEN-004',N'Lente',N'Samyang',N'VDSLR 35mm T1.5 Cine',N'Samyang VDSLR 35mm T1.5 Cine',N'Disponible',8000.00,700000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (15,NULL,N'LEN-005',N'SN-LEN-005',N'Lente',N'Canon',N'RF 24-70mm f/2.8L',N'Canon RF 24-70mm f/2.8L',N'Disponible',15000.00,2800000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (16,NULL,N'LEN-006',N'SN-LEN-006',N'Lente',N'Canon',N'RF 50mm f/1.8',N'Canon RF 50mm f/1.8',N'Disponible',4500.00,300000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (17,NULL,N'LEN-007',N'SN-LEN-007',N'Lente',N'Sigma',N'18-35mm f/1.8 Art',N'Sigma 18-35mm f/1.8 Art',N'Disponible',9000.00,1000000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (18,NULL,N'LEN-008',N'SN-LEN-008',N'Lente',N'Canon',N'EF 24-70mm f/2.8L II',N'Canon EF 24-70mm f/2.8L II',N'Disponible',10000.00,1500000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (19,NULL,N'LUZ-001',N'SN-LUZ-001',N'Iluminación',N'Godox',N'SL60W',N'Godox SL60W',N'Disponible',5500.00,200000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (20,NULL,N'LUZ-002',N'SN-LUZ-002',N'Iluminación',N'Godox',N'SL60W',N'Godox SL60W',N'Disponible',5500.00,200000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (21,NULL,N'LUZ-003',N'SN-LUZ-003',N'Iluminación',N'Nanlite',N'Forza 60B',N'Nanlite Forza 60B',N'Disponible',8000.00,500000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (22,NULL,N'LUZ-004',N'SN-LUZ-004',N'Iluminación',N'Aputure',N'Amaran 200x S',N'Aputure Amaran 200x S',N'Disponible',9000.00,450000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (23,NULL,N'LUZ-005',N'SN-LUZ-005',N'Iluminación',N'Aputure',N'Amaran 200x S',N'Aputure Amaran 200x S',N'Disponible',9000.00,450000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (24,NULL,N'LUZ-006',N'SN-LUZ-006',N'Iluminación',N'Aputure',N'LS 300d II',N'Aputure LS 300d II',N'Disponible',16000.00,1200000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (25,NULL,N'LUZ-007',N'SN-LUZ-007',N'Iluminación',N'Aputure',N'Nova P300c',N'Aputure Nova P300c',N'Disponible',18000.00,1800000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (26,NULL,N'LUZ-008',N'SN-LUZ-008',N'Iluminación',N'Nanlite',N'PavoTube II 15C',N'Nanlite PavoTube II 15C',N'Disponible',4500.00,160000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (27,NULL,N'LUZ-009',N'SN-LUZ-009',N'Iluminación',N'Nanlite',N'PavoTube II 15C',N'Nanlite PavoTube II 15C',N'Disponible',4500.00,160000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (28,NULL,N'LUZ-010',N'SN-LUZ-010',N'Iluminación',N'Aputure',N'Light Dome II',N'Aputure Light Dome II',N'Disponible',4000.00,250000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (29,NULL,N'LUZ-011',N'SN-LUZ-011',N'Iluminación',N'Neewer',N'Reflector 5 en 1 110cm',N'Neewer Reflector 5 en 1 110cm',N'Disponible',1800.00,40000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (30,NULL,N'LUZ-012',N'SN-LUZ-012',N'Iluminación',N'Neewer',N'Reflector 5 en 1 110cm',N'Neewer Reflector 5 en 1 110cm',N'Disponible',1800.00,40000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (31,NULL,N'EST-001',N'SN-EST-001',N'Estabilizador',N'Zhiyun',N'Crane M3',N'Zhiyun Crane M3',N'Disponible',7000.00,280000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (32,NULL,N'EST-002',N'SN-EST-002',N'Estabilizador',N'DJI',N'RS 3',N'DJI RS 3',N'Disponible',12000.00,650000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (33,NULL,N'EST-003',N'SN-EST-003',N'Estabilizador',N'DJI',N'RS 3 Pro',N'DJI RS 3 Pro',N'Disponible',20000.00,1100000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (34,NULL,N'EST-004',N'SN-EST-004',N'Estabilizador',N'Rhino',N'Slider motorizado 80cm',N'Rhino Slider motorizado 80cm',N'Disponible',9000.00,500000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (35,NULL,N'SOP-001',N'SN-SOP-001',N'Soporte',N'Manfrotto',N'MVK504 cabeza fluida',N'Manfrotto MVK504 cabeza fluida',N'Disponible',6000.00,300000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (36,NULL,N'SOP-002',N'SN-SOP-002',N'Soporte',N'Manfrotto',N'MVK504 cabeza fluida',N'Manfrotto MVK504 cabeza fluida',N'Disponible',6000.00,300000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (37,NULL,N'SOP-003',N'SN-SOP-003',N'Soporte',N'Sachtler',N'Ace XL',N'Sachtler Ace XL',N'Disponible',10000.00,600000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (38,NULL,N'MON-001',N'SN-MON-001',N'Monitor',N'SmallHD',N'Focus 5',N'SmallHD Focus 5',N'Disponible',5000.00,250000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (39,NULL,N'MON-002',N'SN-MON-002',N'Monitor',N'Atomos',N'Ninja V 5',N'Atomos Ninja V 5',N'Disponible',8000.00,450000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (40,NULL,N'MON-003',N'SN-MON-003',N'Monitor',N'SmallHD',N'Cine 7',N'SmallHD Cine 7',N'Disponible',14000.00,1300000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (41,NULL,N'AUD-001',N'SN-AUD-001',N'Audio',N'Rode',N'Wireless GO II',N'Rode Wireless GO II',N'Disponible',6000.00,350000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (42,NULL,N'AUD-002',N'SN-AUD-002',N'Audio',N'Rode',N'Wireless GO II',N'Rode Wireless GO II',N'Disponible',6000.00,350000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (43,NULL,N'AUD-003',N'SN-AUD-003',N'Audio',N'Sennheiser',N'EW 112P G4',N'Sennheiser EW 112P G4',N'Disponible',9000.00,700000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (44,NULL,N'AUD-004',N'SN-AUD-004',N'Audio',N'Sennheiser',N'EW 112P G4',N'Sennheiser EW 112P G4',N'Disponible',9000.00,700000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (45,NULL,N'AUD-005',N'SN-AUD-005',N'Audio',N'Sennheiser',N'EW 112P G4',N'Sennheiser EW 112P G4',N'Disponible',9000.00,700000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (46,NULL,N'AUD-006',N'SN-AUD-006',N'Audio',N'Rode',N'NTG4+',N'Rode NTG4+',N'Disponible',4500.00,250000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (47,NULL,N'AUD-007',N'SN-AUD-007',N'Audio',N'Sennheiser',N'MKH 416',N'Sennheiser MKH 416',N'Disponible',10000.00,1000000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (48,NULL,N'AUD-008',N'SN-AUD-008',N'Audio',N'Zoom',N'F3 32-bit float',N'Zoom F3 32-bit float',N'Disponible',7000.00,500000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (49,NULL,N'AUD-009',N'SN-AUD-009',N'Audio',N'K-Tek',N'Pértiga de carbono',N'K-Tek Pértiga de carbono',N'Disponible',2500.00,120000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (50,NULL,N'ENE-001',N'SN-ENE-001',N'Energía',N'Core SWX',N'Kit 2 baterías V-mount 98Wh',N'Core SWX Kit 2 baterías V-mount 98Wh',N'Disponible',5000.00,300000.00,1);
INSERT dbo.[Equipo] ([Id],[SeguroId],[CodigoInventario],[Serie],[Categoria],[Marca],[Modelo],[Descripcion],[Estado],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento]) VALUES (51,NULL,N'ENE-002',N'SN-ENE-002',N'Energía',N'Core SWX',N'Kit 2 baterías V-mount 98Wh',N'Core SWX Kit 2 baterías V-mount 98Wh',N'Disponible',5000.00,300000.00,1);
SET IDENTITY_INSERT dbo.[Equipo] OFF;
-- dbo.EquipoPerfil (51 filas)
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (1,1,N'montura:kit;4k;peso:0.8;kit-lente',N'Cámara 4K con lente incluido: lista para usar.',N'Óptica y sensor básicos.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (2,1,N'luz:key;potencia:60;daylight',N'Panel LED simple para entrevistas.',N'Potencia limitada.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (3,1,N'audio:lavalier;cubre:1;inalambrico',N'Micrófono básico de uso general.',N'Calidad de audio básica.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (4,1,N'montura:E;4k;peso:0.5;liviana',N'Liviana y con enfoque automático confiable: ideal para moverse y para estabilizadores chicos.',N'Sensor APS-C: rinde menos con poca luz.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (5,2,N'montura:E;4k;fullframe;baja-luz;peso:0.66',N'Full frame versátil con muy buen rendimiento con poca luz.',N'Sin ventilación activa: puede recalentarse en tomas largas.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (6,3,N'montura:E;4k;fullframe;baja-luz;baja-luz-extrema;peso:0.66',N'Rendimiento excepcional en penumbra y grabación sin límite de tiempo.',N'12 MP: menos resolución para recortes en posproducción.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (7,3,N'montura:E;4k;fullframe;baja-luz;cine;peso:0.72',N'Cámara de cine compacta, ventilada y con excelente sensibilidad.',N'Cuesta más y suele requerir accesorios de rigging.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (8,2,N'montura:RF;4k;fullframe;baja-luz;peso:0.67',N'Colores de piel naturales y estabilización interna efectiva.',N'Sin ventilación activa: tomas largas con riesgo de recalentamiento.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (9,3,N'montura:RF;4k;baja-luz;cine;nd-interno;peso:1.2',N'ND interno y doble ganancia: rinde igual de bien en exterior y con poca luz.',N'Más pesada y más cara; exige soportes robustos.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (10,2,N'montura:EF;6k;cine;nd-interno;peso:0.9',N'Imagen de cine en RAW a costo medio y ND interno.',N'Batería de poca duración y autofocus limitado.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (11,3,N'montura:E;zoom;f2.8;peso:0.7',N'Zoom luminoso y versátil: cubre casi todo el set con un solo lente.',N'Pesado para tomas largas en mano.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (12,1,N'montura:E;fijo;f1.8;peso:0.2',N'Muy luminoso, económico y liviano; fondo desenfocado.',N'Focal fija: obliga a moverse para encuadrar.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (13,3,N'montura:E;zoom;angular;f2.8;peso:0.68',N'Gran angular ideal para interiores chicos y locaciones.',N'Distorsiona rostros si se usa muy cerca.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (14,2,N'montura:E;fijo;cine;t1.5;peso:0.7',N'Look de cine con aro de foco dentado, apto para follow focus.',N'Foco manual: requiere asistente o práctica.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (15,3,N'montura:RF;zoom;f2.8;peso:0.9',N'Zoom profesional con muy buena nitidez y estabilización.',N'Pesado y de costo alto.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (16,1,N'montura:RF;fijo;f1.8;peso:0.16',N'Económico y liviano con gran luminosidad.',N'Focal fija, sin estabilización propia.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (17,2,N'montura:EF;zoom;f1.8;cine;peso:0.8',N'Zoom con f/1.8 constante y look cinematográfico.',N'Pesado y sin autofocus ágil.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (18,2,N'montura:EF;zoom;f2.8;peso:0.8',N'Zoom clásico de trabajo, confiable y versátil.',N'Sin estabilización de imagen.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (19,1,N'luz:key;potencia:60;daylight',N'Luz continua económica, ideal para entrevistas.',N'Potencia limitada: no compite con la luz solar.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (20,1,N'luz:key;potencia:60;daylight',N'Luz continua económica, ideal para entrevistas.',N'Potencia limitada: no compite con la luz solar.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (21,2,N'luz:key;potencia:60;bicolor;compacta',N'Bicolor, compacta y silenciosa: ajusta la temperatura de color.',N'Potencia moderada para espacios grandes.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (22,2,N'luz:key;potencia:200;bicolor',N'Potencia media con bicolor: sirve de luz principal en interiores.',N'Necesita difusor para luz suave.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (23,2,N'luz:key;potencia:200;bicolor',N'Potencia media con bicolor: sirve de luz principal en interiores.',N'Necesita difusor para luz suave.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (24,3,N'luz:key;potencia:300;daylight;alta-potencia;exterior',N'Alta potencia: equilibra ventanas y rinde en exteriores.',N'Pesada, requiere alimentación robusta.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (25,3,N'luz:panel;potencia:300;rgb;suave',N'Panel RGB grande de luz suave, ideal para publicidad y videoclip.',N'Es voluminoso y caro.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (26,1,N'luz:efecto;rgb;compacta',N'Tubo RGB para fondos y toques de color.',N'No sirve como luz principal.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (27,1,N'luz:efecto;rgb;compacta',N'Tubo RGB para fondos y toques de color.',N'No sirve como luz principal.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (28,2,N'luz:difusor;suave',N'Softbox parabólico: luz suave y favorecedora para rostros.',N'Agrega tiempo de armado.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (29,1,N'luz:reflector;exterior;rebote',N'Rebota la luz del sol sin consumir energía.',N'Depende del sol y de un asistente.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (30,1,N'luz:reflector;exterior;rebote',N'Rebota la luz del sol sin consumir energía.',N'Depende del sol y de un asistente.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (31,1,N'gimbal;carga:1.2;compacta',N'Compacto y fácil de llevar para cámaras livianas.',N'Soporta poco peso: solo cámaras chicas con lente liviano.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (32,2,N'gimbal;carga:3',N'Cubre la mayoría de las mirrorless con lentes medios.',N'Con cámaras de cine pesadas queda al límite.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (33,3,N'gimbal;carga:4.5',N'Soporta cámaras de cine y accesorios.',N'Más pesado y más caro.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (34,2,N'slider;movimiento-lento',N'Movimientos suaves de cámara para planos de producto o entrevista.',N'Solo movimientos lineales cortos.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (35,1,N'tripode;carga:4;fluido',N'Trípode fluido económico para cámaras livianas.',N'Soporta poco peso.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (36,1,N'tripode;carga:4;fluido',N'Trípode fluido económico para cámaras livianas.',N'Soporta poco peso.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (37,2,N'tripode;carga:8;fluido',N'Cabeza fluida firme para cámaras de cine y lentes largos.',N'Más pesado de transportar.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (38,1,N'monitor;5pulg',N'Monitoreo preciso en set con ayudas de enfoque.',N'Pantalla chica y poco brillo al sol.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (39,2,N'monitor;grabador;5pulg',N'Monitorea y graba ProRes/RAW externo.',N'Agrega cables y consumo.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (40,3,N'monitor;7pulg;lut;exterior',N'Gran brillo para exterior, LUTs y ayudas de cine.',N'Pesado y de costo alto.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (41,1,N'audio:lavalier;cubre:2;inalambrico',N'Dos micrófonos inalámbricos en un solo kit, muy simple de usar.',N'Alcance y robustez inferiores a un sistema profesional.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (42,1,N'audio:lavalier;cubre:2;inalambrico',N'Dos micrófonos inalámbricos en un solo kit, muy simple de usar.',N'Alcance y robustez inferiores a un sistema profesional.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (43,2,N'audio:lavalier;cubre:1;inalambrico;profesional',N'Transmisión estable y calidad profesional de broadcast.',N'Cubre una sola persona por kit.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (44,2,N'audio:lavalier;cubre:1;inalambrico;profesional',N'Transmisión estable y calidad profesional de broadcast.',N'Cubre una sola persona por kit.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (45,2,N'audio:lavalier;cubre:1;inalambrico;profesional',N'Transmisión estable y calidad profesional de broadcast.',N'Cubre una sola persona por kit.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (46,1,N'audio:boom;cubre:3;direccional',N'Shotgun liviano con buen rechazo lateral.',N'Necesita pértiga y operador.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (47,3,N'audio:boom;cubre:3;direccional;exterior',N'Referencia de la industria para diálogo en exteriores.',N'Costoso y requiere pértiga y grabador.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (48,2,N'audio:grabador;float',N'Grabación 32-bit float: no distorsiona ni se queda corto de nivel.',N'Requiere sincronizar con la imagen.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (49,2,N'audio:pertiga',N'Pértiga liviana para operar el micrófono sin entrar en cuadro.',N'Requiere un operador dedicado.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (50,2,N'energia;jornada-larga',N'Respaldo de energía para cámara, monitor y luces durante jornadas largas.',N'Suma peso al rig.');
INSERT dbo.[EquipoPerfil] ([EquipoId],[Gama],[Etiquetas],[Ventaja],[Limitacion]) VALUES (51,2,N'energia;jornada-larga',N'Respaldo de energía para cámara, monitor y luces durante jornadas largas.',N'Suma peso al rig.');
-- dbo.Reserva (2 filas)
SET IDENTITY_INSERT dbo.[Reserva] ON;
INSERT dbo.[Reserva] ([Id],[ClienteId],[Desde],[Hasta],[Importe],[Sena],[Garantia],[Estado],[NumeroContrato],[NumeroRemito],[ContratoFirmado],[SenaRequerida],[GarantiaRequerida]) VALUES (8,1,CONVERT(datetime2,'2026-11-01T08:09:06.6323702',126),CONVERT(datetime2,'2026-11-03T08:09:06.0000000',126),30000.00,9000.00,0.00,N'Cerrada',N'C-8',N'R-8',1,9000.00,0.00);
INSERT dbo.[Reserva] ([Id],[ClienteId],[Desde],[Hasta],[Importe],[Sena],[Garantia],[Estado],[NumeroContrato],[NumeroRemito],[ContratoFirmado],[SenaRequerida],[GarantiaRequerida]) VALUES (10,2,CONVERT(datetime2,'2026-11-01T18:21:24.5011239',126),CONVERT(datetime2,'2026-11-03T18:21:24.0000000',126),36000.00,10800.00,0.00,N'Cerrada',N'C-10',N'R-10',1,10800.00,0.00);
SET IDENTITY_INSERT dbo.[Reserva] OFF;
-- dbo.ReservaEquipo (2 filas)
INSERT dbo.[ReservaEquipo] ([ReservaId],[EquipoId],[SeguroId],[CoberturaSeguro],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento],[EstadoEntrega],[TipoSeguro],[DetalleSeguro],[PolizaSeguro],[AseguradoraSeguro],[DesdeSeguro],[HastaSeguro]) VALUES (8,1,3,500000.00,15000.00,500000.00,1,N'Disponible',N'Basico',N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.',N'USUARIO-1',N'Seguro académico',CONVERT(datetime2,'2026-11-01T00:00:00.0000000',126),CONVERT(datetime2,'2028-11-01T00:00:00.0000000',126));
INSERT dbo.[ReservaEquipo] ([ReservaId],[EquipoId],[SeguroId],[CoberturaSeguro],[TarifaDiaria],[ValorReposicion],[DiasReacondicionamiento],[EstadoEntrega],[TipoSeguro],[DetalleSeguro],[PolizaSeguro],[AseguradoraSeguro],[DesdeSeguro],[HastaSeguro]) VALUES (10,4,5,500000.00,18000.00,1500000.00,1,N'Disponible',N'Basico',N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.',N'USUARIO-3',N'Seguro académico',CONVERT(datetime2,'2026-11-01T00:00:00.0000000',126),CONVERT(datetime2,'2028-11-01T00:00:00.0000000',126));
-- dbo.Devolucion (2 filas)
SET IDENTITY_INSERT dbo.[Devolucion] ON;
INSERT dbo.[Devolucion] ([Id],[ReservaId],[Fecha],[Conforme],[ClientePresente],[Finalizada],[Observaciones],[GarantiaAplicada],[GarantiaDevuelta],[SaldoPendiente]) VALUES (5,8,CONVERT(datetime2,'2026-11-01T08:09:56.3998529',126),1,1,1,N'',0.00,0.00,0.00);
INSERT dbo.[Devolucion] ([Id],[ReservaId],[Fecha],[Conforme],[ClientePresente],[Finalizada],[Observaciones],[GarantiaAplicada],[GarantiaDevuelta],[SaldoPendiente]) VALUES (7,10,CONVERT(datetime2,'2026-11-01T18:30:07.6966898',126),0,1,1,N'',0.00,0.00,1200000.00);
SET IDENTITY_INSERT dbo.[Devolucion] OFF;
-- dbo.Incidencia (1 filas)
SET IDENTITY_INSERT dbo.[Incidencia] ON;
INSERT dbo.[Incidencia] ([Id],[DevolucionId],[EquipoId],[Tipo],[Descripcion],[Cargo],[Estado],[FechaAltaTecnica],[CargoBase],[DescuentoSeguro],[MostrarEnAntecedentes]) VALUES (5,7,4,N'DañoTotal',N'se rompió todo',1200000.00,N'Cerrada',CONVERT(datetime2,'2026-11-01T18:32:10.9150742',126),1200000.00,0.00,1);
SET IDENTITY_INSERT dbo.[Incidencia] OFF;
-- dbo.PropuestaGuardada (1 filas)
SET IDENTITY_INSERT dbo.[PropuestaGuardada] ON;
INSERT dbo.[PropuestaGuardada] ([Id],[UsuarioId],[Nombre],[Creada],[Variante],[Total],[TipoPieza],[Presupuesto],[Desde],[Hasta],[Personas],[Camaras],[Locacion],[Luz],[HorasJornada],[CamaraEnMovimiento],[SonidoDirecto],[Monitoreo],[LookCinematografico]) VALUES (2,1,N'Propuesta1',CONVERT(datetime2,'2026-11-01T17:50:51.7427658',126),N'Recomendada',98000.00,N'Streaming / podcast',100000.00,CONVERT(datetime2,'2026-11-02T09:00:00.0000000',126),CONVERT(datetime2,'2026-11-03T09:00:00.0000000',126),2,1,N'Interior',N'Media',8,0,1,0,0);
SET IDENTITY_INSERT dbo.[PropuestaGuardada] OFF;
GO
PRINT N'Restauracion de TC-AlquilerAudiovisual completada.';
GO

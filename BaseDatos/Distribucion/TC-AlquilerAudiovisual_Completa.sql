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
 WHERE u.Rol=N'Cliente';
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
  IF @Rol<>N'Cliente' AND @TipoSeguro<>N'SinSeguro'
   THROW 50032,N'El seguro de alquiler corresponde a cuentas Cliente.',1;
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
 SELECT * FROM dbo.vUsuario WHERE Id=@UsuarioId AND Rol=N'Cliente';
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
   WHERE c.Id=@ClienteId AND u.Id=@UsuarioId AND u.Rol=N'Cliente' AND u.Activo=1)
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
 IF @Rol<>N'Cliente' AND EXISTS(SELECT 1 FROM dbo.Cliente WHERE UsuarioId=@UsuarioId)
   THROW 50002,N'La cuenta tiene una ficha de cliente; debe conservar el rol Cliente.',1;
 UPDATE dbo.Usuario SET Rol=@Rol WHERE Id=@UsuarioId;
 SET @Resultado=CASE WHEN @@ROWCOUNT=1 THEN 1 ELSE 0 END;
 IF @Rol<>N'Cliente' UPDATE dbo.Usuario SET TipoSeguro=N'SinSeguro',SeguroId=NULL WHERE Id=@UsuarioId;
 END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Cliente_Insertar
 @UsuarioId int,@DniCuit nvarchar(13),@Nombre nvarchar(100),@Telefono nvarchar(30),@Email nvarchar(150),@Resultado int OUTPUT AS
 BEGIN SET NOCOUNT ON; SET XACT_ABORT ON;
 BEGIN TRY
 BEGIN TRANSACTION;
 IF NOT EXISTS(SELECT 1 FROM dbo.Usuario WHERE Id=@UsuarioId AND Rol=N'Cliente' AND Activo=1)
   THROW 50003,N'Seleccioná una cuenta activa con rol Cliente.',1;
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
   WHERE c.Id=@ClienteId AND u.Activo=1 AND u.Rol=N'Cliente')
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
   THROW 50018,N'Importe, seña o garantía no coinciden con la cotización actual.',1;
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
   THROW 50203,N'El cliente debe pagar la seña y la garantía antes de la entrega.',1;
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
				THROW 50203,N'El cliente debe pagar la seña y la garantía antes de la entrega.',1;
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

-- ===== Datos actuales de la base de origen =====
USE [TC-AlquilerAudiovisual];
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;
SET IDENTITY_INSERT dbo.[Usuario] ON;
INSERT dbo.[Usuario] ([Id], [NombreUsuario], [Hash], [Sal], [Rol], [Activo], [TipoSeguro], [SeguroId]) VALUES (1, N'admin', 0x2FB1312A547579D48EC07E7E36ACC4EEAA2704492C2DD42E19A87A0755601705, 0x4BCB875F06F7A0F29F8D09C37904DE2F, N'Administrador', 1, N'SinSeguro', NULL);
INSERT dbo.[Usuario] ([Id], [NombreUsuario], [Hash], [Sal], [Rol], [Activo], [TipoSeguro], [SeguroId]) VALUES (2, N'stock', 0x41B70F3FC424A8F017CA912E2D8202B77B4B7AA2891B17C069C117C6AA717339, 0x488AB350F8F4124897EC765C48B21059, N'EncargadoStock', 1, N'SinSeguro', NULL);
INSERT dbo.[Usuario] ([Id], [NombreUsuario], [Hash], [Sal], [Rol], [Activo], [TipoSeguro], [SeguroId]) VALUES (3, N'cliente', 0x38F28E03E9D070EB2D7FA39E67FAF98B12C706D1FBFBD09BC1111824DB325390, 0x7A9A07B1C1F5915358111ADAA9D068EF, N'Cliente', 1, N'Basico', NULL);
INSERT dbo.[Usuario] ([Id], [NombreUsuario], [Hash], [Sal], [Rol], [Activo], [TipoSeguro], [SeguroId]) VALUES (4, N'tecnico', 0xA597850CEFD6730C1C62951E633FBB5C658BE7E9D158E7E49CE764CC4A7683D8, 0x5FA0FAC414DF48C7216C5E9BDC160157, N'Tecnico', 1, N'SinSeguro', NULL);
SET IDENTITY_INSERT dbo.[Usuario] OFF;

SET IDENTITY_INSERT dbo.[Cliente] ON;
INSERT dbo.[Cliente] ([Id], [UsuarioId], [DniCuit], [Nombre], [Telefono], [Email], [AntecedenteNegativo]) VALUES (1, 3, N'30123456', N'Cliente de ejemplo', N'1100000000', N'cliente@example.com', 0);
SET IDENTITY_INSERT dbo.[Cliente] OFF;

SET IDENTITY_INSERT dbo.[Seguro] ON;
INSERT dbo.[Seguro] ([Id], [ClienteId], [Poliza], [Aseguradora], [Desde], [Hasta], [Cobertura], [Tipo], [Detalle]) VALUES (1, 1, N'DEMO-N01', N'Aseguradora de ejemplo', CONVERT(datetime2, '2026-10-04T00:00:00.0000000', 126), CONVERT(datetime2, '2028-10-05T00:00:00.0000000', 126), 500000.00, N'Basico', N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.');
SET IDENTITY_INSERT dbo.[Seguro] OFF;

SET IDENTITY_INSERT dbo.[Equipo] ON;
INSERT dbo.[Equipo] ([Id], [SeguroId], [CodigoInventario], [Serie], [Categoria], [Marca], [Modelo], [Descripcion], [Estado], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento]) VALUES (1, 1, N'DEMO-001', N'SERIE-DEMO-1', N'Cámara', N'Ejemplo', N'Cámara 4K', N'Camara', N'Disponible', 15000.00, 500000.00, 1);
INSERT dbo.[Equipo] ([Id], [SeguroId], [CodigoInventario], [Serie], [Categoria], [Marca], [Modelo], [Descripcion], [Estado], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento]) VALUES (2, 1, N'DEMO-002', N'SERIE-DEMO-2', N'Iluminación', N'Ejemplo', N'Panel LED', N'Panel LED', N'Disponible', 5000.00, 150000.00, 1);
INSERT dbo.[Equipo] ([Id], [SeguroId], [CodigoInventario], [Serie], [Categoria], [Marca], [Modelo], [Descripcion], [Estado], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento]) VALUES (3, 1, N'DEMO-003', N'SERIE-DEMO-3', N'Audio', N'Ejemplo', N'Micrófono', N'Unidad para la entrega académica N01', N'Disponible', 3000.00, 80000.00, 1);
SET IDENTITY_INSERT dbo.[Equipo] OFF;

SET IDENTITY_INSERT dbo.[Reserva] ON;
INSERT dbo.[Reserva] ([Id], [ClienteId], [Desde], [Hasta], [Importe], [Sena], [Garantia], [Estado], [NumeroContrato], [NumeroRemito], [ContratoFirmado], [SenaRequerida], [GarantiaRequerida]) VALUES (1, 1, CONVERT(datetime2, '2026-10-05T00:00:00.0000000', 126), CONVERT(datetime2, '2026-10-07T00:00:00.0000000', 126), 30000.00, 9000.00, 100000.00, N'Cerrada', N'C-1', N'R-1', 1, 9000.00, 100000.00);
INSERT dbo.[Reserva] ([Id], [ClienteId], [Desde], [Hasta], [Importe], [Sena], [Garantia], [Estado], [NumeroContrato], [NumeroRemito], [ContratoFirmado], [SenaRequerida], [GarantiaRequerida]) VALUES (2, 1, CONVERT(datetime2, '2026-10-05T00:00:00.0000000', 126), CONVERT(datetime2, '2026-10-07T00:00:00.0000000', 126), 30000.00, 9000.00, 100000.00, N'Cerrada', N'C-2', N'R-2', 1, 9000.00, 100000.00);
INSERT dbo.[Reserva] ([Id], [ClienteId], [Desde], [Hasta], [Importe], [Sena], [Garantia], [Estado], [NumeroContrato], [NumeroRemito], [ContratoFirmado], [SenaRequerida], [GarantiaRequerida]) VALUES (3, 1, CONVERT(datetime2, '2026-10-05T00:00:00.0000000', 126), CONVERT(datetime2, '2026-10-06T00:00:00.0000000', 126), 8000.00, 2400.00, 46000.00, N'Cerrada', N'C-3', N'R-3', 1, 2400.00, 46000.00);
INSERT dbo.[Reserva] ([Id], [ClienteId], [Desde], [Hasta], [Importe], [Sena], [Garantia], [Estado], [NumeroContrato], [NumeroRemito], [ContratoFirmado], [SenaRequerida], [GarantiaRequerida]) VALUES (4, 1, CONVERT(datetime2, '2026-10-05T00:00:00.0000000', 126), CONVERT(datetime2, '2026-10-06T00:00:00.0000000', 126), 5000.00, 0.00, 0.00, N'Rechazada', NULL, NULL, 0, 0.00, 0.00);
INSERT dbo.[Reserva] ([Id], [ClienteId], [Desde], [Hasta], [Importe], [Sena], [Garantia], [Estado], [NumeroContrato], [NumeroRemito], [ContratoFirmado], [SenaRequerida], [GarantiaRequerida]) VALUES (5, 1, CONVERT(datetime2, '2026-10-05T00:00:00.0000000', 126), CONVERT(datetime2, '2026-10-06T00:00:00.0000000', 126), 5000.00, 1500.00, 30000.00, N'Cerrada', N'C-5', N'R-5', 1, 1500.00, 30000.00);
SET IDENTITY_INSERT dbo.[Reserva] OFF;

INSERT dbo.[ReservaEquipo] ([ReservaId], [EquipoId], [SeguroId], [CoberturaSeguro], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento], [EstadoEntrega], [TipoSeguro], [DetalleSeguro], [PolizaSeguro], [AseguradoraSeguro], [DesdeSeguro], [HastaSeguro]) VALUES (1, 1, 1, 500000.00, 15000.00, 500000.00, 1, N'Disponible', N'Basico', N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.', N'DEMO-N01', N'Aseguradora de ejemplo', CONVERT(datetime2, '2026-10-04T00:00:00.0000000', 126), CONVERT(datetime2, '2028-10-05T00:00:00.0000000', 126));
INSERT dbo.[ReservaEquipo] ([ReservaId], [EquipoId], [SeguroId], [CoberturaSeguro], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento], [EstadoEntrega], [TipoSeguro], [DetalleSeguro], [PolizaSeguro], [AseguradoraSeguro], [DesdeSeguro], [HastaSeguro]) VALUES (2, 1, 1, 500000.00, 15000.00, 500000.00, 1, N'Disponible', N'Basico', N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.', N'DEMO-N01', N'Aseguradora de ejemplo', CONVERT(datetime2, '2026-10-04T00:00:00.0000000', 126), CONVERT(datetime2, '2028-10-05T00:00:00.0000000', 126));
INSERT dbo.[ReservaEquipo] ([ReservaId], [EquipoId], [SeguroId], [CoberturaSeguro], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento], [EstadoEntrega], [TipoSeguro], [DetalleSeguro], [PolizaSeguro], [AseguradoraSeguro], [DesdeSeguro], [HastaSeguro]) VALUES (3, 2, 1, 500000.00, 5000.00, 150000.00, 1, N'Disponible', N'Basico', N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.', N'DEMO-N01', N'Aseguradora de ejemplo', CONVERT(datetime2, '2026-10-04T00:00:00.0000000', 126), CONVERT(datetime2, '2028-10-05T00:00:00.0000000', 126));
INSERT dbo.[ReservaEquipo] ([ReservaId], [EquipoId], [SeguroId], [CoberturaSeguro], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento], [EstadoEntrega], [TipoSeguro], [DetalleSeguro], [PolizaSeguro], [AseguradoraSeguro], [DesdeSeguro], [HastaSeguro]) VALUES (3, 3, 1, 500000.00, 3000.00, 80000.00, 1, N'Disponible', N'Basico', N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.', N'DEMO-N01', N'Aseguradora de ejemplo', CONVERT(datetime2, '2026-10-04T00:00:00.0000000', 126), CONVERT(datetime2, '2028-10-05T00:00:00.0000000', 126));
INSERT dbo.[ReservaEquipo] ([ReservaId], [EquipoId], [SeguroId], [CoberturaSeguro], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento], [EstadoEntrega], [TipoSeguro], [DetalleSeguro], [PolizaSeguro], [AseguradoraSeguro], [DesdeSeguro], [HastaSeguro]) VALUES (4, 2, 1, 500000.00, 5000.00, 150000.00, 1, NULL, N'Basico', N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.', N'DEMO-N01', N'Aseguradora de ejemplo', CONVERT(datetime2, '2026-10-04T00:00:00.0000000', 126), CONVERT(datetime2, '2028-10-05T00:00:00.0000000', 126));
INSERT dbo.[ReservaEquipo] ([ReservaId], [EquipoId], [SeguroId], [CoberturaSeguro], [TarifaDiaria], [ValorReposicion], [DiasReacondicionamiento], [EstadoEntrega], [TipoSeguro], [DetalleSeguro], [PolizaSeguro], [AseguradoraSeguro], [DesdeSeguro], [HastaSeguro]) VALUES (5, 2, 1, 500000.00, 5000.00, 150000.00, 1, N'Disponible', N'Basico', N'Cubre el 25% del daño reparable hasta el tope por unidad. No cubre atraso, faltante ni daño total.', N'DEMO-N01', N'Aseguradora de ejemplo', CONVERT(datetime2, '2026-10-04T00:00:00.0000000', 126), CONVERT(datetime2, '2028-10-05T00:00:00.0000000', 126));

SET IDENTITY_INSERT dbo.[Devolucion] ON;
INSERT dbo.[Devolucion] ([Id], [ReservaId], [Fecha], [Conforme], [ClientePresente], [Finalizada], [Observaciones], [GarantiaAplicada], [GarantiaDevuelta], [SaldoPendiente]) VALUES (1, 1, CONVERT(datetime2, '2026-10-05T07:56:34.7400809', 126), 0, 1, 1, N'', 75000.00, 25000.00, 0.00);
INSERT dbo.[Devolucion] ([Id], [ReservaId], [Fecha], [Conforme], [ClientePresente], [Finalizada], [Observaciones], [GarantiaAplicada], [GarantiaDevuelta], [SaldoPendiente]) VALUES (2, 2, CONVERT(datetime2, '2026-10-05T12:04:55.7949350', 126), 0, 1, 1, N'', 75000.00, 25000.00, 0.00);
INSERT dbo.[Devolucion] ([Id], [ReservaId], [Fecha], [Conforme], [ClientePresente], [Finalizada], [Observaciones], [GarantiaAplicada], [GarantiaDevuelta], [SaldoPendiente]) VALUES (3, 3, CONVERT(datetime2, '2026-10-05T12:56:29.6861485', 126), 0, 1, 1, N'', 12000.00, 34000.00, 0.00);
INSERT dbo.[Devolucion] ([Id], [ReservaId], [Fecha], [Conforme], [ClientePresente], [Finalizada], [Observaciones], [GarantiaAplicada], [GarantiaDevuelta], [SaldoPendiente]) VALUES (4, 5, CONVERT(datetime2, '2026-10-05T13:22:21.4394014', 126), 1, 1, 1, N'', 0.00, 30000.00, 0.00);
SET IDENTITY_INSERT dbo.[Devolucion] OFF;

SET IDENTITY_INSERT dbo.[Incidencia] ON;
INSERT dbo.[Incidencia] ([Id], [DevolucionId], [EquipoId], [Tipo], [Descripcion], [Cargo], [Estado], [FechaAltaTecnica], [CargoBase], [DescuentoSeguro], [MostrarEnAntecedentes]) VALUES (1, 1, 1, N'DañoReparable', N'Se rompio el lente', 75000.00, N'Cerrada', CONVERT(datetime2, '2026-10-05T08:04:33.2313887', 126), 100000.00, 25000.00, 0);
INSERT dbo.[Incidencia] ([Id], [DevolucionId], [EquipoId], [Tipo], [Descripcion], [Cargo], [Estado], [FechaAltaTecnica], [CargoBase], [DescuentoSeguro], [MostrarEnAntecedentes]) VALUES (2, 2, 1, N'DañoReparable', N'rotura', 75000.00, N'Cerrada', CONVERT(datetime2, '2026-10-05T12:06:46.3175957', 126), 100000.00, 25000.00, 0);
INSERT dbo.[Incidencia] ([Id], [DevolucionId], [EquipoId], [Tipo], [Descripcion], [Cargo], [Estado], [FechaAltaTecnica], [CargoBase], [DescuentoSeguro], [MostrarEnAntecedentes]) VALUES (3, 3, 3, N'DañoReparable', N'se rompio el diafragma', 12000.00, N'Cerrada', CONVERT(datetime2, '2026-10-05T12:57:34.3633139', 126), 16000.00, 4000.00, 0);
SET IDENTITY_INSERT dbo.[Incidencia] OFF;

-- Restaurar SeguroId despues de insertar clientes y polizas.
UPDATE dbo.Usuario SET SeguroId = 1 WHERE Id = 3;
COMMIT TRANSACTION;
GO
PRINT N'Restauracion de TC-AlquilerAudiovisual completada.';

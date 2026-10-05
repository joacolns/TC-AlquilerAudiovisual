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

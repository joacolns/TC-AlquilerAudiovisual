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

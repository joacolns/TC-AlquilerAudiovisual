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

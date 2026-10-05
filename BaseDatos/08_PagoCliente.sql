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

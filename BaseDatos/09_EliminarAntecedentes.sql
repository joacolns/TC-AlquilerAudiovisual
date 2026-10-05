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

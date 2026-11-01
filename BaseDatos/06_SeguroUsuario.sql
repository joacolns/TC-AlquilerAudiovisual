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

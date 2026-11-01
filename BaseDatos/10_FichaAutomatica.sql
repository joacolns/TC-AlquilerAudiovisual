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

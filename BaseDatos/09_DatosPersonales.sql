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

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

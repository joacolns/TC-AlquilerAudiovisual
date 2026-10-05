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

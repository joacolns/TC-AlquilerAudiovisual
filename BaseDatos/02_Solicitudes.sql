-- Compatible migration: existing firm reservations and their snapshots are preserved.
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET ARITHABORT ON;
SET NUMERIC_ROUNDABORT OFF;
USE [TC-AlquilerAudiovisual];
GO
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.Reserva') AND name=N'CK_Reserva_EstadoSolicitud')
BEGIN
 DECLARE @ddlEstado nvarchar(max)=N'';
 SELECT @ddlEstado=@ddlEstado+N'ALTER TABLE dbo.Reserva DROP CONSTRAINT '+QUOTENAME(name)+N';'
 FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.Reserva')
 AND parent_column_id=COLUMNPROPERTY(OBJECT_ID(N'dbo.Reserva'),N'Estado',N'ColumnId');
 IF @ddlEstado<>N'' EXEC sys.sp_executesql @ddlEstado;
 ALTER TABLE dbo.Reserva WITH CHECK ADD CONSTRAINT CK_Reserva_EstadoSolicitud
 CHECK(Estado IN(N'Pendiente',N'Firme',N'Entregada',N'ConIncidencia',N'Cerrada'));
END;
IF NOT EXISTS(SELECT 1 FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.ReservaEquipo') AND name=N'CK_ReservaEquipo_CoberturaSolicitud')
BEGIN
 DECLARE @ddlCobertura nvarchar(max)=N'';
 SELECT @ddlCobertura=@ddlCobertura+N'ALTER TABLE dbo.ReservaEquipo DROP CONSTRAINT '+QUOTENAME(name)+N';'
 FROM sys.check_constraints WHERE parent_object_id=OBJECT_ID(N'dbo.ReservaEquipo')
 AND parent_column_id=COLUMNPROPERTY(OBJECT_ID(N'dbo.ReservaEquipo'),N'CoberturaSeguro',N'ColumnId');
 IF @ddlCobertura<>N'' EXEC sys.sp_executesql @ddlCobertura;
 ALTER TABLE dbo.ReservaEquipo WITH CHECK ADD CONSTRAINT CK_ReservaEquipo_CoberturaSolicitud CHECK(CoberturaSeguro>=0);
END;
IF EXISTS(SELECT 1 FROM sys.columns WHERE object_id=OBJECT_ID(N'dbo.ReservaEquipo') AND name=N'SeguroId' AND is_nullable=0)
 ALTER TABLE dbo.ReservaEquipo ALTER COLUMN SeguroId int NULL;
GO

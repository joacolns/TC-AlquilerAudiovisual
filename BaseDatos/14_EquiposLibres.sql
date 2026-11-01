USE [TC-AlquilerAudiovisual];
GO
-- Un equipo con una solicitud pendiente en esas fechas ya "fue tomado": no se ofrece en el catálogo ni se recomienda.
-- EquiposDisponibles (solo compromisos firmes) se conserva para que stock pueda aceptar una solicitud pendiente.
CREATE OR ALTER FUNCTION dbo.EquiposLibres(@Desde datetime2,@Hasta datetime2)
RETURNS TABLE AS RETURN
(
 SELECT d.Id FROM dbo.EquiposDisponibles(@Desde,@Hasta) d JOIN dbo.Equipo e ON e.Id=d.Id
 WHERE NOT EXISTS(
  SELECT 1 FROM dbo.ReservaEquipo re JOIN dbo.Reserva r ON r.Id=re.ReservaId
  WHERE re.EquipoId=e.Id AND r.Estado=N'Pendiente'
   AND @Desde<DATEADD(DAY,re.DiasReacondicionamiento,r.Hasta)
   AND r.Desde<DATEADD(DAY,e.DiasReacondicionamiento,@Hasta))
);
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_Libres @Desde datetime2,@Hasta datetime2 AS
 BEGIN SET NOCOUNT ON; SELECT e.* FROM dbo.vEquipo e JOIN dbo.EquiposLibres(@Desde,@Hasta) d ON d.Id=e.Id ORDER BY e.CodigoInventario; END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_DisponiblesAsesor @Desde datetime2,@Hasta datetime2 AS
 BEGIN SET NOCOUNT ON;
 -- Las unidades cargadas sin perfil técnico igual se consideran (gama económica, sin etiquetas).
 SELECT e.*,ISNULL(p.Gama,1) Gama,ISNULL(p.Etiquetas,N'') Etiquetas,
  ISNULL(p.Ventaja,N'Unidad del inventario sin perfil técnico cargado.') Ventaja,
  ISNULL(p.Limitacion,N'Sin datos técnicos para comparar.') Limitacion FROM dbo.vEquipo e
 JOIN dbo.EquiposLibres(@Desde,@Hasta) d ON d.Id=e.Id LEFT JOIN dbo.EquipoPerfil p ON p.EquipoId=e.Id
 ORDER BY e.Categoria,e.CodigoInventario; END;
GO
-- Una solicitud nueva no puede tomar una unidad que ya tiene otra solicitud pendiente en esas fechas.
DECLARE @def nvarchar(max)=OBJECT_DEFINITION(OBJECT_ID(N'dbo.sp_Reserva_Insertar'));
IF @def LIKE N'%dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=x.EquipoId%'
BEGIN
 SET @def=REPLACE(@def,N'dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=x.EquipoId',N'dbo.EquiposLibres(@Desde,@Hasta) d ON d.Id=x.EquipoId');
 SET @def=N'ALTER '+SUBSTRING(@def,CHARINDEX(N'PROCEDURE',@def),LEN(@def));
 EXEC(@def);
END;
GO

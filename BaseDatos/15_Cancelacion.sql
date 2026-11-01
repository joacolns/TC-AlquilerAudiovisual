USE [TC-AlquilerAudiovisual];
GO
-- El cliente puede cancelar su pedido mientras esté pendiente de revisión o aceptado sin pagar.
IF EXISTS(SELECT 1 FROM sys.check_constraints WHERE name=N'CK_Reserva_EstadoSolicitud' AND parent_object_id=OBJECT_ID(N'dbo.Reserva'))
 ALTER TABLE dbo.Reserva DROP CONSTRAINT CK_Reserva_EstadoSolicitud;
ALTER TABLE dbo.Reserva WITH CHECK ADD CONSTRAINT CK_Reserva_EstadoSolicitud
 CHECK(Estado IN(N'Pendiente',N'Rechazada',N'Cancelada',N'Aceptada',N'Firme',N'Entregada',N'ConIncidencia',N'Cerrada'));
GO
CREATE OR ALTER PROCEDURE dbo.sp_Reserva_Cancelar @ReservaId int,@UsuarioId int,@Resultado int OUTPUT AS
BEGIN
 SET NOCOUNT ON;
 -- La condición de estado va en el UPDATE: si otra persona la procesó antes, no se cancela nada.
 UPDATE r SET Estado=N'Cancelada'
 FROM dbo.Reserva r JOIN dbo.Cliente c ON c.Id=r.ClienteId
 WHERE r.Id=@ReservaId AND c.UsuarioId=@UsuarioId AND r.Estado IN(N'Pendiente',N'Aceptada');
 SET @Resultado=@@ROWCOUNT;
END;
GO

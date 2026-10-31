USE [TC-AlquilerAudiovisual];
GO
-- 1. Limpiar tablas hijas sin FK circular
DELETE dbo.Incidencia;
DELETE dbo.Devolucion;
DELETE dbo.ReservaEquipo;
DELETE dbo.Reserva;

-- 2. Romper ciclo: Usuario -> Seguro (nullear primero)
UPDATE dbo.Usuario SET SeguroId = NULL;

-- 3. Ahora Equipo -> Seguro
UPDATE dbo.Equipo SET SeguroId = NULL;

-- 4. Seguro -> Cliente (eliminar Seguro antes que Cliente)
DELETE dbo.Seguro;

-- 5. Cliente -> Usuario
DELETE dbo.Cliente;

-- 6. Finalmente Usuario
DELETE dbo.Usuario;

-- Reiniciar identidades
DBCC CHECKIDENT ('dbo.Usuario', RESEED, 0);
DBCC CHECKIDENT ('dbo.Cliente', RESEED, 0);

-- Insertar usuarios con contraseÃ±a "123"
INSERT dbo.Usuario (NombreUsuario, Hash, Sal, Rol, Activo, TipoSeguro, SeguroId)
  VALUES (N'admin', 0xB62BC2941739C91D261365209499B88D26802A970A9E612EA517D7EA3782E730, 0xDF65E2D68203CFD8C80CCBF295129F6A, N'Administrador', 1, N'SinSeguro', NULL);
INSERT dbo.Usuario (NombreUsuario, Hash, Sal, Rol, Activo, TipoSeguro, SeguroId)
  VALUES (N'stock', 0x7602497923E0F115081E1624B19BCC3031880B8606B283686F170673B57EA60A, 0x18F6B9B3A4309AD110F2D0E61A1782C7, N'EncargadoStock', 1, N'SinSeguro', NULL);
INSERT dbo.Usuario (NombreUsuario, Hash, Sal, Rol, Activo, TipoSeguro, SeguroId)
  VALUES (N'cliente', 0x42A4B8F9A1F08934A6B414AA62850B66D36DEDA9737C2F9A38F732D975E82153, 0x0212C812749E1C7B1F50677F7E1B4A14, N'Cliente', 1, N'SinSeguro', NULL);
INSERT dbo.Usuario (NombreUsuario, Hash, Sal, Rol, Activo, TipoSeguro, SeguroId)
  VALUES (N'tecnico', 0x59C3AF948F30F5A5CDA3339923DE64BA5320665179980A1DF22FBFE52B94B77E, 0xCDAD6E8B691298386569B4478C544B13, N'Tecnico', 1, N'SinSeguro', NULL);
GO
PRINT N'Usuarios recreados con contraseÃ±a 123.';

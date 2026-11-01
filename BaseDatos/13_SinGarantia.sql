USE [TC-AlquilerAudiovisual];
GO
-- El sistema ya no maneja garantía: solo seña y el seguro predefinido del cliente.
-- Las columnas de garantía se conservan en 0 por compatibilidad; los cargos de una devolución quedan como saldo pendiente.
UPDATE dbo.Reserva SET GarantiaRequerida=0,Garantia=0 WHERE GarantiaRequerida<>0 OR Garantia<>0;
UPDATE dbo.Devolucion SET GarantiaAplicada=0,GarantiaDevuelta=0 WHERE GarantiaAplicada<>0 OR GarantiaDevuelta<>0;
GO
DECLARE @nombre sysname,@def nvarchar(max);
DECLARE c CURSOR LOCAL FAST_FORWARD FOR
 SELECT OBJECT_NAME(object_id),definition FROM sys.sql_modules
 WHERE object_id IN(OBJECT_ID(N'dbo.sp_Reserva_RegistrarEntrega'),OBJECT_ID(N'dbo.sp_Reserva_Confirmar'))
 AND (definition LIKE N'%la seña y la garantía antes%' OR definition LIKE N'%seña o garantía no coinciden%');
OPEN c; FETCH NEXT FROM c INTO @nombre,@def;
WHILE @@FETCH_STATUS=0
BEGIN
 SET @def=REPLACE(@def,N'la seña y la garantía antes',N'la seña antes');
 SET @def=REPLACE(@def,N'seña o garantía no coinciden',N'o seña no coinciden');
 SET @def=N'ALTER '+SUBSTRING(@def,CHARINDEX(N'PROCEDURE',@def),LEN(@def));
 EXEC(@def);
 FETCH NEXT FROM c INTO @nombre,@def;
END;
CLOSE c; DEALLOCATE c;
GO

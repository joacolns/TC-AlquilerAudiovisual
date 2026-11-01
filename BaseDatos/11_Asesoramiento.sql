USE [TC-AlquilerAudiovisual];
GO
-- Asesoramiento técnico (N03): perfil de cada equipo y más inventario para armar propuestas.
IF OBJECT_ID(N'dbo.EquipoPerfil',N'U') IS NULL
 CREATE TABLE dbo.EquipoPerfil(EquipoId int NOT NULL PRIMARY KEY REFERENCES dbo.Equipo(Id),
  Gama tinyint NOT NULL CHECK(Gama BETWEEN 1 AND 3),Etiquetas nvarchar(300) NOT NULL,
  Ventaja nvarchar(300) NOT NULL,Limitacion nvarchar(300) NOT NULL);
GO
CREATE OR ALTER PROCEDURE dbo.sp_Equipo_DisponiblesAsesor @Desde datetime2,@Hasta datetime2 AS
 BEGIN SET NOCOUNT ON;
 SELECT e.*,p.Gama,p.Etiquetas,p.Ventaja,p.Limitacion FROM dbo.vEquipo e
 JOIN dbo.EquiposDisponibles(@Desde,@Hasta) d ON d.Id=e.Id JOIN dbo.EquipoPerfil p ON p.EquipoId=e.Id
 ORDER BY e.Categoria,e.CodigoInventario; END;
GO
-- Equipos de ejemplo existentes
INSERT dbo.EquipoPerfil(EquipoId,Gama,Etiquetas,Ventaja,Limitacion)
 SELECT e.Id,v.Gama,v.Etiquetas,v.Ventaja,v.Limitacion FROM dbo.Equipo e JOIN (VALUES
 (N'DEMO-001',1,N'montura:kit;4k;peso:0.8;kit-lente',N'Cámara 4K con lente incluido: lista para usar.',N'Óptica y sensor básicos.'),
 (N'DEMO-002',1,N'luz:key;potencia:60;daylight',N'Panel LED simple para entrevistas.',N'Potencia limitada.'),
 (N'DEMO-003',1,N'audio:lavalier;cubre:1;inalambrico',N'Micrófono básico de uso general.',N'Calidad de audio básica.')
 ) v(Codigo,Gama,Etiquetas,Ventaja,Limitacion) ON v.Codigo=e.CodigoInventario
 WHERE NOT EXISTS(SELECT 1 FROM dbo.EquipoPerfil p WHERE p.EquipoId=e.Id);
GO
DECLARE @Nuevos TABLE(Codigo nvarchar(60),Serie nvarchar(160),Categoria nvarchar(100),Marca nvarchar(100),Modelo nvarchar(160),Tarifa decimal(18,2),Reposicion decimal(18,2),Gama tinyint,Etiquetas nvarchar(300),Ventaja nvarchar(300),Limitacion nvarchar(300));
INSERT @Nuevos VALUES
(N'CAM-001',N'SN-CAM-001',N'Cámara',N'Sony',N'Alpha a6700',18000,1500000,1,N'montura:E;4k;peso:0.5;liviana',N'Liviana y con enfoque automático confiable: ideal para moverse y para estabilizadores chicos.',N'Sensor APS-C: rinde menos con poca luz.'),
(N'CAM-002',N'SN-CAM-002',N'Cámara',N'Sony',N'Alpha a7 IV',28000,2800000,2,N'montura:E;4k;fullframe;baja-luz;peso:0.66',N'Full frame versátil con muy buen rendimiento con poca luz.',N'Sin ventilación activa: puede recalentarse en tomas largas.'),
(N'CAM-003',N'SN-CAM-003',N'Cámara',N'Sony',N'Alpha a7S III',48000,4800000,3,N'montura:E;4k;fullframe;baja-luz;baja-luz-extrema;peso:0.66',N'Rendimiento excepcional en penumbra y grabación sin límite de tiempo.',N'12 MP: menos resolución para recortes en posproducción.'),
(N'CAM-004',N'SN-CAM-004',N'Cámara',N'Sony',N'FX3 Cinema Line',45000,5200000,3,N'montura:E;4k;fullframe;baja-luz;cine;peso:0.72',N'Cámara de cine compacta, ventilada y con excelente sensibilidad.',N'Cuesta más y suele requerir accesorios de rigging.'),
(N'CAM-005',N'SN-CAM-005',N'Cámara',N'Canon',N'EOS R6 Mark II',30000,3000000,2,N'montura:RF;4k;fullframe;baja-luz;peso:0.67',N'Colores de piel naturales y estabilización interna efectiva.',N'Sin ventilación activa: tomas largas con riesgo de recalentamiento.'),
(N'CAM-006',N'SN-CAM-006',N'Cámara',N'Canon',N'EOS C70',55000,6500000,3,N'montura:RF;4k;baja-luz;cine;nd-interno;peso:1.2',N'ND interno y doble ganancia: rinde igual de bien en exterior y con poca luz.',N'Más pesada y más cara; exige soportes robustos.'),
(N'CAM-007',N'SN-CAM-007',N'Cámara',N'Blackmagic',N'Pocket Cinema 6K Pro',32000,3500000,2,N'montura:EF;6k;cine;nd-interno;peso:0.9',N'Imagen de cine en RAW a costo medio y ND interno.',N'Batería de poca duración y autofocus limitado.'),
(N'LEN-001',N'SN-LEN-001',N'Lente',N'Sony',N'FE 24-70mm f/2.8 GM II',14000,2400000,3,N'montura:E;zoom;f2.8;peso:0.7',N'Zoom luminoso y versátil: cubre casi todo el set con un solo lente.',N'Pesado para tomas largas en mano.'),
(N'LEN-002',N'SN-LEN-002',N'Lente',N'Sony',N'FE 50mm f/1.8',5000,350000,1,N'montura:E;fijo;f1.8;peso:0.2',N'Muy luminoso, económico y liviano; fondo desenfocado.',N'Focal fija: obliga a moverse para encuadrar.'),
(N'LEN-003',N'SN-LEN-003',N'Lente',N'Sony',N'FE 16-35mm f/2.8 GM',13000,2600000,3,N'montura:E;zoom;angular;f2.8;peso:0.68',N'Gran angular ideal para interiores chicos y locaciones.',N'Distorsiona rostros si se usa muy cerca.'),
(N'LEN-004',N'SN-LEN-004',N'Lente',N'Samyang',N'VDSLR 35mm T1.5 Cine',8000,700000,2,N'montura:E;fijo;cine;t1.5;peso:0.7',N'Look de cine con aro de foco dentado, apto para follow focus.',N'Foco manual: requiere asistente o práctica.'),
(N'LEN-005',N'SN-LEN-005',N'Lente',N'Canon',N'RF 24-70mm f/2.8L',15000,2800000,3,N'montura:RF;zoom;f2.8;peso:0.9',N'Zoom profesional con muy buena nitidez y estabilización.',N'Pesado y de costo alto.'),
(N'LEN-006',N'SN-LEN-006',N'Lente',N'Canon',N'RF 50mm f/1.8',4500,300000,1,N'montura:RF;fijo;f1.8;peso:0.16',N'Económico y liviano con gran luminosidad.',N'Focal fija, sin estabilización propia.'),
(N'LEN-007',N'SN-LEN-007',N'Lente',N'Sigma',N'18-35mm f/1.8 Art',9000,1000000,2,N'montura:EF;zoom;f1.8;cine;peso:0.8',N'Zoom con f/1.8 constante y look cinematográfico.',N'Pesado y sin autofocus ágil.'),
(N'LEN-008',N'SN-LEN-008',N'Lente',N'Canon',N'EF 24-70mm f/2.8L II',10000,1500000,2,N'montura:EF;zoom;f2.8;peso:0.8',N'Zoom clásico de trabajo, confiable y versátil.',N'Sin estabilización de imagen.'),
(N'LUZ-001',N'SN-LUZ-001',N'Iluminación',N'Godox',N'SL60W',5500,200000,1,N'luz:key;potencia:60;daylight',N'Luz continua económica, ideal para entrevistas.',N'Potencia limitada: no compite con la luz solar.'),
(N'LUZ-002',N'SN-LUZ-002',N'Iluminación',N'Godox',N'SL60W',5500,200000,1,N'luz:key;potencia:60;daylight',N'Luz continua económica, ideal para entrevistas.',N'Potencia limitada: no compite con la luz solar.'),
(N'LUZ-003',N'SN-LUZ-003',N'Iluminación',N'Nanlite',N'Forza 60B',8000,500000,2,N'luz:key;potencia:60;bicolor;compacta',N'Bicolor, compacta y silenciosa: ajusta la temperatura de color.',N'Potencia moderada para espacios grandes.'),
(N'LUZ-004',N'SN-LUZ-004',N'Iluminación',N'Aputure',N'Amaran 200x S',9000,450000,2,N'luz:key;potencia:200;bicolor',N'Potencia media con bicolor: sirve de luz principal en interiores.',N'Necesita difusor para luz suave.'),
(N'LUZ-005',N'SN-LUZ-005',N'Iluminación',N'Aputure',N'Amaran 200x S',9000,450000,2,N'luz:key;potencia:200;bicolor',N'Potencia media con bicolor: sirve de luz principal en interiores.',N'Necesita difusor para luz suave.'),
(N'LUZ-006',N'SN-LUZ-006',N'Iluminación',N'Aputure',N'LS 300d II',16000,1200000,3,N'luz:key;potencia:300;daylight;alta-potencia;exterior',N'Alta potencia: equilibra ventanas y rinde en exteriores.',N'Pesada, requiere alimentación robusta.'),
(N'LUZ-007',N'SN-LUZ-007',N'Iluminación',N'Aputure',N'Nova P300c',18000,1800000,3,N'luz:panel;potencia:300;rgb;suave',N'Panel RGB grande de luz suave, ideal para publicidad y videoclip.',N'Es voluminoso y caro.'),
(N'LUZ-008',N'SN-LUZ-008',N'Iluminación',N'Nanlite',N'PavoTube II 15C',4500,160000,1,N'luz:efecto;rgb;compacta',N'Tubo RGB para fondos y toques de color.',N'No sirve como luz principal.'),
(N'LUZ-009',N'SN-LUZ-009',N'Iluminación',N'Nanlite',N'PavoTube II 15C',4500,160000,1,N'luz:efecto;rgb;compacta',N'Tubo RGB para fondos y toques de color.',N'No sirve como luz principal.'),
(N'LUZ-010',N'SN-LUZ-010',N'Iluminación',N'Aputure',N'Light Dome II',4000,250000,2,N'luz:difusor;suave',N'Softbox parabólico: luz suave y favorecedora para rostros.',N'Agrega tiempo de armado.'),
(N'LUZ-011',N'SN-LUZ-011',N'Iluminación',N'Neewer',N'Reflector 5 en 1 110cm',1800,40000,1,N'luz:reflector;exterior;rebote',N'Rebota la luz del sol sin consumir energía.',N'Depende del sol y de un asistente.'),
(N'LUZ-012',N'SN-LUZ-012',N'Iluminación',N'Neewer',N'Reflector 5 en 1 110cm',1800,40000,1,N'luz:reflector;exterior;rebote',N'Rebota la luz del sol sin consumir energía.',N'Depende del sol y de un asistente.'),
(N'EST-001',N'SN-EST-001',N'Estabilizador',N'Zhiyun',N'Crane M3',7000,280000,1,N'gimbal;carga:1.2;compacta',N'Compacto y fácil de llevar para cámaras livianas.',N'Soporta poco peso: solo cámaras chicas con lente liviano.'),
(N'EST-002',N'SN-EST-002',N'Estabilizador',N'DJI',N'RS 3',12000,650000,2,N'gimbal;carga:3',N'Cubre la mayoría de las mirrorless con lentes medios.',N'Con cámaras de cine pesadas queda al límite.'),
(N'EST-003',N'SN-EST-003',N'Estabilizador',N'DJI',N'RS 3 Pro',20000,1100000,3,N'gimbal;carga:4.5',N'Soporta cámaras de cine y accesorios.',N'Más pesado y más caro.'),
(N'EST-004',N'SN-EST-004',N'Estabilizador',N'Rhino',N'Slider motorizado 80cm',9000,500000,2,N'slider;movimiento-lento',N'Movimientos suaves de cámara para planos de producto o entrevista.',N'Solo movimientos lineales cortos.'),
(N'SOP-001',N'SN-SOP-001',N'Soporte',N'Manfrotto',N'MVK504 cabeza fluida',6000,300000,1,N'tripode;carga:4;fluido',N'Trípode fluido económico para cámaras livianas.',N'Soporta poco peso.'),
(N'SOP-002',N'SN-SOP-002',N'Soporte',N'Manfrotto',N'MVK504 cabeza fluida',6000,300000,1,N'tripode;carga:4;fluido',N'Trípode fluido económico para cámaras livianas.',N'Soporta poco peso.'),
(N'SOP-003',N'SN-SOP-003',N'Soporte',N'Sachtler',N'Ace XL',10000,600000,2,N'tripode;carga:8;fluido',N'Cabeza fluida firme para cámaras de cine y lentes largos.',N'Más pesado de transportar.'),
(N'MON-001',N'SN-MON-001',N'Monitor',N'SmallHD',N'Focus 5',5000,250000,1,N'monitor;5pulg',N'Monitoreo preciso en set con ayudas de enfoque.',N'Pantalla chica y poco brillo al sol.'),
(N'MON-002',N'SN-MON-002',N'Monitor',N'Atomos',N'Ninja V 5',8000,450000,2,N'monitor;grabador;5pulg',N'Monitorea y graba ProRes/RAW externo.',N'Agrega cables y consumo.'),
(N'MON-003',N'SN-MON-003',N'Monitor',N'SmallHD',N'Cine 7',14000,1300000,3,N'monitor;7pulg;lut;exterior',N'Gran brillo para exterior, LUTs y ayudas de cine.',N'Pesado y de costo alto.'),
(N'AUD-001',N'SN-AUD-001',N'Audio',N'Rode',N'Wireless GO II',6000,350000,1,N'audio:lavalier;cubre:2;inalambrico',N'Dos micrófonos inalámbricos en un solo kit, muy simple de usar.',N'Alcance y robustez inferiores a un sistema profesional.'),
(N'AUD-002',N'SN-AUD-002',N'Audio',N'Rode',N'Wireless GO II',6000,350000,1,N'audio:lavalier;cubre:2;inalambrico',N'Dos micrófonos inalámbricos en un solo kit, muy simple de usar.',N'Alcance y robustez inferiores a un sistema profesional.'),
(N'AUD-003',N'SN-AUD-003',N'Audio',N'Sennheiser',N'EW 112P G4',9000,700000,2,N'audio:lavalier;cubre:1;inalambrico;profesional',N'Transmisión estable y calidad profesional de broadcast.',N'Cubre una sola persona por kit.'),
(N'AUD-004',N'SN-AUD-004',N'Audio',N'Sennheiser',N'EW 112P G4',9000,700000,2,N'audio:lavalier;cubre:1;inalambrico;profesional',N'Transmisión estable y calidad profesional de broadcast.',N'Cubre una sola persona por kit.'),
(N'AUD-005',N'SN-AUD-005',N'Audio',N'Sennheiser',N'EW 112P G4',9000,700000,2,N'audio:lavalier;cubre:1;inalambrico;profesional',N'Transmisión estable y calidad profesional de broadcast.',N'Cubre una sola persona por kit.'),
(N'AUD-006',N'SN-AUD-006',N'Audio',N'Rode',N'NTG4+',4500,250000,1,N'audio:boom;cubre:3;direccional',N'Shotgun liviano con buen rechazo lateral.',N'Necesita pértiga y operador.'),
(N'AUD-007',N'SN-AUD-007',N'Audio',N'Sennheiser',N'MKH 416',10000,1000000,3,N'audio:boom;cubre:3;direccional;exterior',N'Referencia de la industria para diálogo en exteriores.',N'Costoso y requiere pértiga y grabador.'),
(N'AUD-008',N'SN-AUD-008',N'Audio',N'Zoom',N'F3 32-bit float',7000,500000,2,N'audio:grabador;float',N'Grabación 32-bit float: no distorsiona ni se queda corto de nivel.',N'Requiere sincronizar con la imagen.'),
(N'AUD-009',N'SN-AUD-009',N'Audio',N'K-Tek',N'Pértiga de carbono',2500,120000,2,N'audio:pertiga',N'Pértiga liviana para operar el micrófono sin entrar en cuadro.',N'Requiere un operador dedicado.'),
(N'ENE-001',N'SN-ENE-001',N'Energía',N'Core SWX',N'Kit 2 baterías V-mount 98Wh',5000,300000,2,N'energia;jornada-larga',N'Respaldo de energía para cámara, monitor y luces durante jornadas largas.',N'Suma peso al rig.'),
(N'ENE-002',N'SN-ENE-002',N'Energía',N'Core SWX',N'Kit 2 baterías V-mount 98Wh',5000,300000,2,N'energia;jornada-larga',N'Respaldo de energía para cámara, monitor y luces durante jornadas largas.',N'Suma peso al rig.');
INSERT dbo.Equipo(CodigoInventario,Serie,Categoria,Marca,Modelo,Descripcion,Estado,TarifaDiaria,ValorReposicion,DiasReacondicionamiento)
 SELECT n.Codigo,n.Serie,n.Categoria,n.Marca,n.Modelo,n.Marca+N' '+n.Modelo,N'Disponible',n.Tarifa,n.Reposicion,1 FROM @Nuevos n
 WHERE NOT EXISTS(SELECT 1 FROM dbo.Equipo e WHERE e.CodigoInventario=n.Codigo);
INSERT dbo.EquipoPerfil(EquipoId,Gama,Etiquetas,Ventaja,Limitacion)
 SELECT e.Id,n.Gama,n.Etiquetas,n.Ventaja,n.Limitacion FROM @Nuevos n JOIN dbo.Equipo e ON e.CodigoInventario=n.Codigo
 WHERE NOT EXISTS(SELECT 1 FROM dbo.EquipoPerfil p WHERE p.EquipoId=e.Id);
GO

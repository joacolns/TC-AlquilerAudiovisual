param([switch]$SinDatosDemo)
$ErrorActionPreference = 'Stop'
$raizN01 = $PSScriptRoot
$msbuildN01 = 'C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe'
$sqlcmdN01 = 'C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE'
if (!(Test-Path -LiteralPath $msbuildN01)) { throw 'Se requiere Visual Studio 2022 con MSBuild y .NET Framework 4.7.2.' }
if (!(Test-Path -LiteralPath $sqlcmdN01)) { $sqlcmdN01 = (Get-Command sqlcmd -ErrorAction Stop).Source }
& $msbuildN01 (Join-Path $raizN01 'TC-AlquilerAudiovisual.sln') /t:Build /p:Configuration=Debug /v:minimal /nologo
if ($LASTEXITCODE -ne 0) { throw 'Falló la compilación.' }
foreach ($archivoN01 in @('BaseDatos\01_Base.sql', 'BaseDatos\02_Solicitudes.sql', 'BaseDatos\03_StoredProcedures\N01.sql')) {
    & $sqlcmdN01 -S . -E -b -l 10 -f 65001 -i (Join-Path $raizN01 $archivoN01)
    if ($LASTEXITCODE -ne 0) { throw "No se pudo aplicar $archivoN01" }
}
if ($SinDatosDemo) { Write-Host 'Base y procedimientos N01 listos, sin datos de ejemplo.'; return }
foreach ($bibliotecaN01 in @('BE', 'DAL', 'SERVICE')) {
    Add-Type -Path (Join-Path $raizN01 "GUI\bin\Debug\$bibliotecaN01.dll")
}
$seguridadN01 = New-Object SERVICE.Seguridad
$usuariosN01 = New-Object DAL.UsuarioMapper
foreach ($nombreN01 in @('admin', 'stock', 'cliente', 'tecnico')) {
    if ($null -eq $usuariosN01.Buscar($nombreN01)) {
        $usuarioN01 = New-Object BE.Usuario
        $usuarioN01.NombreUsuario = $nombreN01
        $usuarioN01.Activo = $true
        switch ($nombreN01) {
            'admin' { $usuarioN01.Rol = 'Administrador'; $claveN01 = 'Admin123!' }
            'stock' { $usuarioN01.Rol = 'EncargadoStock'; $claveN01 = 'Stock123!' }
            'cliente' { $usuarioN01.Rol = 'Cliente'; $claveN01 = 'Cliente123!' }
            'tecnico' { $usuarioN01.Rol = 'Tecnico'; $claveN01 = 'Tecnico123!' }
        }
        $usuarioN01.Sal = $seguridadN01.CrearSal()
        $usuarioN01.Hash = $seguridadN01.Hashear($claveN01, $usuarioN01.Sal)
        $null = $usuariosN01.Insertar($usuarioN01)
        $claveN01 = $null
    }
}
$clientesN01 = New-Object DAL.ClienteMapper
$cuentaN01 = $usuariosN01.Buscar('cliente')
$fichasN01 = $clientesN01.Listar($cuentaN01.Id)
if ($fichasN01.Count -eq 0) {
    $clienteN01 = New-Object BE.Cliente
    $clienteN01.UsuarioId = $cuentaN01.Id; $clienteN01.Usuario = $cuentaN01
    $clienteN01.DniCuit = '30123456'; $clienteN01.Nombre = 'Cliente de ejemplo'
    $clienteN01.Telefono = '1100000000'; $clienteN01.Email = 'cliente@example.com'
    $clienteN01.Id = $clientesN01.Insertar($clienteN01)
} else { $clienteN01 = $fichasN01[0] }
$polizaN01 = $null
foreach ($existenteN01 in $clientesN01.ListarSeguros($clienteN01.Id)) {
    if ($existenteN01.Poliza -eq 'DEMO-N01') { $polizaN01 = $existenteN01; break }
}
if ($null -eq $polizaN01) {
    $polizaN01 = New-Object BE.Seguro
    $polizaN01.ClienteId = $clienteN01.Id; $polizaN01.Cliente = $clienteN01
    $polizaN01.Poliza = 'DEMO-N01'; $polizaN01.Aseguradora = 'Aseguradora de ejemplo'
    $polizaN01.Desde = [DateTime]::Today.AddDays(-1); $polizaN01.Hasta = [DateTime]::Today.AddYears(2)
    $polizaN01.Cobertura = 500000
    $polizaN01.Id = $clientesN01.GuardarSeguro($polizaN01)
}
$equiposN01 = New-Object DAL.EquipoMapper
foreach ($indiceN01 in @(1,2,3)) {
    $codigoN01 = 'DEMO-00' + $indiceN01
    $existeN01 = $false
    foreach ($unidadN01 in $equiposN01.Listar()) { if ($unidadN01.CodigoInventario -eq $codigoN01) { $existeN01 = $true; break } }
    if ($existeN01) { continue }
    $equipoN01 = New-Object BE.Equipo
    $equipoN01.CodigoInventario = $codigoN01; $equipoN01.Serie = 'SERIE-DEMO-' + $indiceN01
    $equipoN01.Seguro = $polizaN01; $equipoN01.Estado = 'Disponible'; $equipoN01.DiasReacondicionamiento = 1
    $equipoN01.Marca = 'Ejemplo'; $equipoN01.Descripcion = 'Unidad para la entrega académica N01'
    switch ($indiceN01) {
        1 { $equipoN01.Categoria = 'Cámara'; $equipoN01.Modelo = 'Cámara 4K'; $equipoN01.TarifaDiaria = 15000; $equipoN01.ValorReposicion = 500000 }
        2 { $equipoN01.Categoria = 'Iluminación'; $equipoN01.Modelo = 'Panel LED'; $equipoN01.TarifaDiaria = 5000; $equipoN01.ValorReposicion = 150000 }
        3 { $equipoN01.Categoria = 'Audio'; $equipoN01.Modelo = 'Micrófono'; $equipoN01.TarifaDiaria = 3000; $equipoN01.ValorReposicion = 80000 }
    }
    $null = $equiposN01.Insertar($equipoN01)
}
Write-Host 'N01 listo. Los registros existentes se conservaron. Abrí GUI\bin\Debug\GUI.exe.'

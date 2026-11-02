param([ValidateSet('Debug', 'Release')][string]$Configuracion = 'Debug')
$ErrorActionPreference = 'Stop'
$raizProyecto = Split-Path -Parent $PSScriptRoot
$vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio/Installer/vswhere.exe'
$instalacionVS = & $vswhere -latest -products '*' -requires Microsoft.Component.MSBuild -property installationPath
if (-not $instalacionVS) { throw 'No se encontro MSBuild en Visual Studio.' }
$msbuild = Join-Path $instalacionVS 'MSBuild/Current/Bin/MSBuild.exe'
$compilador = Join-Path $instalacionVS 'MSBuild/Current/Bin/Roslyn/csc.exe'
& $msbuild (Join-Path $raizProyecto 'GUI/GUI.csproj') /t:Build "/p:Configuration=$Configuracion" /nologo /v:minimal
if ($LASTEXITCODE -ne 0) { throw 'Fallo la compilacion de la aplicacion.' }
$binarios = Join-Path $raizProyecto "GUI/bin/$Configuracion"
$salidaPruebas = Join-Path $env:TEMP ('FOCO-Verificacion-' + [Guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $salidaPruebas | Out-Null
Copy-Item -LiteralPath (Join-Path $binarios 'GUI.exe') -Destination $salidaPruebas
Get-ChildItem -LiteralPath $binarios -Filter '*.dll' | Copy-Item -Destination $salidaPruebas
$referencias = @('BE.dll', 'BLL.dll', 'SERVICE.dll', 'GUI.exe') | ForEach-Object { '/r:' + (Join-Path $binarios $_) }
$ejecutable = Join-Path $salidaPruebas 'Verificar.exe'
& $compilador /nologo /target:exe "/out:$ejecutable" /r:System.Design.dll /r:System.Windows.Forms.dll @referencias (Join-Path $PSScriptRoot 'Verificar.cs')
if ($LASTEXITCODE -ne 0) { throw 'Fallo la compilacion de las verificaciones.' }
& $ejecutable (Join-Path $salidaPruebas 'Brief-ejemplo.xml')
if ($LASTEXITCODE -ne 0) { throw 'Fallo una verificacion.' }
Write-Host "Archivos de prueba: $salidaPruebas"

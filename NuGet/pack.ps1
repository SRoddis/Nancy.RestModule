$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\Nancy.RestModule\bin\Release\Nancy.RestModule.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\NuGet\Nancy.RestModule.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\nuget\Nancy.RestModule.compiled.nuspec

& $root\NuGet\NuGet.exe pack $root\nuget\Nancy.RestModule.compiled.nuspec

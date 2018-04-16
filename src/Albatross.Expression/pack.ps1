cls
set-location $PSScriptRoot;
Set-Alias -Name msbuild -Value "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\bin\msbuild.exe"
msbuild .\Albatross.Expression.csproj -property:Configuration=Release
nuget pack .\Albatross.Expression.nuspec -outputDirectory ..\..\pack

cls


[System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path) | set-location;


$debug = $false;
$category = $null;

Set-Alias nunit "..\packages\NUnit.Console.3.0.1\tools\nunit3-console.exe";
$args= @(".\Albatross.Expression.Test.csproj", "--workers=10", "--inprocess");


if($debug){
	$args += "--debug";
}

if($category){
	$args += "--where:cat=$category";
}


& nunit $args;
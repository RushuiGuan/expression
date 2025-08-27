param(
	[switch]
	[bool]$skip
)
$InformationPreference = "Continue";
$install = $env:InstallDirectory;

if(-not $skip) {
	$projects = @(
		"Albatross.Expression.Utility"
	);
	if(-not [string]::IsNullOrEmpty($project)){
		$projects = $projects | Where-Object { $_ -like "*$project" }
	}
	foreach($item in $projects){
		if(Test-Path "$install/$item" -type Container){
			Write-Information "Deleting $item";
 			Get-ChildItem $install\$item | Remove-Item -Recurse -Force;
		}
	}

	foreach($project in $projects){
		"Building $project";
		dotnet publish $PSScriptRoot\$project\$project.csproj -o $install\$project -c debug
	}
}

set-alias -name ex -Value $env:InstallDirectory\Albatross.Expression.Utility\Albatross.Expression.Utility.exe

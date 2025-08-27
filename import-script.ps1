Invoke-WebRequest `
	-Uri https://raw.githubusercontent.com/RushuiGuan/dev-scripts/refs/heads/main/dev-scripts.psm1 `
	-OutFile $PSScriptRoot/dev-scripts.psm1

Import-Module $PSScriptRoot/dev-scripts.psm1
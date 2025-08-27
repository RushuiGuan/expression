$working = $PSScriptRoot;

Get-ChildItem $working\docs | Remove-Item -Recurse -Force

xmldoc2md $working\Albatross.Expression\bin\Debug\net8.0\Albatross.Expression.dll `
	-o $working\docs\ `
	--github-pages `
	--structure tree `
	--back-button

xmldoc2md $working\Albatross.Expression.Utility\bin\Debug\net8.0\Albatross.Expression.Utility.dll `
	-o $working\docs\ `
	--github-pages `
	--structure tree `
	--back-button `
	--index-page-name $working\docs\index2

Get-Content $working\docs\index2.md >> $PSScriptRoot\docs\index.md

Remove-Item $working\docs\index2.md
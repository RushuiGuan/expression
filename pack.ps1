param(
	[parameter(Mandatory = $true)]
	[System.IO.DirectoryInfo]
	$directory,
	[switch]
	[bool]$skipTest,
	[switch]
	[bool]$prod,
	[switch]
	[bool]$force,
	[switch]
	[bool]$push,
	[switch]
	[bool]$tag
)
$InformationPreference = "Continue";
$ErrorActionPreference = "Stop";
Set-StrictMode -Version Latest;

function Join(
	[string[]]$array
) {
	return [System.IO.Path]::Join($array);
}


$root = Resolve-Path -Path $directory;

if (-not [System.IO.Directory]::Exists($root)) {
	Write-Error "Directory $root does not exist"
}
else {
	Write-Information "Project directory: $root"
}


if (-not [System.IO.File]::Exists((Join $root, .projects))) {
	Write-Error ".projects file not found"
}

$testProjects = devtools project list -f (Join $root,  .projects) -h tests
Write-Information "Test projects: $($testProjects -join ', ')"

$projects = devtools project list -f (Join $root, .projects) -h packages
Write-Information "Projects: $($projects -join ', ')"

if (-not $skipTest) {
	# run the test projects
	foreach ($item in $testProjects) {
		"Testing $item";
		dotnet test (join $root, $item, "$item.csproj") -c release
		if ($LASTEXITCODE -ne 0) {
			Write-Error "Test failed for $item"
		}
	}
}

if ($projects.Length -eq 0) {
	Write-Information "Nothing to do";
	return;	
}

$isDirty = $false;
devtools git is-dirty -d $root
if ($LASTEXITCODE -ne 0) {
	$isDirty = $true;
}

# if $prod is true and $force is false, do not proceed if the directory is dirty
if ($prod -and -not $force -and $isDirty) {
	Write-Error "Directory is dirty. Please commit or stash changes before proceeding with a prod build"
}
if ($tag -and $isDirty) {
	Write-Error "Directory is dirty. Please commit or stash changes before tagging"
}
$oldVersion = devtools project property -f (Join $root, Directory.Build.props) -p Version
$version = devtools project version --directory-build-props -d $root -p="$prod"
if ($LASTEXITCODE -ne 0) {
	Write-Error "Unable to get project version"
}
try {
	# first clean up the artifacts folder
	Write-Information "Cleaning up artifacts folder: $(Join $root, artifacts)";
	if (-not [System.IO.Directory]::Exists((Join $root, artifacts))) {
		New-Item -ItemType Directory -Path (Join $root, artifacts)
	} else {
		Get-ChildItem (Join $root, artifacts, *.nupkg) | Remove-Item -Force
	}
	Write-Information "Version: $version";
	devtools project set-version -d $root -ver $version
	
	$repositoryProjectRoot = devtools project property -f (Join $PSScriptRoot, Directory.Build.props) -p RepositoryUrl
	if ($LASTEXITCODE -ne 0) {
		Write-Error "Unable to read RepositoryUrl from the Directory.Build.props file";
	} else {
		$repositoryProjectRoot = $repositoryProjectRoot + "/tree/main/README.md";
	}
	foreach ($project in $projects) {
		# first fix the README.md file
		$readme = (Join $root, $project, README.md);
		$tmp = [System.IO.Path]::GetTempFileName()
		Copy-Item $readme $tmp -Force
		try {
			if ([System.IO.File]::Exists($readme)) {
				devtools project fix-markdown-relative-urls --markdown-file $readme --root-folder $PSScriptRoot --root-url $repositoryProjectRoot
				if ($LASTEXITCODE -ne 0) {
					Write-Error "Unable to fix the README.md file for $project"
				}
			}
			"Building $project";
			dotnet pack (Join $root, $project, "$project.csproj") -c release -o (Join $root, artifacts)
			if ($LASTEXITCODE -ne 0) {
				Write-Error "Build failed for $project"
			}
		}
		finally {
			Copy-Item $tmp $readme -Force
			Remove-Item $tmp -Force
		}
	}
	devtools project set-version -d $root -ver $oldVersion
	if ($tag -and $projects.Length -ne 0) {
		$directoryName = Split-Path $root -Leaf
		$version = devtools version build -ver $version -clear-meta
		if ($LASTEXITCODE -ne 0) {
			Write-Error "Error removing meta from version";
		}
		$tagText = "$directoryName-$version";
		Write-Information "Tagging $tagText";
		git tag $tagText;
		if($prod){
			#if it is a prod build and tagged, bump the version to the next patch
			$version = devtools version build -ver $version --next-patch -clear-pre -clear-meta
			if ($LASTEXITCODE -ne 0) {
				Write-Error "Error bumping version";
			}
			devtools project set-version -d $root -ver $version
			devtools xml format -f (Join $root, Directory.Build.props)
			git commit -m "Bump version of $directoryName to $version" (Join $root, Directory.Build.props);
		}
	}
}
finally {
	devtools xml format -f (Join $root, Directory.Build.props)
	Get-ChildItem (Join $root, *.csproj) -recurse | ForEach-Object { 
		devtools xml format -f $_.FullName
	}
}
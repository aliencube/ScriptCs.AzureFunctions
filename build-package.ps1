Param(
	[string] [Parameter(Mandatory=$true)] $Version,
	[string] [Parameter(Mandatory=$false)] $BuildPath
)

$nuget = ".\tools\NuGet.exe"
$projects = Get-ChildItem .\src | ?{ $_.PSIsContainer }
foreach($project in $projects)
{
	$projectPath = $project.FullName;
	$projectName = $project.Name;
	
	$nuspec = "$projectName.nuspec"
	$isPackage = Test-Path -Path $(Join-Path $projectPath $nuspec)
	if ($isPackage -ne $true)
	{
		continue
	}

	if ([string]::IsNullOrWhiteSpace($BuildPath))
	{
		& $nuget pack $(Join-Path $projectPath $nuspec) -Version $Version
	}
	else
	{
		& $nuget pack $(Join-Path $projectPath $nuspec) -OutputDirectory $buildPath -Version $Version
	}
}

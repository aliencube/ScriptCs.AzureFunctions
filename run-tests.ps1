Param(
    [string] [Parameter(Mandatory=$true)] $Configuration
)

$xunit = ".\packages\xunit.runner.console.2.2.0-beta2-build3300\tools\xunit.console.exe"
$projects = Get-ChildItem .\test | ?{ $_.PSIsContainer }
foreach($project in $projects)
{
    $projectPath = $project.FullName;
    $projectName = $project.Name;

    & $xunit $projectPath\bin\$Configuration\net46\Aliencube.$projectName.dll -appveyor
}

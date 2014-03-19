param($installPath, $toolsPath, $package, $project)
$projectFullName = $project.FullName
$fileInfo = new-object -typename System.IO.FileInfo -ArgumentList $projectFullName
$projectDirectory = $fileInfo.DirectoryName
$sourceDirectory = "$projectDirectory\Views"
Write-Host $sourceDirectory
$destinationDirectory = "$projectDirectory\Themes\Views"
Write-Host $destinationDirectory
if(test-path $sourceDirectory -pathtype container)
{
Write-Host "Copying files from $sourceDirectory to $destinationDirectory"
robocopy $sourceDirectory $destinationDirectory /E
}
$debugString = "install.ps1 complete" + $projectFullName
Write-Host $debugString
#Mandatory Input  parameter for the name of the project
param(
    [Parameter(Mandatory=$true)]
    [string]$projectName
)

#From the current folder, create the project folder in the Data\2023 folder and create two files: input.txt and example.txt
Write-Output "Creating project $projectName"
Write-Output "Creating data folder in Data\2023"
$dataPath = Join-Path -Path $PSScriptRoot -ChildPath "Data\2023\$projectName"
New-Item -Path $dataPath -ItemType Directory
Write-Output "Creating input.txt and example.txt"
New-Item -Path $dataPath -Name "input.txt" -ItemType File
New-Item -Path $dataPath -Name "example.txt" -ItemType File

#From the current folder, create the project folder in the Solutions\2023 folder 
Write-Output "Creating project folder in Solutions\2023"
$projectPath = Join-Path -Path $PSScriptRoot -ChildPath "Solutions\2023\$projectName"
New-Item -Path $projectPath -ItemType Directory

#Copy the files in the ProjectTemplate folder to the project folder. In each file, rename DayXX to the project name
Write-Output "Copying files from ProjectTemplate to project folder"
$templatePath = Join-Path -Path $PSScriptRoot -ChildPath "ProjectTemplate"
Get-ChildItem -Path $templatePath -Recurse | Copy-Item -Destination $projectPath -Recurse -Force
Write-Output "Renaming DayXX to $projectName"
Get-ChildItem -Path $projectPath -Recurse -Include *.cs, *.txt | ForEach-Object { (Get-Content $_.FullName) -replace 'DayXX', $projectName | Set-Content $_.FullName } 
Get-ChildItem -Path $projectPath -Recurse -Include DayXX.csproj | ForEach-Object { Rename-Item $_.FullName -NewName "$projectName.csproj" }

#Add the dotnet project of the project to the solution
Write-Output "Adding project to solution"
$solutionPath = Join-Path -Path $PSScriptRoot -ChildPath "Solutions\2023\AdventOfCode.sln"
$csprojPath = Join-Path -Path $PSScriptRoot -ChildPath "Solutions\2023\$projectName\$projectName.csproj"
dotnet sln $solutionPath add $csprojPath
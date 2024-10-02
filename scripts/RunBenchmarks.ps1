# Define the relative path to the .csproj file
$projectPath = "..\src\ZeroRedact.Benchmark\ZeroRedact.Benchmark.csproj"

# Get the full path to the .csproj file
$fullProjectPath = Resolve-Path $projectPath

# Extract the directory containing the .csproj file
$projectDirectory = Split-Path $fullProjectPath

# Navigate to the project directory
Set-Location $projectDirectory

# Run the benchmark
dotnet run -c Release --project $fullProjectPath

# Define the source and destination directories
$sourceDir = "BenchmarkDotNet.Artifacts\results"
$destinationDir = "..\..\benchmarks"

# Ensure the destination directory exists
if (-not (Test-Path -Path $destinationDir)) {
    New-Item -ItemType Directory -Path $destinationDir
}

# Get all .md files from the source directory
$mdFiles = Get-ChildItem -Path $sourceDir -Filter *.md

# Move each .md file to the destination directory, overwriting if it exists
foreach ($file in $mdFiles) {
    $destinationPath = Join-Path -Path $destinationDir -ChildPath $file.Name
    Move-Item -Path $file.FullName -Destination $destinationPath -Force

    # Read the content of the file
    $content = Get-Content -Path $destinationPath

    # Remove all occurrences of "**"
    $updatedContent = $content -replace "\*\*", ""

    # Write the updated content back to the file
    Set-Content -Path $destinationPath -Value $updatedContent
}


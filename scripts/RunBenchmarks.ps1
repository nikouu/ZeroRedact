
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
# Check if reportgenerator tool is installed
if (-not (Get-Command reportgenerator -ErrorAction SilentlyContinue)) {
    Write-Host "The 'reportgenerator' tool is not installed. Please run the following command to install it:"
    Write-Host "dotnet tool install -g dotnet-reportgenerator-globaltool"
    exit 1
}

# Run the tests and collect code coverage
dotnet test ..\src\ZeroRedact.UnitTest\ZeroRedact.UnitTest.csproj --collect:"XPlat Code Coverage" /p:CollectCoverage=true

# Get the latest test results folder
$testResultsPath = "..\src\ZeroRedact.UnitTest\TestResults"
$latestFolder = Get-ChildItem -Directory $testResultsPath | Sort-Object LastWriteTime -Descending | Select-Object -First 1

# Construct the path to the coverage report
$coverageReportPath = Join-Path $latestFolder.FullName "coverage.cobertura.xml"

# Generate the report
reportgenerator -reports:$coverageReportPath -targetdir:"..\src\ZeroRedact.UnitTest\TestResults\00-CoverageReport" -reporttypes:Html

# Open the resulting HTML report
$reportPath = "..\src\ZeroRedact.UnitTest\TestResults\00-CoverageReport\index.html"
Start-Process $reportPath
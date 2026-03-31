# Versions to benchmark (edit this array for future runs)
$versions = @("3.0.0", "2.4.1", "2.4.0", "2.3.0", "2.2.0", "2.1.0")

# Versions that contain the RedactkDate typo (method was misspelled in source, fixed in 2.4.1)
$redactkDateTypoVersions = @("2.1.0", "2.2.0", "2.3.0", "2.4.0")

# Versions where PhoneNumberValidatorBenchmarks has method named "ValidateMacAddresses" instead of
# "ValidatePhoneNumber" due to a copy-paste error in the benchmark source. Tags are immutable so we
# fix the JSON output after the run.
$phoneNumberTypoVersions = @("2.2.0", "2.3.0", "2.4.0", "2.4.1")

# Output directory for benchmark results
$outputBase = "C:\temp\ZeroRedactBenchmarks"

# Derive repo root from script location
$repoRoot = Resolve-Path "$PSScriptRoot\.."
$benchmarkProjectDir = "$repoRoot\src\ZeroRedact.Benchmark"
$csprojPath = "$benchmarkProjectDir\ZeroRedact.Benchmark.csproj"
$programCsPath = "$benchmarkProjectDir\Program.cs"
$artifactsDir = "$benchmarkProjectDir\BenchmarkDotNet.Artifacts"
$resultsDir = "$artifactsDir\results"

# Program.cs content to use for all versions
$programCsContent = @'
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using ZeroRedact;

var config = DefaultConfig.Instance
    .AddDiagnoser(MemoryDiagnoser.Default)
    .AddExporter(BenchmarkDotNet.Exporters.Json.JsonExporter.Brief);

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
'@

# Recreate output base directory (clean start)
if (Test-Path -Path $outputBase) {
    Remove-Item -Path $outputBase -Recurse -Force
}
New-Item -ItemType Directory -Path $outputBase | Out-Null

# Save current branch to return to after all runs
$originalBranch = git -C $repoRoot rev-parse --abbrev-ref HEAD

# Track results for summary report
$report = @()
$scriptStartTime = Get-Date

foreach ($version in $versions) {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host " Benchmarking version $version" -ForegroundColor Cyan
    Write-Host " Started: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')" -ForegroundColor Cyan
    Write-Host "========================================" -ForegroundColor Cyan

    $versionStartTime = Get-Date

    # 1. Checkout the tag
    Write-Host "Checking out tag $version..."
    git -C $repoRoot checkout $version
    if ($LASTEXITCODE -ne 0) {
        Write-Host "ERROR: Failed to checkout tag $version. Skipping." -ForegroundColor Red
        $report += [PSCustomObject]@{ Version = $version; Status = "FAILED (checkout)"; Files = 0; Duration = "N/A" }
        continue
    }

    # 2. Clear artifacts
    if (Test-Path -Path $artifactsDir) {
        Write-Host "Clearing BenchmarkDotNet.Artifacts..."
        Remove-Item -Path $artifactsDir -Recurse -Force
    }

    # 3. Update BenchmarkDotNet version to 0.15.8
    Write-Host "Updating BenchmarkDotNet to version 0.15.8..."
    dotnet add $csprojPath package BenchmarkDotNet --version 0.15.8

    # 4. Replace Program.cs
    Write-Host "Replacing Program.cs..."
    Set-Content -Path $programCsPath -Value $programCsContent -NoNewline

    # 5. Run benchmarks (must run from project directory for BenchmarkDotNet to find the project)
    Write-Host "Running benchmarks (this may take a while)..."
    Push-Location $benchmarkProjectDir
    dotnet run -c Release -- --filter *
    $benchmarkExitCode = $LASTEXITCODE
    Pop-Location
    if ($benchmarkExitCode -ne 0) {
        Write-Host "ERROR: Benchmark run failed for version $version." -ForegroundColor Red
        $report += [PSCustomObject]@{ Version = $version; Status = "FAILED (benchmark)"; Files = 0; Duration = "{0:hh\:mm\:ss}" -f ((Get-Date) - $versionStartTime) }
        git -C $repoRoot checkout -- .
        continue
    }

    # 6. Copy JSON results (excluding Simple benchmarks)
    if (-not (Test-Path -Path $resultsDir)) {
        Write-Host "WARNING: No results directory found for version $version. Skipping." -ForegroundColor Yellow
        $report += [PSCustomObject]@{ Version = $version; Status = "FAILED (no results)"; Files = 0; Duration = "{0:hh\:mm\:ss}" -f ((Get-Date) - $versionStartTime) }
        git -C $repoRoot checkout -- .
        continue
    }

    $versionOutputDir = "$outputBase\$version"
    if (-not (Test-Path -Path $versionOutputDir)) {
        New-Item -ItemType Directory -Path $versionOutputDir | Out-Null
    }

    $jsonFiles = Get-ChildItem -Path $resultsDir -Filter "*-report-brief.json" | Where-Object { $_.Name -notmatch "Simple" }

    foreach ($file in $jsonFiles) {
        Copy-Item -Path $file.FullName -Destination $versionOutputDir -Force
    }

    Write-Host "Copied $($jsonFiles.Count) JSON files to $versionOutputDir"

    # 7. Fix known typos in benchmark output for affected versions

    # Fix "RedactkDate" -> "RedactDate" (misspelled method name in source, fixed in 2.4.0)
    if ($redactkDateTypoVersions -contains $version) {
        Write-Host "Fixing RedactkDate typo in JSON files..."
        $copiedFiles = Get-ChildItem -Path $versionOutputDir -Filter "*.json"

        foreach ($file in $copiedFiles) {
            $content = Get-Content -Path $file.FullName -Raw
            if ($content -match "RedactkDate") {
                $content = $content -replace "RedactkDate", "RedactDate"
                Set-Content -Path $file.FullName -Value $content -NoNewline
            }

            if ($file.Name -match "RedactkDate") {
                $newName = $file.Name -replace "RedactkDate", "RedactDate"
                Rename-Item -Path $file.FullName -NewName $newName
            }
        }
    }

    # Fix PhoneNumber validator method name: "ValidateMacAddresses" -> "ValidatePhoneNumber"
    # (copy-paste error in benchmark source, fixed in 3.0.0. Tags are immutable so we fix the output here)
    if ($phoneNumberTypoVersions -contains $version) {
        $phoneFile = Join-Path $versionOutputDir "ZeroRedact.Benchmark.Validators.PhoneNumberValidatorBenchmarks-report-brief.json"
        if (Test-Path -Path $phoneFile) {
            Write-Host "Fixing PhoneNumber validator method name in JSON..."
            $content = Get-Content -Path $phoneFile -Raw
            $content = $content -replace "ValidateMacAddresses", "ValidatePhoneNumber"
            Set-Content -Path $phoneFile -Value $content -NoNewline
        }
    }

    # 8. Discard local changes
    Write-Host "Discarding local changes..."
    git -C $repoRoot checkout -- .

    $versionDuration = (Get-Date) - $versionStartTime
    $report += [PSCustomObject]@{ Version = $version; Status = "OK"; Files = $jsonFiles.Count; Duration = "{0:hh\:mm\:ss}" -f $versionDuration }
    Write-Host "Completed version $version at $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')" -ForegroundColor Green
}

# Return to original branch
git -C $repoRoot checkout $originalBranch

# Print summary report
$totalDuration = (Get-Date) - $scriptStartTime
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host " Benchmark Summary" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
$report | Format-Table -Property Version, Status, Files, Duration -AutoSize
Write-Host "Total time: $("{0:hh\:mm\:ss}" -f $totalDuration)"
Write-Host "Results in: $outputBase"
Write-Host ""

$failed = ($report | Where-Object { $_.Status -ne "OK" }).Count
if ($failed -gt 0) {
    Write-Host "$failed version(s) failed." -ForegroundColor Red
} else {
    Write-Host "All versions completed successfully." -ForegroundColor Green
}

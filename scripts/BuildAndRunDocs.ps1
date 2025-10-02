if (-not (Get-Command docfx -ErrorAction SilentlyContinue)) {
    Write-Host "The 'docfx' tool is not installed. Please run the following command to install it:"
    Write-Host "dotnet tool update -g docfx"
    exit 1
}

$docsJsonPath = Resolve-Path "..\docfx\docfx.json"
$apiFolderPath = Resolve-Path "..\docfx\api"

Write-Host "Generating benchmark pages..."
dotnet run GenerateBenchmarkPages.cs
Write-Host "Generating benchmark pages complete."


# Remove the /api folder and its contents
# Gives a fresh API refresh each run
Remove-Item -Path $apiFolderPath -Recurse -Force

docfx metadata $docsJsonPath
docfx build $docsJsonPath --serve --open-browser
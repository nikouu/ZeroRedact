if (-not (Get-Command docfx -ErrorAction SilentlyContinue)) {
    Write-Host "The 'docfx' tool is not installed. Please run the following command to install it:"
    Write-Host "dotnet tool update -g docfx"
    exit 1
}

# 01 - Run the docfx tool
# Define the relative path to the .json file
$docsJsonPath = "..\docfx\docfx.json"

# Get the full path to the .json
$fulldocsJsonPath = Resolve-Path $docsJsonPath

docfx metadata $fulldocsJsonPath
docfx build $fulldocsJsonPath --serve --open-browser
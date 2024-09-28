if (-not (Get-Command docfx -ErrorAction SilentlyContinue)) {
    Write-Host "The 'docfx' tool is not installed. Please run the following command to install it:"
    Write-Host "dotnet tool update -g docfx"
    exit 1
}

# 01 - Copy over the readme.md file to the docfx folder
$sourcePath = "../readme.md"
$destinationPath = "../docfx/index.md"

# Read the contents of the source file
$sourceContent = Get-Content -Path $sourcePath -Raw

# Define the string to be added at the top
$header = @"
---
_layout: landing
---
"@

# Combine the header and the source content
$combinedContent = $header + "`n" + $sourceContent

# Write the combined content to the destination file
Set-Content -Path $destinationPath -Value $combinedContent

# 02 - Run the docfx tool
# Define the relative path to the .json file
$docsJsonPath = "..\docfx\docfx.json"

# Get the full path to the .json
$fulldocsJsonPath = Resolve-Path $docsJsonPath

docfx $fulldocsJsonPath --serve


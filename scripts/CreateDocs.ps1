if (-not (Get-Command docfx -ErrorAction SilentlyContinue)) {
    Write-Host "The 'docfx' tool is not installed. Please run the following command to install it:"
    Write-Host "dotnet tool update -g docfx"
    exit 1
}
# PowerShell script to create a NuGet package

$project = "..\src\ZeroRedact\ZeroRedact.csproj"
$output = "..\artifacts"


Write-Output "Packing the NuGet package..."
dotnet pack $project -c Release -o $output

Write-Output "NuGet package created successfully."
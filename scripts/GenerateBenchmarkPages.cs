using System.Text.Json;

// Change to benchmarks directory
var benchmarksPath = Path.Combine("..", "benchmarks");
Directory.SetCurrentDirectory(benchmarksPath);

// Get all version folders
var versionFolders = Directory.GetDirectories(".")
    .Select(d => new DirectoryInfo(d).Name)
    .Where(name => Version.TryParse(name, out _))
    .OrderBy(name => Version.Parse(name))
    .ToList();

Console.WriteLine($"Found {versionFolders.Count} version folders: {string.Join(", ", versionFolders)}");

// Group all benchmark files by their type (namespace)
var benchmarkGroups = new Dictionary<string, List<(string version, string filePath)>>();

foreach (var version in versionFolders)
{
    var jsonFiles = Directory.GetFiles(version, "*-report-brief.json");
    
    foreach (var file in jsonFiles)
    {
        var fileName = Path.GetFileNameWithoutExtension(file);
        var benchmarkName = fileName.Replace("-report-brief", "");
        
        if (!benchmarkGroups.ContainsKey(benchmarkName))
        {
            benchmarkGroups[benchmarkName] = new List<(string, string)>();
        }
        
        benchmarkGroups[benchmarkName].Add((version, file));
    }
}

Console.WriteLine($"Found {benchmarkGroups.Count} unique benchmark types");

// Store benchmark info for generating index and toc
var benchmarkInfoList = new List<(string name, string category, string displayName)>();

// Output to docfx benchmarks folder
var docfxBenchmarksPath = Path.Combine("..", "docfx", "benchmarks");
Directory.CreateDirectory(docfxBenchmarksPath);

// Process each benchmark group and generate HTML
foreach (var (benchmarkName, files) in benchmarkGroups)
{
    Console.WriteLine($"Processing {benchmarkName}...");
    
    var dataPoints = new List<(string version, string method, double mean, int allocated)>();
    
    foreach (var (version, filePath) in files.OrderBy(f => Version.Parse(f.version)))
    {
        try
        {
            var json = File.ReadAllText(filePath);
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            
            if (root.TryGetProperty("Benchmarks", out var benchmarks))
            {
                foreach (var benchmark in benchmarks.EnumerateArray())
                {
                    var method = benchmark.GetProperty("Method").GetString() ?? "";
                    var mean = benchmark.GetProperty("Statistics").GetProperty("Mean").GetDouble();
                    var allocated = benchmark.GetProperty("Memory").GetProperty("BytesAllocatedPerOperation").GetInt32();
                    
                    dataPoints.Add((version, method, mean, allocated));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error reading {filePath}: {ex.Message}");
        }
    }
    
    // Group by method to create separate lines in the chart
    var methodGroups = dataPoints.GroupBy(d => d.method).ToList();
    
    // Generate HTML with Chart.js
    var htmlContent = GenerateChartHtml(benchmarkName, versionFolders, methodGroups);
    
    // Create markdown with embedded HTML
    var markdownContent = GenerateMarkdownWithHtml(benchmarkName, htmlContent);
    var mdOutputPath = Path.Combine(docfxBenchmarksPath, $"{benchmarkName}.md");
    File.WriteAllText(mdOutputPath, markdownContent);
    Console.WriteLine($"  Generated {mdOutputPath}");
    
    // Extract category and display name for TOC generation
    var parts = benchmarkName.Split('.');
    var category = parts.Length > 2 && parts[2] == "Redactors" ? "Redactors" : "Validators";
    var displayName = parts.Length > 3 ? parts[3].Replace("Benchmarks", "") : benchmarkName;
    benchmarkInfoList.Add((benchmarkName, category, displayName));
}

// Generate index.md
Console.WriteLine("\nGenerating index.md...");
var indexContent = GenerateIndexMarkdown(benchmarkInfoList);
var indexPath = Path.Combine(docfxBenchmarksPath, "index.md");
File.WriteAllText(indexPath, indexContent);
Console.WriteLine($"  Generated {indexPath}");

// Generate toc.yml
Console.WriteLine("Generating toc.yml...");
var tocContent = GenerateTocYaml(benchmarkInfoList);
var tocPath = Path.Combine(docfxBenchmarksPath, "toc.yml");
File.WriteAllText(tocPath, tocContent);
Console.WriteLine($"  Generated {tocPath}");

Console.WriteLine("\nDone! Benchmark files have been generated in the docfx/benchmarks folder.");

// Function to generate markdown with embedded HTML
string GenerateMarkdownWithHtml(string benchmarkName, string htmlContent)
{
    return $@"# {benchmarkName}

{htmlContent}";
}

// Function to generate Chart HTML content
string GenerateChartHtml(string benchmarkName, List<string> versions, List<IGrouping<string, (string version, string method, double mean, int allocated)>> methodGroups)
{
    // Prepare data for Chart.js
    var colors = new[] { "#FF6384", "#36A2EB", "#FFCE56", "#4BC0C0", "#9966FF", "#FF9F40", "#FF6384", "#C9CBCF" };
    
    var durationDatasets = new List<string>();
    var memoryDatasets = new List<string>();
    
    for (int i = 0; i < methodGroups.Count; i++)
    {
        var method = methodGroups[i];
        var color = colors[i % colors.Length];
        
        var durationValues = versions.Select(v =>
        {
            var point = method.FirstOrDefault(m => m.version == v);
            return point.mean > 0 ? point.mean.ToString("F2") : "null";
        });
        
        var memoryValues = versions.Select(v =>
        {
            var point = method.FirstOrDefault(m => m.version == v);
            return point.allocated > 0 ? point.allocated.ToString() : "null";
        });
        
        durationDatasets.Add($@"
            {{
                label: '{method.Key}',
                data: [{string.Join(", ", durationValues)}],
                borderColor: '{color}',
                backgroundColor: '{color}33',
                tension: 0.1
            }}");
        
        memoryDatasets.Add($@"
            {{
                label: '{method.Key}',
                data: [{string.Join(", ", memoryValues)}],
                borderColor: '{color}',
                backgroundColor: '{color}33',
                tension: 0.1
            }}");
    }
    
    var versionsJson = "[" + string.Join(", ", versions.Select(v => $"\"{v}\"")) + "]";
    
    // Generate duration table HTML
    var durationTableRows = string.Join("", methodGroups.Select(method => 
    {
        var durationCells = string.Join("", versions.Select(v =>
        {
            var point = method.FirstOrDefault(m => m.version == v);
            var value = point.mean > 0 ? point.mean.ToString("F3") + " ns" : "-";
            return $"<td class=\"number-col\">{value}</td>";
        }));
        
        return $"<tr><td class=\"method-col\">{method.Key}</td>{durationCells}</tr>";
    }));
    
    // Generate memory table HTML
    var memoryTableRows = string.Join("", methodGroups.Select(method => 
    {
        var memoryCells = string.Join("", versions.Select(v =>
        {
            var point = method.FirstOrDefault(m => m.version == v);
            string value;
            if (point.allocated <= 0)
            {
                value = "-";
            }
            else if (point.allocated < 1024)
            {
                value = point.allocated.ToString("F0") + " B";
            }
            else if (point.allocated < 1024 * 1024)
            {
                value = (point.allocated / 1024.0).ToString("F3") + " KB";
            }
            else
            {
                value = (point.allocated / (1024.0 * 1024.0)).ToString("F3") + " MB";
            }
            return $"<td class=\"number-col\">{value}</td>";
        }));
        
        return $"<tr><td class=\"method-col\">{method.Key}</td>{memoryCells}</tr>";
    }));
    
    var versionHeaders = string.Join("", versions.Select(v => $"<th class=\"number-col\">{v}</th>"));
    
    // Return HTML content that can be embedded directly in markdown
    return $@"<script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>
<style>
    .chart-container {{
        background: white;
        border-radius: 8px;
        padding: 20px;
        margin-bottom: 30px;
        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    }}
    .chart-title {{
        font-size: 18px;
        font-weight: 600;
        color: #555;
        margin-bottom: 15px;
        text-align: center;
    }}
    table {{
        width: 100%;
        border-collapse: collapse;
        background: white;
        border-radius: 8px;
        overflow: hidden;
        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        margin-top: 30px;
    }}
    th {{
        background: #f8f9fa;
        padding: 12px;
        text-align: left;
        font-weight: 600;
        color: #333;
        border-bottom: 2px solid #dee2e6;
    }}
    td {{
        padding: 10px 12px;
        border-bottom: 1px solid #dee2e6;
    }}
    tr:last-child td {{
        border-bottom: none;
    }}
    tr:hover {{
        background: #f8f9fa;
    }}
    .method-col {{
        font-weight: 500;
        color: #495057;
    }}
    .number-col {{
        text-align: right;
      
    }}
    h2 {{
        color: #333;
        margin-top: 40px;
        margin-bottom: 20px;
    }}
    .section-group {{
        margin-bottom: 60px;
    }}
</style>

<div class=""section-group"">
    <h2>Duration Chart</h2>
    <div class=""chart-container"">
        <div class=""chart-title"">Duration (ns) Over Versions</div>
        <canvas id=""durationChart_{benchmarkName.Replace(".", "_")}""></canvas>
    </div>
    
    <h2>Duration Results</h2>
    <table>
        <thead>
            <tr>
                <th class=""method-col"">Method</th>
                {versionHeaders}
            </tr>
        </thead>
        <tbody>
            {durationTableRows}
        </tbody>
    </table>
</div>

<div class=""section-group"">
    <h2>Memory Allocation Chart</h2>
    <div class=""chart-container"">
        <div class=""chart-title"">Allocated Memory (bytes) Over Versions</div>
        <canvas id=""memoryChart_{benchmarkName.Replace(".", "_")}""></canvas>
    </div>
    
    <h2>Memory Allocation Results</h2>
    <table>
        <thead>
            <tr>
                <th class=""method-col"">Method</th>
                {versionHeaders}
            </tr>
        </thead>
        <tbody>
            {memoryTableRows}
        </tbody>
    </table>
</div>

<script>
    const versions_{benchmarkName.Replace(".", "_")} = {versionsJson};
    
    // Duration Chart
    new Chart(document.getElementById('durationChart_{benchmarkName.Replace(".", "_")}'), {{
        type: 'line',
        data: {{
            labels: versions_{benchmarkName.Replace(".", "_")},
            datasets: [{string.Join(",", durationDatasets)}]
        }},
        options: {{
            responsive: true,
            plugins: {{
                legend: {{
                    position: 'top',
                }},
                tooltip: {{
                    callbacks: {{
                        label: function(context) {{
                            return context.dataset.label + ': ' + context.parsed.y.toFixed(2) + ' ns';
                        }}
                    }}
                }}
            }},
            scales: {{
                y: {{
                    beginAtZero: true,
                    title: {{
                        display: true,
                        text: 'Mean Duration (ns)'
                    }}
                }},
                x: {{
                    title: {{
                        display: true,
                        text: 'Version'
                    }}
                }}
            }}
        }}
    }});
    
    // Memory Chart
    new Chart(document.getElementById('memoryChart_{benchmarkName.Replace(".", "_")}'), {{
        type: 'line',
        data: {{
            labels: versions_{benchmarkName.Replace(".", "_")},
            datasets: [{string.Join(",", memoryDatasets)}]
        }},
        options: {{
            responsive: true,
            plugins: {{
                legend: {{
                    position: 'top',
                }},
                tooltip: {{
                    callbacks: {{
                        label: function(context) {{
                            return context.dataset.label + ': ' + context.parsed.y + ' bytes';
                        }}
                    }}
                }}
            }},
            scales: {{
                y: {{
                    beginAtZero: true,
                    title: {{
                        display: true,
                        text: 'Bytes Allocated Per Operation'
                    }}
                }},
                x: {{
                    title: {{
                        display: true,
                        text: 'Version'
                    }}
                }}
            }}
        }}
    }});
</script>";
}

// Function to generate index.md
string GenerateIndexMarkdown(List<(string name, string category, string displayName)> benchmarks)
{
    var redactors = benchmarks.Where(b => b.category == "Redactors").OrderBy(b => b.displayName).ToList();
    var validators = benchmarks.Where(b => b.category == "Validators").OrderBy(b => b.displayName).ToList();
    
    var content = new System.Text.StringBuilder();
    content.AppendLine("# Benchmarks");
    content.AppendLine();
    content.AppendLine("Performance benchmarks for ZeroRedact across different versions. Each benchmark shows the mean duration and memory allocation for various operations.");
    content.AppendLine();
    
    if (redactors.Any())
    {
        content.AppendLine("## Redactor Benchmarks");
        content.AppendLine();
        content.AppendLine("Performance benchmarks for redaction operations:");
        content.AppendLine();
        foreach (var benchmark in redactors)
        {
            content.AppendLine($"- [{benchmark.displayName}]({benchmark.name}.md)");
        }
        content.AppendLine();
    }
    
    if (validators.Any())
    {
        content.AppendLine("## Validator Benchmarks");
        content.AppendLine();
        content.AppendLine("Performance benchmarks for validation operations:");
        content.AppendLine();
        foreach (var benchmark in validators)
        {
            content.AppendLine($"- [{benchmark.displayName}]({benchmark.name}.md)");
        }
        content.AppendLine();
    }
    
    content.AppendLine("## About the Benchmarks");
    content.AppendLine();
    content.AppendLine("These benchmarks are generated using [BenchmarkDotNet](https://benchmarkdotnet.org/). The charts display:");
    content.AppendLine();
    content.AppendLine("- **Duration Chart**: Shows the mean execution time in nanoseconds for each method across versions");
    content.AppendLine("- **Memory Chart**: Shows the bytes allocated per operation for each method across versions");
    content.AppendLine();
    content.AppendLine("Lower values indicate better performance.");
    
    return content.ToString();
}

// Function to generate toc.yml
string GenerateTocYaml(List<(string name, string category, string displayName)> benchmarks)
{
    var redactors = benchmarks.Where(b => b.category == "Redactors").OrderBy(b => b.displayName).ToList();
    var validators = benchmarks.Where(b => b.category == "Validators").OrderBy(b => b.displayName).ToList();
    
    var content = new System.Text.StringBuilder();
    content.AppendLine("- name: Overview");
    content.AppendLine("  href: index.md");
    
    if (redactors.Any())
    {
        content.AppendLine("- name: Redactors");
        content.AppendLine("  items:");
        foreach (var benchmark in redactors)
        {
            content.AppendLine($"  - name: {benchmark.displayName}");
            content.AppendLine($"    href: {benchmark.name}.md");
        }
    }
    
    if (validators.Any())
    {
        content.AppendLine("- name: Validators");
        content.AppendLine("  items:");
        foreach (var benchmark in validators)
        {
            content.AppendLine($"  - name: {benchmark.displayName}");
            content.AppendLine($"    href: {benchmark.name}.md");
        }
    }
    
    return content.ToString();
}

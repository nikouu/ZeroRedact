# ZeroRedact.Benchmark.Redactors.RedactStringBenchmarks

> **Note**: These values are averaged across multiple benchmarks. They represent an overall view of the performance, not any one single redaction performance. Please see the [benchmarks folder](https://github.com/nikouu/ZeroRedact/tree/main/benchmarks) for per-test benchmarks.

<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
<style>
    .chart-container {
        background: white;
        border-radius: 8px;
        padding: 20px;
        margin-bottom: 30px;
        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    }
    .chart-title {
        font-size: 18px;
        font-weight: 600;
        color: #555;
        margin-bottom: 15px;
        text-align: center;
    }
    table {
        width: 100%;
        border-collapse: collapse;
        background: white;
        border-radius: 8px;
        overflow: hidden;
        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        margin-top: 30px;
    }
    th {
        background: #f8f9fa;
        padding: 12px;
        text-align: left;
        font-weight: 600;
        color: #333;
        border-bottom: 2px solid #dee2e6;
    }
    td {
        padding: 10px 12px;
        border-bottom: 1px solid #dee2e6;
    }
    tr:last-child td {
        border-bottom: none;
    }
    tr:hover {
        background: #f8f9fa;
    }
    .method-col {
        font-weight: 500;
        color: #495057;
    }
    .number-col {
        text-align: right;
      
    }
    h2 {
        margin-top: 40px;
        margin-bottom: 20px;
    }
    .section-group {
        margin-bottom: 60px;
    }
</style>

<div class="section-group">
    <h2>Duration Chart</h2>
    <div class="chart-container">
        <div class="chart-title">Duration (ns) Over Versions</div>
        <canvas id="durationChart_ZeroRedact_Benchmark_Redactors_RedactStringBenchmarks"></canvas>
    </div>
    
    <h2>Duration Results</h2>
    <table>
        <thead>
            <tr>
                <th class="method-col">Method</th>
                <th class="number-col">2.1.0</th><th class="number-col">2.2.0</th><th class="number-col">2.3.0</th><th class="number-col">2.4.0</th><th class="number-col">2.4.1</th><th class="number-col">3.0.0</th>
            </tr>
        </thead>
        <tbody>
            <tr><td class="method-col">RedactString_String</td><td class="number-col">12.432 ns</td><td class="number-col">12.769 ns</td><td class="number-col">11.234 ns</td><td class="number-col">12.126 ns</td><td class="number-col">11.714 ns</td><td class="number-col">4.884 ns</td></tr><tr><td class="method-col">RedactString_ReadOnlySpan</td><td class="number-col">13.455 ns</td><td class="number-col">12.408 ns</td><td class="number-col">13.094 ns</td><td class="number-col">13.123 ns</td><td class="number-col">11.984 ns</td><td class="number-col">5.368 ns</td></tr>
        </tbody>
    </table>
</div>

<div class="section-group">
    <h2>Memory Allocation Chart</h2>
    <div class="chart-container">
        <div class="chart-title">Allocated Memory (bytes) Over Versions</div>
        <canvas id="memoryChart_ZeroRedact_Benchmark_Redactors_RedactStringBenchmarks"></canvas>
    </div>
    
    <h2>Memory Allocation Results</h2>
    <table>
        <thead>
            <tr>
                <th class="method-col">Method</th>
                <th class="number-col">2.1.0</th><th class="number-col">2.2.0</th><th class="number-col">2.3.0</th><th class="number-col">2.4.0</th><th class="number-col">2.4.1</th><th class="number-col">3.0.0</th>
            </tr>
        </thead>
        <tbody>
            <tr><td class="method-col">RedactString_String</td><td class="number-col">80 B</td><td class="number-col">80 B</td><td class="number-col">80 B</td><td class="number-col">80 B</td><td class="number-col">80 B</td><td class="number-col">80 B</td></tr><tr><td class="method-col">RedactString_ReadOnlySpan</td><td class="number-col">80 B</td><td class="number-col">80 B</td><td class="number-col">80 B</td><td class="number-col">80 B</td><td class="number-col">80 B</td><td class="number-col">80 B</td></tr>
        </tbody>
    </table>
</div>

<script>
    const versions_ZeroRedact_Benchmark_Redactors_RedactStringBenchmarks = ["2.1.0", "2.2.0", "2.3.0", "2.4.0", "2.4.1", "3.0.0"];
    
    // Duration Chart
    new Chart(document.getElementById('durationChart_ZeroRedact_Benchmark_Redactors_RedactStringBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_Redactors_RedactStringBenchmarks,
            datasets: [
            {
                label: 'RedactString_String',
                data: [12.43, 12.77, 11.23, 12.13, 11.71, 4.88],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
                tension: 0.1
            },
            {
                label: 'RedactString_ReadOnlySpan',
                data: [13.45, 12.41, 13.09, 13.12, 11.98, 5.37],
                borderColor: '#36A2EB',
                backgroundColor: '#36A2EB33',
                tension: 0.1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            return context.dataset.label + ': ' + context.parsed.y.toFixed(2) + ' ns';
                        }
                    }
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Mean Duration (ns)'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Version'
                    }
                }
            }
        }
    });
    
    // Memory Chart
    new Chart(document.getElementById('memoryChart_ZeroRedact_Benchmark_Redactors_RedactStringBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_Redactors_RedactStringBenchmarks,
            datasets: [
            {
                label: 'RedactString_String',
                data: [80, 80, 80, 80, 80, 80],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
                tension: 0.1
            },
            {
                label: 'RedactString_ReadOnlySpan',
                data: [80, 80, 80, 80, 80, 80],
                borderColor: '#36A2EB',
                backgroundColor: '#36A2EB33',
                tension: 0.1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            return context.dataset.label + ': ' + context.parsed.y + ' bytes';
                        }
                    }
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Bytes Allocated Per Operation'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Version'
                    }
                }
            }
        }
    });
</script>
# ZeroRedact.Benchmark.Redactors.RedactDateBenchmarks

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
        <canvas id="durationChart_ZeroRedact_Benchmark_Redactors_RedactDateBenchmarks"></canvas>
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
            <tr><td class="method-col">RedactDate_DateTime</td><td class="number-col">41.829 ns</td><td class="number-col">42.792 ns</td><td class="number-col">43.634 ns</td><td class="number-col">-</td><td class="number-col">43.495 ns</td><td class="number-col">31.289 ns</td></tr><tr><td class="method-col">RedactDate_DateOnly</td><td class="number-col">42.684 ns</td><td class="number-col">43.104 ns</td><td class="number-col">43.009 ns</td><td class="number-col">51.865 ns</td><td class="number-col">42.221 ns</td><td class="number-col">31.558 ns</td></tr><tr><td class="method-col">RedactDate_DateTime</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">43.423 ns</td><td class="number-col">-</td><td class="number-col">-</td></tr>
        </tbody>
    </table>
</div>

<div class="section-group">
    <h2>Memory Allocation Chart</h2>
    <div class="chart-container">
        <div class="chart-title">Allocated Memory (bytes) Over Versions</div>
        <canvas id="memoryChart_ZeroRedact_Benchmark_Redactors_RedactDateBenchmarks"></canvas>
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
            <tr><td class="method-col">RedactDate_DateTime</td><td class="number-col">40 B</td><td class="number-col">40 B</td><td class="number-col">40 B</td><td class="number-col">-</td><td class="number-col">40 B</td><td class="number-col">40 B</td></tr><tr><td class="method-col">RedactDate_DateOnly</td><td class="number-col">40 B</td><td class="number-col">40 B</td><td class="number-col">40 B</td><td class="number-col">40 B</td><td class="number-col">40 B</td><td class="number-col">40 B</td></tr><tr><td class="method-col">RedactDate_DateTime</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">40 B</td><td class="number-col">-</td><td class="number-col">-</td></tr>
        </tbody>
    </table>
</div>

<script>
    const versions_ZeroRedact_Benchmark_Redactors_RedactDateBenchmarks = ["2.1.0", "2.2.0", "2.3.0", "2.4.0", "2.4.1", "3.0.0"];
    
    // Duration Chart
    new Chart(document.getElementById('durationChart_ZeroRedact_Benchmark_Redactors_RedactDateBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_Redactors_RedactDateBenchmarks,
            datasets: [
            {
                label: 'RedactDate_DateTime',
                data: [41.83, 42.79, 43.63, null, 43.49, 31.29],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
                tension: 0.1
            },
            {
                label: 'RedactDate_DateOnly',
                data: [42.68, 43.10, 43.01, 51.87, 42.22, 31.56],
                borderColor: '#36A2EB',
                backgroundColor: '#36A2EB33',
                tension: 0.1
            },
            {
                label: 'RedactDate_DateTime',
                data: [null, null, null, 43.42, null, null],
                borderColor: '#FFCE56',
                backgroundColor: '#FFCE5633',
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
    new Chart(document.getElementById('memoryChart_ZeroRedact_Benchmark_Redactors_RedactDateBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_Redactors_RedactDateBenchmarks,
            datasets: [
            {
                label: 'RedactDate_DateTime',
                data: [40, 40, 40, null, 40, 40],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
                tension: 0.1
            },
            {
                label: 'RedactDate_DateOnly',
                data: [40, 40, 40, 40, 40, 40],
                borderColor: '#36A2EB',
                backgroundColor: '#36A2EB33',
                tension: 0.1
            },
            {
                label: 'RedactDate_DateTime',
                data: [null, null, null, 40, null, null],
                borderColor: '#FFCE56',
                backgroundColor: '#FFCE5633',
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
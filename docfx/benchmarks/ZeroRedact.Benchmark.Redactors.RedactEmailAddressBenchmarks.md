# ZeroRedact.Benchmark.Redactors.RedactEmailAddressBenchmarks

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
        <canvas id="durationChart_ZeroRedact_Benchmark_Redactors_RedactEmailAddressBenchmarks"></canvas>
    </div>
    
    <h2>Duration Results</h2>
    <table>
        <thead>
            <tr>
                <th class="method-col">Method</th>
                <th class="number-col">2.0.0</th><th class="number-col">2.1.0</th><th class="number-col">2.2.0</th><th class="number-col">2.3.0</th><th class="number-col">2.4.0</th><th class="number-col">2.4.1</th><th class="number-col">3.0.0</th>
            </tr>
        </thead>
        <tbody>
            <tr><td class="method-col">RedactEmailAddress_String</td><td class="number-col">31.188 ns</td><td class="number-col">32.353 ns</td><td class="number-col">30.270 ns</td><td class="number-col">31.960 ns</td><td class="number-col">36.765 ns</td><td class="number-col">36.765 ns</td><td class="number-col">36.765 ns</td></tr><tr><td class="method-col">RedactEmailAddress_ReadOnlySpan</td><td class="number-col">31.439 ns</td><td class="number-col">32.132 ns</td><td class="number-col">31.033 ns</td><td class="number-col">33.164 ns</td><td class="number-col">36.909 ns</td><td class="number-col">36.909 ns</td><td class="number-col">36.909 ns</td></tr>
        </tbody>
    </table>
</div>

<div class="section-group">
    <h2>Memory Allocation Chart</h2>
    <div class="chart-container">
        <div class="chart-title">Allocated Memory (bytes) Over Versions</div>
        <canvas id="memoryChart_ZeroRedact_Benchmark_Redactors_RedactEmailAddressBenchmarks"></canvas>
    </div>
    
    <h2>Memory Allocation Results</h2>
    <table>
        <thead>
            <tr>
                <th class="method-col">Method</th>
                <th class="number-col">2.0.0</th><th class="number-col">2.1.0</th><th class="number-col">2.2.0</th><th class="number-col">2.3.0</th><th class="number-col">2.4.0</th><th class="number-col">2.4.1</th><th class="number-col">3.0.0</th>
            </tr>
        </thead>
        <tbody>
            <tr><td class="method-col">RedactEmailAddress_String</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td></tr><tr><td class="method-col">RedactEmailAddress_ReadOnlySpan</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td><td class="number-col">224 B</td></tr>
        </tbody>
    </table>
</div>

<script>
    const versions_ZeroRedact_Benchmark_Redactors_RedactEmailAddressBenchmarks = ["2.0.0", "2.1.0", "2.2.0", "2.3.0", "2.4.0", "2.4.1", "3.0.0"];
    
    // Duration Chart
    new Chart(document.getElementById('durationChart_ZeroRedact_Benchmark_Redactors_RedactEmailAddressBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_Redactors_RedactEmailAddressBenchmarks,
            datasets: [
            {
                label: 'RedactEmailAddress_String',
                data: [31.19, 32.35, 30.27, 31.96, 36.76, 36.76, 36.76],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
                tension: 0.1
            },
            {
                label: 'RedactEmailAddress_ReadOnlySpan',
                data: [31.44, 32.13, 31.03, 33.16, 36.91, 36.91, 36.91],
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
    new Chart(document.getElementById('memoryChart_ZeroRedact_Benchmark_Redactors_RedactEmailAddressBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_Redactors_RedactEmailAddressBenchmarks,
            datasets: [
            {
                label: 'RedactEmailAddress_String',
                data: [224, 224, 224, 224, 224, 224, 224],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
                tension: 0.1
            },
            {
                label: 'RedactEmailAddress_ReadOnlySpan',
                data: [224, 224, 224, 224, 224, 224, 224],
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
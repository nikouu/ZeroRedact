# ZeroRedact.Benchmark.SimpleRedactionBenchmarks

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
        <canvas id="durationChart_ZeroRedact_Benchmark_SimpleRedactionBenchmarks"></canvas>
    </div>
    
    <h2>Duration Results</h2>
    <table>
        <thead>
            <tr>
                <th class="method-col">Method</th>
                <th class="number-col">2.0.0</th><th class="number-col">2.1.0</th><th class="number-col">2.2.0</th><th class="number-col">2.3.0</th><th class="number-col">2.4.0</th><th class="number-col">2.4.1</th><th class="number-col">3.0.0</th><th class="number-col">4.0.0</th>
            </tr>
        </thead>
        <tbody>
            <tr><td class="method-col">RedactFirstHalfString0</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">15.826 ns</td></tr><tr><td class="method-col">RedactFirstHalfString1</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">20.464 ns</td></tr><tr><td class="method-col">RedactFirstHalfString2</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">20.709 ns</td></tr><tr><td class="method-col">RedactFirstHalfString3</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">29.521 ns</td></tr><tr><td class="method-col">RedactFirstHalfString4</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">53.962 ns</td></tr><tr><td class="method-col">RedactFirstHalfString5</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">143.781 ns</td></tr><tr><td class="method-col">RedactFirstHalfString6</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">16.870 ns</td></tr>
        </tbody>
    </table>
</div>

<div class="section-group">
    <h2>Memory Allocation Chart</h2>
    <div class="chart-container">
        <div class="chart-title">Allocated Memory (bytes) Over Versions</div>
        <canvas id="memoryChart_ZeroRedact_Benchmark_SimpleRedactionBenchmarks"></canvas>
    </div>
    
    <h2>Memory Allocation Results</h2>
    <table>
        <thead>
            <tr>
                <th class="method-col">Method</th>
                <th class="number-col">2.0.0</th><th class="number-col">2.1.0</th><th class="number-col">2.2.0</th><th class="number-col">2.3.0</th><th class="number-col">2.4.0</th><th class="number-col">2.4.1</th><th class="number-col">3.0.0</th><th class="number-col">4.0.0</th>
            </tr>
        </thead>
        <tbody>
            <tr><td class="method-col">RedactFirstHalfString0</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">80 B</td></tr><tr><td class="method-col">RedactFirstHalfString1</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">176 B</td></tr><tr><td class="method-col">RedactFirstHalfString2</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">176 B</td></tr><tr><td class="method-col">RedactFirstHalfString3</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">208 B</td></tr><tr><td class="method-col">RedactFirstHalfString4</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">272 B</td></tr><tr><td class="method-col">RedactFirstHalfString5</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">168 B</td></tr><tr><td class="method-col">RedactFirstHalfString6</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">128 B</td></tr>
        </tbody>
    </table>
</div>

<script>
    const versions_ZeroRedact_Benchmark_SimpleRedactionBenchmarks = ["2.0.0", "2.1.0", "2.2.0", "2.3.0", "2.4.0", "2.4.1", "3.0.0", "4.0.0"];
    
    // Duration Chart
    new Chart(document.getElementById('durationChart_ZeroRedact_Benchmark_SimpleRedactionBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_SimpleRedactionBenchmarks,
            datasets: [
            {
                label: 'RedactFirstHalfString0',
                data: [null, null, null, null, null, null, null, 15.83],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString1',
                data: [null, null, null, null, null, null, null, 20.46],
                borderColor: '#36A2EB',
                backgroundColor: '#36A2EB33',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString2',
                data: [null, null, null, null, null, null, null, 20.71],
                borderColor: '#FFCE56',
                backgroundColor: '#FFCE5633',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString3',
                data: [null, null, null, null, null, null, null, 29.52],
                borderColor: '#4BC0C0',
                backgroundColor: '#4BC0C033',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString4',
                data: [null, null, null, null, null, null, null, 53.96],
                borderColor: '#9966FF',
                backgroundColor: '#9966FF33',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString5',
                data: [null, null, null, null, null, null, null, 143.78],
                borderColor: '#FF9F40',
                backgroundColor: '#FF9F4033',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString6',
                data: [null, null, null, null, null, null, null, 16.87],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
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
    new Chart(document.getElementById('memoryChart_ZeroRedact_Benchmark_SimpleRedactionBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_SimpleRedactionBenchmarks,
            datasets: [
            {
                label: 'RedactFirstHalfString0',
                data: [null, null, null, null, null, null, null, 80],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString1',
                data: [null, null, null, null, null, null, null, 176],
                borderColor: '#36A2EB',
                backgroundColor: '#36A2EB33',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString2',
                data: [null, null, null, null, null, null, null, 176],
                borderColor: '#FFCE56',
                backgroundColor: '#FFCE5633',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString3',
                data: [null, null, null, null, null, null, null, 208],
                borderColor: '#4BC0C0',
                backgroundColor: '#4BC0C033',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString4',
                data: [null, null, null, null, null, null, null, 272],
                borderColor: '#9966FF',
                backgroundColor: '#9966FF33',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString5',
                data: [null, null, null, null, null, null, null, 168],
                borderColor: '#FF9F40',
                backgroundColor: '#FF9F4033',
                tension: 0.1
            },
            {
                label: 'RedactFirstHalfString6',
                data: [null, null, null, null, null, null, null, 128],
                borderColor: '#FF6384',
                backgroundColor: '#FF638433',
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
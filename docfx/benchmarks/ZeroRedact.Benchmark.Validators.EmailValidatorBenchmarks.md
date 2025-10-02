# ZeroRedact.Benchmark.Validators.EmailValidatorBenchmarks

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
        <canvas id="durationChart_ZeroRedact_Benchmark_Validators_EmailValidatorBenchmarks"></canvas>
    </div>
    
    <h2>Duration Results</h2>
    <table>
        <thead>
            <tr>
                <th class="method-col">Method</th>
                <th class="number-col">2.0.0</th><th class="number-col">2.1.0</th><th class="number-col">2.2.0</th><th class="number-col">2.3.0</th><th class="number-col">2.4.0</th><th class="number-col">2.4.1</th>
            </tr>
        </thead>
        <tbody>
            <tr><td class="method-col">ValidateEmailAddresses</td><td class="number-col">8.748 ns</td><td class="number-col">8.820 ns</td><td class="number-col">8.621 ns</td><td class="number-col">8.814 ns</td><td class="number-col">8.639 ns</td><td class="number-col">8.662 ns</td></tr>
        </tbody>
    </table>
</div>

<div class="section-group">
    <h2>Memory Allocation Chart</h2>
    <div class="chart-container">
        <div class="chart-title">Allocated Memory (bytes) Over Versions</div>
        <canvas id="memoryChart_ZeroRedact_Benchmark_Validators_EmailValidatorBenchmarks"></canvas>
    </div>
    
    <h2>Memory Allocation Results</h2>
    <table>
        <thead>
            <tr>
                <th class="method-col">Method</th>
                <th class="number-col">2.0.0</th><th class="number-col">2.1.0</th><th class="number-col">2.2.0</th><th class="number-col">2.3.0</th><th class="number-col">2.4.0</th><th class="number-col">2.4.1</th>
            </tr>
        </thead>
        <tbody>
            <tr><td class="method-col">ValidateEmailAddresses</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td><td class="number-col">-</td></tr>
        </tbody>
    </table>
</div>

<script>
    const versions_ZeroRedact_Benchmark_Validators_EmailValidatorBenchmarks = ["2.0.0", "2.1.0", "2.2.0", "2.3.0", "2.4.0", "2.4.1"];
    
    // Duration Chart
    new Chart(document.getElementById('durationChart_ZeroRedact_Benchmark_Validators_EmailValidatorBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_Validators_EmailValidatorBenchmarks,
            datasets: [
            {
                label: 'ValidateEmailAddresses',
                data: [8.75, 8.82, 8.62, 8.81, 8.64, 8.66],
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
    new Chart(document.getElementById('memoryChart_ZeroRedact_Benchmark_Validators_EmailValidatorBenchmarks'), {
        type: 'line',
        data: {
            labels: versions_ZeroRedact_Benchmark_Validators_EmailValidatorBenchmarks,
            datasets: [
            {
                label: 'ValidateEmailAddresses',
                data: [null, null, null, null, null, null],
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
<?php
if (!isset($_SESSION['generos'])) {
    $_SESSION['generos'] = json_decode(file_get_contents('genero.json'), true);
}

$generoStats = [
    'Masculino' => 0,
    'Feminino' => 0,
    'Outro' => 0
];

foreach ($_SESSION['generos'] as $genero) {
    if (isset($generoStats[$genero])) {
        $generoStats[$genero]++;
    }
}
?>

<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    google.charts.load('current', {
        'packages': ['corechart']
    });
    google.charts.setOnLoadCallback(drawChart);
    
    function drawChart() {
        var data = google.visualization.arrayToDataTable([
            ['Gênero', 'Quantidade'],
            ['Masculino', <?php echo $generoStats['Masculino']; ?>],
            ['Feminino', <?php echo $generoStats['Feminino']; ?>],
            ['Outro', <?php echo $generoStats['Outro']; ?>]
        ]);
        
        var options = {
            'width': 425,
            'height': 325,
            slices: {
                0: { color: '#3498db' },
                1: { color: '#ff69b4' },
                2: { color: '#7f8c8d' }
            },
            backgroundColor: 'transparent',
            titleTextStyle: {
                color: '#fff'
            },
            legend: {
                textStyle: {
                    color: '#fff'
                }
            }
        };
        
        var chart = new google.visualization.PieChart(document.getElementById('piechart'));
        chart.draw(data, options);
    }
</script>

<div id="piechart" style="width: 100%; height: 300px;"></div>
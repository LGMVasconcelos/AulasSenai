<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <title>Verificador de ano bissexto</title>
</head>

<body>
    <center>
        <h2>VERIFICADOR DE ANO BISSEXTO</h2>
    </center>
    <hr />
    <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
        <div class="col">
            <div class="card mb-4 rounded-3 shadow-sw">
                <div class="card-header py-3">
                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-calendar" viewBox="0 0 16 16">
                        <path d="M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5M1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4z" />
                    </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>VERIFICADOR DE ANO BISSEXTO</b></font>
                </div>
                <div class="card-body">
                    <?php
                    $ano = $_POST['ano'];
                    $era = $ano < 0 ? "a.C." : "d.C.";

                    if (($ano % 4 == 0 && $ano % 100 != 0) || ($ano % 400 == 0)) {
                        echo "<h3 style='color:green;'>O ano <b>$ano $era</b> é bissexto!</h3>";
                    } else {
                        echo "<h3 style='color:red;'>O ano <b>$ano $era</b> não é bissexto!</h3>";
                    }
                    ?>
                </div>
            </div>
        </div>
    </div>
</body>

</html>

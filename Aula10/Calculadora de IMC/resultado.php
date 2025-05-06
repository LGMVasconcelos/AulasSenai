<?php
session_start();

$msg = "<div class='alert alert-danger'>Erro ao calcular o IMC. Certifique-se de preencher todos os campos corretamente.</div>";

if (!empty($_POST['peso']) && !empty($_POST['altura'])) {
    $peso = str_replace(',', '.', $_POST['peso']);
    $altura = str_replace(',', '.', $_POST['altura']);

    $peso = filter_var($peso, FILTER_VALIDATE_FLOAT);
    $altura = filter_var($altura, FILTER_VALIDATE_FLOAT);

    if ($peso && $altura && $altura > 0) {
        $_SESSION['peso'] = $peso;
        $_SESSION['altura'] = $altura;

        $imc = $peso / ($altura * $altura);
        $imc = number_format($imc, 2, '.', '');

        if ($imc < 18.5) {
            $msg = "<div class='alert alert-info'>Seu IMC é: <strong>$imc</strong>. Infelizmente, você está abaixo do peso ideal para a sua altura.</div>";
        } elseif ($imc < 24.9) {
            $msg = "<div class='alert alert-success'>Seu IMC é: <strong>$imc</strong>. Você está com o peso ideal para a sua altura.</div>";
        } elseif ($imc < 29.9) {
            $msg = "<div class='alert alert-warning'>Seu IMC é: <strong>$imc</strong>. Você está acima do peso ideal para a sua altura.</div>";
        } elseif ($imc < 34.9) {
            $msg = "<div class='alert alert-danger'>Seu IMC é: <strong>$imc</strong>. Você está obeso.</div>";
        } elseif ($imc < 39.9) {
            $msg = "<div class='alert alert-danger'>Seu IMC é: <strong>$imc</strong>. Você está severamente obeso.</div>";
        } else {
            $msg = "<div class='alert alert-danger'>Seu IMC é: <strong>$imc</strong>. Infelizmente, você está morbidamente obeso.</div>";
        }
    } else {
        $msg = "<div class='alert alert-danger'>Erro ao calcular o IMC. Certifique-se de que os valores inseridos são válidos.</div>";
    }
}
?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <title>Calculadora de Índice de Massa Corporal</title>
</head>

<body>
    <center>
        <h2>CALCULADORA IMC</h2>
    </center>
    <hr />
    <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
        <div class="col">
            <div class="card mb-4 rounded-3 shadow-sw">
                <div class="card-header py-3">
                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-person-arms-up" viewBox="0 0 16 16">
                        <path d="M8 3a1.5 1.5 0 1 0 0-3 1.5 1.5 0 0 0 0 3" />
                        <path d="m5.93 6.704-.846 8.451a.768.768 0 0 0 1.523.203l.81-4.865a.59.59 0 0 1 1.165 0l.81 4.865a.768.768 0 0 0 1.523-.203l-.845-8.451A1.5 1.5 0 0 1 10.5 5.5L13 2.284a.796.796 0 0 0-1.239-.998L9.634 3.84a.7.7 0 0 1-.33.235c-.23.074-.665.176-1.304.176-.64 0-1.074-.102-1.305-.176a.7.7 0 0 1-.329-.235L4.239 1.286a.796.796 0 0 0-1.24.998l2.5 3.216c.317.316.475.758.43 1.204Z" />
                    </svg>
                    </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>Calculadora de IMC</b></font>
                </div>
                <div class="card-body">
                    <label class="form-label">Sua Altura (em metros): <?php echo number_format($_SESSION['altura'] ?? 0, 2, ",", ".") ?></label>
                    <hr />
                    <label class="form-label">Seu peso (em kg): <?php echo number_format($_SESSION['peso'] ?? 0, 2, ",", ".") ?></label>
                    <hr />
                    <?php echo $msg; ?>
                    <br />
                    <a href="index.php" class="btn btn-outline-secondary">Voltar</a>
                </div>
            </div>
        </div>
    </div>
</body>

</html>

<?php
session_start();
if ($_SERVER['REQUEST_METHOD'] == 'POST' && isset($_POST['palavra'])) {
    $_SESSION['palavra'] = strtolower(trim($_POST['palavra']));
    $_SESSION['tentativas'] = 3;
}
$jogoencerrado = false;
if (!isset($_SESSION['palavra'])) {
    header("Location:index.php");
    exit;
}
$palavra = $_SESSION['palavra'];
$tamanho = strlen($palavra);
$msg = '';
if (isset($_POST['chute'])) {
    $chute = strtolower(trim($_POST['chute']));
    $_SESSION['tentativas']--;
    if ($chute === $palavra) {
        $msg = "<div class='alert alert-success'>Parabéns! Você acertou a palavra: <strong>$palavra</strong></div>";
        $jogoencerrado = true;
    } elseif ($_SESSION['tentativas'] <= 0) {
        $msg = "<div class='alert alert-danger'>Você perdeu! A palavra era: <strong>$palavra</strong></div>";
        $jogoencerrado = true;
    } else {
        $msg = "<div class='alert alert-warning'>Errado! Tentativas restantes: <strong>{$_SESSION['tentativas']}</strong></div>";
    }
    if ($jogoencerrado) {
        session_unset();
        session_destroy();
        header("Refresh: 5;URL=index.php");
    }
}
?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <title>Palavra Secreta</title>
</head>

<body>
    <center>
        <h2>WORD GAME</h2>
    </center>
    <hr />
    <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
        <div class="col">
            <div class="card mb-4 rounded-3 shadow-sw">
                <div class="card-header py-3">
                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-question-octagon-fill" viewBox="0 0 16 16">
                        <path d="M11.46.146A.5.5 0 0 0 11.107 0H4.893a.5.5 0 0 0-.353.146L.146 4.54A.5.5 0 0 0 0 4.893v6.214a.5.5 0 0 0 .146.353l4.394 4.394a.5.5 0 0 0 .353.146h6.214a.5.5 0 0 0 .353-.146l4.394-4.394a.5.5 0 0 0 .146-.353V4.893a.5.5 0 0 0-.146-.353zM5.496 6.033a.237.237 0 0 1-.24-.247C5.35 4.091 6.737 3.5 8.005 3.5c1.396 0 2.672.73 2.672 2.24 0 1.08-.635 1.594-1.244 2.057-.737.559-1.01.768-1.01 1.486v.105a.25.25 0 0 1-.25.25h-.81a.25.25 0 0 1-.25-.246l-.004-.217c-.038-.927.495-1.498 1.168-1.987.59-.444.965-.736.965-1.371 0-.825-.628-1.168-1.314-1.168-.803 0-1.253.478-1.342 1.134-.018.137-.128.25-.266.25h-.825zm2.325 6.443c-.584 0-1.009-.394-1.009-.927 0-.552.425-.94 1.01-.94.609 0 1.028.388 1.028.94 0 .533-.42.927-1.029.927" />
                    </svg>
                    </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>PALAVRA SECRETA</b></font>
                </div>
                <div class="card-body">
                    <h3>Dica: A palavra tem <strong><?php echo $tamanho; ?> letras.</strong></h3>
                    <?php if (!empty($msg)) echo $msg; ?>
                    <?php if (!$jogoencerrado): ?>
                        <form action="resultado.php" method="post">
                            <label class="form-label">Digite uma palavra</label>
                            <input class="form-control" type="text" name="chute" required placeholder="Digite uma palavra" />
                            <br />
                            <input type="submit" class="btn btn-outline-success" value="ADIVINHAR" />
                        </form>
                    <?php else: ?>
                        <a href="index.php" class="btn btn-secondary">RECOMEÇAR</a>
                        <p class="text-muted mt-2">Você será redirecionado em alguns segundos...</p>
                    <?php endif; ?>
                </div>
            </div>
        </div>
    </div>
</body>

</html>

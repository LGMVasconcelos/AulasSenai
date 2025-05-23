<?php
    session_start();
    $email = $_POST['email'] ?? '';
    $senha = $_POST['senha'] ?? '';
    $emails = json_decode(file_get_contents("email.json"), true);
    $senhas = json_decode(file_get_contents("senha.json"), true);
    $indice = array_search($email, $emails);
    if ($indice !== false && isset($senhas[$indice]) && $senha === $senhas[$indice]) {
        $_SESSION['usuario'] = $email;
        header("Location: menu.php");
        exit;
    } else {
        echo "<script>alert('Credenciais inválidas. Tente novamente, por favor!');</script>";
        echo "<script>window.location.href='index.php';</script>";
        exit;
    }
?>
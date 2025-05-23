<?php
    session_start();
    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $id = $_POST['id'];
        $nome = $_POST['nome'];
        $email = $_POST['email'];
        $genero = $_POST['genero'];
        $senha = $_POST['senha'];
        $_SESSION['nomes'][$id] = $nome;
        $_SESSION['emails'][$id] = $email;
        $_SESSION['generos'][$id] = $genero;
        $_SESSION['senhas'][$id] = $senha;
        header("Location: listagem.php");
    }
?>

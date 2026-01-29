<?php
$servidor = 'localhost';
$usuario = 'root';
$senha = '';
$banco = 'senai';

//Criando a conexão
$conn = mysqli_connect($servidor, $usuario, $senha, $banco);

//Testando se deu certo
if (!$conn) {
    die("A conexão falhou: " . mysqli_connect_error());
}
?>
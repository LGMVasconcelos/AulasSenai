<?php
include_once("conexao.php");

$id = $_POST['id'];
$nome = $_POST['nome'];
$email = $_POST['email'];

$sql = "update alunos set nome = '$nome', email = '$email' where id = $id";

if (mysqli_query($conn, $sql)) {
    header("Location: lista.php");
} else {
    echo "Erro ao atualizar o aluno.";
}
?>
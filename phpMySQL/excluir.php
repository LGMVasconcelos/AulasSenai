<?php
include_once("conexao.php");

$id = $_GET['id'];

$sql = "delete from alunos where id = $id";

if (mysqli_query($conn, $sql)) {
    header("Location: lista.php");
} else {
    echo "Erro ao excluir o aluno.";
}
?>
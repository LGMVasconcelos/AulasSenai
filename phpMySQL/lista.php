<?php
include_once("conexao.php");
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="stylelist.css">
    <title>Lista de Alunos</title>
</head>
<body>
    <div class="container">
        <h2>Alunos Cadastrados</h2>
        <table>
            <tr>
                <th>Nome</th>
                <th>E-mail</th>
                <th>Ações</th>
            </tr>
            <?php
            $sql = "select * from alunos";
            $resultado = mysqli_query($conn, $sql);
            while($linha = mysqli_fetch_assoc($resultado)) {
                echo "<tr>";
                echo "<td>" . $linha['nome'] . "</td>";
                echo "<td>" . $linha['email'] . "</td>";
                echo "<td><a href='excluir.php?id=" . $linha['id'] . "' class='btn-excluir'>Excluir</a></td>";
                echo "<td><a href='editar.php?id=" . $linha['id'] . "' class='btn-editar'>Editar</a></td>";
                echo "</tr>";
            }
            ?>
            <a href="index.html" class="btn-voltar"><-- 
            Cadastrar Novo Aluno</a>
        </table>
    </div>
</body>
</html>
<?php
include_once("conexao.php");

$id = $_GET['id'];

$sql = "select * from alunos where id = $id";
$resultado = mysqli_query($conn, $sql);
$dados = mysqli_fetch_assoc($resultado);
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editar Aluno</title>
</head>
<body>
    <h2>Editar Aluno</h2>
    <form action="atualizar.php" method="post">
        <input type="hidden" name="id" value="<?php echo $dados['id']; ?>">
        <label for="nome">Nome:</label>
        <input type="text" name="nome" value="<?php echo $dados['nome']; ?>" required><br><br>
        <label for="email">Email:</label>
        <input type="email" name="email" value="<?php echo $dados['email']; ?>" required><br><br>
        <button type="submit" style="background: #007bff">Salvar alterações</button>
    </form>
</body>
</html>
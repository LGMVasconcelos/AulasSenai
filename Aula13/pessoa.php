<?php
session_start();
//Incializa o array
if (!isset($_SESSION['pessoas'])) {
    $_SESSION['pessoas'] = [];
}
//Adicionar
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $nome = $_POST['nome'];
    $idade = $_POST['idade'];
    $id = $_POST['id'];
    $pessoa = ['nome' => $nome, 'idade' => $idade];
    if ($id === '') {
        $_SESSION['pessoas'][] = $pessoa; //Criando o registro
    } else {
        $_SESSION['pessoas'][$id] = $pessoa; //Atualizando
    }
    header("Location:pessoa.php");
    exit();
}
//Deletar
if (isset($_GET['delete'])) {
    $id = $_GET['delete'];
    unset($_SESSION['pessoas'][$id]);
    header("Location:pessoa.php");
    exit();
}
//Editar
$editando = false;
$editId = '';
$editNome = '';
$editIdade = '';
if (isset($_GET['edit'])) {
    $editando = true;
    $editId = $_GET['edit'];
    $editNome = $_SESSION['pessoas'][$editId]['nome'];
    $editIdade = $_SESSION['pessoas'][$editId]['idade'];
}
?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
    <title> CRUD - PHP</title>
    <style>
        body {
            background-color: lightblue;
        }

        .contêinerDeTexto {
            margin: 5px;
        }
    </style>
</head>

<body>
    <center>
        <h2>CRUD</h2>
    </center>
    <hr />
    <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
        <div class="col">
            <div class="card mb-4 rounded-3 shadow-sw">
                <div class="card-header py-3">
                    <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" fill="green" class="bi bi-person-fill-check" viewBox="0 0 16 16">
                        <path d="M12.5 16a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7m1.679-4.493-1.335 2.226a.75.75 0 0 1-1.174.144l-.774-.773a.5.5 0 0 1 .708-.708l.547.548 1.17-1.951a.5.5 0 1 1 .858.514M11 5a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                        <path d="M2 13c0 1 1 1 1 1h5.256A4.5 4.5 0 0 1 8 12.5a4.5 4.5 0 0 1 1.544-3.393Q8.844 9.002 8 9c-5 0-6 3-6 4" />
                    </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>CRUD PESSOA</b></font
                        </div>
                    <div class="card-body">
                        <form method="post" action="pessoa.php" class="form-control">
                            <h2><?= $editando ? "Editar Pessoa" : "Cadastrar Pessoa" ?></h2>
                            <input type="hidden" name="id" value="<?= htmlspecialchars($editId) ?>">
                            <label for="nome">Nome:</label>
                            <input type="text" name="nome" class="contêinerDeTexto" required value="<?= htmlspecialchars($editNome) ?>" required>
                            <br>
                            <label for="idade">Idade:</label>
                            <input type="number" name="idade" class="contêinerDeTexto" required value="<?= htmlspecialchars($editIdade) ?>" required>
                            <br>
                            <button type="submit" class="btn btn-outline-success"><?= $editando ? "Atualizar" : "Cadastrar" ?></button>
                        </form>
                        <br>
                        <fieldset>
                            <table class="table table-striped table-hover">
                                <h2>LISTAGEM DAS PESSOAS</h2>
                                <thead>
                                    <th scope="col"> ID </th>
                                    <th scope="col">NOME</th>
                                    <th scope="col">IDADE</th>
                                    <th scope="col">AÇÕES</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <?php foreach ($_SESSION['pessoas'] as $index => $pessoa): ?>
                                        <tr>
                                            <td><?= htmlspecialchars($index) ?></td>
                                            <td><?= htmlspecialchars($pessoa['nome']) ?></td>
                                            <td><?= htmlspecialchars($pessoa['idade']) ?></td>
                                            <td>
                                                <a href="pessoa.php?edit=<?= $index ?>"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="blue" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                                        <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                                        <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z" />
                                                    </svg></a>
                                                |
                                                <a href="pessoa.php?delete=<?= $index ?>" onclick="return confirm('Deseja realmente excluir')"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="red" class="bi bi-trash" viewBox="0 0 16 16">
                                                        <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z" />
                                                        <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z" />
                                                    </svg></a>
                                            </td>
                                        </tr>
                                    <?php endforeach; ?>
                                </tbody>
                            </table>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
</body>

</html>

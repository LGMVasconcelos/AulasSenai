<?php
    session_start();
    if (!isset($_SESSION["usuario"])) {
        echo "<script>alert('Você não está logado.');</script>";
        echo "<script>window.location.href='index.php';</script>";
        exit;
    }
    if (!isset($_SESSION['nomes'])) {
        $emails = json_decode(file_get_contents("email.json"), true);
        $senhas = json_decode(file_get_contents("senha.json"), true);
        $nomes = json_decode(file_get_contents("nome.json"), true);
        $generos = json_decode(file_get_contents("genero.json"), true);
        $id = array_search($_SESSION['usuario'], $emails);
        $_SESSION['nomes'] = $nomes;
        $_SESSION['emails'] = $emails;
        $_SESSION['generos'] = $generos;
        $_SESSION['senhas'] = $senhas;
    }
    else {
        $emails = $_SESSION['emails'];
        $id = array_search($_SESSION['usuario'], $emails);
        $nomes = $_SESSION['nomes'];
    }
?>
<!DOCTYPE html>
<html lang="pt-br" data-bs-theme="dark">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="content-language" content="pt-br">
    <link rel='stylesheet' href='https://cdn-uicons.flaticon.com/2.6.0/uicons-regular-rounded/css/uicons-regular-rounded.css'>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
    <title>MENU - PHP ARRAY</title>
    <style>
        body {
            background-color: rgb(33, 35, 37);
            color: white;
            font-family: Calibri
        }

        .logout-btn {
            margin-top: 2rem;
        }

        .user {
            float: right;
        }
        .totalUsuariosBtn {
            color: #000;
        }
        .comunidade {
            padding: 2rem;
        }
        .genero {
            padding: 2rem;
        }
    </style>
</head>

<body>
    <div class="container">
        <center>
            <h2>MENU - ARRAY PHP</h2>
        </center>
        <hr />
        <nav>
            &nbsp;&nbsp;<a href="menu.php" style="color: white; text-decoration: none">MENU |</a>
            <a href="listagem.php" style="color: white; text-decoration: none">LISTAGEM DE USUÁRIOS |</a>
            <a href="gravar.php" style="color: white; text-decoration: none">SALVAR</a>
            <div class="user">
                <?php echo isset($nomes[$id]) ? $nomes[$id] : 'Usuário'; ?> | <a href="sair.php" style="color: white; text-decoration: none"> SAIR</a>&nbsp;&nbsp;
            </div>
        </nav>
        <br>
        <center><button type="button" class="btn btn-outline-light" data-bs-toggle="modal" data-bs-target="#exampleModal">
                <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" fill="currentColor" class="bi bi-person-fill-add" viewBox="0 0 16 16">
  <path d="M12.5 16a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7m.5-5v1h1a.5.5 0 0 1 0 1h-1v1a.5.5 0 0 1-1 0v-1h-1a.5.5 0 0 1 0-1h1v-1a.5.5 0 0 1 1 0m-2-6a3 3 0 1 1-6 0 3 3 0 0 1 6 0"/>
  <path d="M2 13c0 1 1 1 1 1h5.256A4.5 4.5 0 0 1 8 12.5a4.5 4.5 0 0 1 1.544-3.393Q8.844 9.002 8 9c-5 0-6 3-6 4"/>
</svg> CADASTRAR NOVO USUÁRIO
            </button></center>
            <br>
        <div class="row justify-content-center mb-3 row-cols-2 row-cols-md3 text-center">
            <div class="col-md-8">
                <div class="card mb-4 rounded-3 shadow-sw">
                    <div class="card-header py-3">
                        <h4 class="my-0 fw-normal">Estatísticas do Sistema</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6 mb-4">
                                <div class="card h-100 ">
                                    <img src="img/genero.svg" class="card-img-top genero" alt="Imagem de Gêneros" onerror="this.src='https://via.placeholder.com/300x150?text=Imagem+de+Gêneros'">
                                    <div class="card-body">
                                        <h5 class="card-title"><b>Gráfico de Gêneros</b></h5>
                                        <p class="card-text"><b>Gráfico de gêneros cadastrados no sistema</b></p>
                                        <?php include 'generos.php'; ?>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6 mb-4">
                                <div class="card h-100">
                                    <img src="img/comunidade.svg" class="card-img-top comunidade" alt="Imagem de Comunidade" onerror="this.src='https://via.placeholder.com/300x150?text=Imagem+de+Comunidade'">
                                    <div class="card-body">
                                        <h5 class="card-title"><b>Usuários atualmente cadastrados</b></h5>
                                        <?php include 'usuarios.php'; ?>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">CADASTRAR USUÁRIO</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body text-start">
        <form action="cadastro.php" method="post">
            <div class="mb-3">
                <label for="nome" class="form-label">Nome</label>
                <input type="text" class="form-control" id="nome" name="nome" required>
            </div>
            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <input type="email" class="form-control" id="email" name="email" required>
            </div>
            <div class="mb-3">
                <label for="genero" class="form-label">Gênero</label>
                <select class="form-select" id="genero" name="genero" required>
                    <option value="" disabled selected>Selecione o gênero</option>
                    <option value="Masculino">Masculino</option>
                    <option value="Feminino">Feminino</option>
                    <option value="Outro">Outro</option>
                </select>
            </div>
            <div class="mb-3">
                <label for="senha" class="form-label">Senha</label>
                <input type="password" class="form-control" id="senha" name="senha" required>
            </div>
            <button type="submit" class="btn btn-light">CADASTRAR</button>
        </form>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">FECHAR</button>
      </div>
    </div>
  </div>
</div>
</body>
</html>

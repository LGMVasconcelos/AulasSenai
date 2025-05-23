<?php
session_start();
$resultadoPesquisa = [];
$pesquisaRealizada = false;

if ($_POST && isset($_POST['nome']) && isset($_POST['email']) && isset($_POST['genero'])) {
    $pesquisaRealizada = true;
    $nomePesquisa = strtolower(trim($_POST['nome']));
    $emailPesquisa = strtolower(trim($_POST['email']));
    $generoPesquisa = $_POST['genero'];
    
    $nomes = $_SESSION['nomes'];
    $emails = $_SESSION['emails'];
    $generos = $_SESSION['generos'];
    
    for ($i = 0; $i < count($nomes); $i++) {
        // Permitir pesquisa parcial - se o campo estiver vazio, considera como match
        $nomeMatch = empty($nomePesquisa) || stripos($nomes[$i], $nomePesquisa) !== false;
        $emailMatch = empty($emailPesquisa) || stripos($emails[$i], $emailPesquisa) !== false;
        $generoMatch = empty($generoPesquisa) || $generos[$i] === $generoPesquisa;
        
        if ($nomeMatch && $emailMatch && $generoMatch) {
            $resultadoPesquisa[] = [
                'id' => $i,
                'nome' => $nomes[$i],
                'email' => $emails[$i],
                'genero' => $generos[$i]
            ];
        }
    }
}

if (!isset($_SESSION["usuario"])) {
    echo "<script>alert('Você não está logado.');</script>";
    echo "<script>window.location.href='index.php';</script>";
    exit;
}
$emails = $_SESSION['emails'];
$id = array_search($_SESSION['usuario'], $emails);
$nomes = $_SESSION['nomes'];
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
    <title>SALVAR DADOS - PHP ARRAY</title>
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
        <center><button type="button" class="btn btn-outline-light" data-bs-toggle="modal" data-bs-target="#pesquisaModal">
                <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
  <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"/>
</svg> PESQUISAR USUÁRIOS
            </button></center>
        <br>
        <div class="row justify-content-center mb-3 row-cols-2 row-cols-md3 text-center">
            <div class="col-md-8">
                <div class="card mb-4 rounded-3 shadow-sw">
                    <div class="card-header py-3">
                        <h4 class="my-0 fw-normal"><svg xmlns="http://www.w3.org/2000/svg" width="34" height="34" fill="currentColor" class="bi bi-people-fill" viewBox="0 0 16 16">
                                <path d="M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6m-5.784 6A2.24 2.24 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.3 6.3 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1zM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5" />
                            </svg> LISTAGEM DE USUÁRIOS</h4>
                        <br />
                        <table class="table table-hover">
                            <tr>
                                <th>ID</th>
                                <th>NOME</th>
                                <th>E-MAIL</th>
                                <th>GENERO</th>
                                <th>AÇÕES</th>
                            </tr>
                            <?php
                            $reg = count($_SESSION['nomes']);
                            for ($i = 0; $i <= $reg - 1; $i++) {
                                echo "<tr>";
                                echo "<td>$i</td>";
                                echo "<td>" . $_SESSION['nomes'][$i] . "</td>";
                                echo "<td>" . $_SESSION['emails'][$i] . "</td>";
                                echo "<td>" . $_SESSION['generos'][$i] . "</td>";
                                echo "<td><a href='editar.php?pos=$i' class='editar-btn' data-bs-toggle='modal' data-bs-target='#exampleModal' data-id='$i' data-nome='" . $_SESSION['nomes'][$i] . "' data-email='" . $_SESSION['emails'][$i] . "' data-genero='" . $_SESSION['generos'][$i] . "' data-senha='" . $_SESSION['senhas'][$i] . "'><svg xmlns='http://www.w3.org/2000/svg' width='22' height='22' fill='white' class='bi bi-pencil-square' viewBox='0 0 16 16'>
                                        <path d='M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z'/>
                                        <path fill-rule='evenodd' d='M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z'/>
                                      </svg></a> | <a href='excluir.php?pos=$i'><svg xmlns='http://www.w3.org/2000/svg' width='22' height='22' fill='white' class='bi bi-trash3' viewBox='0 0 16 16'>
                                            <path d='M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5M11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47M8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5'/>
                                          </svg></a></td>";
                                echo "</tr>";
                            }
                            ?>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal de Edição -->
    <div class='modal fade' id='exampleModal' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>
        <div class='modal-dialog'>
            <div class='modal-content'>
                <div class='modal-header'>
                    <h5 class='modal-title' id='exampleModalLabel'>ATUALIZAR USUÁRIO</h5>
                    <button type='button' class='btn-close' data-bs-dismiss='modal' aria-label='Close'></button>
                </div>
                <div class='modal-body'>
                    <form action='editar.php' method='post'>
                        <label class='form-label'>NOME</label>
                        <input class='form-control' type='text' name='nome' id='edit-nome' required />
                        <br />
                        <label class='form-label'>E-MAIL</label>
                        <input class='form-control' type='email' name='email' id='edit-email' required />
                        <br />
                        <label class='form-label'>GENERO</label>
                        <select class='form-select' aria-label='Selecione um genero' name='genero' id='edit-genero' required>
                            <option selected>Selecione um genero</option>
                            <option value='Masculino'>Masculino</option>
                            <option value='Feminino'>Feminino</option>
                            <option value='Outro'>Outro</option>
                        </select>
                        <br />
                        <label class='form-label'>SENHA</label>
                        <input class='form-control' type='password' id='edit-senha' name='senha' />
                        <br />
                        <input type='hidden' name='id' id='edit-id' />
                        <input type='submit' class='btn btn-light' value='ATUALIZAR' />
                    </form>
                </div>
                <div class='modal-footer'>
                    <button type='button' class='btn btn-danger' data-bs-dismiss='modal'>FECHAR</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal de Pesquisa -->
    <div class="modal fade" id="pesquisaModal" tabindex="-1" aria-labelledby="pesquisaModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="pesquisaModalLabel">PROCURAR USUÁRIO</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body text-start">
                    <form action="listagem.php" method="post">
                        <div class="mb-3">
                            <label for="nome" class="form-label">Nome</label>
                            <input type="text" class="form-control" id="nome" name="nome" placeholder="Digite o nome que quer encontrar">
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label">Email</label>
                            <input type="email" class="form-control" id="email" name="email" placeholder="Digite o email que quer encontrar">
                        </div>
                        <div class="mb-3">
                            <label for="genero" class="form-label">Gênero</label>
                            <select class="form-select" id="genero" name="genero">
                                <option value="">Qualquer gênero</option>
                                <option value="Masculino">Masculino</option>
                                <option value="Feminino">Feminino</option>
                                <option value="Outro">Outro</option>
                            </select>
                        </div>
                        <button type="submit" class="btn btn-light">PESQUISAR</button>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">FECHAR</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal de Resultado da Pesquisa -->
    <div class="modal fade" id="resultadoModal" tabindex="-1" aria-labelledby="resultadoModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="resultadoModalLabel">RESULTADO DA PESQUISA</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <?php if ($pesquisaRealizada): ?>
                        <?php if (count($resultadoPesquisa) > 0): ?>
                            <div class="alert alert-success">
                                Encontrados <?php echo count($resultadoPesquisa); ?> usuário(s).
                            </div>
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>NOME</th>
                                        <th>E-MAIL</th>
                                        <th>GÊNERO</th>
                                        <th>AÇÕES</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <?php foreach ($resultadoPesquisa as $usuario): ?>
                                        <tr>
                                            <td><?php echo $usuario['id']; ?></td>
                                            <td><?php echo $usuario['nome']; ?></td>
                                            <td><?php echo $usuario['email']; ?></td>
                                            <td><?php echo $usuario['genero']; ?></td>
                                            <td>
                                                <a href='editar.php?pos=<?php echo $usuario['id']; ?>' class='editar-btn' data-bs-toggle='modal' data-bs-target='#exampleModal' data-id='<?php echo $usuario['id']; ?>' data-nome='<?php echo $usuario['nome']; ?>' data-email='<?php echo $usuario['email']; ?>' data-genero='<?php echo $usuario['genero']; ?>'><svg xmlns='http://www.w3.org/2000/svg' width='22' height='22' fill='white' class='bi bi-pencil-square' viewBox='0 0 16 16'>
                                        <path d='M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z'/>
                                        <path fill-rule='evenodd' d='M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z'/>
                                      </svg></a> | 
                                                <a href='excluir.php?pos=<?php echo $usuario['id']; ?>'><svg xmlns='http://www.w3.org/2000/svg' width='22' height='22' fill='white' class='bi bi-trash3' viewBox='0 0 16 16'>
                                            <path d='M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5M11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47M8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5'/>
                                          </svg>
                                        </tr>
                                    <?php endforeach; ?>
                                </tbody>
                            </table>
                        <?php else: ?>
                            <div class="alert alert-warning">
                                <strong>Nenhum usuário encontrado!</strong><br>
                                Nenhum usuário corresponde aos critérios de pesquisa informados.
                            </div>
                        <?php endif; ?>
                    <?php endif; ?>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#pesquisaModal">NOVA PESQUISA</button>
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">FECHAR</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        document.addEventListener('DOMContentLoaded', function() {
            // Script para edição de usuários
            const botoesEditar = document.querySelectorAll('.editar-btn');
            botoesEditar.forEach(function(botao) {
                botao.addEventListener('click', function() {
                    const id = this.getAttribute('data-id');
                    const nome = this.getAttribute('data-nome');
                    const email = this.getAttribute('data-email');
                    const genero = this.getAttribute('data-genero');
                    const senha = this.getAttribute('data-senha');
                    document.getElementById('edit-id').value = id;
                    document.getElementById('edit-nome').value = nome;
                    document.getElementById('edit-email').value = email;
                    document.getElementById('edit-genero').value = genero;
                    document.getElementById('edit-senha').value = senha;
                });
            });

            // Mostrar modal de resultado se uma pesquisa foi realizada
            <?php if ($pesquisaRealizada): ?>
                var resultadoModal = new bootstrap.Modal(document.getElementById('resultadoModal'));
                resultadoModal.show();
            <?php endif; ?>
        });
    </script>
</body>
</html>

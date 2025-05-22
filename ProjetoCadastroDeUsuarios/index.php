<!DOCTYPE html>
<html lang="pt-br" data-bs-theme="dark">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="content-language" content="pt-br">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4Q6Gf2aSP4eDXB8Miphtr37CMZZQ5oXLH2yaXMJ2w8e2ZtHTl7GptT4jmndRuHDT" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js" integrity="sha384-j1CDi7MgGQ12Z7Qab0qlWQ/Qqz24Gc6BM0thvEMVjHnfYGF0rmFCozFSxQBxwHKO" crossorigin="anonymous"></script>
    <title> LOGIN - PHP ARRAY</title>
    <style>
        body {
            background-color: rgb(33, 35, 37);
            color: white;
        }

        .linkCadastro {
            text-decoration: none;
        }
    </style>
</head>

<body>
    <center>
        <h2>ARRAY - PHP</h2>
    </center>
    <hr />
    <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
        <div class="col">
            <div class="card mb-4 rounded-3 shadow-sw">
                <div class="card-header py-3">
                    <svg xmlns="http://www.w3.org/2000/svg" width="40" height="40" fill="currentColor" class="bi bi-person-fill-check" viewBox="0 0 16 16">
                        <path d="M12.5 16a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7m1.679-4.493-1.335 2.226a.75.75 0 0 1-1.174.144l-.774-.773a.5.5 0 0 1 .708-.708l.547.548 1.17-1.951a.5.5 0 1 1 .858.514M11 5a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                        <path d="M2 13c0 1 1 1 1 1h5.256A4.5 4.5 0 0 1 8 12.5a4.5 4.5 0 0 1 1.544-3.393Q8.844 9.002 8 9c-5 0-6 3-6 4" />
                    </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>LOGIN</b></font>
                </div>
                <div class="card-body">
                    <?php if (isset($loginError)): ?>
                        <div class="alert alert-danger" role="alert">
                            <?php echo $loginError; ?>
                        </div>
                    <?php endif; ?>

                    <form action="login.php" class="form-control form-control-sm" method="post">
                        <div class="mb-3">
                            <label for="email" class="form-label">Email</label>
                            <input type="email" class="form-control" id="email" name="email" required>
                        </div>
                        <div class="mb-3">
                            <label for="senha" class="form-label">Senha</label>
                            <input type="password" class="form-control" id="senha" name="senha" required>
                        </div>
                        <input type="submit" class="btn btn-light" value="ENTRAR">
                        <br />
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>

</html>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <title>Aula 09</title>
</head>

<body>
    <center>
        <h2>FORMULÁRIO DE SOMA<h2>
                <center>
                    <hr />
                    <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
                        <div class="col">
                            <div class="card mb-4 rounded-3 shadow-sw">
                                <div class="card-header py-3">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="red" class="bi bi-ui-checks" viewBox="0 0 16 16">
                                        <path d="M7 2.5a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-7a.5.5 0 0 1-.5-.5zM2 1a2 2 0 0 0-2 2v2a2 2 0 0 0 2 2h2a2 2 0 0 0 2-2V3a2 2 0 0 0-2-2zm0 8a2 2 0 0 0-2 2v2a2 2 0 0 0 2 2h2a2 2 0 0 0 2-2v-2a2 2 0 0 0-2-2zm.854-3.646a.5.5 0 0 1-.708 0l-1-1a.5.5 0 1 1 .708-.708l.646.647 1.646-1.647a.5.5 0 1 1 .708.708zm0 8a.5.5 0 0 1-.708 0l-1-1a.5.5 0 0 1 .708-.708l.646.647 1.646-1.647a.5.5 0 0 1 .708.708zM7 10.5a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-7a.5.5 0 0 1-.5-.5zm0-5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5m0 8a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5" />
                                    </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>SOMA</b></font>
                                </div>
                                <div class="card-body">
                                    <form action="resultado.php" method="post">
                                        <label class="form-label">Soma de números</label>
                                        <input class="form-control" type="number" name="num1" placeholder="Digite aqui o primeiro número" required>
                                        <br/>
                                        <input class="form-control" type="number" name="num2" placeholder="Digite aqui o segundo número" required>
                                        <br/>
                                        <input type="submit" class="btn btn-outline-success" value="VERIFICAR" name="verificar">
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
</body>

</html>

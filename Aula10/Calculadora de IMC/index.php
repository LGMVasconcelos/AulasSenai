<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <title>Calculadora de Índice de Massa Corporal</title>
</head>

<body>
    <center>
        <h2>CALCULADORA IMC</h2>
        <center>
            <hr />
            <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
                <div class="col">
                    <div class="card mb-4 rounded-3 shadow-sw">
                        <div class="card-header py-3">
                            <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-person-arms-up" viewBox="0 0 16 16">
                                <path d="M8 3a1.5 1.5 0 1 0 0-3 1.5 1.5 0 0 0 0 3" />
                                <path d="m5.93 6.704-.846 8.451a.768.768 0 0 0 1.523.203l.81-4.865a.59.59 0 0 1 1.165 0l.81 4.865a.768.768 0 0 0 1.523-.203l-.845-8.451A1.5 1.5 0 0 1 10.5 5.5L13 2.284a.796.796 0 0 0-1.239-.998L9.634 3.84a.7.7 0 0 1-.33.235c-.23.074-.665.176-1.304.176-.64 0-1.074-.102-1.305-.176a.7.7 0 0 1-.329-.235L4.239 1.286a.796.796 0 0 0-1.24.998l2.5 3.216c.317.316.475.758.43 1.204Z" />
                            </svg>
                            </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>Calculadora de IMC</b></font>
                        </div>
                        <div class="card-body">
                            <form action="resultado.php" method="post">
                                <label class="form-label">Digite abaixo sua altura e quilos</label>
                                <div class="input-group mb-3">
                                    <input class="form-control" type="text" name="altura" id="altura" placeholder="Digite aqui sua altura" required>
                                    <span class="input-group-text">m</span>
                                </div>
                                <div class="input-group mb-3">
                                    <input class="form-control" type="text" name="peso" id="peso" placeholder="Digite aqui seu peso" required>
                                    <span class="input-group-text">kg</span>
                                </div>
                                <script>
                                    function formatInput(input) {
                                        let value = input.value.replace(/[^0-9]/g, '');
                                        if (value.length > 0) {
                                            value = (parseInt(value) / 100).toFixed(2).replace('.', ',');
                                        }
                                        input.value = value;
                                    }

                                    document.getElementById('altura').addEventListener('input', function(e) {
                                        formatInput(e.target);
                                    });

                                    document.getElementById('peso').addEventListener('input', function(e) {
                                        formatInput(e.target);
                                    });
                                </script>
                                <br />
                                <input type="submit" class="btn btn-outline-success" value="CALCULAR" name="calcular">
                            </form>
                        </div>
                    </div>
                </div>
            </div>
</body>

</html>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <title>Lista de exercícios</title>
</head>
<!-- 1.Verificação de Paridade: Escreva um programa que declare uma variável inteira e 
use  um  if-else  para  verificar  se  o  número  é  par ou  ímpar.  Imprima  a  mensagem 
correspondente. 
 
2.Classificação por Idade: Declare uma variável inteira para representar a idade de 
uma pessoa. Use if-else if-else para classificá-la em "Criança" (0-12), "Adolescente" 
(13-17), "Adulto" (18-59) ou "Idoso" (60+). Imprima a classificação. 
 
3.Calculadora Simples (If-Else): Crie um programa que receba dois números e uma 
operação (+, -, *, /) como entrada (armazenados em variáveis). Use uma série de if-
else if para realizar a operação selecionada e exibir o resultado. Lembre-se de tratar 
a divisão por zero. 
 
4.Dia da Semana: Declare uma variável inteira representando um número de 1 a 7. 
Use um switch para exibir o nome do dia da semana correspondente (1 = Domingo, 2 
= Segunda etc.). Inclua um caso default para números inválidos. 
 
5.Verificação de Vogal/Consoante: Escreva um programa que receba um caractere 
(armazenado em uma variável char). Use um switch para verificar se o caractere é 
uma vogal (a, e, i, o, u - maiúsculas ou minúsculas) ou uma consoante. Imprima a 
mensagem adequada. 
 
6.Média Aritmética e Aprovação: Declare três variáveis double para representar as 
notas de um aluno. Calcule a média aritmética. Use um if-else para verificar se a média 
é maior ou igual a 7. Se for, imprima "Aprovado"; caso contrário, imprima "Reprovado". 
 
7.Desconto por Faixa de Valor: Declare uma variável decimal representando o valor 
total de uma compra. Aplique um desconto usando if-else if-else: 
  Se o valor for menor que R$50, sem desconto. 
  Se o valor estiver entre R$50 e R$100 (inclusive), desconto de 5%. 
  Se o valor for maior que R$100, desconto de 10%. Imprima o valor original e 
o valor com desconto. 
 
8.Ano Bissexto: Declare uma variável inteira para representar um ano. Use uma 
estrutura if-else com as regras para determinar se o ano é bissexto (divisível por 4, 
mas não por 100, a menos que também seja divisível por 400). Imprima se o ano é 
bissexto ou não. 
 
9.Calculadora Simples (Switch): Refaça o exercício 3, mas utilizando a estrutura 
switch para selecionar a operação a ser realizada. 
 
10.Nível de Alerta: Declare uma variável inteira representando um nível de alerta (1 
a 5). Use um switch para exibir uma mensagem diferente para cada nível: 
  1: "Nível de alerta baixo." 
  2: "Nível de alerta moderado." 
  3: "Nível de alerta elevado." 
  4: "Nível de alerta crítico." 
  5: "EMERGÊNCIA!" Inclua um caso default para níveis inválidos. 
 
11.Comparação de Três Números: Declare três variáveis inteiras. Use estruturas if-
else aninhadas para encontrar e imprimir o maior dos três números. 
 
12.Verificação de Triângulo: Declare três variáveis inteiras representando os lados 
de um possível triângulo. Use if-else para verificar se os valores podem formar um 
triângulo (a soma de quaisquer dois lados deve ser maior que o terceiro lado). Imprima 
se é um triângulo válido ou não. 
 
13.Conversão de Nota para Conceito: Declare uma variável double representando 
a nota de um aluno (0 a 10). Use um switch para converter a nota em um conceito: 
  9.0 a 10.0: "A" 
  7.0 a 8.9: "B" 
  5.0 a 6.9: "C" 
  a 4.9: "D" Inclua um caso default para notas inválidas. 
 
14.Operações com Números Pares/Ímpares: Declare duas variáveis inteiras. Se 
ambas forem pares, some-as. Se ambas forem ímpares, multiplique-as. Se uma for 
par e a outra ímpar, subtraia a menor da maior. Use estruturas if-else para realizar a 
operação correta e exibir o resultado. 
 
15.Menu Interativo: Crie um programa que exiba um menu com três opções (1 - 
Soma, 2 - Subtração, 3 - Sair). Peça ao usuário para fazer sua escolha utilizando select.

(armazenada em uma variável inteira). Use um switch para executar a ação 
correspondente: 
  Caso 1: Peça dois números e exiba a soma. 
  Caso 2: Peça dois números e exiba a subtração (primeiro menos o segundo). 
  Caso 3: Exiba uma mensagem de saída. 
  Caso default: Exiba uma mensagem de opção inválida. -->

<body>
    <center>
        <h2>LISTA DE EXERCÍCIOS</h2>
    </center>
    <hr />
    <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
        <div class="col">
            <div class="card mb-4 rounded-3 shadow-sw">
                <div class="card-header py-3">
                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-list" viewBox="0 0 16 16">
                        <path fill-rule="evenodd" d="M2.5 12a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5m0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5m0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5" />
                    </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>LISTA DE EXERCÍCIOS</b></font>
                </div>
                <div class="card-body">
                    <form action="index.php" method="post">
                        <label class="form-label">Digite o primeiro valor</label>
                        <input class="form-control" type="number" name="valor1" required placeholder="Digite um valor" />
                        <br />
                        <label class="form-label">Digite o segundo valor</label>
                        <input class="form-control" type="number" name="valor2" required placeholder="Digite um valor" />
                        <hr />

                        <label class="form-label">Digite a sua idade para classificá-la</label>
                        <input class="form-control" type="number" name="idade" required placeholder="Digite sua idade abaixo" />
                        <hr />

                        <label class="form-label">Digite um valor numérico para somar, subtrair, dividir ou multiplicar por ele.</label>
                        <input class="form-control" type="number" name="num1" required placeholder="Digite um valor" />
                        <br />
                        <input class="form-control" type="number" name="num2" required placeholder="Digite um valor" />
                        <br />
                        <select class="form-select" name="operacao" required>
                            <option value="">Selecione uma operação</option>
                            <option value="+">Soma</option>
                            <option value="-">Subtração</option>
                            <option value="/">Divisão</option>
                            <option value="*">Multiplicação</option>
                        </select>
                        <hr />

                        <label class="form-label">Digite um número de 1 a 7 para verificar o dia da semana</label>
                        <input class="form-control" type="number" name="dia" required placeholder="Digite um número de 1 a 7" />
                        <hr />

                        <label class="form-label">Digite um caractere para verificar se é vogal ou consoante</label>
                        <input class="form-control" type="text" name="caractere" required placeholder="Digite um caractere" maxlength="1" />
                        <hr />

                        <label class="form-label">Digite três notas entre 0 a 10 para verificar se o aluno foi aprovado ou reprovado</label>
                        <input class="form-control" type="number" name="nota1" required placeholder="Digite a primeira nota" step="0.1" />
                        <br />
                        <input class="form-control" type="number" name="nota2" required placeholder="Digite a segunda nota" step="0.1" />
                        <br />
                        <input class="form-control" type="number" name="nota3" required placeholder="Digite a terceira nota" step="0.1" />
                        <hr />

                        <label class="form-label">Digite o valor total da compra para verificar o desconto</label>
                        <input class="form-control" type="number" name="valorCompra" required placeholder="Digite o valor da compra" step="0.01" />
                        <div class="input-group mb-3">
                            <input class="form-control" type="number" name="desconto" placeholder="Digite aqui o valor do desconto" required>
                            <span class="input-group-text">%</span>
                        </div>
                        <hr />

                        <label class="form-label">Digite abaixo um ano para verificar se o mesmo é bissexto ou não:</label>
                        <input class="form-control" type="number" name="ano" placeholder="Digite aqui o ano" required>
                        <hr />

                        <label class="form-label">Digite novamente um valor numérico para somar, subtrair, dividir ou multiplicar por ele.</label>
                        <input class="form-control" type="number" name="num1v2" required placeholder="Digite um valor" />
                        <br />
                        <input class="form-control" type="number" name="num2v2" required placeholder="Digite um valor" />
                        <br />
                        <select class="form-select" name="operacaov2" required>
                            <option value="">Selecione uma operação</option>
                            <option value="+">Soma</option>
                            <option value="-">Subtração</option>
                            <option value="/">Divisão</option>
                            <option value="*">Multiplicação</option>
                        </select>
                        <hr />

                        <label class="form-label">Digite um número de 1 a 5 para verificar o nível de alerta</label>
                        <input class="form-control" type="number" name="nivelDeAlerta" required placeholder="Digite um número de 1 a 5" />
                        <hr />

                        <label class="form-label">Digite três números para verificar qual deles é o maior</label>
                        <input class="form-control" type="number" name="numero1" required placeholder="Digite o primeiro número" />
                        <br />
                        <input class="form-control" type="number" name="numero2" required placeholder="Digite o segundo número" />
                        <br />
                        <input class="form-control" type="number" name="numero3" required placeholder="Digite o terceiro número" />
                        <hr />

                        <label class="form-label">Digite três lados para verificar se formam um triângulo</label>
                        <input class="form-control" type="number" name="lado1" required placeholder="Digite o primeiro lado" />
                        <br />
                        <input class="form-control" type="number" name="lado2" required placeholder="Digite o segundo lado" />
                        <br />
                        <input class="form-control" type="number" name="lado3" required placeholder="Digite o terceiro lado" />
                        <hr />

                        <label class="form-label">Digite uma nota entre 0 a 10 para verificar o conceito</label>
                        <input class="form-control" type="number" name="notaConceito" required placeholder="Digite a nota" step="0.1" />
                        <hr />

                        <label class="form-label">Digite dois números inteiros</label>
                        <input class="form-control" type="number" name="num1int" required placeholder="Digite o primeiro número" />
                        <br />
                        <input class="form-control" type="number" name="num2int" required placeholder="Digite o segundo número" />
                        <hr />

                        <label class="form-label">Escolha uma opção do menu abaixo:</label>
                        <select class="form-select" name="menu" required>
                            <option value="">Selecione uma opção</option>
                            <option value="1">Soma</option>
                            <option value="2">Subtração</option>
                            <option value="3">Sair</option>
                        </select>
                        <hr />
                        <button class="btn btn-primary" type="submit">Enviar</button>
                        </form>
                    <br />
                    <a href="index.php" class="btn btn-secondary">Limpar</a>
                </div>
            </div>
        </div>
                <div class="row justify-content-center row-cols-1 row-cols-md-2 mb-3 text-center">
                    <div class="col">
                        <div class="card mb-4 rounded-3 shadow-sw">
                            <div class="card-header py-3">
                                <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-list" viewBox="0 0 16 16">
                                    <path fill-rule="evenodd" d="M2.5 12a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5m0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5" />
                                </svg>&nbsp;&nbsp;<font style="font-size: 30px;"><b>RESULTADOS DA LISTA DE EXERCÍCIOS</b></font>
                            </div>
                            <div class="card-body">
                                <div id="resultados" style="display: none;">
                                    <?php
                                    if (isset($_POST['valor1']) && isset($_POST['valor2'])) {
                                        $valor1 = (float)$_POST['valor1'];
                                        $valor2 = (float)$_POST['valor2'];
                                        echo "<br/> A soma dos valores foi: <b>" . ($valor1 + $valor2) . "</b><br/>";
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['idade'])) {
                                        $idade = $_POST['idade'];
                                        if ($idade > 0 && $idade <= 12) {
                                            echo "<br/> Você é uma criança!<br/>";
                                        } else if ($idade > 12 && $idade <= 17) {
                                            echo "<br/> Você é um adolescente!<br/>";
                                        } else if ($idade > 17 && $idade <= 59) {
                                            echo "<br/> Você é um adulto!<br/>";
                                        } else if ($idade >= 60) {
                                            echo "<br/> Você é um idoso!<br/>";
                                        } else {
                                            echo "<br/> Idade inválida!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['num1']) && isset($_POST['num2']) && isset($_POST['operacao'])) {
                                        $valor1 = $_POST['num1'];
                                        $valor2 = $_POST['num2'];
                                        $operacao = $_POST['operacao'];

                                        if ($operacao == '+') {
                                            $resultado = $valor1 + $valor2;
                                            echo "<br/> O resultado da soma é: <b>" . $resultado . "</b><br/>";
                                        } else if ($operacao == '-') {
                                            $resultado = $valor1 - $valor2;
                                            echo "<br/> O resultado da subtração é: <b>" . $resultado . "</b><br/>";
                                        } else if ($operacao == '*') {
                                            $resultado = $valor1 * $valor2;
                                            echo "<br/> O resultado da multiplicação é: <b>" . $resultado . "</b><br/>";
                                        } else if ($operacao == '/') {
                                            if ($valor2 != 0) {
                                                $resultado = $valor1 / $valor2;
                                                echo "<br/> O resultado da divisão é: <b>" . $resultado . "</b><br/>";
                                            } else {
                                                echo "<br/> Divisão por zero não é permitida!<br/>";
                                            }
                                        } else {
                                            echo "<br/> Operação inválida!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['dia'])) {
                                        $dia = $_POST['dia'];
                                        switch ($dia) {
                                            case 1:
                                                echo "<br/> O dia da semana é: <b>Domingo</b><br/>";
                                                break;
                                            case 2:
                                                echo "<br/> O dia da semana é: <b>Segunda-feira</b><br/>";
                                                break;
                                            case 3:
                                                echo "<br/> O dia da semana é: <b>Terça-feira</b><br/>";
                                                break;
                                            case 4:
                                                echo "<br/> O dia da semana é: <b>Quarta-feira</b><br/>";
                                                break;
                                            case 5:
                                                echo "<br/> O dia da semana é: <b>Quinta-feira</b><br/>";
                                                break;
                                            case 6:
                                                echo "<br/> O dia da semana é: <b>Sexta-feira</b><br/>";
                                                break;
                                            case 7:
                                                echo "<br/> O dia da semana é: <b>Sábado</b><br/>";
                                                break;
                                            default:
                                                echo "<br/> Opção inválida!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['caractere'])) {
                                        $caractere = strtolower($_POST['caractere']);
                                        switch ($caractere) {
                                            case 'a':
                                            case 'e':
                                            case 'i':
                                            case 'o':
                                            case 'u':
                                                echo "<br/> O caractere <b>$caractere</b> é uma vogal!<br/>";
                                                break;
                                            default:
                                                echo "<br/> O caractere <b>$caractere</b> é uma consoante!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['nota1'], $_POST['nota2'], $_POST['nota3'])) {
                                        $nota1 = (float)$_POST['nota1'];
                                        $nota2 = (float)$_POST['nota2'];
                                        $nota3 = (float)$_POST['nota3'];
                                        $media = ($nota1 + $nota2 + $nota3) / 3;
                                        if ($media >= 7) {
                                            echo "<br/> O aluno foi <b>Aprovado</b> com média: <b>" . $media . "</b><br/>";
                                        } else {
                                            echo "<br/> O aluno foi <b>Reprovado</b> com média: <b>" . $media . "</b><br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['valorCompra'])) {
                                        $valorCompra = (float)$_POST['valorCompra'];
                                        if ($valorCompra < 50) {
                                            echo "<br/> Valor total da compra: <b>R$" . $valorCompra . "</b> (sem desconto)<br/>";
                                        } else if ($valorCompra >= 50 && $valorCompra <= 100) {
                                            $desconto = $valorCompra * 0.05;
                                            $valorFinal = $valorCompra - $desconto;
                                            echo "<br/> Valor total da compra: <b>R$" . $valorCompra . "</b> (desconto de 5%: R$" . $desconto . ")<br/>";
                                            echo "Valor com desconto: <b>R$" . $valorFinal . "</b><br/>";
                                        } else {
                                            $desconto = $valorCompra * 0.10;
                                            $valorFinal = $valorCompra - $desconto;
                                            echo "<br/> Valor total da compra: <b>R$" . $valorCompra . "</b> (desconto de 10%: R$" . $desconto . ")<br/>";
                                            echo "Valor com desconto: <b>R$" . $valorFinal . "</b><br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['ano'])) {
                                        $ano = (int)$_POST['ano'];
                                        if (($ano % 4 == 0 && $ano % 100 != 0) || ($ano % 400 == 0)) {
                                            echo "<br/> O ano <b>$ano</b> é bissexto!<br/>";
                                        } else {
                                            echo "<br/> O ano <b>$ano</b> não é bissexto!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['num1v2']) && isset($_POST['num2v2']) && isset($_POST['operacaov2'])) {
                                        $valor1 = $_POST['num1v2'];
                                        $valor2 = $_POST['num2v2'];
                                        $operacao = $_POST['operacaov2'];

                                        switch ($operacao) {
                                            case '+':
                                                $resultado = $valor1 + $valor2;
                                                echo "<br/> O resultado da soma é: <b>" . $resultado . "</b><br/>";
                                                break;
                                            case '-':
                                                $resultado = $valor1 - $valor2;
                                                echo "<br/> O resultado da subtração é: <b>" . $resultado . "</b><br/>";
                                                break;
                                            case '*':
                                                $resultado = $valor1 * $valor2;
                                                echo "<br/> O resultado da multiplicação é: <b>" . $resultado . "</b><br/>";
                                                break;
                                            case '/':
                                                if ($valor2 != 0) {
                                                    $resultado = $valor1 / $valor2;
                                                    echo "<br/> O resultado da divisão é: <b>" . $resultado . "</b><br/>";
                                                } else {
                                                    echo "<br/> Divisão por zero não é permitida!<br/>";
                                                }
                                                break;
                                            default:
                                                echo "<br/> Operação inválida!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['nivelDeAlerta'])) {
                                        $nivelDeAlerta = $_POST['nivelDeAlerta'];
                                        switch ($nivelDeAlerta) {
                                            case 1:
                                                echo "<br/> Nível de alerta: <b>Baixo</b><br/>";
                                                break;
                                            case 2:
                                                echo "<br/> Nível de alerta: <b>Moderado</b><br/>";
                                                break;
                                            case 3:
                                                echo "<br/> Nível de alerta: <b>Elevado</b><br/>";
                                                break;
                                            case 4:
                                                echo "<br/> Nível de alerta: <b>Critico</b><br/>";
                                                break;
                                            case 5:
                                                echo "<br/> Nível de alerta: <b>EMERGÊNCIA!</b><br/>";
                                                break;
                                            default:
                                                echo "<br/> Nível de alerta inválido!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['numero1']) && isset($_POST['numero2']) && isset($_POST['numero3'])) {
                                        $num1 = $_POST['numero1'];
                                        $num2 = $_POST['numero2'];
                                        $num3 = $_POST['numero3'];

                                        $maior = $num1;
                                        if ($num2 > $maior) {
                                            $maior = $num2;
                                        }
                                        if ($num3 > $maior) {
                                            $maior = $num3;
                                        }
                                        echo "<br/> O maior número é: <b>" . $maior . "</b><br/>";
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['lado1']) && isset($_POST['lado2']) && isset($_POST['lado3'])) {
                                        $lado1 = $_POST['lado1'];
                                        $lado2 = $_POST['lado2'];
                                        $lado3 = $_POST['lado3'];

                                        if (($lado1 + $lado2 > $lado3) && ($lado1 + $lado3 > $lado2) && ($lado2 + $lado3 > $lado1)) {
                                            echo "<br/> Os lados formam um triângulo!<br/>";
                                        } else {
                                            echo "<br/> Os lados não formam um triângulo!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['notaConceito'])) {
                                        $nota = $_POST['notaConceito'];
                                        switch (true) {
                                            case ($nota >= 9.0 && $nota <= 10.0):
                                                echo "<br/> Conceito: <b>A</b><br/>";
                                                break;
                                            case ($nota >= 7.0 && $nota < 9.0):
                                                echo "<br/> Conceito: <b>B</b><br/>";
                                                break;
                                            case ($nota >= 5.0 && $nota < 7.0):
                                                echo "<br/> Conceito: <b>C</b><br/>";
                                                break;
                                            case ($nota >= 4.0 && $nota < 5.0):
                                                echo "<br/> Conceito: <b>D</b><br/>";
                                                break;
                                            default:
                                                echo "<br/> Nota inválida!<br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['num1int']) && isset($_POST['num2int'])) {
                                        $num1 = $_POST['num1int'];
                                        $num2 = $_POST['num2int'];

                                        if ($num1 % 2 == 0 && $num2 % 2 == 0) {
                                            $resultado = $num1 + $num2;
                                            echo "<br/> Ambos os números são pares. A soma é: <b>" . $resultado . "</b><br/>";
                                        } else if ($num1 % 2 != 0 && $num2 % 2 != 0) {
                                            $resultado = $num1 * $num2;
                                            echo "<br/> Ambos os números são ímpares. O produto é: <b>" . $resultado . "</b><br/>";
                                        } else {
                                            if ($num1 > $num2) {
                                                $resultado = $num1 - $num2;
                                            } else {
                                                $resultado = $num2 - $num1;
                                            }
                                            echo "<br/> Um número é par e o outro é ímpar. A diferença é: <b>" . $resultado . "</b><br/>";
                                        }
                                    }
                                    ?>
                                    <hr />
                                    <?php
                                    if (isset($_POST['menu'])) {
                                        $opcao = $_POST['menu'];
                                        switch ($opcao) {
                                            case 1:
                                                echo "<br/> Você escolheu a opção <b>Soma</b>!<br/>";
                                                break;
                                            case 2:
                                                echo "<br/> Você escolheu a opção <b>Subtração</b>!<br/>";
                                                break;
                                            case 3:
                                                echo "<br/> Você escolheu a opção <b>Sair</b>!<br/>";
                                                break;
                                            default:
                                                echo "<br/> Opção inválida!<br/>";
                                        }
                                    }
                                    ?>
                                </div>
                                <button class="btn btn-primary" onclick="mostrarResultados()">Mostrar Resultados</button>
                            </div>
                        </div>
                    </div>
                </div>

                <script>
                    function mostrarResultados() {
                        document.getElementById('resultados').style.display = 'block';
                    }
                </script>
                            </div>
                        </div>
                    </div>
                </div>
</body>

</html>

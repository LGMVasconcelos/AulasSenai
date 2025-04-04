using static System.Console;

//1 - Verificação de Paridade:
int VerificarParidade(int numero)
{
    if (numero % 2 == 0)
    {
        WriteLine($"O valor {numero} é Par.");
    }
    else
    {
        WriteLine($"O valor {numero} é Ímpar.");
    }
    return numero;
}
int valorEntradaParidade;
WriteLine("Informe um valor para verificar se é Par ou Ímpar:");
valorEntradaParidade = Convert.ToInt32(ReadLine());
VerificarParidade(valorEntradaParidade);

// 2 - Classificação por Idade:
int ClassificarIdade(int idade)
{
    if (idade >= 0 & idade <= 12)
    {
        WriteLine($"A faixa etária é: Criança com {idade} anos.");
    }
    else if (idade >= 13 && idade <= 17)
    {
        WriteLine($"A faixa etária é: Adolescente com {idade} anos.");
    }
    else if (idade >= 18 && idade <= 59)
    {
        WriteLine($"A faixa etária é: Adulto com {idade} anos.");
    }
    else if (idade >= 60)
    {
        WriteLine($"A faixa etária é: Idoso com {idade} anos.");
    }
    else
    {
        WriteLine("Entrada inválida. Tente novamente.");
    }
    return idade;
}

int faixaEtaria;
WriteLine("Digite sua idade para verificar sua faixa etária:");
faixaEtaria = Convert.ToInt32(ReadLine());
ClassificarIdade(faixaEtaria);

// 3 - Calculadora Simples:
double Calculadora(string operador, double valor1, double valor2)
{
    string soma = "+", subtracao = "-", multiplicacao1 = "*", multiplicacao2 = "x", multiplicacao3 = "X", multiplicacao4 = "•", divisao = "/";
    if (operador == soma)
    {
        WriteLine($"O resultado de {valor1} {operador} {valor2} é {valor1 + valor2}.");
    }
    else if (operador == subtracao)
    {
        WriteLine($"O resultado de {valor1} {operador} {valor2} é {valor1 - valor2}.");
    }
    else if (operador == multiplicacao1 || operador == multiplicacao2 || operador == multiplicacao3 || operador == multiplicacao4)
    {
        WriteLine($"O resultado de {valor1} {operador} {valor2} é {valor1 * valor2}.");
    }
    else if (operador == divisao)
    {
        if (valor2 != 0)
        {
            WriteLine($"O resultado de {valor1} {operador} {valor2} é {valor1 / valor2}.");
        }
        else
        {
            WriteLine("Não é possível dividir por 0.");
        }
    }
    return valor1;
}

double primeiroNumero, segundoNumero;
string operadorEscolhido;
WriteLine("Digite o primeiro valor para a operação:");
primeiroNumero = Convert.ToDouble(ReadLine());
WriteLine("Digite o segundo valor para a operação:");
segundoNumero = Convert.ToDouble(ReadLine());
WriteLine("Escolha uma operação: (+), (-), (*), (/):");
operadorEscolhido = ReadLine();
Calculadora(operadorEscolhido, primeiroNumero, segundoNumero);

// 4 - Dia da Semana:
int numeroDiaSemana;
WriteLine("Informe um número de 1 a 7 para ver o dia correspondente:");
numeroDiaSemana = Convert.ToInt32(ReadLine());

switch (numeroDiaSemana)
{
    case 1:
        WriteLine("Domingo");
        break;
    case 2:
        WriteLine("Segunda-feira");
        break;
    case 3:
        WriteLine("Terça-feira");
        break;
    case 4:
        WriteLine("Quarta-feira");
        break;
    case 5:
        WriteLine("Quinta-feira");
        break;
    case 6:
        WriteLine("Sexta-feira");
        break;
    case 7:
        WriteLine("Sábado");
        break;
    default:
        WriteLine("Entrada inválida. Por favor, forneça um número de 1 a 7.");
        break;
}

// 5 - Verificação de Vogal ou Consoante:
string letraEscolhida;
WriteLine("Digite uma letra para saber se é vogal ou consoante:");
letraEscolhida = ReadLine().ToLower();
switch (letraEscolhida)
{
    case "a":
    case "e":
    case "i":
    case "o":
    case "u":
        WriteLine($"{letraEscolhida} é uma vogal.");
        break;
    case "b":
    case "c":
    case "d":
    case "f":
    case "g":
    case "h":
    case "j":
    case "k":
    case "l":
    case "m":
    case "n":
    case "p":
    case "q":
    case "r":
    case "s":
    case "t":
    case "v":
    case "w":
    case "x":
    case "y":
    case "z":
        WriteLine($"{letraEscolhida} é uma consoante.");
        break;
    default:
        WriteLine("A entrada não corresponde a uma letra válida.");
        break;
}

// 6 - Média Aritmética e Aprovação:
double CalcularMedia(double nota1, double nota2, double nota3)
{
    double mediaFinal = (nota1 + nota2 + nota3) / 3;
    if (mediaFinal < 7.0)
    {
        WriteLine($"Infelizmente, sua média é {mediaFinal}. Você foi reprovado.");
    }
    else
    {
        WriteLine($"Parabéns! Sua média é {mediaFinal}. Você foi aprovado.");
    }
    return mediaFinal;
}

double primeiraNota, segundaNota, terceiraNota;
WriteLine("Informe a primeira nota:");
primeiraNota = Convert.ToDouble(ReadLine());
WriteLine("Informe a segunda nota:");
segundaNota = Convert.ToDouble(ReadLine());
WriteLine("Informe a terceira nota:");
terceiraNota = Convert.ToDouble(ReadLine());
CalcularMedia(primeiraNota, segundaNota, terceiraNota);

// 7 - Desconto por Faixa de Valor:
double AplicarDesconto(double preco)
{
    double valorDesconto;
    if (preco < 50)
    {
        WriteLine($"Nenhum desconto aplicado. O valor final é R${preco}.");
    }
    else if (preco >= 51 && preco <= 100)
    {
        valorDesconto = preco * 0.05;
        WriteLine($"Desconto de 5%! O valor com desconto é R${Math.Round(preco - valorDesconto, 2)}.");
    }
    else
    {
        valorDesconto = preco * 0.10;
        WriteLine($"Desconto de 10%! O valor com desconto é R${Math.Round(preco - valorDesconto, 2)}.");
    }
    return preco;
}

double precoProduto;
WriteLine("Informe o preço do produto:");
precoProduto = Convert.ToDouble(ReadLine());
AplicarDesconto(precoProduto);

// 8 - Ano Bissexto:
int VerificarAnoBissexto(int ano)
{
    if ((ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0))
    {
        WriteLine($"O ano {ano} é bissexto.");
    }
    else
    {
        WriteLine($"O ano {ano} não é bissexto.");
    }
    return ano;
}

int anoVerificado;
WriteLine("Informe o ano que deseja verificar:");
anoVerificado = Convert.ToInt32(ReadLine());
VerificarAnoBissexto(anoVerificado);

// 9 - Calculadora Simples (Switch):
int numero1, numero2;
string operacaoDesejada;
WriteLine("Informe o primeiro valor:");
numero1 = Convert.ToInt32(ReadLine());
WriteLine("Informe o segundo valor:");
numero2 = Convert.ToInt32(ReadLine());
WriteLine("Escolha a operação desejada: (+), (-), (*), (/):");
operacaoDesejada = ReadLine();

switch (operacaoDesejada)
{
    case "+":
        WriteLine($"O resultado é: {numero1 + numero2}");
        break;
    case "-":
        WriteLine($"O resultado é: {numero1 - numero2}");
        break;
    case "*":
        WriteLine($"O resultado é: {numero1 * numero2}");
        break;
    case "/":
        if (numero2 != 0)
        {
            WriteLine($"O resultado é: {numero1 / numero2}");
        }
        else
        {
            WriteLine("Erro: Divisão por zero não permitida.");
        }
        break;
    default:
        WriteLine("Operação inválida.");
        break;
}

// 10 - Nível de Alerta:
int nivelAlerta;
WriteLine("Informe um valor entre 1 e 5 para verificar o nível de alerta:");
nivelAlerta = Convert.ToInt32(ReadLine());

switch (nivelAlerta)
{
    case 1:
        WriteLine("Alerta Nível 1: Baixo.");
        break;
    case 2:
        WriteLine("Alerta Nível 2: Moderado.");
        break;
    case 3:
        WriteLine("Alerta Nível 3: Alto.");
        break;
    case 4:
        WriteLine("Alerta Nível 4: Crítico.");
        break;
    case 5:
        WriteLine("Alerta Nível 5: Emergência!");
        break;
    default:
        WriteLine("Valor inválido. Informe um número entre 1 e 5.");
        break;
}

// 11 - Comparação de Três Números:
int primeiroValor, segundoValor, terceiroValor;
WriteLine("Informe o primeiro número:");
primeiroValor = Convert.ToInt32(ReadLine());
WriteLine("Informe o segundo número:");
segundoValor = Convert.ToInt32(ReadLine());
WriteLine("Informe o terceiro número:");
terceiroValor = Convert.ToInt32(ReadLine());

if (primeiroValor > segundoValor && primeiroValor > terceiroValor)
{
    WriteLine($"O maior número é: {primeiroValor}");
}
else if (segundoValor > primeiroValor && segundoValor > terceiroValor)
{
    WriteLine($"O maior número é: {segundoValor}");
}
else if (terceiroValor > primeiroValor && terceiroValor > segundoValor)
{
    WriteLine($"O maior número é: {terceiroValor}");
}
else
{
    WriteLine("Os números são iguais.");
}

// 12 - Verificação de Triângulo:
int ladoA, ladoB, ladoC;
WriteLine("Informe o comprimento do primeiro lado do triângulo:");
ladoA = Convert.ToInt32(ReadLine());
WriteLine("Informe o comprimento do segundo lado do triângulo:");
ladoB = Convert.ToInt32(ReadLine());
WriteLine("Informe o comprimento do terceiro lado do triângulo:");
ladoC = Convert.ToInt32(ReadLine());

if (ladoA + ladoB > ladoC && ladoA + ladoC > ladoB && ladoB + ladoC > ladoA)
{
    WriteLine("Os valores formam um triângulo.");
}
else
{
    WriteLine("Os valores não formam um triângulo.");
}

// 13 - Conversão de Nota para Conceito:
double notaFinal;
WriteLine("Informe a nota do aluno (entre 0 e 10):");
notaFinal = Convert.ToDouble(ReadLine());

switch (notaFinal)
{
    case <= 4.9:
        WriteLine("Conceito: D");
        break;
    case >= 5 and <= 6.9:
        WriteLine("Conceito: C");
        break;
    case >= 7 and <= 8.9:
        WriteLine("Conceito: B");
        break;
    case >= 9 and <= 10:
        WriteLine("Conceito: A");
        break;
    default:
        WriteLine("Nota inválida.");
        break;
}

// 14 - Operações com Números Pares/Ímpares:

int variavel1, variavel2, maior, menor;
WriteLine("Digite um número:");
variavel1 = Convert.ToInt32(ReadLine());
WriteLine("Digite um outro número:");
variavel2 = Convert.ToInt32(ReadLine());


if ((variavel1 % 2 == 0) && (variavel2 % 2 == 0))
{
    WriteLine($"{variavel1} + {variavel2} = {variavel1 + variavel2}");
}
else if ((variavel1 % 2 != 0) && (variavel2 % 2 != 0) || (variavel1 % 2 != 0) && (variavel2 % 2 != 0))
{
    WriteLine($"{variavel1} * {variavel2} = {variavel1 * variavel2}");
}
else if ((variavel1 % 2 != 0) && (variavel2 % 2 == 0) || (variavel1 % 2 == 0) && (variavel2 % 2 != 0))
{
    if (variavel1 > variavel2)
    {
        maior = variavel1;
        menor = variavel2;
        WriteLine($"{maior} - {menor} = {maior - menor}");
    }
    else if (variavel1 == variavel2)
    {
        WriteLine($"{variavel1} - {variavel2} = {variavel1 - variavel2}");
    }
    else
    {
        maior = variavel2;
        menor = variavel1;
        WriteLine($"{maior} - {menor} = {maior - menor}");
    }
}

// 15 - Menu Interativo:
string opcoes;
int numerozinho1, numerozinho2;
WriteLine("Escolha uma das seguintes opções. Para escolher ela, digite exatamente o que ela diz: \n 1 • Somar \n 2 • Subtrair \n 3 • Sair");
opcoes = Convert.ToString(ReadLine());

switch (opcoes)
{
    case "Somar":
        WriteLine("Digite o número a ser somado: ");
        numerozinho1 = Convert.ToInt32(ReadLine());
        WriteLine("Digite o outro número a ser somado: ");
        numerozinho2 = Convert.ToInt32(ReadLine());
        WriteLine($"A soma dos números {numero1} e {numero2} é igual a: {numero1 + numero2}.");
        break;
    case "Subtrair":
        WriteLine("Digite o número a ser subtraído: ");
        numerozinho1 = Convert.ToInt32(ReadLine());
        WriteLine("Digite o outro número a ser subtraído: ");
        numerozinho2 = Convert.ToInt32(ReadLine());
        WriteLine($"A subtração dos números {numero1} e {numero2} é igual a: {numero1 - numero2}.");
        break;
    case "Sair":
        WriteLine("Adeus! Foi bom te ver aqui!");
        break;
    default:
        WriteLine("Opção inválida! Escolha outra!");
        break;
}
ReadLine();

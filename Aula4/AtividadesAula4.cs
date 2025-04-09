using static System.Console;
using static System.Convert;
//Nome: Luiz Gustavo Morais Vasconcelos
//Exercício 1:

int primeiroValor, segundoValor;
WriteLine("Informe o primeiro número:");
primeiroValor = ToInt32(ReadLine());
WriteLine("Informe o segundo número:");
segundoValor = ToInt32(ReadLine());

if (primeiroValor > segundoValor)
{
    WriteLine($"O maior número é: {primeiroValor}");
}

else if (segundoValor > primeiroValor)
{
    WriteLine($"O maior número é: {segundoValor}");
}

else
{
    WriteLine("Os números são iguais.");
}

//Exercício 2:

int variavel1, variavel2, variavel3;
WriteLine("Informe o primeiro número:");
variavel1 = Convert.ToInt32(ReadLine());
WriteLine("Informe o segundo número:");
variavel2 = Convert.ToInt32(ReadLine());
WriteLine("Informe o terceiro número:");
variavel3 = Convert.ToInt32(ReadLine());

if (variavel1 > variavel2 && variavel1 > variavel3 && variavel2 > variavel3)
{
    WriteLine($"O maior número é: {variavel1}, o menor é {variavel3}");
}
else if (variavel1 > variavel3 && variavel3 > variavel2)
{
    WriteLine($"O maior número é: {variavel1}, o menor é {variavel2}");
}
else if (variavel2 > variavel1 && variavel2 > variavel3 && variavel3 > variavel1)
{
    WriteLine($"O maior número é: {variavel2}, o menor é {variavel1}");
}
else if (variavel2 > variavel1 && variavel2 > variavel3 && variavel1 > variavel3)
{
    WriteLine($"O maior número é: {variavel2}, o menor é {variavel3}");
}
else if (variavel3 > variavel1 && variavel3 > variavel2 && variavel1 > variavel2)
{
    WriteLine($"O maior número é: {variavel3}, o menor é {variavel2}");
}
else if (variavel3 > variavel1 && variavel3 > variavel2 && variavel2 > variavel1)
{
    WriteLine($"O maior número é: {variavel3}, o menor é {variavel1}");
}
else
{
    WriteLine("Dois ou mais números são iguais.");
}

//Exercício 3:

double nota1, nota2, nota3;
WriteLine("Digite a primeira nota:");
nota1 = ToDouble(ReadLine());
WriteLine("Digite a segunda nota:");
nota2 = ToDouble(ReadLine());
WriteLine("Digite a terceira nota:");
nota3 = ToDouble(ReadLine());
double media = (nota1 + nota2 + nota3) / 3;

if (media == 10)
{
    WriteLine("Aprovado com distinção.");
}
else if (media > 7){
    WriteLine("Aprovado.");
}
else
{
    WriteLine("Reprovado.");
}

//Exercício 4:

string produto1, produto2, produto3;
double precoProduto1, precoProduto2, precoProduto3;
WriteLine("Digite o nome do primeiro produto:");
produto1 = ReadLine();
WriteLine("Digite o nome do segundo produto:");
produto2 = ReadLine();
WriteLine("Digite o nome do terceiro produto:");
produto3 = ReadLine();
WriteLine("Digite o preço do primeiro produto:");
precoProduto1 = ToDouble(ReadLine());
WriteLine("Digite o preço do segundo produto:");
precoProduto2 = ToDouble(ReadLine());
WriteLine("Digite o preço do terceiro produto:");
precoProduto3 = ToDouble(ReadLine());

if (precoProduto3 < precoProduto1 && precoProduto3 < precoProduto2)
{
    WriteLine($"Você deveria comprar o(a) {produto3}, visto que tem o menor valor.");
}
else if (precoProduto2 < precoProduto1 && precoProduto2 < precoProduto3)
{
    WriteLine($"Você deveria comprar o(a) {produto2}, visto que tem o menor valor.");
}
else if (precoProduto1 < precoProduto3 && precoProduto1 < precoProduto3)
{
    WriteLine($"Você deveria comprar o(a) {produto1}, visto que tem o menor valor.");
}
else
{
    WriteLine("Dois ou mais produtos têm o mesmo preço.");
}

//Exercício 5:

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

//Exercício 6:

int ClassificarIdade(int idade)
{
    if (idade >= 0 & idade <= 17)
    {
        WriteLine($"Você não pode doar sangue, pois tem {idade} anos. Espere até fazer 18!");
    }
    else if (idade >= 18 && idade <= 67)
    {
        WriteLine($"Você consegue doar sangue!");
    }
    else if (idade >= 68)
    {
        WriteLine($"Você já não pode mais doar sangue pois o limite de idade para doação de sangue é 67 anos. Sinto muito!");
    }
    else
    {
        WriteLine("Entrada inválida. Tente novamente.");
    }
    return idade;
}

int faixaEtaria;
WriteLine("Digite sua idade para verificar se você pode ou não doar sangue:");
faixaEtaria = ToInt32(ReadLine());
ClassificarIdade(faixaEtaria);

//Exercício 7:

int var1, var2;
var1 = 10;
var2 = 20;
WriteLine($"Valor 1: {var1};\nValor 2: {var2}.\n");

var1 = var1 + var2;
var2 = var1 - var2;
var1 = var1 - var2;
WriteLine($"Valor 1 invertido: {var1};\nValor 2 invertido: {var2}.");

//Exercício 8:

double fixo, fixoCarro, comissao, comissaoVendas, salarioTotal;
int carrosVendidos;
WriteLine("Digite o salário fixo dos funcionários:");
fixo = ToDouble(ReadLine());
if (fixo < 1518)
{
    WriteLine("O salário vai contra a legislação Brasileira! Tente novamente.");
    do
    {
        WriteLine("Digite outro salário fixo:");
        fixo = ToDouble(ReadLine());
    } while (fixo < 1518);
}
WriteLine("Digite quantos carros foram vendidos:");
carrosVendidos = ToInt32(ReadLine());
WriteLine("Digite uma comissão fixa por carro vendido:");
fixoCarro = ToDouble(ReadLine());
WriteLine($"Salário fixo mensal do funcionário: R${fixo}");
WriteLine($"Carros vendidos esse mês: {carrosVendidos}");
WriteLine($"Comissão Fixa por carro vendido: R${fixoCarro}");
comissao = (carrosVendidos * fixoCarro);
WriteLine($"Valor de comissão por carro vendido: R${comissao}");
comissaoVendas = (comissao * 0.05);
WriteLine($"Valor de comissão de venda: R${comissaoVendas}");
salarioTotal = (fixo + comissao + comissaoVendas);
WriteLine($"Salário final do mês: R${salarioTotal}");

//Exercício 9:

double reducaoCelsius, celsius, temperaturaFahrenheit;
WriteLine("Digite a temperatura de hoje em Fahrenheit:");
temperaturaFahrenheit = ToDouble(ReadLine());
reducaoCelsius = (temperaturaFahrenheit - 32);
celsius = reducaoCelsius * 5 / 9;
WriteLine($"Temperatura em Fahrenheit: {temperaturaFahrenheit}ºF;\nTemperatura em Celsius: {Math.Round(celsius, 0)}ºC.");

//Exercício 10:

double velocidadeMs, velocidadeKmH;
WriteLine("Digite a velocidade desejada em metros por segundo:");
velocidadeMs = ToDouble(ReadLine());
velocidadeKmH = velocidadeMs * 3.6;
WriteLine($"A velocidade digitada em metros por segundo: {velocidadeMs}m/s;\nA velocidade digitada em quilômetros por hora: {Math.Round(velocidadeKmH, 2)}Km/h.");

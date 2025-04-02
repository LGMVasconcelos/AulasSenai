using System.Runtime.Serialization;
using static System.Console;

int valor1, valor2, soma, valor3, valor4;
double n1, desconto, descontoDeclarado;
string produto;
valor1 = 1;
valor2 = 2;
soma = valor1 + valor2;
WriteLine($"Valor A: {valor1}, Valor B: {valor2}");
WriteLine($"A soma dos dois valores é {soma}");

WriteLine("Digite um valor C:");
valor3 = Convert.ToInt32(ReadLine());
WriteLine("Digite um valor D:");
valor4 = Convert.ToInt32(ReadLine());
WriteLine($"Valor C: {valor3}, Valor D: {valor4}");
valor3 = valor3 + valor4;
valor4 = valor3 - valor4;
valor3 = valor3 - valor4;
WriteLine($"Valor A invertido: {valor3}, Valor B invertido {valor4}");

WriteLine("Digite o nome do produto:");
produto = ReadLine();
WriteLine("Digite o valor do Produto:");
n1 = Convert.ToDouble(ReadLine());
WriteLine("Digite o valor do Desconto:");
descontoDeclarado = Convert.ToDouble(ReadLine());
desconto = (n1 * descontoDeclarado / 100);
double valordescontado = (n1 - desconto);
WriteLine($"O {produto} encomendado está com {Math.Round(descontoDeclarado, 2)}% de desconto, indo de {n1} para {Math.Round(valordescontado, 2)}!");
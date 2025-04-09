using static System.Console;
using static System.Convert;

int valor1, valor2;
WriteLine("Exercício 1: impressão de intervalos entre números, usando for e if-else:\n");
WriteLine("Digite o primeiro valor:");
valor1 = ToInt32(ReadLine());
WriteLine("Digite o segundo valor:");
valor2 = ToInt32(ReadLine());
if (valor1 > valor2){

    WriteLine($"Números entre {valor2} e {valor1}:");
   
    for (int i = valor2 + 1; i < valor1; i++)
{
    WriteLine(i.ToString());
}
}

else
{

    WriteLine($"Números entre {valor1} e {valor2}:");

    for (int i = valor1 + 1; i < valor2; i++)
{
    WriteLine(i.ToString());
}
}
ReadKey();
WriteLine("\nExercício 2: impressão de números de 10 em 10, usando while:\n");
int contador = -150;
while (contador < 150)
{
    contador += 10;
    WriteLine(contador.ToString());
}

ReadLine();

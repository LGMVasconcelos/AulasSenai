using System;
/*using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyNamespace
{
    class ManipuladorNumero
    {
        public int fatorial(int num)
        {
            int resultado;
            if (num == 1)
            {
                return 1;
            }
            else
            {
                resultado = num;
                for (int i = num - 1; i >= 1; i--)
                {
                    resultado = resultado * i;
                }
                return resultado;
                
            }
        }
        static void Main(string[] args)
        {
            ManipuladorNumero n = new ManipuladorNumero();
            WriteLine("Digite um número inteiro");
            int numero = Convert.ToInt32(ReadLine());
            WriteLine("O fatorial do número digitado é: {0}", n.fatorial(numero));
        }*/
/*using System;
using static System.Console;

namespace Mynamespace
{
    class CalcIdade
    {
        public int aniversario(int num)
        {
            int ano = DateTime.Today.Year;
            int nascimento = 0;
            if (num > 1900 && num <= ano)
            {
                nascimento = ano - num;
                WriteLine($"Você atualmente possui {nascimento} anos!");
            }
            else
            {
                WriteLine("Ano inválido! Deve ser entre 1901 e 2025.");
                nascimento = -1;
            }
            return nascimento;
        }

        static void Main(string[] args)
        {
            CalcIdade n = new CalcIdade();
            int idade;
            int resultado;

            do
            {
                Write("Digite o ano em que você nasceu: ");
                idade = Convert.ToInt32(ReadLine());
                resultado = n.aniversario(idade);
            } while (resultado == -1);
        }
    }
}

*/

using System.ComponentModel.Design;
using static System.Console;
using static System.Convert;

namespace menu
{
    class MainClass
    {
        public static void printMenu(String[] options)
        {
            foreach (String option in options)
            {
                WriteLine(option);
            }
            WriteLine("Escolha a sua opção: ");
        }

        public static void Main(String[] args)
        {
            WriteLine("<<<<< MENU >>>>>");
            String[] options = { "1 - Opção 1", "2 - Opção 2", "3 - Opção 3", "4 - Sair" };
            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Por favor, digite uma opção entre 1 e " + options.Length + ".");
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Ocorreu um erro fatal!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        option1();
                        break;
                    case 2:
                        option2();
                        break;
                    case 3:
                        option3();
                        break;
                    case 4:
                        WriteLine("Até a próxima!");
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, digite uma opção entre 1 e " + options.Length + ". Aperte qualquer tecla para prosseguir e tente novamente.");
                        ReadKey();
                        break;
                }
            }
        }
        
        private static void option1()
        {
            int valor1, valor2, resultadoValores;
            WriteLine("Digite dois valores inteiros abaixo:");
            Write("Valor 1: ");
            valor1 = ToInt32(ReadLine());
            Write("Valor 2: ");
            valor2 = ToInt32(ReadLine());
            resultadoValores = valor1 + valor2;
            WriteLine($"A soma de {valor1} e {valor2} é igual a {resultadoValores}. Aperte qualquer tecla para prosseguir.");
            ReadKey();
        }

        private static void option2()
        {
            double valor1, valor2, maior;
            WriteLine("Digite dois valores abaixo:");
            Write("Valor 1: ");
            valor1 = ToDouble(ReadLine());
            Write("Valor 2: ");
            valor2 = ToDouble(ReadLine());
            if (valor1 > valor2)
            {
                maior = valor1;
                WriteLine($"O maior valor entre os dois digitados é {maior}. Aperte qualquer tecla para prosseguir.");
                ReadKey();
            }
            else if (valor2 > valor1)
            {
                maior = valor2;
                WriteLine($"O maior valor entre os dois digitados é {maior}. Aperte qualquer tecla para prosseguir.");
                ReadKey();
            }
            else
            {
                WriteLine("Os dois valores são iguais.");
            }
        }

        private static void option3()
        {
            double peso, altura, imc;
            WriteLine("Digite seu peso e sua altura abaixo:");
            Write("Peso: ");
            peso = ToDouble(ReadLine());
            Write("Altura: ");
            altura = ToDouble(ReadLine());
            imc = peso / (Math.Pow(altura, 2));
            if (imc < 18.5)
            {
                WriteLine($"Seu índice de massa corporal é de {imc}, e sinto lhe informar, mas você está abaixo do peso ideal para sua altura. Aperte qualquer tecla para prosseguir.");
                ReadKey();
            }
            else if (imc > 18.5 && imc <= 24.9)
            {
                WriteLine($"Seu índice de massa corporal é de {imc}, e você está dentro do peso ideal para sua altura. Aperte qualquer tecla para prosseguir.");
                ReadKey();
            }
            else if (imc > 24.9 && imc <= 29.9)
            {
                WriteLine($"Seu índice de massa corporal é de {imc}, e você está um pouco acima do peso ideal para a sua altura. Aperte qualquer tecla para prosseguir.");
                ReadKey();
            }
            else if (imc > 29.9 && imc <= 34.9)
            {
                WriteLine($"Seu índice de massa corporal é de {imc}, e sinto lhe informar, mas você está em estado de obesidade visto a proporção entre sua altura e peso. Aperte qualquer tecla para prosseguir.");
                ReadKey();
            }
            else if (imc >= 35)
            {
                WriteLine($"Seu índice de massa corporal é de {imc}, e sinto lhe informar, mas você está em estado de obesidade EXTREMA visto a proporção entre sua altura e peso. Aperte qualquer tecla para prosseguir.");
                ReadKey();
            }
        }
    }
}

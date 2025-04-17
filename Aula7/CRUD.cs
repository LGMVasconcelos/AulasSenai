using System;
using static System.Console;

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
            Write("Escolha a sua opção : ");
        }
        public static void Main(string[] args)
        {
            WriteLine("<<<<<<<<<< NOMES >>>>>>>>>>");
            String[] options = {"1 - Cadastrar",
                            "2 - Editar",
                            "3 - Excluir",
                            "4 - Gravar",
                            "5 - Carregar",
                            "6 - Listar",
                            "7 - Sair",
                                };

            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = Convert.ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Um erro aconteceu! Tente novamente.");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Gravar();
                        break;
                    case 5:
                        Carregar();
                        break;
                    case 6:
                        Listar();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, digite uma opção entre 1 e  " + options.Length);
                        break;
                }

            }
        }

        static List<string> nomes = new List<string>();
        private static void Cadastrar()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=            CADASTRAR NOME                 =");
            WriteLine("=============================================");
            WriteLine();
            WriteLine("Digite um nome: ");
            string nome = ReadLine();
            var repetido = nomes.Any(x => x.Contains(nome));
            if (repetido == true)
            {
                WriteLine("O nome digitado já consta em nossos registros!");
                return;
            }
            else
            {
                nomes.Add(nome);
            }
            WriteLine();
            WriteLine("=============================================");
            WriteLine("=            LISTAGEM DE NOMES              =");
            WriteLine("=============================================");
            WriteLine();
            foreach (var item in nomes)
            {
                WriteLine(item);
            }
            WriteLine();
        }

        private static void Editar()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=               EDITAR NOME                 =");
            WriteLine("=============================================");
            WriteLine();
            string nome = "";
            WriteLine("Digite o nome que você deseja editar: ");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine();
                WriteLine($"O nome que será editado é {nomes[index]}");
                WriteLine();
                WriteLine("Redigite o nome: ");
                string novonome = ReadLine();
                var repetido = nomes.Any(x => x.Contains(novonome));
                if (repetido == true)
                {
                    WriteLine("Este nome já consta em nossos registros!");
                    return;
                }
                else
                {
                    nomes[index] = novonome;
                }
            }
            else
            {
                WriteLine("O nome digitado não foi encontrado em nossos registros!");
                return;
            }
            WriteLine();
            WriteLine("=============================================");
            WriteLine("=            LISTAGEM DE NOMES              =");
            WriteLine("=============================================");
            WriteLine();
            foreach (var item in nomes)
            {
                WriteLine(item);
            }
            WriteLine();
        }

        private static void Excluir()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=              EXCLUIR NOME                 =");
            WriteLine("=============================================");
            WriteLine();
            string nome = "";
            WriteLine("Digite o nome que deseja excluir: ");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            string confirma = "";
            if (index >= 0)
            {
                WriteLine();
                WriteLine($"O nome que será excluído é {nomes[index]}");
                WriteLine();
                WriteLine("Confirma (s/n)?");
                confirma = ReadLine();
                if (confirma == "s")
                {
                    nomes.RemoveAt(index);
                }
            }
            WriteLine();
            WriteLine("=============================================");
            WriteLine("=            LISTAGEM DE NOMES              =");
            WriteLine("=============================================");
            WriteLine();
            foreach (var item in nomes)
            {
                WriteLine(item);
            }
            WriteLine();
        }

        private static void Gravar()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=           GRAVAR NO ARQUIVO               =");
            WriteLine("=============================================");
            WriteLine();
            try
            {
                StreamWriter dadosnomes;
                string arq = @"C:\Nomes\nomes.txt";
                dadosnomes = File.CreateText(arq);
                foreach (var item in nomes)
                {
                    dadosnomes.WriteLine($"{item}");
                }
                dadosnomes.Close();
            }
            catch (Exception e)
            {
                WriteLine($"{e.Message}");
            }
            finally
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("<<<<<< DADOS GRAVADOS COM SUCESSO! >>>>>>");
                ResetColor();
                
            }
        }

        private static void Carregar()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=              LER ARQUIVO                  =");
            WriteLine("=============================================");
            WriteLine();
            var nome = File.ReadAllLines(@"C:\Nomes\nomes.txt");
            for (int i = 0; i < nome.Length; i++)
            {
                nomes.Add(nome[i]);
            }
            ForegroundColor = ConsoleColor.Green;
            WriteLine("<<<<<<< LEITURA REALIZADA COM SUCESSO! >>>>>>>");
            ResetColor();
            WriteLine();
        }

        private static void Listar()
        {
            Clear();
            WriteLine();
            WriteLine("=============================================");
            WriteLine("=            LISTAGEM DE NOMES              =");
            WriteLine("=============================================");
            WriteLine();
            foreach (var item in nomes)
            {
                WriteLine(item);
            }
            WriteLine();
        }
    }
}

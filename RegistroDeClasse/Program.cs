using Microsoft.VisualBasic.FileIO;
using System;
using static System.Console;
using static System.Convert;

namespace MyNamespace
{
    class sistemaDeNotas
    {
        public static void Menu(string[] opcoes)
        {
            ForegroundColor = ConsoleColor.Cyan;
            foreach (string item in opcoes)
            {
                WriteLine(item);
            }
            ResetColor();
        }

        public static void Main(string[] args)
        {
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
            string[] opcoes = { "1 - Cadastrar turma", "2 - Cadastrar alunos", "3 - Remover turma", "4 - Remover alunos", "5 - Modificar turma",
        "6 - Modificar aluno","7 - Modificar Notas", "8 - Exibir Turmas", "9 - Exibir alunos", "10 - Exibir alunos de recuperação",
        "11 - Exibir alunos reprovados", "12 - Exibir alunos aprovados", "13 - Salvar informações", "14 - Carregar informações" };
            int opcao = 0;
            while (true)
            {
                Menu(opcoes);
                while (true)
                {
                    try
                    {
                        opcao = ToInt32(ReadLine());
                        if (opcao >= 1 && opcao <= opcoes.Length)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine($"Por favor, digite uma opção entre 1 e {opcoes.Length}");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número.");
                    }
                }

                switch (opcao)
                {
                    case 1:
                        cadastroTurma();
                        break;
                    case 2:
                        cadastroAluno();
                        break;
                    case 3:
                        remocaoTurma();
                        break;
                    case 4:
                        remocaoAluno();
                        break;
                    case 5:
                        modificarTurma();
                        break;
                    case 6:
                        modificarAluno();
                        break;
                    case 7:
                        modificarNota();
                        break;
                    case 8:
                        exibirTurmas();
                        break;
                    case 9:
                        exibirAlunos();
                        break;
                    case 10:
                        exibirRec();
                        break;
                    case 11:
                        exibirRep();
                        break;
                    case 12:
                        exibirApr();
                        break;
                    case 13:
                        salvar();
                        break;
                    case 14:
                        carregar();
                        break;
                    default:
                        Clear();
                        WriteLine($"Por favor insira uma opção entre 1 e {opcoes.Length}");
                        WriteLine();
                        WriteLine("<<<<<<<< MENU >>>>>>>>");
                        break;
                }
            }
        }


        static List<string> alunos = new List<string>();
        static List<string> turmas = new List<string>();
        static List<double> n1 = new List<double>();
        static List<double> n2 = new List<double>();
        static List<double> media = new List<double>();

        private static void cadastroTurma()
        {
            while (true)
            {
                Clear();
                WriteLine("=============================================");
                WriteLine("=             CADASTRAR TURMA               =");
                WriteLine("=============================================");
                WriteLine();
                WriteLine("Digite o nome da turma que deseja cadastrar: ");
                string turma = ReadLine();

                var repetido = false;
                foreach (var t in turmas)
                {
                    if (t == turma)
                    {
                        repetido = true;
                        break;
                    }
                }

                if (repetido)
                {
                    WriteLine("O nome digitado já consta em nossos registros!");
                }
                else
                {
                    turmas.Add(turma);
                    WriteLine($"Turma '{turma}' cadastrada com sucesso!");
                }

                WriteLine();
                WriteLine("Deseja adicionar mais turmas, ir para o cadastro de alunos ou voltar ao menu principal?");
                WriteLine("1 - Adicionar mais turmas");
                WriteLine("2 - Ir para o cadastro de alunos");
                WriteLine("3 - Voltar ao menu principal");

                int escolha = 0;
                while (true)
                {
                    try
                    {
                        escolha = ToInt32(ReadLine());
                        if (escolha >= 1 && escolha <= 3)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("Por favor, escolha uma opção válida (1, 2 ou 3).");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número.");
                    }
                }

                if (escolha == 1)
                {
                    continue;
                }
                else if (escolha == 2)
                {
                    cadastroAluno();
                    break;
                }
                else if (escolha == 3)
                {
                    break;
                }
            }

            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }


        private static void cadastroAluno()
        {
            while (true)
            {
                Clear();
                WriteLine("=============================================");
                WriteLine("=             CADASTRAR ALUNO               =");
                WriteLine("=============================================");
                WriteLine();
                WriteLine("Digite o nome do(a) aluno(a) que deseja cadastrar: ");
                string aluno = ReadLine();

                var alunoExiste = false;
                foreach (var a in alunos)
                {
                    if (a.Contains(aluno))
                    {
                        alunoExiste = true;
                        break;
                    }
                }

                if (alunoExiste)
                {
                    WriteLine("O nome digitado já consta em nossos registros!");
                    WriteLine("Pressione qualquer tecla para continuar...");
                    ReadKey();
                    continue;
                }

                WriteLine("Digite a turma na qual o aluno estará inserido:");
                string turma = ReadLine();

                var turmaExiste = false;
                foreach (var t in turmas)
                {
                    if (t == turma)
                    {
                        turmaExiste = true;
                        break;
                    }
                }

                if (turmaExiste == false)
                {
                    WriteLine("A turma especificada não existe! Cadastre a turma primeiro.");
                    WriteLine("Pressione qualquer tecla para continuar...");
                    ReadKey();
                    continue;
                }

                double nota1 = 0, nota2 = 0;

                while (true)
                {
                    WriteLine("Digite a 1° nota do aluno (entre 0 e 100):");
                    try
                    {
                        nota1 = ToDouble(ReadLine());
                        if (nota1 >= 0 && nota1 <= 100)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("A nota deve valer entre 0 e 100!");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número.");
                    }
                }
                n1.Add(nota1);

                while (true)
                {
                    WriteLine("Digite a 2° nota do aluno (entre 0 e 100):");
                    try
                    {
                        nota2 = ToDouble(ReadLine());
                        if (nota2 >= 0 && nota2 <= 100)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("A nota deve valer entre 0 e 100!");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número.");
                    }
                }
                n2.Add(nota2);

                double mediaEstudante = (nota1 + nota2) / 2;
                media.Add(mediaEstudante);
                Clear();

                alunos.Add($"{aluno} - {turma}");
                WriteLine($"Aluno(a) {aluno} cadastrado(a) com sucesso na turma {turma}!");

                WriteLine();
                WriteLine("Deseja adicionar mais alunos?");
                WriteLine("1 - Sim");
                WriteLine("2 - Não");

                int escolha = 0;
                while (true)
                {
                    try
                    {
                        escolha = ToInt32(ReadLine());
                        if (escolha == 1 || escolha == 2)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("Por favor, escolha uma opção válida (1 ou 2).");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número.");
                    }
                }

                if (escolha == 2)
                {
                    break;
                }
            }

            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }



        private static void remocaoTurma()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=              REMOVER TURMA                =");
            WriteLine("=============================================");
            WriteLine();
            WriteLine("Digite o nome da turma que deseja remover: ");
            string turma = ReadLine();
            if (turma == "")
            {
                WriteLine("Nenhuma turma foi digitada. Operação cancelada.");
                return;
            }
            int index = -1;
            for (int i = 0; i < turmas.Count; i++)
            {
                if (turmas[i] == turma)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                bool turmaAssociada = false;
                foreach (var aluno in alunos)
                {
                    if (aluno.Contains($" - {turma}"))
                    {
                        turmaAssociada = true;
                        break;
                    }
                }

                if (turmaAssociada)
                {
                    WriteLine($"A turma '{turma}' possui alunos associados. Portanto, não pode ser removida.");
                    return;
                }

                WriteLine($"A turma que será removida é: {turmas[index]}");
                WriteLine("Confirma a remoção? (s/n)");
                string confirmacao = ReadLine();

                if (confirmacao.ToLower() == "s")
                {
                    turmas.RemoveAt(index);
                    WriteLine("Turma removida com sucesso!");
                }
                else
                {
                    WriteLine("Operação cancelada.");
                }
            }
            else
            {
                WriteLine("O nome digitado não foi encontrado em nossos registros!");
            }
            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }

        private static void remocaoAluno()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=              REMOVER ALUNO                =");
            WriteLine("=============================================");
            WriteLine();
            WriteLine("Digite o nome do(a) aluno(a) que deseja remover: ");
            string aluno = ReadLine();
            if (aluno == "")
            {
                WriteLine("Nenhum nome foi digitado. Operação cancelada.");
                return;
            }
            int index = -1;
            for (int i = 0; i < alunos.Count; i++)
            {
                if (alunos[i].Contains(aluno))
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                WriteLine($"O aluno que será removido é: {alunos[index]}");
                WriteLine("Confirma a remoção? (s/n)");
                string confirmacao = ReadLine();

                if (confirmacao.ToLower() == "s")
                {
                    alunos.RemoveAt(index);
                    WriteLine("Aluno removido com sucesso!");
                }
                else
                {
                    WriteLine("Operação cancelada.");
                }
            }
            else
            {
                WriteLine("O nome digitado não foi encontrado em nossos registros!");
            }
            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }

        private static void modificarTurma()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=             MODIFICAR TURMA               =");
            WriteLine("=============================================");
            WriteLine();
            WriteLine("Digite o nome da turma que deseja modificar: ");
            string turmaAtual = ReadLine();
            if (turmaAtual == "")
            {
                WriteLine("Nenhuma turma foi digitada. Operação cancelada.");
                return;
            }
            int index = -1;
            for (int i = 0; i < turmas.Count; i++)
            {
                if (turmas[i] == turmaAtual)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                WriteLine($"A turma que será modificada é: {turmas[index]}");
                WriteLine("Digite o novo nome para a turma: ");
                string novoNome = ReadLine();

                var repetido = turmas.Any(x => x == novoNome);
                if (repetido)
                {
                    WriteLine("O novo nome digitado já consta em nossos registros!");
                    return;
                }

                turmas[index] = novoNome;

                for (int i = 0; i < alunos.Count; i++)
                {
                    if (alunos[i].Contains($" - {turmaAtual}"))
                    {
                        alunos[i] = alunos[i].Replace($" - {turmaAtual}", $" - {novoNome}");
                    }
                }

                WriteLine($"Turma '{turmaAtual}' modificada com sucesso para '{novoNome}'!");
            }
            else
            {
                WriteLine("O nome digitado não foi encontrado em nossos registros!");
            }
            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }

        private static void modificarAluno()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=             MODIFICAR ALUNO               =");
            WriteLine("=============================================");
            WriteLine();
            WriteLine("Digite o nome do(a) aluno(a) que deseja modificar: ");
            string aluno = ReadLine();

            int index = alunos.FindIndex(a => a.StartsWith(aluno + " - "));

            if (index >= 0)
            {
                string turmaAtual = alunos[index].Substring(alunos[index].IndexOf(" - ") + 3);

                WriteLine();
                WriteLine($"O aluno que será editado é {aluno} da turma {turmaAtual}");
                WriteLine();
                WriteLine("Qual informação você deseja editar? ");
                string[] informacoes = { "1 - Turma que o aluno está inserido", "2 - Nome do aluno" };
                int informacao = 0;

                while (true)
                {
                    Menu(informacoes);
                    try
                    {
                        informacao = ToInt32(ReadLine());
                        if (informacao == 1 || informacao == 2)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("Por favor, escolha 1 ou 2.");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número.");
                    }
                }

                switch (informacao)
                {
                    case 1:
                        WriteLine("Insira a nova turma para qual o(a) aluno(a) será inserido(a):");
                        string novaTurma = ReadLine();
                        if (turmas.Contains(novaTurma))
                        {
                            alunos[index] = $"{aluno} - {novaTurma}";
                            WriteLine($"Turma do aluno {aluno} atualizada para {novaTurma}.");
                        }
                        else
                        {
                            WriteLine("A turma especificada não existe! Cadastre a turma primeiro.");
                        }
                        break;

                    case 2:
                        WriteLine("Insira o novo nome do(a) aluno(a):");
                        string novoNome = ReadLine();
                        if (alunos.Any(a => a.StartsWith(novoNome + " - ")))
                        {
                            WriteLine("Este nome já consta em nossos registros!");
                        }
                        else
                        {
                            alunos[index] = $"{novoNome} - {turmaAtual}";
                            WriteLine($"Nome do aluno atualizado para {novoNome}.");
                        }
                        break;
                }
            }
            else
            {
                WriteLine("O nome digitado não foi encontrado em nossos registros!");
            }

            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }


        private static void modificarNota()
        {
            while (true)
            {
                Clear();
                WriteLine("=============================================");
                WriteLine("=             MODIFICAR NOTA                =");
                WriteLine("=============================================");
                WriteLine();
                WriteLine("Digite o nome do(a) aluno(a) cuja nota deseja modificar: ");
                string aluno = ReadLine();

                int index = alunos.FindIndex(a => a.StartsWith(aluno + " - "));

                if (index >= 0)
                {
                    while (true)
                    {
                        WriteLine($"Aluno encontrado: {alunos[index]}");
                        WriteLine("Qual nota deseja modificar?");
                        WriteLine("1 - Primeira nota");
                        WriteLine("2 - Segunda nota");

                        int escolha = 0;
                        while (true)
                        {
                            try
                            {
                                escolha = ToInt32(ReadLine());
                                if (escolha == 1 || escolha == 2)
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("Por favor, escolha 1 ou 2.");
                                }
                            }
                            catch (FormatException)
                            {
                                WriteLine("Entrada inválida. Por favor, insira um número.");
                            }
                        }

                        if (escolha == 1)
                        {
                            while (true)
                            {
                                WriteLine($"Nota atual: {n1[index]}");
                                WriteLine("Digite a nova nota (entre 0 e 100):");
                                try
                                {
                                    double novaNota = ToDouble(ReadLine());
                                    if (novaNota >= 0 && novaNota <= 100)
                                    {
                                        n1[index] = novaNota;
                                        break;
                                    }
                                    else
                                    {
                                        WriteLine("A nota deve valer entre 0 e 100!");
                                    }
                                }
                                catch (FormatException)
                                {
                                    WriteLine("Entrada inválida. Por favor, insira um número.");
                                }
                            }
                        }
                        else if (escolha == 2)
                        {
                            while (true)
                            {
                                WriteLine($"Nota atual: {n2[index]}");
                                WriteLine("Digite a nova nota (entre 0 e 100):");
                                try
                                {
                                    double novaNota = ToDouble(ReadLine());
                                    if (novaNota >= 0 && novaNota <= 100)
                                    {
                                        n2[index] = novaNota;
                                        break;
                                    }
                                    else
                                    {
                                        WriteLine("A nota deve valer entre 0 e 100!");
                                    }
                                }
                                catch (FormatException)
                                {
                                    WriteLine("Entrada inválida. Por favor, insira um número.");
                                }
                            }
                        }

                        media[index] = (n1[index] + n2[index]) / 2;
                        WriteLine("Nota modificada com sucesso!");

                        WriteLine("Deseja modificar outra nota para este aluno? (s/n)");
                        string resposta = ReadLine();
                        if (resposta.ToLower() != "s")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    WriteLine("O nome digitado não foi encontrado em nossos registros!");
                }

                WriteLine("Deseja modificar a nota de outro aluno? (s/n)");
                string continuar = ReadLine();
                if (continuar.ToLower() != "s")
                {
                    break;
                }
            }

            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }
        private static void exibirTurmas()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=            LISTA DE TURMAS                =");
            WriteLine("=============================================");
            WriteLine();

            if (turmas.Count == 0)
            {
                WriteLine("Nenhuma turma cadastrada no sistema.");
            }
            else
            {
                foreach (var turma in turmas)
                {
                    WriteLine(turma);
                }
            }

            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }

        private static void exibirAlunos()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=            LISTA DE ALUNOS                =");
            WriteLine("=============================================");
            WriteLine();

            if (alunos.Count == 0)
            {
                WriteLine("Nenhum aluno cadastrado no sistema.");
            }
            else
            {
                foreach (var aluno in alunos)
                {
                    WriteLine(aluno);
                }
            }

            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }


        private static void exibirRec()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=           ALUNOS EM RECUPERAÇÃO           =");
            WriteLine("=============================================");
            WriteLine();

            bool encontrou = false;
            for (int i = 0; i < media.Count && i < alunos.Count; i++)
            {
                if (media[i] >= 50 && media[i] <= 69.9)
                {
                    WriteLine($"Aluno: {alunos[i]} | Média: {Math.Round(media[i], 1)}");
                    encontrou = true;
                }
            }

            if (encontrou == false)
            {
                WriteLine("Nenhum aluno em recuperação encontrado.");
            }

            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }

        private static void exibirRep()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=            ALUNOS REPROVADOS              =");
            WriteLine("=============================================");
            WriteLine();

            bool encontrou = false;
            for (int i = 0; i < media.Count && i < alunos.Count; i++)
            {
                if (media[i] <= 49.9)
                {
                    if (media[i] == 0)
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine($"Aluno: {alunos[i]} | Média: {Math.Round(media[i], 1)}");
                        ResetColor();
                    }
                    else
                    {
                        WriteLine($"Aluno: {alunos[i]} | Média: {Math.Round(media[i], 1)}");
                    }
                    encontrou = true;
                }
            }

            if (encontrou == false)
            {
                WriteLine("Nenhum aluno reprovado encontrado.");
            }

            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }


        private static void exibirApr()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=            ALUNOS APROVADOS               =");
            WriteLine("=============================================");
            WriteLine();

            bool encontrou = false;
            for (int i = 0; i < media.Count && i < alunos.Count; i++)
            {
                if (media[i] >= 70)
                {
                    if (media[i] == 100)
                    {
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine($"Aluno: {alunos[i]} | Média: {Math.Round(media[i], 1)}");
                        ResetColor();
                    }
                    else
                    {
                        WriteLine($"Aluno: {alunos[i]} | Média: {Math.Round(media[i], 1)}");
                    }
                    encontrou = true;
                }
            }

            if (encontrou == false)
            {
                WriteLine("Nenhum aluno aprovado encontrado.");
            }

            WriteLine();
            WriteLine("Pressione qualquer tecla para voltar ao menu...");
            ReadKey();
            Clear();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }

        private static void salvar()
        {
            Clear();
            try
            {
                if (Directory.Exists(@"C:\Dados") == false)
                {
                    Directory.CreateDirectory(@"C:\Dados");
                }

                StreamWriter dadosalunos;
                string arqAln = @"C:\Dados\alunos.txt";
                dadosalunos = File.CreateText(arqAln);
                foreach (var item in alunos)
                {
                    dadosalunos.WriteLine($"{item}");
                }
                dadosalunos.Close();
                StreamWriter dadosturmas;
                string arqTrm = @"C:\Dados\turmas.txt";
                dadosturmas = File.CreateText(arqTrm);
                foreach (var item in turmas)
                {
                    dadosturmas.WriteLine($"{item}");
                }
                dadosturmas.Close();
                StreamWriter dadosn1;
                string arqN1 = @"C:\Dados\nota1.txt";
                dadosn1 = File.CreateText(arqN1);
                foreach (var item in n1)
                {
                    dadosn1.WriteLine($"{item}");
                }
                dadosn1.Close();
                StreamWriter dadosn2;
                string arqN2 = @"C:\Dados\nota2.txt";
                dadosn2 = File.CreateText(arqN2);
                foreach (var item in n2)
                {
                    dadosn2.WriteLine($"{item}");
                }
                dadosn2.Close();
            }
            catch (Exception e)
            {
                WriteLine($"{e.Message}");
            }
            finally
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("<<<<<< DADOS SALVOS COM SUCESSO! >>>>>>");
                ResetColor();
                WriteLine("<<<<<<<< MENU >>>>>>>>");
            }
        }
        private static void carregar()
        {
            Clear();
            var aluno = File.ReadAllLines(@"C:\Dados\alunos.txt");
            for (int i = 0; i < aluno.Length; i++)
            {
                alunos.Add(aluno[i]);
            }
            var turma = File.ReadAllLines(@"C:\Dados\turmas.txt");
            for (int i = 0; i < turma.Length; i++)
            {
                turmas.Add(turma[i]);
            }
            var notas1 = File.ReadAllLines(@"C:\Dados\nota1.txt");
            for (int i = 0; i < notas1.Length; i++)
            {
                n1.Add(ToDouble(notas1[i]));
            }
            var notas2 = File.ReadAllLines(@"C:\Dados\nota2.txt");
            for (int i = 0; i < notas2.Length; i++)
            {
                n2.Add(ToDouble(notas2[i]));
            }
            for (int i = 0; i < n1.Count && i < n2.Count; i++)
            {
                media.Add((n1[i] + n2[i]) / 2);
            }
            ForegroundColor = ConsoleColor.Green;
            WriteLine("<<<<<<< LEITURA REALIZADA COM SUCESSO! >>>>>>>");
            ResetColor();
            WriteLine();
            WriteLine("<<<<<<<< MENU >>>>>>>>");
        }
    }
}

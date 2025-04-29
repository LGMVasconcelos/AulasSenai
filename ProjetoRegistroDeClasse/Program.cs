using System.Runtime.CompilerServices;
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
        "11 - Exibir alunos reprovados", "12 - Exibir alunos aprovados", "13 - Salvar informações", "14 - Carregar informações", "15 - Sair" };
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
                        Clear();
                        WriteLine("<<<<<<<< MENU >>>>>>>>");
                        Menu(opcoes);
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
                    case 15:
                        sair();
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

        static List<string> alunoTurma = new List<string>();
        static List<string> alunos = new List<string>();
        static List<int> numeroAlunos = new List<int>();
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

                string turma;
                while (true)
                {
                    WriteLine("Digite o nome da turma que deseja cadastrar: ");
                    turma = ReadLine();
                    if (!string.IsNullOrWhiteSpace(turma))
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("O nome da turma não pode estar vazio. Por favor, insira um nome válido.");
                    }
                }

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
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"Turma '{turma}' cadastrada com sucesso!");
                    ResetColor();
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

                string aluno;
                while (true)
                {
                    WriteLine("Digite o nome do(a) aluno(a) que deseja cadastrar: ");
                    aluno = ReadLine();
                    if (!string.IsNullOrWhiteSpace(aluno))
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("O nome do aluno não pode estar vazio. Por favor, insira um nome válido.");
                    }
                }

                string turma;
                while (true)
                {
                    WriteLine("Digite a turma na qual o aluno estará inserido:");
                    turma = ReadLine();
                    if (!string.IsNullOrWhiteSpace(turma))
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("O nome da turma não pode estar vazio. Por favor, insira um nome válido.");
                    }
                }

                if (!turmas.Contains(turma))
                {
                    WriteLine("A turma especificada não existe! Cadastre a turma primeiro.");
                    WriteLine("Pressione qualquer tecla para continuar...");
                    ReadKey();
                    continue;
                }

                bool nomeRepetido = false;
                for (int i = 0; i < alunos.Count; i++)
                {
                    if (alunos[i] == aluno && alunoTurma[i] == turma)
                    {
                        nomeRepetido = true;
                        break;
                    }
                }

                if (nomeRepetido)
                {
                    WriteLine("Já existe um aluno com este nome na turma especificada!");
                    WriteLine("Pressione qualquer tecla para continuar...");
                    ReadKey();
                    continue;
                }

                int numeroAluno = 0;
                while (true)
                {
                    WriteLine("Digite o número do(a) aluno(a) (número inteiro positivo):");
                    try
                    {
                        numeroAluno = ToInt32(ReadLine());
                        if (numeroAluno > 0)
                        {
                            bool numeroRepetido = false;
                            for (int i = 0; i < numeroAlunos.Count; i++)
                            {
                                if (numeroAlunos[i] == numeroAluno && alunoTurma[i] == turma)
                                {
                                    numeroRepetido = true;
                                    break;
                                }
                            }

                            if (numeroRepetido)
                            {
                                WriteLine("Já existe um aluno com este número na turma especificada!");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            WriteLine("O número do aluno deve ser um valor positivo!");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
                    }
                }

                double nota1 = 0, nota2 = 0;

                while (true)
                {
                    WriteLine("Digite a 1ª nota do aluno (entre 0 e 10):");
                    try
                    {
                        nota1 = ToDouble(ReadLine());
                        if (nota1 >= 0 && nota1 <= 10)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("A nota deve estar entre 0 e 10!");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número.");
                    }
                }

                while (true)
                {
                    WriteLine("Digite a 2ª nota do aluno (entre 0 e 10):");
                    try
                    {
                        nota2 = ToDouble(ReadLine());
                        if (nota2 >= 0 && nota2 <= 10)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("A nota deve estar entre 0 e 10!");
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número.");
                    }
                }

                double mediaEstudante = Math.Floor((nota1 + nota2) / 2 * 10) / 10;

                alunos.Add(aluno);
                numeroAlunos.Add(numeroAluno);
                alunoTurma.Add(turma);
                n1.Add(nota1);
                n2.Add(nota2);
                media.Add(mediaEstudante);

                ForegroundColor = ConsoleColor.Green;
                WriteLine($"Aluno(a) {aluno} (Nº {numeroAluno}) cadastrado(a) com sucesso na turma {turma} com média {mediaEstudante}!");
                ResetColor();

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

            string turma;
            while (true)
            {
                WriteLine("Digite o nome da turma que deseja remover: ");
                turma = ReadLine();
                if (!string.IsNullOrWhiteSpace(turma))
                {
                    break;
                }
                else
                {
                    WriteLine("O nome da turma não pode estar vazio. Por favor, insira um nome válido.");
                }
            }

            int index = turmas.FindIndex(t => t == turma);

            if (index >= 0)
            {
                bool turmaAssociada = alunoTurma.Contains(turma);

                if (turmaAssociada)
                {
                    while (true)
                    {
                        WriteLine($"A turma '{turma}' possui alunos associados. Deseja removê-la mesmo assim? (s/n)");
                        string confirmacao = ReadLine();
                        if (confirmacao.ToLower() == "s")
                        {
                            for (int i = 0; i < alunoTurma.Count; i++)
                            {
                                if (alunoTurma[i] == turma)
                                {
                                    alunoTurma[i] = "[Turma excluída]";
                                }
                            }
                            break;
                        }
                        else if (confirmacao.ToLower() == "n")
                        {
                            Clear();
                            WriteLine("Operação cancelada.\n");
                            return;
                        }
                        else
                        {
                            WriteLine("Entrada inválida! Tente novamente!");
                        }
                    }
                }

                turmas.RemoveAt(index);
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Turma removida com sucesso!");
                ResetColor();
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

            WriteLine("Como deseja identificar o aluno?");
            WriteLine("1 - Pelo nome");
            WriteLine("2 - Pelo número");

            int opcaoIdentificacao = 0;
            while (true)
            {
                try
                {
                    opcaoIdentificacao = ToInt32(ReadLine());
                    if (opcaoIdentificacao == 1 || opcaoIdentificacao == 2)
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

            int index = -1;

            if (opcaoIdentificacao == 1)
            {
                string aluno;
                while (true)
                {
                    WriteLine("Digite o nome do(a) aluno(a) que deseja remover: ");
                    aluno = ReadLine();
                    if (!string.IsNullOrWhiteSpace(aluno))
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("O nome do aluno não pode estar vazio. Por favor, insira um nome válido.");
                    }
                }

                List<int> indices = new List<int>();
                for (int i = 0; i < alunos.Count; i++)
                {
                    if (alunos[i] == aluno)
                    {
                        indices.Add(i);
                    }
                }

                if (indices.Count > 1)
                {
                    WriteLine("Existem múltiplos alunos com este nome em diferentes turmas:");
                    for (int i = 0; i < indices.Count; i++)
                    {
                        WriteLine($"{i + 1} - {alunos[indices[i]]} (Nº {numeroAlunos[indices[i]]}) da turma {alunoTurma[indices[i]]}");
                    }

                    WriteLine("Selecione o número correspondente ao aluno que deseja remover:");
                    int selecao = 0;
                    while (true)
                    {
                        try
                        {
                            selecao = ToInt32(ReadLine());
                            if (selecao >= 1 && selecao <= indices.Count)
                            {
                                index = indices[selecao - 1];
                                break;
                            }
                            else
                            {
                                WriteLine($"Por favor, escolha um número entre 1 e {indices.Count}.");
                            }
                        }
                        catch (FormatException)
                        {
                            WriteLine("Entrada inválida. Por favor, insira um número.");
                        }
                    }
                }
                else if (indices.Count == 1)
                {
                    index = indices[0];
                }
                else
                {
                    WriteLine("O nome digitado não foi encontrado em nossos registros!");
                    WriteLine();
                    WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    ReadKey();
                    Clear();
                    WriteLine("<<<<<<<< MENU >>>>>>>>");
                    return;
                }
            }
            else
            {
                int numeroAluno = 0;
                string turma = "";

                while (true)
                {
                    WriteLine("Digite o número do(a) aluno(a) que deseja remover: ");
                    try
                    {
                        numeroAluno = ToInt32(ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
                    }
                }

                List<int> indices = new List<int>();
                for (int i = 0; i < numeroAlunos.Count; i++)
                {
                    if (numeroAlunos[i] == numeroAluno)
                    {
                        indices.Add(i);
                    }
                }

                if (indices.Count > 1)
                {
                    WriteLine("Existem múltiplos alunos com este número em diferentes turmas:");
                    for (int i = 0; i < indices.Count; i++)
                    {
                        WriteLine($"{i + 1} - {alunos[indices[i]]} (Nº {numeroAlunos[indices[i]]}) da turma {alunoTurma[indices[i]]}");
                    }

                    WriteLine("Selecione o número correspondente ao aluno que deseja remover:");
                    int selecao = 0;
                    while (true)
                    {
                        try
                        {
                            selecao = ToInt32(ReadLine());
                            if (selecao >= 1 && selecao <= indices.Count)
                            {
                                index = indices[selecao - 1];
                                break;
                            }
                            else
                            {
                                WriteLine($"Por favor, escolha um número entre 1 e {indices.Count}.");
                            }
                        }
                        catch (FormatException)
                        {
                            WriteLine("Entrada inválida. Por favor, insira um número.");
                        }
                    }
                }
                else if (indices.Count == 1)
                {
                    index = indices[0];
                }
                else
                {
                    WriteLine("O número digitado não foi encontrado em nossos registros!");
                    WriteLine();
                    WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    ReadKey();
                    Clear();
                    WriteLine("<<<<<<<< MENU >>>>>>>>");
                    return;
                }
            }

            if (index >= 0)
            {
                WriteLine($"O aluno que será removido é: {alunos[index]} (Nº {numeroAlunos[index]}) da turma {alunoTurma[index]}");
                while (true)
                {
                    WriteLine("Confirma a remoção? (s/n)");
                    string confirmacao = ReadLine();

                    if (confirmacao.ToLower() == "s")
                    {
                        alunos.RemoveAt(index);
                        numeroAlunos.RemoveAt(index);
                        alunoTurma.RemoveAt(index);
                        n1.RemoveAt(index);
                        n2.RemoveAt(index);
                        media.RemoveAt(index);

                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("Aluno removido com sucesso!");
                        ResetColor();
                        break;
                    }
                    else if (confirmacao.ToLower() == "n")
                    {
                        Clear();
                        WriteLine("Operação cancelada.\n");
                        return;
                    }
                    else
                    {
                        WriteLine("Entrada inválida! Tente novamente!");
                    }
                }
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

            string turmaAtual;
            while (true)
            {
                WriteLine("Digite o nome da turma que deseja modificar: ");
                turmaAtual = ReadLine();
                if (!string.IsNullOrWhiteSpace(turmaAtual))
                {
                    break;
                }
                else
                {
                    WriteLine("O nome da turma não pode estar vazio. Por favor, insira um nome válido.");
                }
            }

            int index = turmas.FindIndex(t => t == turmaAtual);

            if (index >= 0)
            {
                WriteLine($"A turma que será modificada é: {turmas[index]}");

                string novoNome;
                while (true)
                {
                    WriteLine("Digite o novo nome para a turma: ");
                    novoNome = ReadLine();
                    if (!string.IsNullOrWhiteSpace(novoNome))
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("O nome da nova turma não pode estar vazio. Por favor, insira um nome válido.");
                    }
                }

                if (!turmas.Contains(novoNome))
                {
                    turmas[index] = novoNome;

                    for (int i = 0; i < alunoTurma.Count; i++)
                    {
                        if (alunoTurma[i] == turmaAtual)
                        {
                            alunoTurma[i] = novoNome;
                        }
                    }

                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"Turma '{turmaAtual}' modificada com sucesso para '{novoNome}'!");
                    ResetColor();
                }
                else
                {
                    WriteLine("O novo nome digitado já consta em nossos registros!");
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

        private static void modificarAluno()
        {
            Clear();
            WriteLine("=============================================");
            WriteLine("=             MODIFICAR ALUNO               =");
            WriteLine("=============================================");
            WriteLine();

            WriteLine("Como deseja identificar o aluno?");
            WriteLine("1 - Pelo nome");
            WriteLine("2 - Pelo número");

            int opcaoIdentificacao = 0;
            while (true)
            {
                try
                {
                    opcaoIdentificacao = ToInt32(ReadLine());
                    if (opcaoIdentificacao == 1 || opcaoIdentificacao == 2)
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

            int index = -1;

            if (opcaoIdentificacao == 1)
            {
                string aluno;
                while (true)
                {
                    WriteLine("Digite o nome do(a) aluno(a) que deseja modificar: ");
                    aluno = ReadLine();
                    if (!string.IsNullOrWhiteSpace(aluno))
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("O nome do aluno não pode estar vazio. Por favor, insira um nome válido.");
                    }
                }

                List<int> indices = new List<int>();
                for (int i = 0; i < alunos.Count; i++)
                {
                    if (alunos[i] == aluno)
                    {
                        indices.Add(i);
                    }
                }

                if (indices.Count > 1)
                {
                    WriteLine("Existem múltiplos alunos com este nome em diferentes turmas:");
                    for (int i = 0; i < indices.Count; i++)
                    {
                        WriteLine($"{i + 1} - {alunos[indices[i]]} (Nº {numeroAlunos[indices[i]]}) da turma {alunoTurma[indices[i]]}");
                    }

                    WriteLine("Selecione o número correspondente ao aluno que deseja modificar:");
                    int selecao = 0;
                    while (true)
                    {
                        try
                        {
                            selecao = ToInt32(ReadLine());
                            if (selecao >= 1 && selecao <= indices.Count)
                            {
                                index = indices[selecao - 1];
                                break;
                            }
                            else
                            {
                                WriteLine($"Por favor, escolha um número entre 1 e {indices.Count}.");
                            }
                        }
                        catch (FormatException)
                        {
                            WriteLine("Entrada inválida. Por favor, insira um número.");
                        }
                    }
                }
                else if (indices.Count == 1)
                {
                    index = indices[0];
                }
                else
                {
                    WriteLine("O nome digitado não foi encontrado em nossos registros!");
                    WriteLine();
                    WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    ReadKey();
                    Clear();
                    WriteLine("<<<<<<<< MENU >>>>>>>>");
                    return;
                }
            }
            else
            {
                int numeroAluno = 0;

                while (true)
                {
                    WriteLine("Digite o número do(a) aluno(a) que deseja modificar: ");
                    try
                    {
                        numeroAluno = ToInt32(ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
                    }
                }

                List<int> indices = new List<int>();
                for (int i = 0; i < numeroAlunos.Count; i++)
                {
                    if (numeroAlunos[i] == numeroAluno)
                    {
                        indices.Add(i);
                    }
                }

                if (indices.Count > 1)
                {
                    WriteLine("Existem múltiplos alunos com este número em diferentes turmas:");
                    for (int i = 0; i < indices.Count; i++)
                    {
                        WriteLine($"{i + 1} - {alunos[indices[i]]} (Nº {numeroAlunos[indices[i]]}) da turma {alunoTurma[indices[i]]}");
                    }

                    WriteLine("Selecione o número correspondente ao aluno que deseja modificar:");
                    int selecao = 0;
                    while (true)
                    {
                        try
                        {
                            selecao = ToInt32(ReadLine());
                            if (selecao >= 1 && selecao <= indices.Count)
                            {
                                index = indices[selecao - 1];
                                break;
                            }
                            else
                            {
                                WriteLine($"Por favor, escolha um número entre 1 e {indices.Count}.");
                            }
                        }
                        catch (FormatException)
                        {
                            WriteLine("Entrada inválida. Por favor, insira um número.");
                        }
                    }
                }
                else if (indices.Count == 1)
                {
                    index = indices[0];
                }
                else
                {
                    WriteLine("O número digitado não foi encontrado em nossos registros!");
                    WriteLine();
                    WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    ReadKey();
                    Clear();
                    WriteLine("<<<<<<<< MENU >>>>>>>>");
                    return;
                }
            }

            if (index >= 0)
            {
                WriteLine($"O aluno que será editado é {alunos[index]} (Nº {numeroAlunos[index]}) da turma {alunoTurma[index]}");
                WriteLine();
                WriteLine("Qual informação você deseja editar? ");
                string[] informacoes = { "1 - Turma que o aluno está inserido", "2 - Nome do aluno", "3 - Número do aluno" };
                int informacao = 0;

                while (true)
                {
                    Menu(informacoes);
                    try
                    {
                        informacao = ToInt32(ReadLine());
                        if (informacao >= 1 && informacao <= 3)
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("Por favor, escolha uma opção entre 1 e 3.");
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
                        string novaTurma;
                        if (turmas.Count == 0)
                        {
                            WriteLine("Não existe nenhuma turma para qual o aluno possa ser transferido!");
                            WriteLine("Clique qualquer tecla pra voltar!");
                            ReadKey();
                            Clear();
                            return;
                        }
                        else if (turmas.Count == 1)
                        {
                            var primeiroIndice = turmas[0];
                            WriteLine($"A única turma para qual o aluno pode ser transferido é {primeiroIndice}. Quer transferir o aluno para essa turma? (s/n)");
                            string escolha = ReadLine().ToLower();
                            if (escolha == "s")
                            {
                                alunoTurma[index] = primeiroIndice;
                            }
                            else if(escolha == "n")
                            {
                                WriteLine("Operação cancelada.");
                                ReadKey();
                                Clear();
                                return;
                            }
                            else
                            {
                                WriteLine("Entrada inválida! Cancelando a operação...");
                                ReadKey();
                                Clear();
                                return;
                            }
                        }
                        else
                        {
                            while (true)
                            {
                                WriteLine("Insira a nova turma para qual o(a) aluno(a) será inserido(a):");
                                novaTurma = ReadLine();
                                if (!string.IsNullOrWhiteSpace(novaTurma))
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("O nome da turma não pode estar vazio. Por favor, insira um nome válido.");
                                }

                            }
                            if (turmas.Contains(novaTurma))
                            {
                                bool nomeRepetido = false;
                                for (int i = 0; i < alunos.Count; i++)
                                {
                                    if (i != index && alunos[i] == alunos[index] && alunoTurma[i] == novaTurma)
                                    {
                                        nomeRepetido = true;
                                        break;
                                    }
                                }

                                bool numeroRepetido = false;
                                for (int i = 0; i < numeroAlunos.Count; i++)
                                {
                                    if (i != index && numeroAlunos[i] == numeroAlunos[index] && alunoTurma[i] == novaTurma)
                                    {
                                        numeroRepetido = true;
                                        break;
                                    }
                                }

                                if (nomeRepetido)
                                {
                                    WriteLine("Já existe um aluno com este nome na turma de destino!");
                                }
                                else if (numeroRepetido)
                                {
                                    WriteLine("Já existe um aluno com este número na turma de destino!");
                                }
                                else
                                {
                                    alunoTurma[index] = novaTurma;
                                    ForegroundColor = ConsoleColor.Green;
                                    WriteLine($"Turma do aluno {alunos[index]} (Nº {numeroAlunos[index]}) atualizada para {novaTurma} com sucesso!");
                                    ResetColor();
                                }
                            }
                            else
                            {
                                WriteLine("A turma especificada não existe! Cadastre a turma primeiro.");
                            }
                        }
                        
                        break;

                    case 2:
                        string novoNome;
                        while (true)
                        {
                            WriteLine("Insira o novo nome do(a) aluno(a):");
                            novoNome = ReadLine();
                            if (!string.IsNullOrWhiteSpace(novoNome))
                            {
                                break;
                            }
                            else
                            {
                                WriteLine("O nome do aluno não pode estar vazio. Por favor, insira um nome válido.");
                            }
                        }

                        bool nomeJaExiste = false;
                        for (int i = 0; i < alunos.Count; i++)
                        {
                            if (i != index && alunos[i] == novoNome && alunoTurma[i] == alunoTurma[index])
                            {
                                nomeJaExiste = true;
                                break;
                            }
                        }

                        if (nomeJaExiste)
                        {
                            WriteLine("Já existe um aluno com este nome na mesma turma!");
                        }
                        else
                        {
                            alunos[index] = novoNome;
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine($"Nome do aluno atualizado para {novoNome} (Nº {numeroAlunos[index]}) com sucesso!");
                            ResetColor();
                        }
                        break;

                    case 3:
                        int novoNumero = 0;
                        while (true)
                        {
                            WriteLine("Insira o novo número do(a) aluno(a) (número inteiro positivo):");
                            try
                            {
                                novoNumero = ToInt32(ReadLine());
                                if (novoNumero > 0)
                                {
                                    break;
                                }
                                else
                                {
                                    WriteLine("O número do aluno deve ser um valor positivo!");
                                }
                            }
                            catch (FormatException)
                            {
                                WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
                            }
                        }

                        bool numeroJaExiste = false;
                        for (int i = 0; i < numeroAlunos.Count; i++)
                        {
                            if (i != index && numeroAlunos[i] == novoNumero && alunoTurma[i] == alunoTurma[index])
                            {
                                numeroJaExiste = true;
                                break;
                            }
                        }

                        if (numeroJaExiste)
                        {
                            WriteLine("Já existe um aluno com este número na mesma turma!");
                        }
                        else
                        {
                            numeroAlunos[index] = novoNumero;
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine($"Número do aluno {alunos[index]} atualizado para {novoNumero} com sucesso!");
                            ResetColor();
                        }
                        break;
                }
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

                WriteLine("Como deseja identificar o aluno?");
                WriteLine("1 - Pelo nome");
                WriteLine("2 - Pelo número");

                int opcaoIdentificacao = 0;
                while (true)
                {
                    try
                    {
                        opcaoIdentificacao = ToInt32(ReadLine());
                        if (opcaoIdentificacao == 1 || opcaoIdentificacao == 2)
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

                int index = -1;

                if (opcaoIdentificacao == 1)
                {
                    string aluno;
                    while (true)
                    {
                        WriteLine("Digite o nome do(a) aluno(a) cuja nota deseja modificar: ");
                        aluno = ReadLine();
                        if (!string.IsNullOrWhiteSpace(aluno))
                        {
                            break;
                        }
                        else
                        {
                            WriteLine("O nome do aluno não pode estar vazio. Por favor, insira um nome válido.");
                        }
                    }

                    List<int> indices = new List<int>();
                    for (int i = 0; i < alunos.Count; i++)
                    {
                        if (alunos[i] == aluno)
                        {
                            indices.Add(i);
                        }
                    }

                    if (indices.Count > 1)
                    {
                        WriteLine("Existem múltiplos alunos com este nome em diferentes turmas:");
                        for (int i = 0; i < indices.Count; i++)
                        {
                            WriteLine($"{i + 1} - {alunos[indices[i]]} (Nº {numeroAlunos[indices[i]]}) da turma {alunoTurma[indices[i]]}");
                        }

                        WriteLine("Selecione o número correspondente ao aluno que deseja modificar a nota:");
                        int selecao = 0;
                        while (true)
                        {
                            try
                            {
                                selecao = ToInt32(ReadLine());
                                if (selecao >= 1 && selecao <= indices.Count)
                                {
                                    index = indices[selecao - 1];
                                    break;
                                }
                                else
                                {
                                    WriteLine($"Por favor, escolha um número entre 1 e {indices.Count}.");
                                }
                            }
                            catch (FormatException)
                            {
                                WriteLine("Entrada inválida. Por favor, insira um número.");
                            }
                        }
                    }
                    else if (indices.Count == 1)
                    {
                        index = indices[0];
                    }
                    else
                    {
                        WriteLine("O nome digitado não foi encontrado em nossos registros!");
                        continue;
                    }
                }
                else
                {
                    int numeroAluno = 0;

                    while (true)
                    {
                        WriteLine("Digite o número do(a) aluno(a) cuja nota deseja modificar: ");
                        try
                        {
                            numeroAluno = ToInt32(ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
                        }
                    }

                    List<int> indices = new List<int>();
                    for (int i = 0; i < numeroAlunos.Count; i++)
                    {
                        if (numeroAlunos[i] == numeroAluno)
                        {
                            indices.Add(i);
                        }
                    }

                    if (indices.Count > 1)
                    {
                        WriteLine("Existem múltiplos alunos com este número em diferentes turmas:");
                        for (int i = 0; i < indices.Count; i++)
                        {
                            WriteLine($"{i + 1} - {alunos[indices[i]]} (Nº {numeroAlunos[indices[i]]}) da turma {alunoTurma[indices[i]]}");
                        }

                        WriteLine("Selecione o número correspondente ao aluno que deseja modificar a nota:");
                        int selecao = 0;
                        while (true)
                        {
                            try
                            {
                                selecao = ToInt32(ReadLine());
                                if (selecao >= 1 && selecao <= indices.Count)
                                {
                                    index = indices[selecao - 1];
                                    break;
                                }
                                else
                                {
                                    WriteLine($"Por favor, escolha um número entre 1 e {indices.Count}.");
                                }
                            }
                            catch (FormatException)
                            {
                                WriteLine("Entrada inválida. Por favor, insira um número.");
                            }
                        }
                    }
                    else if (indices.Count == 1)
                    {
                        index = indices[0];
                    }
                    else
                    {
                        WriteLine("O número digitado não foi encontrado em nossos registros!");
                        continue;
                    }
                }

                if (index >= 0)
                {
                    WriteLine($"Aluno encontrado: {alunos[index]} (Nº {numeroAlunos[index]}) | Turma: {alunoTurma[index]} | Média Atual: {media[index]}");

                    double novaNota1 = 0, novaNota2 = 0;

                    while (true)
                    {
                        WriteLine("Digite a nova 1ª nota (entre 0 e 10):");
                        try
                        {
                            novaNota1 = ToDouble(ReadLine());
                            if (novaNota1 >= 0 && novaNota1 <= 10)
                            {
                                break;
                            }
                            else
                            {
                                WriteLine("A nota deve estar entre 0 e 10!");
                            }
                        }
                        catch (FormatException)
                        {
                            WriteLine("Entrada inválida. Por favor, insira um número.");
                        }
                    }

                    while (true)
                    {
                        WriteLine("Digite a nova 2ª nota (entre 0 e 10):");
                        try
                        {
                            novaNota2 = ToDouble(ReadLine());
                            if (novaNota2 >= 0 && novaNota2 <= 10)
                            {
                                break;
                            }
                            else
                            {
                                WriteLine("A nota deve estar entre 0 e 10!");
                            }
                        }
                        catch (FormatException)
                        {
                            WriteLine("Entrada inválida. Por favor, insira um número.");
                        }
                    }

                    n1[index] = novaNota1;
                    n2[index] = novaNota2;
                    media[index] = Math.Floor((novaNota1 + novaNota2) / 2 * 10) / 10;

                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"Notas atualizadas com sucesso! Nova média: {media[index]}");
                    ResetColor();
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
                for (int i = 0; i < alunos.Count; i++)
                {
                    WriteLine($"Aluno: {alunos[i]} (Nº {numeroAlunos[i]}) | Turma: {alunoTurma[i]} | Média: {media[i]}");
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
            for (int i = 0; i < media.Count; i++)
            {
                if (media[i] >= 5 && media[i] < 7)
                {
                    WriteLine($"Aluno: {alunos[i]} (Nº {numeroAlunos[i]}) | Turma: {alunoTurma[i]} | Média: {media[i]}");
                    encontrou = true;
                }
            }

            if (!encontrou)
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
            for (int i = 0; i < media.Count; i++)
            {
                if (media[i] < 5)
                {
                    if (media[i] == 0)
                    {
                        ForegroundColor = ConsoleColor.Red;
                    }

                    WriteLine($"Aluno: {alunos[i]} (Nº {numeroAlunos[i]}) | Turma: {alunoTurma[i]} | Média: {media[i]}");
                    ResetColor();
                    encontrou = true;
                }
            }

            if (!encontrou)
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
            for (int i = 0; i < media.Count; i++)
            {
                if (media[i] >= 7)
                {
                    if (media[i] == 10)
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }

                    WriteLine($"Aluno: {alunos[i]} (Nº {numeroAlunos[i]}) | Turma: {alunoTurma[i]} | Média: {media[i]}");
                    ResetColor();
                    encontrou = true;
                }
            }

            if (!encontrou)
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
            WriteLine("=============================================");
            WriteLine("=           SALVAR INFORMAÇÕES             =");
            WriteLine("=============================================");
            WriteLine();

            bool temTurmas = turmas.Count > 0;
            bool temAlunos = alunos.Count > 0;

            if (!temTurmas && !temAlunos)
            {
                WriteLine("Não há dados para ser salvos. Salvar o programa sem nenhum dado pode acabar reescrevendo os dados atualmente salvos e causando a perda de todos os arquivos.");
                WriteLine("Tem certeza que quer proceder? (s/n)");

                string resposta = ReadLine().ToLower();
                if (resposta != "s")
                {
                    WriteLine("Operação cancelada.");
                    WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    ReadKey();
                    Clear();
                    WriteLine("<<<<<<<< MENU >>>>>>>>");
                    return;
                }
            }
            else if (!temTurmas)
            {
                WriteLine("Você ainda não registrou nenhuma turma para ser salva!");
                WriteLine("Tem certeza que quer proceder? (s/n)");

                string resposta = ReadLine().ToLower();
                if (resposta != "s")
                {
                    WriteLine("Operação cancelada.");
                    WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    ReadKey();
                    Clear();
                    WriteLine("<<<<<<<< MENU >>>>>>>>");
                    return;
                }
            }
            else if (!temAlunos)
            {
                WriteLine("Você ainda não registrou nenhum aluno para ser salvo!");
                WriteLine("Tem certeza que quer proceder? (s/n)");

                string resposta = ReadLine().ToLower();
                if (resposta != "s")
                {
                    WriteLine("Operação cancelada.");
                    WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    ReadKey();
                    Clear();
                    WriteLine("<<<<<<<< MENU >>>>>>>>");
                    return;
                }
            }

            try
            {
                if (Directory.Exists(@"C:\Dados") == false)
                {
                    Directory.CreateDirectory(@"C:\Dados");
                }

                StreamWriter dadosAlunos = File.CreateText(@"C:\Dados\alunos.txt");
                foreach (var aluno in alunos)
                {
                    dadosAlunos.WriteLine(aluno);
                }
                dadosAlunos.Close();

                StreamWriter dadosTurmas = File.CreateText(@"C:\Dados\turmas.txt");
                foreach (var turma in turmas)
                {
                    dadosTurmas.WriteLine(turma);
                }
                dadosTurmas.Close();

                StreamWriter dadosAlunoTurma = File.CreateText(@"C:\Dados\alunoTurma.txt");
                foreach (var turma in alunoTurma)
                {
                    dadosAlunoTurma.WriteLine(turma);
                }
                dadosAlunoTurma.Close();

                StreamWriter dadosNumeroAlunos = File.CreateText(@"C:\Dados\numeroAlunos.txt");
                foreach (var numero in numeroAlunos)
                {
                    dadosNumeroAlunos.WriteLine(numero);
                }
                dadosNumeroAlunos.Close();

                StreamWriter dadosNotas1 = File.CreateText(@"C:\Dados\notas1.txt");
                StreamWriter dadosNotas2 = File.CreateText(@"C:\Dados\notas2.txt");
                StreamWriter dadosMedias = File.CreateText(@"C:\Dados\medias.txt");

                for (int i = 0; i < n1.Count; i++)
                {
                    dadosNotas1.WriteLine(n1[i]);
                    dadosNotas2.WriteLine(n2[i]);
                    dadosMedias.WriteLine(media[i]);
                }

                dadosNotas1.Close();
                dadosNotas2.Close();
                dadosMedias.Close();

                ForegroundColor = ConsoleColor.Green;
                WriteLine("<<<<<< DADOS SALVOS COM SUCESSO! >>>>>>");
                ResetColor();
            }
            catch (Exception e)
            {
                WriteLine($"Erro ao salvar os dados: {e.Message}");
            }
            finally
            {
                WriteLine("Pressione qualquer tecla para voltar ao menu...");
                ReadKey();
                Clear();
                WriteLine("<<<<<<<< MENU >>>>>>>>");
            }
        }

        private static void carregar()
        {
            Clear();
            if (File.Exists(@"C:\Dados\alunos.txt") == false ||
                File.Exists(@"C:\Dados\turmas.txt") == false ||
                File.Exists(@"C:\Dados\alunoTurma.txt") == false ||
                File.Exists(@"C:\Dados\numeroAlunos.txt") == false ||
                File.Exists(@"C:\Dados\notas1.txt") == false ||
                File.Exists(@"C:\Dados\notas2.txt") == false ||
                File.Exists(@"C:\Dados\medias.txt") == false)
            {
                WriteLine("Os arquivos necessários para carregar os dados não foram encontrados.");
                WriteLine("Pressione qualquer tecla para voltar ao menu...");
                ReadKey();
                return;
            }

            try
            {
                alunos.Clear();
                turmas.Clear();
                alunoTurma.Clear();
                numeroAlunos.Clear();
                n1.Clear();
                n2.Clear();
                media.Clear();

                var alunosArquivo = File.ReadAllLines(@"C:\Dados\alunos.txt");
                foreach (var aluno in alunosArquivo)
                {
                    alunos.Add(aluno);
                }

                var turmasArquivo = File.ReadAllLines(@"C:\Dados\turmas.txt");
                foreach (var turma in turmasArquivo)
                {
                    turmas.Add(turma);
                }

                var alunoTurmaArquivo = File.ReadAllLines(@"C:\Dados\alunoTurma.txt");
                foreach (var turma in alunoTurmaArquivo)
                {
                    alunoTurma.Add(turma);
                }

                var numerosArquivo = File.ReadAllLines(@"C:\Dados\numeroAlunos.txt");
                foreach (var numero in numerosArquivo)
                {
                    numeroAlunos.Add(int.Parse(numero));
                }

                var notas1Arquivo = File.ReadAllLines(@"C:\Dados\notas1.txt");
                var notas2Arquivo = File.ReadAllLines(@"C:\Dados\notas2.txt");
                var mediasArquivo = File.ReadAllLines(@"C:\Dados\medias.txt");

                for (int i = 0; i < notas1Arquivo.Length; i++)
                {
                    n1.Add(double.Parse(notas1Arquivo[i]));
                    n2.Add(double.Parse(notas2Arquivo[i]));
                    media.Add(double.Parse(mediasArquivo[i]));
                }

                ForegroundColor = ConsoleColor.Green;
                WriteLine("<<<<<<< LEITURA REALIZADA COM SUCESSO! >>>>>>>");
                ResetColor();
            }
            catch (Exception e) 
            {
                WriteLine($"Erro ao carregar os dados: {e.Message}");
            }
            finally
            {
                WriteLine("Pressione qualquer tecla para voltar ao menu...");
                ReadKey();
                Clear();
                WriteLine("<<<<<<<< MENU >>>>>>>>");
            }
        }

        private static void sair()
        {
            Environment.Exit(0);
        }
    }
}

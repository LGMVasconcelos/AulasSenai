using static System.Console;
using static System.Convert; //TODOS os exercícios irão utilizar o static System.Convert e o static System.Console.

//Exercício 1:

List<string> nomes = new List<string>();
List<int> idade = new List<int>();

for (int i = 1; i <= 10; i++)
{
    WriteLine($"Digite o nome do {i}º estudante:");
    nomes.Add(ReadLine());
}

WriteLine("\n");

for (int i = 1; i <= 10; i++)
{
    WriteLine($"Digite a idade do {i}º estudante:");
    idade.Add(ToInt32(ReadLine()));
}

int menor = idade[0], maior = idade[0];

for (int i = 1; i < idade.Count; i++)
{
    if (idade[i] < menor)
    {
        menor = idade[i];
    }
    if (idade[i] > maior)
    {
        maior = idade[i];
    }
}


int indiceMenor = idade.IndexOf(menor);
int indiceMaior = idade.IndexOf(maior);


WriteLine($"\nO estudante com maior idade é {nomes[indiceMaior]}, com {maior} anos.\n");
WriteLine($"O estudante com menor idade é {nomes[indiceMenor]}, com {menor} anos.");

//Exercício 2:

List<string> estudantes = new List<string>();
List<double> notas = new List<double>();

for (int i = 1; i <= 10; i++)
{
    WriteLine($"Digite o nome do {i}º estudante:");
    estudantes.Add(ReadLine());
}

WriteLine("\n");

for (int i = 1; i <= 10; i++)
{
    WriteLine($"Digite a nota do {i}º estudante:");
    double nota = ToDouble(ReadLine());
    while (nota > 10.0)
    {
        WriteLine("A nota é inválida. Tente novamente!");
        WriteLine("Digite a nota do aluno:");
        nota = ToDouble(ReadLine());
    }
    notas.Add(nota);
}

WriteLine("\nResultado dos estudantes:");

for (int i = 0; i < notas.Count; i++)
{
    if (notas[i] <= 6.0)
    {
        WriteLine($"O estudante {estudantes[i]} foi reprovado, com nota {notas[i]}.");
    }
    else
    {
        WriteLine($"O estudante {estudantes[i]} foi aprovado, com nota {notas[i]}.");
    }
}


//Exercício 3:

List<string> candidatas = new List<string>() { "Beatriz", "Ana", "Letícia", "Isabela", "Joana", "Maria", "Isadora", "Carol", "Yasmin", "Gabriela", "Bárbara", "Maysa", "Bianca", "Jossyara", "Marceline", "Regina", "Karla", "Maraisa", "Maiara", "Raissa" };
List<int> faixa = new List<int>() { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16 };
candidatas.Sort();
for (int i = 0; i < faixa.Count; i++)
{
    if (faixa[i] >= 18 && faixa[i] <= 20)
    {
        WriteLine($"A candidata {candidatas[i]} foram aprovadas!!!");
    }
    else if (faixa[i] >= 21)
    {
        WriteLine($"A candidata {candidatas[i]} foram reprovadas, pois são velhas demais para as vagas.");
    }
    else
    {
        WriteLine($"A candidata {candidatas[i]} foram reprovadas, pois ainda são novas demais as vagas.");
    }
}

// Exercício 4:

List<int> v1 = new List<int>() { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16 };
List<int> v2 = new List<int>() { 16, 24, 23, 22, 22, 21, 19, 18, 24, 16, 16, 17, 23, 19, 20, 21, 22, 18, 24, 25 };
int numerosIguais = 0;
WriteLine("Lista de números 1:\n");
for (int i = 0; i < v1.Count; i++)
{
    if (i == v1.Count - 1)
    {
        Write(v1[i] + ".\n");
    }
    else if (i == v1.Count - 2)
    {
        Write(v1[i] + " e ");
    }
    else
    {
        Write(v1[i] + ", ");
    }
    Task.Delay(25).Wait();
}
WriteLine("\nLista de números 2:\n");
for (int i = 0; i < v2.Count; i++)
{
    if (i == v2.Count - 1)
    {
        Write(v2[i] + ".\n");
    }
    else if (i == v1.Count - 2)
    {
        Write(v2[i] + " e ");
    }
    else
    {
        Write(v2[i] + ", ");
    }
    Task.Delay(25).Wait();
}

for (int i = 0; i < 20; i++)
    if (v1[i] == v2[i])
    {
        numerosIguais++;
    }
WriteLine($"\n'As duas listas de números apresentam {numerosIguais} valores idênticos uns aos outros na mesma posição.");

//Exercício 5:

List<string> alunos = new List<string>() { "Arthur", "André", "Bárbara", "Djeffer", "Francisco", "Fernando", "Enrico", "Gabriela", "Gabriel Bertaglia", "Gabriel dos Santos", "Lucas Henrique", "Lucas Mateus", "Luiz Gustavo", "Marco Antônio", "Maysa" };
List<double> notinhas = new List<double>() { 1, 5, 9, 10, 4, 9.5, 10, 8, 6, 2, 7, 6, 9, 0, 8 };
double media = notinhas.Sum() / notinhas.Count;
WriteLine("Alunos em ordem alfabética:\n");
for (int i = 0; i < alunos.Count; i++)
{
    if (i == alunos.Count - 1)
    {
        Write(alunos[i] + ".\n");
    }
    else if (i == alunos.Count - 2)
    {
        Write(alunos[i] + " e ");
    }
    else
    {
        Write(alunos[i] + ", ");
    }
    Task.Delay(25).Wait();
}
WriteLine("\nNotas de cada aluno respectivamente:\n");
for (int i = 0; i < notinhas.Count; i++)
{
    if (i == notinhas.Count - 1)
    {
        Write(notinhas[i] + ".\n");
    }
    else if (i == notinhas.Count - 2)
    {
        Write(notinhas[i] + " e ");
    }
    else
    {
        Write(notinhas[i] + ", ");
    }
    Task.Delay(25).Wait();
}
WriteLine($"\n A média das notas tiradas é de: {Math.Round(media, 2)}\n");

for (int i = 0; i < notinhas.Count; i++)
{
    if (notinhas[i] >= 7.0)
    {
        WriteLine($"O estudante {alunos[i]} tirou acima de 7.0, com nota {notas[i]}. Parabéns!!!");
    }

}

if (notinhas.All(nota => nota <= 5))
{
    WriteLine("Nenhum estudante tirou acima de 5.0");
}

//Exercício 6:

List<double> temposDeVolta = new List<double>() { 120.5, 143.2, 123.4, 168.5, 89.3, 54.8, 143.9, 154, 189.7, 96.7, 134.5, 75.9 };
double melhor, medio;
melhor = temposDeVolta[0];
for (int i = 1; i < temposDeVolta.Count; i++)
{
    if (temposDeVolta[i] < melhor)
    {
        melhor = temposDeVolta[i];
    }
}
WriteLine($"O melhor tempo foi de {melhor} segundos");
int voltaComMelhorTempo = 0;
for (int i = 0; i < temposDeVolta.Count; i++)
{
    if (temposDeVolta[i] == melhor)
    {
        voltaComMelhorTempo = i + 1;
        break;
    }
}
WriteLine($"A volta que teve o melhor tempo foi a volta {voltaComMelhorTempo}");
medio = temposDeVolta.Sum() / temposDeVolta.Count;
WriteLine($"O tempo médio das 12 voltas foi de {Math.Round(medio, 2)} segundos");

//Exercício 7:

List<int> numeros = new List<int>();
int numerosASerInseridos, mediazinha, maiorNumero;
WriteLine("Quantos números você deseja inserir?");
numerosASerInseridos = ToInt32(ReadLine());
for (int i = 0; i < numerosASerInseridos; i++)
{
    WriteLine($"Digite o {i + 1}º número:");
    numeros.Add(ToInt32(ReadLine()));
}
maiorNumero = numeros[0];
for (int i = 0; i < numeros.Count; i++)
{
    if (numeros[i] > maiorNumero)
    {
        maiorNumero = numeros[i];
    }
}
mediazinha = numeros.Sum() / numeros.Count;
WriteLine($"A média é dos números inseridos: {media}");
WriteLine($"O maior número inserido é: {maiorNumero}");

//Exercício 8:

List<double> g1 = new List<double>();
List<double> g2 = new List<double>();
List<double> mediaAritmetica = new List<double>();

int alunosASerInseridos;
WriteLine("Quantos alunos você deseja inserir?");
alunosASerInseridos = ToInt32(ReadLine());

for (int i = 0; i < alunosASerInseridos; i++)
{
    WriteLine($"Informe a nota do aluno {i + 1} na G1:");
    g1.Add(ToDouble(ReadLine()));
    WriteLine($"Informe a nota do aluno {i + 1} na G2:");
    g2.Add(ToDouble(ReadLine()));
    mediaAritmetica.Add((g1[i] + g2[i]) / 2);
}

WriteLine("\nResultado dos estudantes:");

for (int i = 0; i < alunosASerInseridos; i++)
{
    WriteLine($"Aluno {i + 1}\nNota do aluno na G1: {g1[i]}\nNota do aluno na G2: {g2[i]}\n.");

}

//Exercício 9:

int numeroASerInformado;
List<int> listaDeNumeros = new List<int>();
List<int> listaDePares = new List<int>();
List<int> listaDeImpares = new List<int>();
WriteLine("Informe 10 números inteiros e maiores que zero:");
for (int i = 0; i < 10; i++)
{
    Write($"Digite o {i + 1}º número: ");
    numeroASerInformado = ToInt32(ReadLine());
    if (numeroASerInformado > 0)
    {
        listaDeNumeros.Add(numeroASerInformado);
        if (numeroASerInformado % 2 == 0)
        {
            listaDePares.Add(numeroASerInformado);
        }
        else
        {
            listaDeImpares.Add(numeroASerInformado);
        }
    }
    else
    {
        WriteLine("Número inválido. Informe um número maior que zero.\n");
        do
        {
            Write("Informe o número novamente: ");
            numeroASerInformado = ToInt32(ReadLine());
        } while (numeroASerInformado < 0);

    }
}
listaDeNumeros.Sort();
listaDePares.Sort();
listaDeImpares.Sort();
Write("\nOs números digitados foram: ");
for (int i = 0; i < listaDeNumeros.Count; i++)
{
    if (i == listaDeNumeros.Count - 1)
    {
        Write(listaDeNumeros[i] + ".");
    }
    else if (i == listaDeNumeros.Count - 2)
    {
        Write(listaDeNumeros[i] + " e ");
    }
    else
    {
        Write(listaDeNumeros[i] + ", ");
    }
    Task.Delay(50).Wait();
}
Write("\n\nOs números pares digitados foram: ");
for (int i = 0; i < listaDePares.Count; i++)
{
    if (i == listaDePares.Count - 1)
    {
        Write(listaDePares[i] + ".");
    }
    else if (i == listaDePares.Count - 2)
    {
        Write(listaDePares[i] + " e ");
    }
    else
    {
        Write(listaDePares[i] + ", ");
    }
    Task.Delay(75).Wait();
}
Write("\n\nOs números ímpares digitados foram: ");
for (int i = 0; i < listaDeImpares.Count; i++)
{
    if (i == listaDeImpares.Count - 1)
    {
        Write(listaDeImpares[i] + ".");
    }
    else if (i == listaDeImpares.Count - 2)
    {
        Write(listaDeImpares[i] + " e ");
    }
    else
    {
        Write(listaDeImpares[i] + ", ");
    }
    Task.Delay(100).Wait();
}

//Exercício 10:

List<int> gabarito = new List<int>
{
  12, 5, 13, 19, 6, 8, 7, 14, 9, 25, 7, 29, 10
};

Write("Digite o número de apostadores que concorrerão na loteria: ");
int quantidadeApostadores = ToInt32(ReadLine());

List<string> nomesDosJogadores = new List<string>();
List<int> numeroDoCartao = new List<int>();
List<List<int>> respostasDosApostadores = new List<List<int>>();
List<int> acertosDosApostadores = new List<int>();

for (int i = 0; i < quantidadeApostadores; i++)
{
    WriteLine($"\nApostador {i + 1}:");

    Write("Nome: ");
    string nome = ReadLine();
    nomesDosJogadores.Add(nome);

    Write("Número do cartão: ");
    int numeroCartao = ToInt32(ReadLine());
    numeroDoCartao.Add(numeroCartao);

    List<int> respostas = new List<int>();
    for (int j = 0; j < 13; j++)
    {
        Write($"Resposta {j + 1}: ");
        respostas.Add(ToInt32(ReadLine()));
    }
    respostasDosApostadores.Add(respostas);

    int acertos = 0;
    for (int j = 0; j < 13; j++)
    {
        if (respostas[j] == gabarito[j])
        {
            acertos++;
        }
    }
    acertosDosApostadores.Add(acertos);
}

WriteLine("\nResultados:");
int maiorAcertos = 0;
string ganhador = "";

for (int i = 0; i < quantidadeApostadores; i++)
{
    WriteLine($"\nApostador: {nomesDosJogadores[i]}");
    WriteLine($"Número do cartão: {numeroDoCartao[i]}");
    WriteLine($"Números escolhidos: ");
    WriteLine($"Números escolhidos: ");
    for (int j = 0; j < respostasDosApostadores[i].Count; j++)
    {
        if (j == respostasDosApostadores[i].Count - 1)
        {
            Write(respostasDosApostadores[i][j] + ".");
        }
        else if (j == respostasDosApostadores[i].Count - 2)
        {
            Write(respostasDosApostadores[i][j] + " e ");
        }
        else
        {
            Write(respostasDosApostadores[i][j] + ", ");
        }
    }


    WriteLine($"\nAcertos: {acertosDosApostadores[i]}/{gabarito.Count}");

    if (acertosDosApostadores[i] > maiorAcertos)
    {
        maiorAcertos = acertosDosApostadores[i];
        ganhador = nomesDosJogadores[i];
    }
}

if (maiorAcertos == 13)
{
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine($"\nO Ganhador é {ganhador} com {maiorAcertos} acertos!");
}
else
{
    ForegroundColor = ConsoleColor.DarkRed;
    WriteLine("\nNenhum apostador acertou todos os números.");
}
ReadKey();

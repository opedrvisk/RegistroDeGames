using RegistroDeGames.Banco;
using RegistroDeGames.Menus;
using RegistroDeGames.Modelos;

var context = new RegistroGamesContext();

var desenvolvedoraDAL = new DAL<Desenvolvedora>(context);


Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarDesenvolvedoras());
opcoes.Add(2, new MenuRegistrarJogos());
opcoes.Add(3, new MenuMostrarDesenvolvedoras());
opcoes.Add(4, new MenuMostrarJogos());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

 ▄▄▄▄▄▄▄ ▄▄▄▄▄▄ ▄▄   ▄▄ ▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄ 
█       █      █  █▄█  █       █       █
█   ▄▄▄▄█  ▄   █       █    ▄▄▄█  ▄▄▄▄▄█
█  █  ▄▄█ █▄█  █       █   █▄▄▄█ █▄▄▄▄▄ 
█  █ █  █      █       █    ▄▄▄█▄▄▄▄▄  █
█  █▄▄█ █  ▄   █ ██▄██ █   █▄▄▄ ▄▄▄▄▄█ █
█▄▄▄▄▄▄▄█▄█ █▄▄█▄█   █▄█▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█


");
    Console.WriteLine("Boas vindas ao Registro de games!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma desenvolvedora");
    Console.WriteLine("Digite 2 para registrar o jogo de uma desenvolvedora");
    Console.WriteLine("Digite 3 para mostrar todos as desenvolvedoras");
    Console.WriteLine("Digite 4 para exibir todos os jogos de uma desenvolvedora");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(desenvolvedoraDAL);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();
using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;

namespace RegistroDeGames.Menus;

internal class MenuMostrarJogos : Menu
{
    public override void Executar(DAL<Desenvolvedora> desenvolvedoraDAL)
    {
        base.Executar(desenvolvedoraDAL);
        ExibirTituloDaOpcao("Exibir detalhes da desenvolvedora");
        Console.Write("Digite o nome da desenvolvedora que deseja conhecer melhor: ");
        string nomeDaDesenvolvedora = Console.ReadLine()!;
        var desenvolvedoraRecuperada = desenvolvedoraDAL.RecuperarPor(a => a.Nome.Equals(nomeDaDesenvolvedora));
        if (desenvolvedoraRecuperada is not null)
        {
            Console.WriteLine("\nJogos da desenvolvedora:");
            desenvolvedoraRecuperada.ExibirJogosDesenvolvedora();
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA desenvolvedora {nomeDaDesenvolvedora} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

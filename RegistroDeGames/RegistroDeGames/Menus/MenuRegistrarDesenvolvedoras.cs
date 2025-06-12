using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;

namespace RegistroDeGames.Menus;

internal class MenuRegistrarDesenvolvedoras : Menu
{
    public override void Executar(DAL<Desenvolvedora> desenvolvedoraDAL)
    {
        base.Executar(desenvolvedoraDAL);
        ExibirTituloDaOpcao("Registro de Desenvolvedoras");
        Console.Write("Digite o nome da desenvolvedora que deseja registrar: ");
        string nomeDaDesenvolvedora = Console.ReadLine()!;
        Console.Write("Digite a bio da desenvolvedora que deseja registrar: ");
        string bioDaDesenvolvedora = Console.ReadLine()!;
        Desenvolvedora desenvolvedora = new Desenvolvedora(nomeDaDesenvolvedora, bioDaDesenvolvedora);
        desenvolvedoraDAL.Adicionar(desenvolvedora);
        Console.WriteLine($"A desenvolvedora {nomeDaDesenvolvedora} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
    }
}

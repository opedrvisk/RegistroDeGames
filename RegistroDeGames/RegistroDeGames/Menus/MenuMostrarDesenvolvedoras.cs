using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;

namespace RegistroDeGames.Menus;

internal class MenuMostrarDesenvolvedoras : Menu
{
    public override void Executar(DAL<Desenvolvedora> desenvolvedoraDAL)
    {
        base.Executar(desenvolvedoraDAL);
        ExibirTituloDaOpcao("Exibindo todos as desenvolvedoras registradas na nossa aplicação");

        foreach (var desenvolvedora in desenvolvedoraDAL.Listar())
        {
            Console.WriteLine($"Desenvolvedora: {desenvolvedora}");
        }
            
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

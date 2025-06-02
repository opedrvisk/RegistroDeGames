using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;

namespace RegistroDeGames.Menus;

internal class MenuSair : Menu
{
    public override void Executar(DAL<Desenvolvedora> desenvolvedoraDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}

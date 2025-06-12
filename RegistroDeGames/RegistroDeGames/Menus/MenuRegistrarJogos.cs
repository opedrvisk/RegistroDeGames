using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;

namespace RegistroDeGames.Menus;

internal class MenuRegistrarJogos : Menu
{
    public override void Executar(DAL<Desenvolvedora> desenvolvedoraDAL)
    {
        base.Executar(desenvolvedoraDAL);
        ExibirTituloDaOpcao("Registro de jogos");
        Console.Write("Digite a desenvolvedora cujo jogo deseja registrar: ");
        string nomeDaDesenvolvedora = Console.ReadLine()!;
        var desenvolvedoraRecuperada = desenvolvedoraDAL.RecuperarPor(a => a.Nome.Equals(nomeDaDesenvolvedora));
        if (desenvolvedoraRecuperada is not null)
        {
            Console.Write("Agora digite o título do jogo: ");
            string tituloDoJogo = Console.ReadLine()!;
            Console.Write("Agora digite o ano de lançamento do jogo: ");
            string lancamentoDoJogo = Console.ReadLine()!;
            desenvolvedoraRecuperada.AdicionarJogo(new Jogo(tituloDoJogo) { AnoLancamento = Convert.ToInt32(lancamentoDoJogo)});
            Console.WriteLine($"O jogo {tituloDoJogo} de {nomeDaDesenvolvedora} foi registrado com sucesso!");
            desenvolvedoraDAL.Atualizar(desenvolvedoraRecuperada);
            Thread.Sleep(2000);
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

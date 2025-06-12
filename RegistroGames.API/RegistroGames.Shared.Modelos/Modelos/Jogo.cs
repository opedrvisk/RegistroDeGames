using RegistroDeGames.Modelos;

public class Jogo
{
    public Jogo(string nome, int? anoLancamento)
    {
        Nome = nome;
        AnoLancamento = anoLancamento;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int? AnoLancamento { get; set; }
    public int? DesenvolvedoraId { get; set; }  
    public virtual Desenvolvedora? Desenvolvedora { get; set; }


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");

    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}

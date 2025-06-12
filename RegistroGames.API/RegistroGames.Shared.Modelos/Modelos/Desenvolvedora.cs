namespace RegistroDeGames.Modelos;


public class Desenvolvedora
{
    public virtual ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();

    public Desenvolvedora(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
    }

    public string Nome { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; }

    public void AdicionarJogo(Jogo jogo)
    {
        Jogos.Add(jogo);
    }

    public void ExibirJogosDesenvolvedora()
    {
        Console.WriteLine($"Jogos desenvolvidos pela desenvolvedora {Nome}");
        foreach (var jogo in Jogos)
        {
            Console.WriteLine($"Jogos: {jogo.Nome} - Ano de lançamento: {jogo.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Bio: {Bio}";
    }
}

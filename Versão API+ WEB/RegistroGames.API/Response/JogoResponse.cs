namespace RegistroGames.API.Response;

public record JogoResponse(int Id, string Nome, int DesenvolvedoraId, string NomeDesenvolvedora)
{
    // Removed unused parameter 'anoLancamento' to address IDE0060
    public JogoResponse(int id, string nome) : this(id, nome, 0, string.Empty)
    {
    }
}


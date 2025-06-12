namespace RegistroGames.API.Response;

public record DesenvolvedoraResponse(int Id, string Nome, string Bio, string? FotoPerfil)
{
    public double? Classificacao { get; set; }
};
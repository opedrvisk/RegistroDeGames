namespace RegistroGames.Web.Requests;

public record DesenvolvedoraRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : DesenvolvedoraRequest(nome, bio, fotoPerfil);
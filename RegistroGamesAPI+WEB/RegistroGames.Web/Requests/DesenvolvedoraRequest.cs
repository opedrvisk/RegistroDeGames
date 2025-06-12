using System.ComponentModel.DataAnnotations;

namespace RegistroGames.Web.Requests;

public record DesenvolvedoraRequest([Required] string nome, [Required] string bio, string? fotoPerfil);



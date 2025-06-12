

using System.ComponentModel.DataAnnotations;

namespace RegistroGames.API.Requests;

public record DesenvolvedoraRequest([Required] string nome, [Required] string bio, string? fotoPerfil);


using System.ComponentModel.DataAnnotations;

namespace RegistroGames.API.Requests;

public record JogoRequest(
        [Required] string Nome,
        [Required] int DesenvolvedoraId,
        int? AnoLancamento 
    );



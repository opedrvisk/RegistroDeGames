using System.ComponentModel.DataAnnotations;

namespace RegistroGames.Web.Requests;

public record JogoRequest(
        [Required] string Nome,
        [Required] int DesenvolvedoraId,
        int? AnoLancamento,
         ICollection<GeneroRequest>? Generos = null
    );



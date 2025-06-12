using Microsoft.AspNetCore.Mvc;
using RegistroDeGames.Banco;
using RegistroGames.API.Requests;
using RegistroGames.API.Response;

public static class JogosExtensions
{
    public static void AddEndPointsJogos(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("jogos")
                              .RequireAuthorization()
                              .WithTags("Jogos");

        groupBuilder.MapGet("", ([FromServices] DAL<Jogo> dal) =>
        {
            var jogos = dal.Listar();
            if (jogos is null)
                return Results.NotFound();

            var responseList = JogosToResponseList(jogos);
            return Results.Ok(responseList);
        });

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Jogo> dal, string nome) =>
        {
            var jogo = dal.RecuperarPor(j => j.Nome.ToUpper() == nome.ToUpper());
            if (jogo is null)
                return Results.NotFound();

            var response = JogoToResponse(jogo);
            return Results.Ok(response);
        });

        groupBuilder.MapPost("", ([FromServices] DAL<Jogo> dal, [FromBody] JogoRequest jogoRequest) =>
        {
            var jogo = new Jogo(jogoRequest.Nome)
            {
                AnoLancamento = jogoRequest.AnoLancamento
            };

            dal.Adicionar(jogo);
            return Results.Ok();
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Jogo> dal, int id) =>
        {
            var jogo = dal.RecuperarPor(j => j.Id == id);
            if (jogo is null)
                return Results.NotFound();

            dal.Deletar(jogo);
            return Results.NoContent();
        });

        groupBuilder.MapPut("", ([FromServices] DAL<Jogo> dal, [FromBody] JogoRequestEdit jogoRequestEdit) =>
        {
            var jogo = dal.RecuperarPor(j => j.Id == jogoRequestEdit.Id);
            if (jogo is null)
                return Results.NotFound();

            jogo.Nome = jogoRequestEdit.Nome;
            jogo.AnoLancamento = jogoRequestEdit.AnoLancamento;

            dal.Atualizar(jogo);
            return Results.Ok();
        });
    }

    private static ICollection<JogoResponse> JogosToResponseList(IEnumerable<Jogo> jogos)
    {
        return jogos.Select(JogoToResponse).ToList();
    }

    private static JogoResponse JogoToResponse(Jogo jogo)
    {
        return new JogoResponse(jogo.Id, jogo.Nome, jogo.AnoLancamento);
    }
}

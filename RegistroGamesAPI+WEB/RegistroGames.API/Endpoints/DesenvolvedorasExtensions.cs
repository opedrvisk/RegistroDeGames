using Microsoft.AspNetCore.Mvc;
using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;
using RegistroGames.API.Requests;
using RegistroGames.API.Response;
using RegistroGames.Shared.Dados.Modelos;
using System.Security.Claims;

namespace RegistroGames.API.Endpoints;

public static class DesenvolvedorasExtensions
{
    public static void AddEndPointsDesenvolvedoras(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("desenvolvedoras")
                              .RequireAuthorization()
                              .WithTags("Desenvolvedoras");

        #region Endpoints Desenvolvedoras

        groupBuilder.MapGet("", ([FromServices] DAL<Desenvolvedora> dal) =>
        {
            var listaDeDesenvolvedoras = dal.Listar();
            if (listaDeDesenvolvedoras is null)
                return Results.NotFound();

            var listaDeResponse = EntityListToResponseList(listaDeDesenvolvedoras);
            return Results.Ok(listaDeResponse);
        });

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Desenvolvedora> dal, string nome) =>
        {
            var desenvolvedora = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (desenvolvedora is null)
                return Results.NotFound();

            var response = EntityToResponse(desenvolvedora);
            return Results.Ok(response);
        });

        groupBuilder.MapPost("", async (
            [FromServices] IHostEnvironment env,
            [FromServices] DAL<Desenvolvedora> dal,
            [FromBody] DesenvolvedoraRequest desenvolvedoraRequest) =>
        {
            var nome = desenvolvedoraRequest.nome.Trim();
            var imagemDesenvolvedora = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpg";
            var path = Path.Combine(env.ContentRootPath, "wwwroot", "FotosPerfil", imagemDesenvolvedora);

            if (!string.IsNullOrEmpty(desenvolvedoraRequest.fotoPerfilBase64))
            {
                var bytesImagem = Convert.FromBase64String(desenvolvedoraRequest.fotoPerfilBase64);
                await File.WriteAllBytesAsync(path, bytesImagem);
            }

            var desenvolvedora = new Desenvolvedora(nome, desenvolvedoraRequest.bio)
            {
                FotoPerfil = $"/FotosPerfil/{imagemDesenvolvedora}"
            };

            dal.Adicionar(desenvolvedora);
            return Results.Ok();
        });

        groupBuilder.MapPut("", ([FromServices] DAL<Desenvolvedora> dal, [FromBody] DesenvolvedoraRequestEdit desenvolvedoraRequestEdit) =>
        {
            var desenvolvedoraAtualizar = dal.RecuperarPor(a => a.Id == desenvolvedoraRequestEdit.Id);
            if (desenvolvedoraAtualizar is null)
                return Results.NotFound();

            desenvolvedoraAtualizar.Nome = desenvolvedoraRequestEdit.nome;
            desenvolvedoraAtualizar.Bio = desenvolvedoraRequestEdit.bio;
            // Atualização de imagem pode ser implementada aqui se quiser.

            dal.Atualizar(desenvolvedoraAtualizar);
            return Results.Ok();
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Desenvolvedora> dal, int id) =>
        {
            var desenvolvedora = dal.RecuperarPor(a => a.Id == id);
            if (desenvolvedora is null)
                return Results.NotFound();

            dal.Deletar(desenvolvedora);
            return Results.NoContent();
        });

        #endregion

        #region Avaliações

        groupBuilder.MapPost("avaliacao", (
            HttpContext context,
            [FromBody] AvaliacaoDesenvolvedoraRequest request,
            [FromServices] DAL<Desenvolvedora> dalDesenvolvedora,
            [FromServices] DAL<PessoaComAcesso> dalPessoa
        ) =>
        {
            var desenvolvedora = dalDesenvolvedora.RecuperarPor(a => a.Id == request.DesenvolvedoraId);
            if (desenvolvedora is null) return Results.NotFound();

            var email = context.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value
                ?? throw new InvalidOperationException("Pessoa não está conectada");

            var pessoa = dalPessoa.RecuperarPor(p => p.Email.Equals(email))
                ?? throw new InvalidOperationException("Pessoa não está conectada");

            var avaliacao = desenvolvedora.Avaliacoes
                .FirstOrDefault(a => a.DesenvolvedoraId == desenvolvedora.Id && a.PessoaId == pessoa.Id);

            if (avaliacao is null)
                desenvolvedora.AdicionarNota(pessoa.Id, request.Nota);
            else
                avaliacao.Nota = request.Nota;

            dalDesenvolvedora.Atualizar(desenvolvedora);
            return Results.Created();
        });

        groupBuilder.MapGet("{id}/avaliacao", (
            int id,
            HttpContext context,
            [FromServices] DAL<Desenvolvedora> dalDesenvolvedora,
            [FromServices] DAL<PessoaComAcesso> dalPessoa
        ) =>
        {
            var desenvolvedora = dalDesenvolvedora.RecuperarPor(a => a.Id == id);
            if (desenvolvedora is null) return Results.NotFound();

            var email = context.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value
                ?? throw new InvalidOperationException("Pessoa não está conectada");

            var pessoa = dalPessoa.RecuperarPor(p => p.Email.Equals(email))
                ?? throw new InvalidOperationException("Pessoa não está conectada");

            var avaliacao = desenvolvedora.Avaliacoes
                .FirstOrDefault(a => a.DesenvolvedoraId == id && a.PessoaId == pessoa.Id);

            var nota = avaliacao?.Nota ?? 0;
            return Results.Ok(new AvaliacaoDesenvolvedoraResponse(id, nota));
        });

        #endregion
    }

    private static ICollection<DesenvolvedoraResponse> EntityListToResponseList(IEnumerable<Desenvolvedora> lista)
    {
        return lista.Select(EntityToResponse).ToList();
    }

    private static DesenvolvedoraResponse EntityToResponse(Desenvolvedora desenvolvedora)
    {
        return new DesenvolvedoraResponse(
            desenvolvedora.Id,
            desenvolvedora.Nome,
            desenvolvedora.Bio,
            desenvolvedora.FotoPerfil)
        {
            Classificacao = desenvolvedora.Avaliacoes
                .Select(a => a.Nota)
                .DefaultIfEmpty(0)
                .Average()
        };
    }
}

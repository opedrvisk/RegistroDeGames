using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using RegistroGames.API.Requests;

namespace RegistroGames.API.Endpoints;

public static class DesenvolvedorasExtensions
{
    public static void AddEndPointsDesenvolvedoras(this WebApplication app)
    {
        app.MapGet("/Desenvolvedoras", ([FromServices] DAL<Desenvolvedora> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Desenvolvedoras/{nome}", ([FromServices] DAL<Desenvolvedora> dal, string nome) =>
        {

            var desenvolvedora = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (desenvolvedora is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(desenvolvedora);
        });

        app.MapPost("/Desenvolvedoras", ([FromServices] DAL<Desenvolvedora> dal, [FromBody] DesenvolvedoraRequest desenvolvedoraRequest) =>
        {
            var desenvolvedora = new Desenvolvedora(desenvolvedoraRequest.Nome,desenvolvedoraRequest.Bio);
            dal.Adicionar(desenvolvedora);
            return Results.Ok();

        });

        app.MapDelete("/Desenvolvedoras/{id}", ([FromServices] DAL<Desenvolvedora> dal, int id) =>
        {
            var desenvolvedora = dal.RecuperarPor(a => a.Id == id);
            if (desenvolvedora is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(desenvolvedora);
            return Results.NoContent();
        });

        app.MapPut("/Desenvolvedoras", ([FromServices] DAL<Desenvolvedora> dal, [FromBody] Desenvolvedora desenvolvedora) =>
        {
            var desenvolvedoraAtualizar = dal.RecuperarPor(a => a.Id == desenvolvedora.Id);
            if (desenvolvedoraAtualizar is null)
            {
                return Results.NotFound();
            }
            desenvolvedoraAtualizar.Nome = desenvolvedora.Nome;
            desenvolvedoraAtualizar.Bio = desenvolvedora.Bio;

            dal.Atualizar(desenvolvedoraAtualizar);
            return Results.Ok();
        });

    }
}

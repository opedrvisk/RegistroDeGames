﻿using Microsoft.AspNetCore.Mvc;
using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;
using RegistroGames.API.Requests;
using System.Runtime.CompilerServices;

namespace RegistroGames.API.Endpoints;

public static class JogosExtensions
{
    public static void AddEndPointsJogos(this WebApplication app)
    {
        app.MapGet("/Jogos/{nome}", ([FromServices] DAL<Jogo> dal, string nome) =>
        {
            var jogo = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (jogo is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(jogo);
        });

        app.MapPost("/Jogos", ([FromServices] DAL<Jogo> dal, [FromBody] JogoRequest jogoRequest) =>
        {
            var jogo = new Jogo(jogoRequest.Nome, jogoRequest.AnoLancamento, jogoRequest.DesenvolvedoraId);
            dal.Adicionar(jogo);
            return Results.Ok();
        });

        app.MapDelete("/Jogos/{id}", ([FromServices] DAL<Jogo> dal, int id) =>
        {
            var jogo = dal.RecuperarPor(a => a.Id == id);
            if (jogo is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(jogo);
            return Results.NoContent();
        });

        app.MapPut("Jogos", ([FromServices] DAL<Jogo> dal, [FromBody] Jogo jogo) =>
        {
            var jogoAtualizar = dal.RecuperarPor(a => a.Id == jogo.Id);
            if (jogoAtualizar is null)
            {
                return Results.NotFound();
            }
            jogoAtualizar.Nome = jogo.Nome;
            jogoAtualizar.AnoLancamento = jogo.AnoLancamento;
            dal.Atualizar(jogoAtualizar);
            return Results.Ok();
        });
    }
}

﻿namespace RegistroGames.API.Requests;

public record JogoRequestEdit(int Id, string nome, int DesenvolvedoraId, int anoLancamento)
    : JogoRequest(nome, DesenvolvedoraId, anoLancamento);

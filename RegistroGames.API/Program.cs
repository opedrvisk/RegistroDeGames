using Microsoft.AspNetCore.Mvc;
using RegistroDeGames.Banco;
using RegistroDeGames.Modelos;
using RegistroGames.API.Endpoints;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RegistroGamesContext>();
builder.Services.AddTransient<DAL<Desenvolvedora>>();
builder.Services.AddTransient<DAL<Jogo>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.AddEndPointsDesenvolvedoras();
app.AddEndPointsJogos();

app.UseSwagger();
app.UseSwaggerUI(); 

app.Run();

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeGames.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Desenvolvedoras", new string[] { "Nome", "Bio" }, new object[] { "Epic Games", "Desenvolvedora enorme criadora do sucesso Fortnite." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Valve", "Criadora do Steam, Half-Life e Counter-Strike." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Rockstar Games", "Conhecida pela série Grand Theft Auto e Red Dead Redemption." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Nintendo", "Gigante japonesa criadora de Mario, Zelda e Pokémon." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Sony Interactive Entertainment", "Responsável por jogos como The Last of Us e God of War." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "CD Projekt Red", "Estúdio polonês famoso por The Witcher e Cyberpunk 2077." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Ubisoft", "Desenvolvedora de Assassin’s Creed, Far Cry e Just Dance." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Bethesda Game Studios", "Criadora de Skyrim, Fallout e Starfield." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Mojang", "Estúdio sueco que criou Minecraft." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Bungie", "Conhecida por Halo e Destiny." });
            migrationBuilder.InsertData("Desenvolvedoras", new[] { "Nome", "Bio" }, new object[] { "Blizzard Entertainment", "Criadora de World of Warcraft, Overwatch e Diablo." });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Desenvolvedores");
        }
    }
}

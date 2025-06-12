using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeGames.Migrations
{
    /// <inheritdoc />
    public partial class insertGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "Counter Strike", "2000" }); // Valve
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "Grand Theft Auto V", "2013" }); // Rockstar Games
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "The Legend of Zelda: Breath of the Wild", "2017" }); // Nintendo
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "The Last of Us Part II", "2020" }); // Sony Interactive Entertainment
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "The Witcher 3: Wild Hunt", "2015" }); // CD Projekt Red
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "Assassin’s Creed Valhalla", "2020" }); // Ubisoft
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "The Elder Scrolls V: Skyrim", "2011" }); // Bethesda Game Studios
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "Minecraft", "2011" }); // Mojang
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "Destiny 2", "2017" }); // Bungie
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "Overwatch", "2016" }); // Blizzard Entertainment
            migrationBuilder.InsertData("Jogos", new[] { "Nome", "AnoLancamento" }, new object[] { "Fortnite", "2017" }); // Epic Games
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Jogos");
        }
    }
}

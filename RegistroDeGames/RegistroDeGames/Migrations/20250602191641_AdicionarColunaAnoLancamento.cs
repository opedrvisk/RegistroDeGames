using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeGames.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarColunaAnoLancamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnoLancamento",
                table: "Jogos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoLancamento",
                table: "Jogos");
        }
    }
}

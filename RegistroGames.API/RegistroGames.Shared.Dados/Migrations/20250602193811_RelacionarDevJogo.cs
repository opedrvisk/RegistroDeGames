using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeGames.Migrations
{
    /// <inheritdoc />
    public partial class RelacionarDevJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesenvolvedoraId",
                table: "Jogos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_DesenvolvedoraId",
                table: "Jogos",
                column: "DesenvolvedoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Desenvolvedoras_DesenvolvedoraId",
                table: "Jogos",
                column: "DesenvolvedoraId",
                principalTable: "Desenvolvedoras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Desenvolvedoras_DesenvolvedoraId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_DesenvolvedoraId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "DesenvolvedoraId",
                table: "Jogos");
        }
    }
}

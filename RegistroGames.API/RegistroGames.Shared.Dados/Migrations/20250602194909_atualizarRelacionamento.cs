using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroDeGames.Migrations
{
    /// <inheritdoc />
    public partial class atualizarRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Jogos SET DesenvolvedoraId = 2 WHERE ID = 2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

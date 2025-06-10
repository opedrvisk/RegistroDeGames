using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RegistroDeGames.Modelos;
using RegistroGames.Shared.Dados.Modelos;

namespace RegistroDeGames.Banco;

public class RegistroGamesContext : IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
{
    public DbSet<Desenvolvedora> Desenvolvedoras { get; set; }

    public DbSet<Jogo> Jogos { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegistroGamesV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}

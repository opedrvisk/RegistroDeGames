using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RegistroDeGames.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeGames.Banco;

internal class RegistroGamesContext : DbContext
{
    public DbSet<Desenvolvedora> Desenvolvedoras { get; set; }

    public DbSet<Jogo> Jogos { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegistroGamesV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}

using ExampleApp.Domen.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp.Domen;

public class ExampleAppDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    public ExampleAppDbContext()
    {
        Database.Migrate();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExampleApp;Trusted_Connection=True");
    }
}

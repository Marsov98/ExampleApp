using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleApp.Domen.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp.Domen;

public class ExampleAppDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExampleApp;Trusted_Connection=True");
    }
}

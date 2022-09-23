using src.Models;
using Microsoft.EntityFrameworkCore;

namespace src.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>(table => {
            table.HasKey(p => p.Id);
            table.HasMany(p => p.Contracts).WithOne().HasForeignKey(c => c.PersonId);
        });

        builder.Entity<Contract>(table => {
            table.HasKey(c => c.Id);
        });
    }

}
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Column>().OwnsOne(x => x.NumberType);
        modelBuilder.Entity<Column>().OwnsOne(x => x.StringType);
        modelBuilder.Entity<Column>().OwnsOne(x => x.TextType);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<PriceList> PriceList { get; set; }
}
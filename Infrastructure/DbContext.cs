using Domain;
using Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;
public class Database :DbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
        //Database.EnsureDeleted();
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

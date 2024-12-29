using Microsoft.EntityFrameworkCore;
using Ven.Shared.Entities;

namespace Ven.AccessData.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Esta linea no se puede eliminar
        base.OnModelCreating(modelBuilder);

        //Validacion
        modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();

        //Para Evitar el borrado en cascada
        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationShips = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var item in relationShips)
        {
            item.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
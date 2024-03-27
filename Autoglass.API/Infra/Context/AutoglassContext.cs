using Autoglass.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.API.Infra.Context;

public class AutoglassContext : DbContext
{
    public AutoglassContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SetupProduct(modelBuilder);
    }

    private void SetupProduct(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Product>()
            .HasAlternateKey(e => e.CodigoProduto);
    }
}

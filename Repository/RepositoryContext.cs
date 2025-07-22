using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RecipeConfiguration());
    }

    public DbSet<Recipe>? Recipes { get; set; }
    public DbSet<HotBin>? HotBins { get; set; }
    public DbSet<Aggregate>? Aggregates { get; set; }

}

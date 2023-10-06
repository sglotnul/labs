using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Category>()
            .AddDefaultData();
        
        modelBuilder
            .Entity<Product>()
            .AddDefaultData();
        
        modelBuilder.Entity<Order>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("DB");
    }
}
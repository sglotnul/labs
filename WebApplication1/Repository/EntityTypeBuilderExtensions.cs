using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1;

public static class EntityTypeBuilderExtensions
{
    public static DataBuilder<Category> AddDefaultData(this EntityTypeBuilder<Category> builder)
    {
        return builder
            .HasData(
                new Category { Id = 1, Name = "Home" },
                new Category { Id = 2, Name = "Chess" },
                new Category { Id = 3, Name = "Soccer" },
                new Category { Id = 4, Name = "Watersports" });
    }

    public static DataBuilder<Product> AddDefaultData(this EntityTypeBuilder<Product> builder)
    {
        return builder
            .HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 4,
                    Name = "Kayak",
                    Description = "A boat for one person",
                    Price = 275m
                },
                new Product
                {
                    Id = 2, 
                    CategoryId = 4, 
                    Name = "Lifejacket", 
                    Description = "Protective and fashionable",
                    Price = 48.95m
                },
                new Product
                {
                    Id = 3, 
                    CategoryId = 3, 
                    Name = "Soccer Ball", 
                    Description = "FIFA-approved size and weight",
                    Price = 19.50m
                },
                new Product
                {
                    Id = 4, 
                    CategoryId = 3, 
                    Name = "Corner Flags",
                    Description = "Give your playing field a professional touch",
                    Price = 34.95m
                },
                new Product
                {
                    Id = 5, 
                    CategoryId = 1, 
                    Name = "Product1", 
                    Description = "Description1",
                    Price = 100m
                },
                new Product
                {
                    Id = 6, 
                    CategoryId = 1, 
                    Name = "Product2",
                    Description = "Description2",
                    Price = 200m
                },
                new Product
                {
                    Id = 7, 
                    CategoryId = 2, 
                    Name = "Product3", 
                    Description = "Description3",
                    Price = 300m
                },
                new Product
                {
                    Id = 8, 
                    CategoryId = 2,
                    Name = "Product4",
                    Description = "Description4",
                    Price = 400m
                },
                new Product { 
                    Id = 9,
                    CategoryId = 2,
                    Name = "Product5", 
                    Description = "Description5",
                    Price = 500m
                });
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace Repositories;

public class StoreDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot config = builder.Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("StoreDB"));
    }

    public virtual DbSet<Category> Categories {get; set;}
    public virtual DbSet<Product> Products {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category() {CategoryId = 1, CategoryName = "A"},
            new Category() {CategoryId = 2, CategoryName = "B"}
        );
    }
}

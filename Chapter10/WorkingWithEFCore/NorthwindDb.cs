using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

// manages interactions with Northwind database
public class NorthwindDb : DbContext
{
    // These two properties map to tables in the database
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        string connectionString = $"Data Source={path}";
        WriteLine($"Connection: {connectionString}");
        optionsBuilder.UseSqlite(connectionString);
        
        // Adding logging statements
        optionsBuilder.LogTo(WriteLine)
#if DEBUG
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
#endif
            ;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example of using Fluent API instead of attributes
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // NOT NULL
            .HasMaxLength(15);
        
        // SQLite-specific configuration
        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            // To 'fix' the lack of decimal support in SQLite
            modelBuilder.Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();
        }
    }
}
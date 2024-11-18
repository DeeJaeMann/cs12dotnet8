using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics; // For RelationalEventId

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<NorthwindDb>()
            .Build();
        
        NpgsqlConnectionStringBuilder builder = new();
        builder.Database = "Northwind";
        builder.Host = "localhost";
        builder.Username = config["PSQLUSER"];
        builder.Password = config["PSQLPASS"];
        builder.Timeout = 3;
        
        optionsBuilder.LogTo(WriteLine,
                new[] { RelationalEventId.CommandExecuting }) // To filter results by provider specific values
#if DEBUG
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
#endif
            ;
        
        string? connectionString = builder.ConnectionString;
        WriteLine($"Connection string: {connectionString}");
        
        optionsBuilder.UseNpgsql(connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired()
            .HasMaxLength(15);
    }
}
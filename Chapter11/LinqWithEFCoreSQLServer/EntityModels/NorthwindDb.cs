using Microsoft.Data.SqlClient; // For SqlConnectionStringBuilder
using Microsoft.EntityFrameworkCore; // For DbContext, DbSet<t>

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlConnectionStringBuilder builder = new();

        builder.DataSource = ".";
        builder.InitialCatalog = "Northwind";
        builder.IntegratedSecurity = true;
        builder.Encrypt = true;
        builder.TrustServerCertificate = true;
        builder.MultipleActiveResultSets = true;

        string connection = builder.ConnectionString;
        WriteLine($"SQL Server connection: {connection}");

        optionsBuilder.UseSqlServer(connection);
    }

}
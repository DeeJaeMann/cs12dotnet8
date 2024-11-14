using Microsoft.Data.SqlClient; // For SqlConnectionStringBuilder
using Microsoft.EntityFrameworkCore; // For DbContext

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqlConnectionStringBuilder builder = new();

        builder.DataSource = "."; // "ServerName\InstanceName" ie. @".\sqlexpress"
        builder.InitialCatalog = "Northwind";
        builder.Encrypt = true;
        builder.TrustServerCertificate = true;
        builder.MultipleActiveResultSets = true;
        builder.ConnectTimeout = 3; // Default is 15 seconds

        // If using Windows Integrated authentication
        builder.IntegratedSecurity = true;

        // If using SQL Server authentication
        // builder.UserId = Environment.GetEnvironmentVariable("MY_SQL_USR");
        // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");

        string? connectionString = builder.ConnectionString;
        WriteLine($"Connection: {connectionString}");
        optionsBuilder.UseSqlServer(connectionString);
    }
}
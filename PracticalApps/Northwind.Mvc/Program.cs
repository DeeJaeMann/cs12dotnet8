#region Import namespaces
using Microsoft.AspNetCore.Identity; // For IdentityUser
using Microsoft.EntityFrameworkCore; // For UseSqlServer
using Northwind.Mvc.Data; // For ApplicationDbContext
using Northwind.EntityModels; // For AddNorthwindContext
#endregion

#region Configure the host web server including services
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// For SQLite
//builder.Services.AddNorthwindContext();

// For SQL Server
string? sqlServerConnection = builder.Configuration.GetConnectionString("NorthwindConnection");

if (sqlServerConnection is null)
{
    Console.WriteLine("SQL Server database connection string is missing!");
}
else
{
    Microsoft.Data.SqlClient.SqlConnectionStringBuilder sql = new(sqlServerConnection);
    sql.IntegratedSecurity = true;
    builder.Services.AddNorthwindContext(sql.ConnectionString);
}

var app = builder.Build();
#endregion

#region Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
#endregion

#region Start the host web server listening for HTTP requests
app.Run(); // Blocking call
#endregion
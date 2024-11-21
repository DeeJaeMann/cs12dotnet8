using Northwind.EntityModels; // For AddNorthwindContext

#region Configure web server host and services

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddNorthwindContext();
var app = builder.Build();

#endregion

#region Configure HTTP pipeline and routes

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapRazorPages();
app.MapGet("/hello", () => $"Environment is {app.Environment.EnvironmentName}");

#endregion

// Start the web server, host the website, and wait for requests
app.Run(); // Thread-blocking call
WriteLine("This executes after the web server has stopped!");

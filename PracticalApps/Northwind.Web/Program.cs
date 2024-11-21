var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region Configure HTTP pipeline and routes

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/hello", () => $"Environment is {app.Environment.EnvironmentName}");

#endregion

// Start the web server, host the website, and wait for requests
app.Run(); // Thread-blocking call
WriteLine("This executes after the web server has stopped!");

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

// Implementing an anonymous inline delegate as middleware to intercept HTTP requests and responses
app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;

    if (rep is not null)
    {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }

    if (context.Request.Path == "/bonjour")
    {
        // In the case of a match on URL path, this becomes a terminating delegate that returns so does not call the next delegate
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }

    // We could modify the request before calling the next delegate
    await next();

    // We could modify the response after calling the next delegate
});

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapRazorPages();
app.MapGet("/hello", () => $"Environment is {app.Environment.EnvironmentName}");

#endregion

// Start the web server, host the website, and wait for requests
app.Run(); // Thread-blocking call
WriteLine("This executes after the web server has stopped!");

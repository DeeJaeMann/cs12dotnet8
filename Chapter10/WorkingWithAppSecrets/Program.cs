using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
    
    WriteLine($"Hello, {config["Name"]}");
using Northwind.EntityModels; // For NorthwindDb

NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");
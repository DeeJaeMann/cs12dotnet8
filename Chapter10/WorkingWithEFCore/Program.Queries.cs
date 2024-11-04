using Microsoft.EntityFrameworkCore; // For Include
using Northwind.EntityModels; // For Northwind, Category, Product

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();
        
        SectionTitle("Categories and how many products they have");
        
        // Query to get all categories and related products
        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products);

        if (categories is null || !categories.Any())
        {
            Fail("No categories found");
            return;
        }
        
        // Execute query and enumerate results
        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }
    }

    private static void FilteredIncludes()
    {
        using NorthwindDb db = new();
        
        SectionTitle("Products with a minimum number of units in stock");

        string? input;
        int stock;

        do
        {
            Write("Enter a minimum for units in stock: ");
            input = ReadLine();
        } while (!int.TryParse(input, out stock));

        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products.Where(p => p.Stock >= stock));

        if (categories is null || !categories.Any())
        {
            Fail("No categories found");
            return;
        }
        
        Info($"ToQueryString: {categories.ToQueryString()}");

        foreach (Category c in categories)
        {
            WriteLine(
                "{0} has {1} products with a minimum {2} units in stock.",
                arg0: c.CategoryName, arg1: c.Products.Count, arg2: stock);

            foreach (Product p in c.Products)
            {
                WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
            }
        }
    }

    private static void QueryingProducts()
    {
        using NorthwindDb db = new();
        
        SectionTitle("Products that cost more than a price, highest at top");

        string? input;
        decimal price;

        do
        {
            Write("Enter a product price: ");
            input = ReadLine();
        } while (!decimal.TryParse(input, out price));
        
        IQueryable<Product>? products = db.Products?
            // LINQ query annotation
            .TagWith("Products filtered by price and sorted")
            .Where(product => product.Cost > price)
            .OrderByDescending(product => product.Cost);

        if (products is null || !products.Any())
        {
            Fail("No products found");
            return;
        }
        
        Info($"ToQueryString: {products.ToQueryString()}");

        foreach (Product p in products)
        {
            WriteLine(
                "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
                p.ProductId, p.ProductName, p.Cost, p.Stock);
        }
    }

    private static void GettingOneProduct()
    {
        using NorthwindDb db = new();
        
        SectionTitle("Getting a single product");

        string? input;
        int id;

        do
        {
            Write("Enter a product ID: ");
            input = ReadLine();
        } while (!int.TryParse(input, out id));
        
        Product? product = db.Products?
            .First(product => product.ProductId == id);
        
        Info($"First: {product?.ProductName}");
        
        if (product is null) Fail("No product found using First.");

        product = db.Products?
            .Single(product => product.ProductId == id);

        Info($"Single: {product?.ProductName}");
        
        if (product is null) Fail("No product found using Single.");
    }
} 
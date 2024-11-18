using Microsoft.EntityFrameworkCore; // For Include
using Northwind.EntityModels; // For Northwind, Category, Product

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();

        SectionTitle("Categories and how many products they have");

        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products);

        if (categories is null || !categories.Any())
        {
            Fail("No categories found");
            return;
        }

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
            Fail("No categories found.");
            return;
        }

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
}
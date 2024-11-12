using Northwind.EntityModels; // For NorthwindDb, Category, Product
using Microsoft.EntityFrameworkCore; // For DbSet<t>

partial class Program
{
    private static void FilterAndSort()
    {
        SectionTitle("Filter and sort");

        using NorthwindDb db = new();

        DbSet<Product> allProducts = db.Products;
        IQueryable<Product> filteredProducts =
            allProducts.Where(product => product.UnitPrice < 10M);
        
        IOrderedQueryable<Product> sortedAndFilteredProducts =
            filteredProducts.OrderByDescending(product => product.UnitPrice);
        
        // Projecting the results
        var projectedProducts = sortedAndFilteredProducts
            .Select(product => new
            {
                product.ProductId,
                product.ProductName,
                product.UnitPrice,
            });
        
        WriteLine("Products that cost less than $10:");
        //WriteLine(sortedAndFilteredProducts.ToQueryString());
        WriteLine(projectedProducts.ToQueryString());

        // Using previous method - Queried all columns
        /*
        foreach (Product p in sortedAndFilteredProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
                p.ProductId, p.ProductName, p.UnitPrice);
        }
        */
        foreach (var p in projectedProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
                p.ProductId, p.ProductName, p.UnitPrice);
        }

        WriteLine();
    }
}
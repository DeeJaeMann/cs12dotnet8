using Northwind.EntityModels; // For NorthwindDb, Category, Product
using Microsoft.EntityFrameworkCore; // For DbSet<T>

partial class Program
{
    private static void FilterAndSort()
    {
        SectionTitle("Filter and sort");

        using NorthwindDb db = new();

        DbSet<Product> allProducts = db.Products;

        IQueryable<Product> filteredProducts = allProducts.Where(product => product.UnitPrice < 10M);

        IOrderedQueryable<Product> sortedAndFilteredProducts = filteredProducts.OrderByDescending(product => product.UnitPrice);

        //Extend LINQ query to use Select method to return only the 3 properties we're going to use
        var projectedProducts = sortedAndFilteredProducts
            .Select(product => new // Anonymous type
            {
                product.ProductId,
                product.ProductName,
                product.UnitPrice,
            });

        WriteLine("Products that cost less than $10:");
        // Output the generated SQL
        // WriteLine(sortedAndFilteredProducts.ToQueryString());
        WriteLine(projectedProducts.ToQueryString());

        // Inefficient method: gets all properties
        /*
        foreach (Product p in sortedAndFilteredProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
                p.ProductId, p.ProductName, p.UnitPrice);
        }
        */

        // Projected method: gets only properties we're going to use
        foreach (var p in projectedProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
                p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }


}
using System.ComponentModel.DataAnnotations.Schema; // For [Column]

namespace Northwind.EntityModels;

public class Category
{
    // These properties map to columns in the db
    public int CategoryId { get; set; } // Primary key
    public string CategoryName { get; set; } = null!;
    
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }
    
    // Define navigation property for related rows
    public virtual ICollection<Product> Products { get; set; }
    // To enable developers to add products to a Category, we must
    // initialize the navigation property to an empty collection.
    // This also avoids an exception if we get a member like Count
        = new HashSet<Product>();
}
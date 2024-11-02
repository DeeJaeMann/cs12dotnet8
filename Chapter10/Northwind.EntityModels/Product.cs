using System.ComponentModel.DataAnnotations; // For [Required]
using System.ComponentModel.DataAnnotations.Schema; // For [Column]

namespace Northwind.EntityModels;

public class Product
{
    public int ProductId { get; set; } // Primary key

    [Required] [StringLength(40)] public string ProductName { get; set; } = null!;
    
    // Property name is different from column name
    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }
    
    [Column("UnitsInStock")]
    public short? Stock { get; set; }
    
    public bool Discontinued { get; set; }
    
    // These two properties define the foreign key relationship
    // to the Categories table
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}
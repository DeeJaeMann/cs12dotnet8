using System.ComponentModel.DataAnnotations; // For [Range], [Required], [EmailAddress]

namespace Northwind.Mvc.Models;

public record Thing(
    [Range(1,10)] int? Id,
    [Required] string? Color,
    [EmailAddress] string? Email
);


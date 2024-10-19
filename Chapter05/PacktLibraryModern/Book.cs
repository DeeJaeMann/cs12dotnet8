using System.Diagnostics.CodeAnalysis; // for [SetsRequiredMembers]

namespace PacktLibraryModern;

public class Book
{
    // .NET 7 or later
    public required string? Isbn;
    public required string? Title;

    public string? Author;
    public int PageCount;

    // Constructor for object initializer syntax
    public Book() { }

    // Constructor with params set for required fields
    [SetsRequiredMembers]
    public Book (string? isbn, string? title)
    {
        Isbn = isbn;
        Title = title;
    }
}

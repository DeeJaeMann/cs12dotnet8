namespace Packt.Shared;

// mutable record class
public record class C1
{
    public string? Name { get; set; }
}

// immutable recrod class
public record class C2(string? Name);

// mutable record struct
public record struct S1
{
    public string? Name { get; set; }
}

// another mutable record struct
public record struct S2(string? Name);

// immutable record struct
public readonly record struct S3(string? Name);
using Packt.Shared;

int thisCannotBeNull = 4;
//thisCannotBeNull = null; // CS0037 error
WriteLine(thisCannotBeNull);

int? thisCouldBeNull = null;

WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;

WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

// actual type if int? is Nullable<int>
Nullable<int> thisCouldAlsoBeNull = null;
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);

WriteLine();

Address address = new(city: "London")
{
    Building = null,
    Street = null!,
    Region = "UK"
};

// Instead of throwing an exception, null is assigned ? suffix - null-conditional operator
WriteLine(address.Building?.Length);
// use is not null instead of != (!= may be overridden)
if (address.Street is not null)
{
    WriteLine(address.Street.Length);
}

// Null-coalescing operator - ?? suffix
WriteLine(address.Building?.Length ?? 10);
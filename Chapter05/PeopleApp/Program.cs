using System.Security.Cryptography;
using Packt.Shared;
using PacktLibraryModern; // For Person
// C# 12 aliasing tuples
using Fruit = (string Name, int Number);

ConfigureConsole(); // Set current culture to US English

Person bob = new();

bob.Name = "Bob Smith";

bob.Born = new DateTimeOffset(
    year: 1965, month: 12, day: 22,
    hour: 16, minute: 28, second: 0,
    offset: TimeSpan.FromHours(-5)); // US Eastern Standard Time

bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

bob.BucketList =
    WondersOfTheAncientWorld.HangingGardensOfBabylon |
    WondersOfTheAncientWorld.MausoleumAtHalicarnassus;


// Demonstrating different ways to add a Person object into Children
// All versions of C#
Person alfred = new Person();
alfred.Name = "Alfred";
bob.Children.Add(alfred);

// C# 3 and later
bob.Children.Add(new Person { Name = "Bella" });

// C# 9 and later
bob.Children.Add(new() { Name = "Zoe" });

WriteLine(bob);
WriteLine(format: "{0} was born on {1:D}.", // Long date
    arg0: bob.Name, arg1: bob.Born);

WriteLine(
    format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
    arg0: bob.Name,
    arg1: bob.FavoriteAncientWonder,
    arg2: (int)bob.FavoriteAncientWonder);

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
WriteLine($"BucketList Enum as int {(int)bob.BucketList}");
WriteLine($"{bob.Name} has {bob.Children.Count} children:");

for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
{
    WriteLine($"> {bob.Children[childIndex].Name}");
}

WriteLine($"{bob.Name} is a {Person.Species}.");
WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");


WriteLine();

// Object initializer syntax
Person alice = new()
{
    Name = "Alice Jones",
    Born = new(1998, 3, 7, 16, 28, 0,
        // UTC time zone
        TimeSpan.Zero)
};

WriteLine(format: "{0} was born on {1:d}.",
    arg0: alice.Name, arg1: alice.Born);

WriteLine();

BankAccount.InterestRate = 0.012M;

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: jonesAccount.AccountName,
    arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: gerrierAccount.AccountName,
    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

WriteLine();

/*
// Object initializer syntax
Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals"
};
*/
Book book = new(isbn: "978-1803237800",
    title: "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
    Author = "Mark J. Price",
    PageCount = 821
};
WriteLine("{0}: {1} written by {2} has {3:N0} pages.",
    book.Isbn, book.Title, book.Author, book.PageCount);

Person blankPerson = new();
WriteLine(format:
    "{0} of {1} was created at {2:hh:mm:ss} on {2:dddd}.",
    arg0: blankPerson.Name,
    arg1: blankPerson.HomePlanet,
    arg2: blankPerson.Instantiated);

WriteLine();

bob.WriteToConsole();
WriteLine(bob.GetOrigin());
WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));
WriteLine(bob.OptionalParameters(3));
WriteLine(bob.OptionalParameters(3, "Jump!", 98.5));
WriteLine(bob.OptionalParameters(3, number: 52.7, command: "Hide!"));
WriteLine(bob.OptionalParameters(3, "Poke!", active: false));

WriteLine();

int a = 10;
int b = 20;
int c = 30;
int d = 40;

WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");
bob.PassingParameters(a, b, ref c, out d);
WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

int e = 50;
int f = 60;
int g = 70;

WriteLine($"Before: e={e}, f={f}, g={g}, h doesn't exist yet!");
// C# 7 or later
bob.PassingParameters(e, f, ref g, out int h);
WriteLine($"After: e={e}, f={f}, g={g}, h={h}");

WriteLine();

(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
// Without aliased tuple type
//var fruitNamed = bob.GetNamedFruit();
// With aliased tuple type
Fruit fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

// Deconstructing tuples
(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed tuple: {fruitName}, {fruitNumber}");

WriteLine();

var (name1, dob1) = bob; // Implicitly calls Deconstruct method
WriteLine($"Deconstructed person: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

WriteLine();

int number = 5;

try
{
    WriteLine($"{number}! is {Person.Factorial(number)}");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}");
}

WriteLine();

Person sam = new()
{
    Name = "Sam",
    Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

WriteLine();

sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");

string color = "red";

try
{
    sam.FavoritePrimaryColor = color;
    WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
}
catch (Exception ex)
{
    WriteLine("Tried to set {0} to '{1}': {2}",
        nameof(sam.FavoritePrimaryColor), color, ex.Message);
}

// Creates an exception
//bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia | WondersOfTheAncientWorld.GreatPyramidOfGiza;
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

WriteLine();

sam.Children.Add(new()
{
    Name = "Charlie",
    Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero) });
sam.Children.Add(new()
{
    Name = "Ella",
    Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero) });

// Get using Children List
WriteLine($"Sam's first child is {sam.Children[0].Name}.");
WriteLine($"Sam's second child is {sam.Children[1].Name}.");

// Get using int indexer
WriteLine($"Sam's first child is {sam[0].Name}.");
WriteLine($"Sam's second child is {sam[1].Name}.");

// Get using string indexer
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old.");

WriteLine();

// Array containing a mix of passenger types
Passenger[] passengers = {
    new FirstClassPassenger { AirMiles = 1_419, Name = "Susan" },
    new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
    new BusinessClassPassenger { Name = "Janice" },
    new CoachClassPassenger { CarryOnKg = 25.7, Name = "Dave" },
    new CoachClassPassenger { CarryOnKg = 0, Name = "Amit" },
};

foreach (Passenger passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        // C# 8 Syntax
        /*
        FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
        FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
        FirstClassPassenger _ => 2_000M, 
        */
        // C# 9 and Later
        /*
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35_000 => 1_500,
            > 15_000 => 1_750,
            _ => 2_000M
        },
        */
        // Can avoid nested switch using relational pattern in combo with property pattern
        
        FirstClassPassenger { AirMiles: > 35000 } => 1500M,
        FirstClassPassenger { AirMiles: > 15000 } => 1750M,
        FirstClassPassenger => 2000M,
        
        BusinessClassPassenger _ => 1_000M,
        CoachClassPassenger p when p.CarryOnKg < 10.0 => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

WriteLine();
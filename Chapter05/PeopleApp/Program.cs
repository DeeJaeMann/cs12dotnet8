using Packt.Shared;
using PacktLibraryModern; // For Person

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

Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals"
};
WriteLine("{0}: {1} written by {2} has {3:N0} pages.",
    book.Isbn, book.Title, book.Author, book.PageCount);

Person blankPerson = new();
WriteLine(format:
    "{0} of {1} was created at {2:hh:mm:ss} on {2:dddd}.",
    arg0: blankPerson.Name,
    arg1: blankPerson.HomePlanet,
    arg2: blankPerson.Instantiated);

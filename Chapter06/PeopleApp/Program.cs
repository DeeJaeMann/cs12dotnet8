using Packt.Shared;

Person harry = new()
{
    Name = "Harry",
    Born = new(year: 2001, month: 3, day: 25,
        hour: 0, minute: 0, second: 0,
        offset: TimeSpan.Zero)
};

harry.WriteToConsole();

WriteLine();

Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };

// Using instance method
lamech.Marry(adah);

// Using static method
//Person.Marry(lamech, zillah);

if (lamech + zillah)
{
    WriteLine($"{lamech.Name} and {zillah.Name} successfully got married.");
}

lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();

// Using instance method
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");

// Using static method
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";

// Use * operator
Person baby3 = lamech * adah;
baby3.Name = "Jubal";

Person baby4 = zillah * lamech;
baby4.Name = "Naamah";

adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();

for (int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine(format: "{0}'s child #{1} is named \"{2}\".",
    arg0: lamech.Name, arg1: i,
    arg2: lamech.Children[i].Name);
}

WriteLine();

// Non-generic lookup collection
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2;

WriteLine(format: "Key {0} has value: {1}",
    arg0: key,
    arg1: lookupObject[key]);

WriteLine(format: "Key {0} has value: {1}",
    arg0: harry,
    arg1: lookupObject[harry]);

WriteLine();

// Generic lookup collection
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
//lookupIntString.Add(key: harry, value: "Delta"); // Causes type error
lookupIntString.Add(key: 4, value: "Delta");

key = 3;

WriteLine(format: "Key {0} has value: {1}",
    arg0: key,
    arg1: lookupIntString[key]);

WriteLine();

// Assign method to Shout event deLagate
harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout_2;

// Call Poke method that will raise Shout event
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

WriteLine();

Person?[] people =
{
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" }
};

OutputPeopleNames(people, "Initial list of people:");

Array.Sort(people);

OutputPeopleNames(people,
    "After sorting using Person's IComparable implementation:");

WriteLine();

Array.Sort(people, new PersonComparer());

OutputPeopleNames(people,
    "After sorting using PersonComparer's IComparer implementation:");

WriteLine();

int a = 3;
int b = 3;
WriteLine($"a: {a}, b: {b}");
WriteLine($"a == b: {a == b}");

Person p1 = new() { Name = "Kevin" };
Person p2 = new() { Name = "Kevin" };
WriteLine($"p1: {p1}, p2: {p2}");
WriteLine($"p1.Name: {p1.Name}, p2.Name: {p2.Name}");
WriteLine($"p1 == p2: {p1 == p2}");

Person p3 = p1;
WriteLine($"p3: {p3}");
WriteLine($"p3.Name: {p3.Name}");
WriteLine($"p1 == p3: {p1 == p3}");

WriteLine($"p1.Name == p2.Name: {p1.Name == p2.Name}");
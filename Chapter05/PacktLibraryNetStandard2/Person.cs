namespace Packt.Shared;

public class Person : Object
{
    #region Fields: Data or state for this person

    public string? Name;
    public DateTimeOffset Born;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = new();
    // Constant field
    public const string Species = "Homo Sapiens";
    // Read only - preferred to constants
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    #endregion
    #region Constructors: Called when using new to instantiate a type

    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    #endregion
    #region Methods: Actions the type can perform

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}.");
    }

    public string GetOrigin()
    {
        return $"{Name} was bron on {HomePlanet}";
    }

    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }

    public string SayHelloTo(string name)
    {
        return $"{Name} says 'Hello, {name}!'";
    }

    #endregion
}
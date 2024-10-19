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

    #endregion
}
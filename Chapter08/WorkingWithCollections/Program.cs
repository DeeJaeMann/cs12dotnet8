//Define alias for a dictionary with string key and string value
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;

// Simple syntax for creating a list and adding 3 items
List<string> cities = new();
cities.Add("London");
cities.Add("Paris");
cities.Add("Milan");

/* Alternative syntax - converted into add methods by compiler
List<string> cities = new()
{ "London", "Paris", "Milan" }; */

/* Alternative syntax - passes an array of string values to AddRange method
List<string> cities = new();
cities.AddRange(new[] { "London", "Paris", "Milan" }); */

OutputCollection("Initial list", cities);
WriteLine($"The first city is {cities[0]}.");
WriteLine($"The last city is {cities[cities.Count - 1]}.");

cities.Insert(0, "Sydney");
OutputCollection("After inserting Sydney at index 0", cities);

cities.RemoveAt(1);
cities.Remove("Milan");
OutputCollection("After removing two cities", cities);

WriteLine();

// Declare dictionary without alias
// Dictionary<string, string> keywords = new();

// Using the alias
StringDictionary keywords = new();

keywords.Add(key: "int", value: "32-bit integer data type");
keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "Single precision floating point number");

/* Alternative syntax, compiler convers to Add method calls
Dictionary<string, string> = new()
{
    { "int", "32-bit integer data type" },
    { "long", "64-bit integer data type" },
    { "float", "Single precision floating point number" },
}; */

/* Alternative syntax, compiler converts to Add method calls
Dictionary<string, string> = new()
{
    ["int"] = "32-bit integer data type",
    ["long"] = "64-bit integer data type",
    ["float"] = "Single precision floating point number",
}; */

OutputCollection("Dictionary keys", keywords.Keys);
OutputCollection("Dictionary values", keywords.Values);

WriteLine("Keywords and their definitions:");
foreach (KeyValuePair<string, string> item in keywords)
{
    WriteLine($"  {item.Key}: {item.Value}");
}

// Look up value using key
string key = "long";
WriteLine($"The definition of {key} is {keywords[key]}");

WriteLine();

HashSet<string> names = new();

foreach (string name in new[] { "Adam", "Barry", "Charlie", "Barry" })
{
    bool added = names.Add(name);
    WriteLine($"{name} was added: {added}");
}

WriteLine($"names set: {string.Join(',', names)}.");
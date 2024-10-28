using System.Collections.Immutable; // For ImmutableDictionary<T, T>
using System.Collections.Frozen; // For FrozenDictionary<T, T>

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

WriteLine();

Queue<string> coffee = new();

coffee.Enqueue("Damir");
coffee.Enqueue("Andrea");
coffee.Enqueue("Ronald");
coffee.Enqueue("Amin");
coffee.Enqueue("Irina");

OutputCollection("Initial queue from front to back", coffee);

// Handle next person in queue
string served = coffee.Dequeue();
WriteLine($"Served: {served}");

served = coffee.Dequeue();
WriteLine($"Served: {served}");

OutputCollection("Current queue from front to back", coffee);
WriteLine($"{coffee.Peek()} is next in line");
OutputCollection("Current queue from front to back", coffee);

WriteLine();

PriorityQueue<string, int> vaccine = new();

// Add some people
// 1 = High priority people in their 70s or poor health
// 2 = Medium priority middle-aged
// 3 = Low priority teens and twenties
vaccine.Enqueue("Pamela", 1);
vaccine.Enqueue("Rebecca", 3);
vaccine.Enqueue("Juliet", 2);
vaccine.Enqueue("Ian", 1);

OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

WriteLine("Adding Mark to queue with priority 2.");
vaccine.Enqueue("Mark", 2);

WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine();
//UseDictionary(keywords);
//UseDictionary(keywords.AsReadOnly());
UseDictionary(keywords.ToImmutableDictionary());

ImmutableDictionary<string, string> immutableKeywords = keywords.ToImmutableDictionary();

ImmutableDictionary<string, string> newDictionary = immutableKeywords.Add(key: Guid.NewGuid().ToString(), value: Guid.NewGuid().ToString());

OutputCollection("Immutable keywords dictionary", immutableKeywords);
OutputCollection("New keywords dictionary", newDictionary);

WriteLine();

FrozenDictionary<string, string> frozenKeywords = keywords.ToFrozenDictionary();

OutputCollection("Frozen keywords dictionary", frozenKeywords);

WriteLine($"Define long: {frozenKeywords["long"]}");
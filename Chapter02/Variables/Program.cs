using System.Xml;

// Avoid these methods
// Object types
object height = 1.88; // store double in an object
object name = "Amir"; // store string in an object
Console.WriteLine($"{name} is {height} meters tall.");

//int length1 = name.Length; // error: object does not contain .Length
int length2 = ((string)name).Length; // cast name to a string
Console.WriteLine($"{name} has {length2} characters\n");

// Dynamic types
// Most useful when interoperating with non-.NET systems
dynamic something;

// Store array of int in dynamic object
// Array has length property
something = new[] { 3, 5, 7 };

// Store int in dynamic object
// Int does not have length property
something = 12;

// Store string in dynamic object
// String has length property (array of characters)
something = "Ahmed";

// Compiles but may throw exception at run time
Console.WriteLine($"The length of something is {something.Length}");
Console.WriteLine($"something is a {something.GetType()}\n");

// Local variables
int population = 67_000_000;
double weight = 1.88;
decimal price = 4.99M;
string fruit = "Apples";
char letter = 'Z';
bool happy = true;

// can use var to declare to infer variables with previous declarations

// Good use of var as to not repeat types
var xml1 = new XmlDocument();

XmlDocument xml2 = new XmlDocument();

// Bad use of var can not tell type
var file1 = File.CreateText("something1.txt");
// Better readability for previous declaration
StreamWriter file2 = File.CreateText("something2.txt");

// C# 9 and later
XmlDocument xml3 = new();

Person kim = new();
kim.BirthDate = new(1967, 12, 26); // new DateTime(1967, 12, 26)
kim.FirstName = "Kim";

List<Person> people = new()
{
    new() { FirstName = "Alice"},
    new() { FirstName = "Bob"},
    new() { FirstName = "Charlie"}
};

Console.WriteLine($"default(int) = {default(int)}");
Console.WriteLine($"default(bool) = {default(bool)}");
Console.WriteLine($"default(DateTime) = {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}\n");

int number = 13;
Console.WriteLine($"number set to: {number}");
number = default;
Console.WriteLine($"number reset to default: {number}\n");

class Person
{
    public DateTime BirthDate;
    public string FirstName;
}
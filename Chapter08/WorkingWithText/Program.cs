using System.Globalization; // For CultureInfo

OutputEncoding = System.Text.Encoding.UTF8; // Enable Euro symbol

string city = "London";
WriteLine($"{city} is {city.Length} characters long.");
WriteLine($"First char is {city[0]} and fourth is {city[3]}.");

WriteLine();

string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellin";

string[] citiesArray = cities.Split(',');

WriteLine($"There are {citiesArray.Length} items in the array:");

foreach (string item in citiesArray)
{
    WriteLine($"  {item}");
}

WriteLine();

string fullName = "Alan Shore";

int indexOfTheSpace = fullName.IndexOf(' ');

string firstName = fullName.Substring(
    startIndex: 0, length: indexOfTheSpace);

string lastName = fullName.Substring(
    startIndex: indexOfTheSpace);

WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");

lastName = lastName.Substring(
    startIndex: 1);

fullName = $"{lastName}, {firstName}";

int indexOfTheComma = fullName.IndexOf(',');

firstName = fullName.Substring(
    startIndex: indexOfTheComma + 1);

lastName = fullName.Substring(
    startIndex: 0, length: indexOfTheComma);

WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {firstName} {lastName}");

WriteLine();

string company = "Microsoft";
WriteLine($"Text: {company}");
WriteLine("Starts with M: {0}, contans an N: {1}",
    arg0: company.StartsWith("M"),
    arg1: company.Contains("N"));

WriteLine();

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

string text1 = "Mark";
string text2 = "MARK";

WriteLine($"text1: {text1}, text2: {text2}");

WriteLine("Compare: {0}.", string.Compare(text1, text2));

WriteLine("Compare (ignoreCase): {0}",
    string.Compare(text1, text2, ignoreCase: true));

WriteLine("Compare (InvariantCultureIgnoreCase): {0}.",
    string.Compare(text1, text2, StringComparison.InvariantCultureIgnoreCase));
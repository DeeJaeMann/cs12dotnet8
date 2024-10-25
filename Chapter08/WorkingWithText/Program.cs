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
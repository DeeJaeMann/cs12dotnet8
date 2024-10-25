using System.Text.RegularExpressions;

Write("Enter your age: ");
string input = ReadLine()!;
//Regex ageChecker = new(@"^\d+$");
//Regex ageChecker = new(DigitsOnlyText);
Regex ageChecker = DigitsOnly();
WriteLine(ageChecker.IsMatch(input) ? "Thank you!" :
    $"This is not a valid age: {input}");

WriteLine();

// C# 1 - 10: Escaped double-quote characters
// string films = "\"Monsters, Inc.\",\"I, Tonya\","Lock, Stock and Two Smoking Barrels\"";

// C# 11 or later: Use """ to start and end raw string literal
string films = """
"Monsters, Inc.","I, Tonya","Lock, Stock and Two Smoking Barrels"
""";

WriteLine($"Films to split: {films}");

string[] filmsDumb = films.Split(',');

WriteLine("Splitting with string.Split method:");
foreach (string film in filmsDumb)
{
    WriteLine($"  {film}");
}

/*
Regex csv = new(
    "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
*/
//Regex csv = new(CommaSeparatorText);
Regex csv = CommaSeparator();

MatchCollection filmsSmart = csv.Matches(films);

WriteLine("Splitting with regular expression:");
foreach (Match film in filmsSmart)
{
    WriteLine($"  {film.Groups[2].Value}");
}
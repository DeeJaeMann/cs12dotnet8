using System.Text.RegularExpressions;

Write("Enter your age: ");
string input = ReadLine()!;
Regex ageChecker = new(@"^\d+$");
WriteLine(ageChecker.IsMatch(input) ? "Thank you!" :
    $"This is not a valid age: {input}");


int numberOfApples = 12;
decimal pricePerApple = 0.3M;

Console.WriteLine(
    format: "{0} apples cost {1:C}",
    arg0: numberOfApples,
    arg1: pricePerApple * numberOfApples);

string formatted = string.Format(
    format: "{0} apples cost {1:C}",
    arg0: numberOfApples,
    arg1: pricePerApple * numberOfApples);

// Used to illustrate concept
//WriteToFile(formatted); // Writes the string to a file

// Three parameter valuses can use namded arguments
Console.WriteLine("{0} {1} lived in {2}.",
    arg0: "Roger", arg1: "Cevung", arg2: "Stockholm");

// Four or more parameter values cannot used named arguments
Console.WriteLine(
    "{0} {1} lived in {2} and worked in the {3} team at {4}.",
    "Roger", "Cevung", "Stockholm", "Education", "Optimizely");

// Formatting interpolated strings
// Must be all on one line if using C# 10 or earlier
// Otherwise can include line break in middle of expression but not in string text
Console.WriteLine($"{numberOfApples} apples cost {pricePerApple * numberOfApples:C}");

// Formatted strings with alignment
// { index [, alignment] [ : formatString ]}
string applesText = "Apples";
int applesCount = 1234;
string bananasText = "Bananas";
int bananasCount = 5678;

Console.WriteLine();
Console.WriteLine(format: "{0,-10} {1,6:N0}",
    arg0: "Name", arg1: "Count");

Console.WriteLine(format: "{0,-10} {1,6:N0}",
    arg0: applesText, arg1: applesCount);

Console.WriteLine(format: "{0,-10} {1,6:N0}",
    arg0: bananasText, arg1: bananasCount);

Console.WriteLine();

// Text input from user
Console.Write("Tyupe your first name and press Enter: ");
// adding ? allows possible null value
string? firstName = Console.ReadLine();

Console.Write("Type your age and press ENTER: ");
// ! null-forgiving operator ReadLine will not return null
// ReadLine always returns string even if empty
string age = Console.ReadLine()!;

Console.WriteLine($"Hello {firstName}, you look good for {age}.");
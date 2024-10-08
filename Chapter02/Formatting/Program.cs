//using static System.Console; // moved to global usings

int numberOfApples = 12;
decimal pricePerApple = 0.3M;

WriteLine(
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
WriteLine("{0} {1} lived in {2}.",
    arg0: "Roger", arg1: "Cevung", arg2: "Stockholm");

// Four or more parameter values cannot used named arguments
WriteLine(
    "{0} {1} lived in {2} and worked in the {3} team at {4}.",
    "Roger", "Cevung", "Stockholm", "Education", "Optimizely");

// Formatting interpolated strings
// Must be all on one line if using C# 10 or earlier
// Otherwise can include line break in middle of expression but not in string text
WriteLine($"{numberOfApples} apples cost {pricePerApple * numberOfApples:C}");

// Formatted strings with alignment
// { index [, alignment] [ : formatString ]}
string applesText = "Apples";
int applesCount = 1234;
string bananasText = "Bananas";
int bananasCount = 5678;

WriteLine();
WriteLine(format: "{0,-10} {1,6:N0}",
    arg0: "Name", arg1: "Count");

WriteLine(format: "{0,-10} {1,6:N0}",
    arg0: applesText, arg1: applesCount);

WriteLine(format: "{0,-10} {1,6:N0}",
    arg0: bananasText, arg1: bananasCount);

WriteLine();

// Text input from user
Write("Tyupe your first name and press Enter: ");
// adding ? allows possible null value
string? firstName = ReadLine();

Write("Type your age and press ENTER: ");
// ! null-forgiving operator ReadLine will not return null
// ReadLine always returns string even if empty
string age = ReadLine()!;

WriteLine($"Hello {firstName}, you look good for {age}.");

WriteLine();

Write("Press any key combination: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();
WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
    arg0: key.Key, arg1: key.KeyChar, arg2: key.Modifiers);
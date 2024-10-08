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
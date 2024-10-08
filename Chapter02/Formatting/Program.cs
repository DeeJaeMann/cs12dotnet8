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


WriteLine("Before parsing");
Write("What is your age? ");
string? input = ReadLine();

try
{
    int age = int.Parse(input!); // null-forgiving operator, input will not be null
    WriteLine($"You are {age} years old.");
}
// Empty catch block can safely complete program, however does not inform of exception
//catch
//{
//}
// Catch specific exceptions:
catch (OverflowException)
{
    WriteLine("Your age is a valid number format but it is either too big or small.");
}

catch (FormatException)
{
    WriteLine("The age you entered is not a valid number format.");
}

// Catches all exceptions:
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
WriteLine("After parsing");
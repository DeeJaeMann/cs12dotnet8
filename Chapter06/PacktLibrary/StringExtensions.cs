using System.Text.RegularExpressions;

namespace Packt.Shared;

public class StringExtensions
{
    public static bool IsValidEmail(string input)
    {
        return Regex.IsMatch(input,
            @"[a-zA-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
    }
}
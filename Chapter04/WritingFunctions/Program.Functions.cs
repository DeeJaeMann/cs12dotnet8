using System.Globalization; // For CultureInfo

partial class Program
{
    /// <summary>
    /// Outputs to console multiplication table.
    /// </summary>
    /// <param name="number">Number for base multiplier</param>
    /// <param name="size">Number of rows for table. Default is 12</param>
    static void TimesTable(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times table with {size} rows:");
        WriteLine();

        for (int row = 1; row <= size; row++)
        {
            WriteLine($"{row} x {number} = {row * number}");
        }
        WriteLine();
    }

    /// <summary>
    /// Calculates total sales tax given amount spent and region code
    /// </summary>
    /// <param name="amount">Amount spent</param>
    /// <param name="twoLetterRegionCode">Region Code</param>
    /// <returns></returns>
    static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
    {
        decimal rate = twoLetterRegionCode switch
        {
            "CH" => 0.08M, // Switzerland
            "DK" or "NO" => 0.2M, // Denmark, Norway
            "GB" or "FR" => 0.2M, // UK, France
            "HU" => 0.27M, // Hungry
            "OR" or "AK" or "MT" => 0.0M, // Oregon, Alaska, Montana
            "ND" or "WI" or "ME" or "VA" => 0.05M,
            "CA" => 0.0825M, // California
            _ => 0.06M // Most other states
        };

        return amount * rate;
    }

    /// <summary>
    /// Configures console locale
    /// </summary>
    /// <param name="culture">Culture to set</param>
    /// <param name="useComputerCulture">Use computer set culture</param>
    static void ConfigureConsole(string culture = "en-US", bool useComputerCulture = false)
    {
        // To enable Unicode characters like Euro symbol in console
        OutputEncoding = System.Text.Encoding.UTF8;

        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    /// <summary>
    /// Determines ordinal given number
    /// </summary>
    /// <param name="number">Number to determine</param>
    /// <returns></returns>
    static string CardinalToOrdinal(uint number)
    {
        uint lastTwoDigits = number % 100;

        switch (lastTwoDigits)
        {
            case 11: // Special cases for 11th to 13th
            case 12:
            case 13:
                return $"{number:N0}th";
            default:
                uint lastDigit = number % 10;
                string suffix = lastDigit switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th"
                };
                return $"{number:N0}{suffix}";
        }
    }

    /// <summary>
    /// Outputs to console ordinal numbers from 1 to 150
    /// </summary>
    static void RunCardinalToOrdinal()
    {
        for (uint number = 1; number <= 150; number++)
        {
            Write($"{CardinalToOrdinal(number)} ");
        }
        WriteLine();
    }

    /// <summary>
    /// Calculates factorial of given number
    /// </summary>
    /// <param name="number">Number to calculate</param>
    /// <returns>Factorial of number</returns>
    /// <exception cref="ArgumentOutOfRangeException">Negative numbers</exception>
    static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException(message:
                $"The factorial function is defined for non-negative integers only. Input {number}",
                paramName: nameof(number));
        }
        else if (number == 0)
        {
            return 1;
        }
        else
        {
            return number * Factorial(number - 1);
        }
    }

    /// <summary>
    /// Outputs to console factorial from 1! to 15!
    /// </summary>
    static void RunFactorial()
    {
        for (int i = 1; i <= 15; i++)
        {
            WriteLine($"{i}! = {Factorial(i):N0}");
        }
    }
}
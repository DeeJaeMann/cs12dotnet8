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
}
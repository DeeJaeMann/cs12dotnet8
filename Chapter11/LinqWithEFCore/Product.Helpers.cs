using System.Globalization; // For CultureInfo

partial class Program
{
    private static void ConfigureConsole(string culture = "en-US", bool useComputerCulture = false)
    {
        // To enable Unicode characters in the console
        OutputEncoding = System.Text.Encoding.UTF8;

        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    private static void SectionTitle(string title)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine(title);
        ForegroundColor = previousColor;
    }
}
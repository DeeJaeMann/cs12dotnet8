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
}
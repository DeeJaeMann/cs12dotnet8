uint naturalNumber = 23;
int integerNumber = -23;
float realNumber = 2.3f;
double anotherRealNumber = 2.3;

int decimalNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;

Console.WriteLine($"{decimalNotation == binaryNotation}");
Console.WriteLine(
    $"{decimalNotation == hexadecimalNotation}\n"
);

// Decimal output
Console.WriteLine($"{decimalNotation:N0}");
Console.WriteLine($"{binaryNotation:N0}");
Console.WriteLine($"{hexadecimalNotation:N0}\n");

// Hexadecimal output
Console.WriteLine($"{decimalNotation:X}");
Console.WriteLine($"{binaryNotation:X}");
Console.WriteLine($"{hexadecimalNotation:X}\n");

// Demonstrate number sizes
Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.\n");
Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range of {double.MinValue:N0} to {double.MaxValue:N0}.\n");
Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range of {decimal.MinValue:N0} to {decimal.MaxValue:N0}.\n");

// Comparisons
Console.WriteLine("Using doubles:");
// Only use double when accuracy is not important
// Good for GT or LT comparison but not equals
double a = 0.1;
double b = 0.2;
// Can not be compared
if (a + b == 0.3)
{
    Console.WriteLine($"{a} + {b} equals {0.3}");
}
else
{
    Console.WriteLine($"{a} + {b} does NOT equal {0.3}");
}

Console.WriteLine("Using decimals:");
// Use decimal when accuracy of real numbers are important
decimal c = 0.1M;
decimal d = 0.2M;

if (c + d == 0.3M)
{
    Console.WriteLine($"{c} + {d} equals {0.3M}.");
}
else
{
    Console.WriteLine($"{c} + {d} does NOT equal {0.3M}.");
}
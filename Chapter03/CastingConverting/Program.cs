using static System.Convert;

#region Casting

int a = 10;
double b = 1;
WriteLine($"a is {a}, b is {b}");

double c = 9.8;
int d = (int)c;
WriteLine($"c is {c}, d is {d}");

long e = 10; // 64 bit
int f = (int)e; // 32 bit
WriteLine($"e is {e:N0}, f is {f:N0}");

e = long.MaxValue;
f = (int)e; // Value is too large 
WriteLine($"e is {e:N0}, f is {f:N0}");

//e = long.MaxValue;
e = 5_000_000_000;
f = (int)e; // Causes int overflow
WriteLine($"e is {e:N0}, f is {f:N0}");

WriteLine();

WriteLine("{0,12} {1,34}", "Decimal", "Binary");
WriteLine("{0,12} {0,34:B32}", int.MaxValue);
for (int i = 8; i >= -8; i--)
{
    WriteLine("{0,12} {0,34:B32}", i);
}
WriteLine("{0,12} {0,34:B32}", int.MinValue);

#endregion
#region Converting numbers

WriteLine();

double g = 9.8;
int h = ToInt32(g); // Will round value
WriteLine($"g is {g}, h is {h}");

#endregion
#region Rounding

double[,] doubles = {
    {9.49,9.5,9.51},
    {10.49,10.5,10.51},
    {11.49,11.5,11.51},
    {12.49,12.5,12.51},
    {-12.49,-12.5,-12.51},
    {-11.49,-11.5,-11.51},
    {-10.49,-10.5,-10.51},
    {-9.49,-9.5,-9.51}
};

WriteLine();

WriteLine($"| double | ToIne32 | double | ToInt32 | double | ToInt32 |");
for (int x = 0; x < 8; x++)
{
    for (int y = 0; y < 3; y++)
    {
        Write($"| {doubles[x, y],6} | {ToInt32(doubles[x, y]),7} ");
    }
    WriteLine("|");
}
WriteLine();

foreach (double n in doubles)
{
    WriteLine(format:
    "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
    arg0: n,
    arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero));
}

#endregion
#region Convert to string

WriteLine();

int number = 12;
WriteLine(number.ToString());
bool boolean = true;
WriteLine(boolean.ToString());
DateTime now = DateTime.Now;
WriteLine(now.ToString());
object me = new();
WriteLine(me.ToString());

WriteLine();

// Allocate an array of 128 bytes
byte[] binaryObject = new byte[128];

// Populate array with random bytes
Random.Shared.NextBytes(binaryObject);

WriteLine("Bindary Object as bytes:");
for (int index = 0; index < binaryObject.Length; index++)
{
    Write($"{binaryObject[index]:X2} ");
}
WriteLine();

// Convert array to Base64 strting and output
string encoded = ToBase64String(binaryObject);
WriteLine($"Binary Object as Base64: {encoded}");

#endregion
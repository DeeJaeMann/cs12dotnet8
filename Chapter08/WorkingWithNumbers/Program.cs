using System.Numerics; // For BigInteger

const int width = 40;

WriteLine("ulong.MaxValue vs a 30-digit BigInteger");
WriteLine(new string('-', width));

ulong big = ulong.MaxValue;
WriteLine($"{big,width:N0}");

BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,width:N0}");

WriteLine();

Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 3, imaginary: 7);
Complex c3 = c1 + c2;

// Output using default ToString
WriteLine($"{c1} added to {c2} is {c3}");

// Output with custom format
WriteLine("{0} + {1}i added to {2} + {3}i is {4} + {5}i",
    c1.Real, c1.Imaginary,
    c2.Real, c2.Imaginary,
    c3.Real, c3.Imaginary);

WriteLine();

Random r = Random.Shared;

// minValue is inclusive lower bound
// maxValue is exclusive upper bound
int dieRoll = r.Next(minValue: 1, maxValue: 7);
WriteLine($"Random die roll: {dieRoll}");

double randomReal = r.NextDouble();
WriteLine($"Random double: {randomReal}");

byte[] arrayOfBytes = new byte[256];
r.NextBytes(arrayOfBytes);
Write("Random bytes: ");
for (int i = 0; i < arrayOfBytes.Length; i++)
{
    Write($"{arrayOfBytes[i]:X2} ");
}
WriteLine();
WriteLine();

string[] beatles = r.GetItems(
    choices: new[] { "John", "Paul", "George", "Ringo" },
    length: 10);

Write("Random ten beatles:");
foreach (string beatle in beatles)
{
    Write($" {beatle}");
}
WriteLine();

r.Shuffle(beatles);

Write("Shuffled beatles:");
foreach (string beatle in beatles)
{
    Write($" {beatle}");
}
WriteLine();
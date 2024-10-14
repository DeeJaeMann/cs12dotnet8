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
#region Converting

WriteLine();

double g = 9.8;
int h = ToInt32(g); // Will round value
WriteLine($"g is {g}, h is {h}");

#endregion
#region Rounding



#endregion
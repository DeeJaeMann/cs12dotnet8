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
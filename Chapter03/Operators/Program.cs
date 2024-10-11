#region Exploring unary operators

int a = 3;
int b = a++; // postfix operator - increment a after assignment
WriteLine($"a is {a}, b is {b}"); // a is 4, b is 3

int c = 3;
int d = ++c; // prefix operator - increment c before assignment
WriteLine($"c is {c}, d is {d}"); // c is 4, d is 4

#endregion

#region Binary operators

int e = 11;
int f = 3;

WriteLine($"e is {e}, f is {f}");
WriteLine($"e + f = {e + f}");
WriteLine($"e - f = {e - f}");
WriteLine($"e * f = {e * f}");
WriteLine($"e / f = {e / f}");
WriteLine($"e % f = {e % f}");

double g = 11.0;
WriteLine($"g is {g:N1}, f is {f}");
WriteLine($"g / f = {g / f}");

#endregion

#region Null-coalescing operators

Write("Enter an author name: ");
string? authorName = ReadLine();

// if authorName is null, Length is 30
int maxLength = authorName?.Length ?? 30;

authorName ??= "unknown";

WriteLine($"maxLength is {maxLength}");
WriteLine();

#endregion

#region Logical Operators

bool p = true;
bool q = false;

WriteLine($"AND\t| p\t| q");
WriteLine($"p\t| {p & q, -5}\t| {p & q, -5}");
WriteLine($"q\t| {q & p,-5}\t| {q & q, -5}");
WriteLine();
WriteLine($"OR\t| p\t| q");
WriteLine($"p\t| {p | p, -5}\t| {p | q, -5}");
WriteLine($"q\t| {q | p, -5}\t| {q | q, -5}");
WriteLine();
WriteLine($"XOR\t| p\t| q");
WriteLine($"p\t| {p ^ p, -5}\t| {p ^ q, -5}");
WriteLine($"q\t| {q ^ p,-5}\t| {q ^ q,-5}");

#endregion
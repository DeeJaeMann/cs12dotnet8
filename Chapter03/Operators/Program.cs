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

#region Conditional Logical Operators

WriteLine();
WriteLine($"p & DoStuff() = {p & DoStuff()}");
WriteLine($"q & DoStuff() = {q & DoStuff()}");
WriteLine();
WriteLine($"p && DoStuff() = {p && DoStuff()}");
WriteLine($"q && DoStuff() = {q && DoStuff()}"); // DoStuff() doesn't execute


#endregion

#region Bitwise and Binary Shift Operators

WriteLine();

int x = 10;
int y = 6;

WriteLine($"Expression\t| Decimal |   Binary");
WriteLine($"------------------------------------");
WriteLine($"x\t\t| {x,7} | {x:B8}");
WriteLine($"y\t\t| {y,7} | {y:B8}");
WriteLine($"x & y\t\t| {x & y,7} | {x & y:B8}");
WriteLine($"x | y\t\t| {x | y,7} | {x | y:B8}");
WriteLine($"x ^ y\t\t| {x ^ y,7} | {x | y:B8}");

// Left-shift x by 3 bit columns
// Faster than multiply by 8
WriteLine($"x << 3\t\t| {x << 3,7} | {x << 3:B8}");

// Multiply by 8
WriteLine($"x * 8\t\t| {x * 8,7} | {x * 8:B8}");

// Right-shift y by 1 bit column
WriteLine($"y >> 1\t\t| {y >> 1,7} | {y >> 1:B8}");

#endregion

#region Helper functions

static bool DoStuff()
{
    WriteLine("I am doing some stuff.");
    return true;
}

#endregion
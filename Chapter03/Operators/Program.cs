#region Exploring unary operators

int a = 3;
int b = a++; // postfix operator - increment a after assignment
WriteLine($"a is {a}, b is {b}"); // a is 4, b is 3

int c = 3;
int d = ++c; // prefix operator - increment c before assignment
WriteLine($"c is {c}, d is {d}"); // c is 4, d is 4

#endregion
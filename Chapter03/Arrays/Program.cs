#region Single Dimensional Arrays

string[] names;

names = new string[4];

names[0] = "Kate";
names[1] = "Jack";
names[2] = "Rebecca";
names[3] = "Tom";

for (int i = 0; i < names.Length; i++)
{
    WriteLine($"{names[i]} is at position {i}.");
}

string[] names2 = { "Kate", "Jack", "Rebecca", "Tom" };

for (int i = 0; i < names2.Length; i++)
{
    WriteLine($"{names2[i]} is at position {i}.");
}

#endregion
#region Multi-dimensional Arrays

string[,] grid1 =
{
    { "Alpha", "Beta", "Gamma", "Delta" },
    { "Anne", "Ben", "Charlie", "Doug" },
    { "Aardvark", "Bear", "Cat", "Dog" }
};

/* Alternate syntax:
 * string[,] grid2 = new string[3,4];
 * 
 * grid2[0,0] = "Alpha";
 * grid2[0,1] = "Beta";
 * ...
 * grid2[2,3] = "Dog";
 */

WriteLine($"1st dimension, lower bound: {grid1.GetLowerBound(0)}");
WriteLine($"1st dimension, upper bound: {grid1.GetUpperBound(0)}");
WriteLine($"2nd dimension, lower bound: {grid1.GetLowerBound(1)}");
WriteLine($"2nd dimension, upper bound: {grid1.GetUpperBound(1)}");

for (int row = 0; row <= grid1.GetUpperBound(0); row++)
{
    for (int col = 0; col <= grid1.GetUpperBound(1); col++)
    {
        WriteLine($"Row {row}, Column {col}: {grid1[row, col]}");
    }
}
#endregion
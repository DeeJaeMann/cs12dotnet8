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
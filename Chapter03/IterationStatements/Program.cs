#region While Loop
int x = 0;
while (x < 10)
{
    WriteLine(x);
    x++;
}

#endregion
#region Do Loop
/*
string? actualPassword = "Pa$$w0rd";
string? password;

do
{
    Write("Enter your password: ");
    password = ReadLine();
}
while (password != actualPassword);

WriteLine("Correct!");
*/
#endregion
#region For Loop

for (int y = 1; y <= 10; y++)
{
    WriteLine(y);
}

for (int y = 1; y <= 10; y += 3)
{
    WriteLine(y);
}

#endregion
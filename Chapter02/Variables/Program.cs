object height = 1.88; // store double in an object
object name = "Amir"; // store string in an object
Console.WriteLine($"{name} is {height} meters tall.");

//int length1 = name.Length; // error: object does not contain .Length
int length2 = ((string)name).Length; // cast name to a string
Console.WriteLine($"{name} has {length2} characters");
// Avoid these methods
// Object types
object height = 1.88; // store double in an object
object name = "Amir"; // store string in an object
Console.WriteLine($"{name} is {height} meters tall.");

//int length1 = name.Length; // error: object does not contain .Length
int length2 = ((string)name).Length; // cast name to a string
Console.WriteLine($"{name} has {length2} characters\n");

// Dynamic types
// Most useful when interoperating with non-.NET systems
dynamic something;

// Store array of int in dynamic object
// Array has length property
something = new[] { 3, 5, 7 };

// Store int in dynamic object
// Int does not have length property
something = 12;

// Store string in dynamic object
// String has length property (array of characters)
something = "Ahmed";

// Compiles but may throw exception at run time
Console.WriteLine($"The length of something is {something.Length}");
Console.WriteLine($"something is a {something.GetType()}");
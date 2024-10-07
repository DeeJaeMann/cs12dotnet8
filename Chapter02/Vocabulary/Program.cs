// See https://aka.ms/new-console-template for more information
//#error version
/*
Block to demonstrate updated global usings

Console.WriteLine("Hello, World!");

WriteLine($"Computer named {Env.MachineName} says \"No.\"");
*/

using System.Reflection; // To use Assembly, TypeName, etc.

// Get the assembly that is the entry point for thi sapp
Assembly? myApp = Assembly.GetEntryAssembly();

// If the previous line returned nothing then end the app
if (myApp is null) return;

// Loop through the assemblies that my app refrences
foreach (AssemblyName name in myApp.GetReferencedAssemblies())
{
    // Load the assembly to read it's details
    Assembly a = Assembly.Load(name);

    // To count number of methods
    int methodCount = 0;

    // Loop through all types in assembly
    foreach (TypeInfo t in a.DefinedTypes)
    {
        // Add counts of all methods
        methodCount += t.GetMethods().Length;
    }

    // Output count of types and methods
    WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.",
        arg0: a.DefinedTypes.Count(),
        arg1: methodCount,
        arg2: name.Name);
}
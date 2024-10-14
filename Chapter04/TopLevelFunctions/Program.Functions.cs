using static System.Console;

// Creating functions using this method merges them into automatically generated Program class
// at the same level as Main()

// Do NOT define a namespace here.
partial class Program
{
    static void WhatsMyNamespace()
    {
        WriteLine("Namespace of Program class: {0}",
        arg0: typeof(Program).Namespace ?? "null");
    }
}
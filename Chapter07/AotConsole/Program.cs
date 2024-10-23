using System.Globalization; // For CultureInfo
using System.Reflection; // For AssemblyName
using System.Reflection.Emit; // For AssemblyBuilder

// Cannot use this, will break during AoT Compilation
// Requires dynamic code
/*
AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(
    new AssemblyName("MyAssembly"), AssemblyBuilderAccess.Run);
*/

WriteLine("This is an ahead-of-time (AOT) compiled console app.");
WriteLine("Current culture: {0}", CultureInfo.CurrentCulture.DisplayName);
WriteLine("OS Version: {0}", Environment.OSVersion);

Write("Press any key to exit.");
ReadKey(intercept: true);
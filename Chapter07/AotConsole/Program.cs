using System.Globalization; // For CultureInfo

WriteLine("This is an ahead-of-time (AOT) compiled console app.");
WriteLine("Current culture: {0}", CultureInfo.CurrentCulture.DisplayName);
WriteLine("OS Version: {0}", Environment.OSVersion);

Write("Press any key to exit.");
ReadKey(intercept: true);
using Spectre.Console; // For Table

#region Handlind cross-platform environments and filesystems

SectionTitle("Handling cross-platform environments and filesystems");

// Create Spectre Console table
Table table = new();

// Add two columns with markup for colors
table.AddColumn("[blue]MEMBER[/]");
table.AddColumn("[blue]VALUE[/]");

// Add rows
table.AddRow("Path.pathSeparator", PathSeparator.ToString());
table.AddRow("Path.DirectorySeparatorChar", DirectorySeparatorChar.ToString());
table.AddRow("Directory.GetCurrentDirectory()", GetCurrentDirectory());
table.AddRow("Environment.GetCurrentDirectory", CurrentDirectory);
table.AddRow("Environment.SystemDirectory", SystemDirectory);
table.AddRow("");
table.AddRow("GetFolderPath(SpecialFolder", "");
table.AddRow("  .System)", GetFolderPath(SpecialFolder.System));
table.AddRow("  .ApplicationData)", GetFolderPath(SpecialFolder.ApplicationData));
table.AddRow("  .MyDocuments)", GetFolderPath(SpecialFolder.MyDocuments));
table.AddRow("  .Personal)", GetFolderPath(SpecialFolder.Personal));

// Render the table to the console
AnsiConsole.Write(table);

#endregion
using Spectre.Console; // For Table

#region Handling cross-platform environments and filesystems

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

WriteLine();

SectionTitle("Managing drives");

Table drives = new();

drives.AddColumn("[blue]NAME[/]");
drives.AddColumn("[blue]TYPE[/]");
drives.AddColumn("[blue]FORMAT[/]");
drives.AddColumn(new TableColumn(
    "[blue]SIZE (BYTES)[/]").RightAligned());
drives.AddColumn(new TableColumn(
    "[blue]FREE SPACE[/]").RightAligned());

foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    try
    {
        if (drive.IsReady)
        {
            drives.AddRow(drive.Name, drive.DriveType.ToString(),
                drive.DriveFormat, drive.TotalSize.ToString("N0"),
                drive.AvailableFreeSpace.ToString("N0"));
        }
        else
        {
            drives.AddRow(drive.Name, drive.DriveType.ToString(),
                string.Empty, string.Empty, string.Empty);
        }
    }
    catch (Exception e)
    {
        drives.AddRow(drive.Name, e.Message, string.Empty, string.Empty, string.Empty);
    }
}


AnsiConsole.Write(drives);

WriteLine();

SectionTitle("Managing directories");

string newFolder = Combine(
    GetFolderPath(SpecialFolder.Personal), "NewFolder");

WriteLine($"Working with: {newFolder}");

WriteLine($"Does it exist? {Path.Exists(newFolder)}");

WriteLine("Creating it...");
CreateDirectory(newFolder);

WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
Write("Confirm the directory exists, and then press any key.");
ReadKey(intercept: true);

WriteLine("Deleting it...");
Delete(newFolder, recursive: true);
WriteLine($"Does it exist? {Path.Exists(newFolder)}");

WriteLine();

SectionTitle("Managing files");

// Define dir path to output files starting in user's dir
string dir = Combine(
    GetFolderPath(SpecialFolder.Personal), "OutputFiles");

CreateDirectory(dir);

string textFile = Combine(dir, "Dummy.txt");
string backupFile = Combine(dir, "Dummy.bak");
WriteLine($"Working with: {textFile}");
WriteLine($"Does it exist? {File.Exists(textFile)}");

// Create new text file and write a line to it
StreamWriter textWriter = File.CreateText(textFile);
textWriter.WriteLine("Hello C#!");
textWriter.Close();
WriteLine($"Does it exist? {File.Exists(textFile)}");

// Copy file and overwrite if already exists
File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

Write("Confirm the file exists, and then press any key.");
ReadKey(intercept: true);

// Delete the file
File.Delete(textFile);
WriteLine($"Does it exist? {File.Exists(textFile)}");

// Read from text file backup
WriteLine($"Reading contents of {backupFile}:");
StreamReader textReader = File.OpenText(backupFile);
WriteLine(textReader.ReadToEnd());
textReader.Close();

WriteLine();

SectionTitle("Managing paths");

WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
WriteLine($"File Name: {GetFileName(textFile)}");
WriteLine("File Name without Extension: {0}",
    GetFileNameWithoutExtension(textFile));
WriteLine($"File Extension: {GetExtension(textFile)}");
WriteLine($"Random File Name: {GetRandomFileName()}");
WriteLine($"Temporary File Name: {GetTempFileName()}");

#endregion
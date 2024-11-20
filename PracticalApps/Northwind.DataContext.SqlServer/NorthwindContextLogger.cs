using static System.Environment;

namespace Northwind.EntityModels;

public class NorthwindContextLogger
{
    /// <summary>
    /// Appends string to end of text file named northwindlog.txt in Desktop Directory
    /// </summary>
    /// <param name="message">Message to append</param>
    public static void WriteLine(string message)
    {
        string path = Path.Combine(GetFolderPath(SpecialFolder.DesktopDirectory), "northwindlog.txt");

        StreamWriter textFile = File.AppendText(path);
        textFile.WriteLine(message);
        textFile.Close();
    }
}
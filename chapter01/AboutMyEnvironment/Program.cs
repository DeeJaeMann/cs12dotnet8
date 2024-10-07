namespace AboutMyEnvironment;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Environment.CurrentDirectory);
        Console.WriteLine(Environment.OSVersion.VersionString);
        Console.WriteLine($"Namespace: {typeof(Program).Namespace}");
    }
}

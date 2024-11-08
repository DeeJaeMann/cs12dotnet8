partial class Program
{
    private static void DeferredExecution(string[] names)
    {
        SectionTitle("Deferred execution");
        
        // Question: Which names end with an M?
        // (using a LINQ expression method)
        IEnumerable<string> query1 = names.Where(name => name.EndsWith('m'));
        
        // Question: Which names end with an M?
        // (using LINQ query comprehension syntax)
        IEnumerable<string> query2 = from name in names where name.EndsWith('m') select name;
        
        // Answer returned as an array of strings containing Pam and Jim
        string[] result1 = query1.ToArray();
        
        // Answer returned as a list of strings containing Pam and Jim
        List<string> result2 = query2.ToList();
        
        // Answer returned as we enumerate over the results
        foreach (string name in query1)
        {
            WriteLine(name); // > Pam
            names[2] = "Jimmy"; // Change Jim to Jimmy
            // On second iteration Jimmy does not end with M so it does not get output
        }
    }

    private static void FilteringUsingWhere(string[] names)
    {
        SectionTitle("Filtering entities using Where");

        // Explicitly creating the required delegate
        //var query = names.Where(new Func<string, bool>(NameLongerThanFour));
        
        // Compiler creates delegate automatically
        //var query = names.Where(NameLongerThanFour);
        
        // Using Lambda expression instead of named method
        IOrderedEnumerable<string> query = names
            .Where(name => name.Length > 4)
            .OrderBy(name => name.Length)
            .ThenBy(name => name);
        
        foreach (string item in query)
        {
            WriteLine(item);
        }
    }

    private static bool NameLongerThanFour(string name)
    {
        return name.Length > 4;
    }

    private static void FilteringByType()
    {
        SectionTitle("Filtering by type");

        List<Exception> exceptions = new()
        {
            new ArgumentException(), new SystemException(),
            new IndexOutOfRangeException(), new InvalidOperationException(),
            new NullReferenceException(), new InvalidCastException(),
            new OverflowException(), new DivideByZeroException(),
            new ApplicationException(),
        };
        
        IEnumerable<ArithmeticException> arithmeticExceptionsQuery = exceptions.OfType<ArithmeticException>();

        foreach (ArithmeticException exception in arithmeticExceptionsQuery)
        {
            WriteLine(exception);
        }
    }
}
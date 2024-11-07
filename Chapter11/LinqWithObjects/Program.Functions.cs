partial class Program
{
    private static void DeferredExecution(string[] names)
    {
        SectionTitle("Deferred execution");
        
        // Question: Which names end with an M?
        // (using a LINQ expression method)
        var query1 = names.Where(name => name.EndsWith('m'));
        
        // Question: Which names end with an M?
        // (using LINQ query comprehension syntax)
        var query2 = from name in names where name.EndsWith('m') select name;
        
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

        var query = names.Where(new Func<string, bool>(NameLongerThanFour));

        foreach (string item in query)
        {
            WriteLine(item);
        }
    }

    private static bool NameLongerThanFour(string name)
    {
        return name.Length > 4;
    }
}
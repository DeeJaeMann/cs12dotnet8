partial class Program
{
    private static void DeferredExecution(string[] names)
    {
        SectionTitle("Deferred execution");
        
        // Question: Which names end with an M?
        // (using a LINQ expression method)
        var query1 = names.Where(name => name.EndsWith("m"));
        
        // Question: Which names end with an M?
        // (using LINQ query comprehension syntax)
        var query2 = from name in names where name.EndsWith("m") select name;
    }
}
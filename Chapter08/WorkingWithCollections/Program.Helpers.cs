partial class Program
{
    private static void OutputCollection<T>(
        string title, IEnumerable<T> collection)
    {
        WriteLine($"{title}:");
        foreach (T item in collection)
        {
            WriteLine($"  {item}");
        }
    }

    private static void OutputPQ<TElement, TPriority>(
        string title, 
        IEnumerable<(TElement Element, TPriority Priority)> collection)
    {
        WriteLine($"{title}:");
        foreach ((TElement, TPriority) item in collection)
        {
            WriteLine($"  {item.Item1}: {item.Item2}");
        }
    }
}
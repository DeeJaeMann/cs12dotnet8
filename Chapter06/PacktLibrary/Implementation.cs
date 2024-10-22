namespace Packt.Shared;

// C# 1 and later
public interface INoImplementation
{
    // Must be implemented by derived type
    void Alpha();
}

// C# 8 and later
public interface ISsomeImplementation
{
    void Alpha();
    void Beta()
    {
        // Default implementation, can override
    }
}

// C# 1 and later
public abstract class PartiallyImplemented
{
    // must be implemented by derived type
    public abstract void Gamma();
    public virtual void Delta()
    {
        // Implementation
    }
}

public class FullyImplemented : PartiallyImplemented, ISsomeImplementation
{
    public void Alpha()
    {
        // Implementation
    }

    public override void Gamma()
    {
        // Implementation
    }
}

// can instantiate FullyImplemented class
// Cannot instantiate the child classes

// Preventing inheritance
public sealed class ScroogeMcDuck
{

}

// Prevent overriding further
public class Singer
{
    public virtual void Sing()
    {
        WriteLine("Singing...");
    }
}

public class LadyGaga : Singer
{
    // cannot override further
    public sealed override void Sing()
    {
        WriteLine("Singing with style...");
    }
}
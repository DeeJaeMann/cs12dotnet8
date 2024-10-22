namespace Packt.Shared;

public class PersonException : Exception
{
    // Constructors are not inerited
    // must declare and call base
    public PersonException() : base() {}
    public PersonException(string message) : base(message) {}
    public PersonException(string message, Exception innerException)
        : base(message, innerException) {}
}
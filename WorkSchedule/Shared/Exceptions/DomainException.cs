namespace Shared.Exceptions;

public class DomainException(string message) : Exception(message)
{
    public DomainException() : this(Strings.ErrorTitle)
    {
    }
}

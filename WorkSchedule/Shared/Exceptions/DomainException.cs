namespace Shared.Exceptions;

public class DomainException(string message) : Exception(message)
{
    public static void When(bool condition, string message = "")
    {
        if (condition)
            throw new DomainException(string.IsNullOrEmpty(message) ? Strings.ErrorTitle : message);
    }
}

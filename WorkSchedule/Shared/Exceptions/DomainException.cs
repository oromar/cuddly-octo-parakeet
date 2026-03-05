namespace Shared.Exceptions;

public class DomainException(string message) : Exception(message)
{
    public static void When(bool condition, string? message = null)
    {
        if (condition)
            throw new DomainException(message ?? Strings.ErrorTitle);
    }
}

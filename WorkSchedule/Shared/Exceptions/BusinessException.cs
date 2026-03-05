namespace Shared.Exceptions;

public class BusinessException(string message) : Exception(message)
{
    public static void When(bool condition, string? message = null)
    {
        if (condition)
            throw new BusinessException(message ?? Strings.ErrorTitle);
    }
}

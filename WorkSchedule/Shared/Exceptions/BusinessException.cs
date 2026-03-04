namespace Shared.Exceptions;

public class BusinessException(string message) : Exception(message)
{
    public static void When(bool condition, string message = "")
    {
        if (condition)
            throw new BusinessException(string.IsNullOrEmpty(message) ? Strings.ErrorTitle : message);
    }
}

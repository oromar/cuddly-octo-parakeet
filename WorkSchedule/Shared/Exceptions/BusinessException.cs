namespace Shared.Exceptions;

public class BusinessException(string message) : Exception(message)
{
    public static void When(bool condition, string? message = null)
    {
        if (condition)
            throw new BusinessException(message ?? Strings.ErrorTitle);
    }

    public static void WhenAny(Dictionary<Func<bool>, string> conditions)
    {
        foreach (var (condition, message) in conditions)
            if (condition?.Invoke() == true)
                throw new BusinessException(message ?? Strings.ErrorTitle);
    }
}

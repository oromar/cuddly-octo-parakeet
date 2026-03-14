namespace Shared.Exceptions;

public class BusinessException(string message) : Exception(message)
{
    public static void ThrowIf(bool condition, string? message = null)
    {
        if (condition)
            throw new BusinessException(message ?? Strings.ErrorTitle);
    }

    public static void ThrowIfAny(Dictionary<Func<bool>, string> scenarios)
    {
        foreach (var (condition, message) in scenarios)
            if (condition?.Invoke() == true)
                throw new BusinessException(message ?? Strings.ErrorTitle);
    }
}

namespace Shared.Exceptions;

public static class ExceptionHelper
{
    public static void ThrowIf<T>(bool condition, string? message = null) where T : Exception
    {
        if (condition)
            throw (T)Activator.CreateInstance(typeof(T), message)!;
    }

    public static void ThrowIfAny<T>(Dictionary<Func<bool>, string> scenarios) where T : Exception
    {
        foreach (var (condition, message) in scenarios)
            ThrowIf<T>(condition?.Invoke() == true, message);
    }
}

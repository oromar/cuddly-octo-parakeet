namespace Shared.Exceptions;

public class BusinessException(string message) : Exception(message)
{
    public BusinessException(): this(Strings.ErrorTitle)
    {
        
    }
}

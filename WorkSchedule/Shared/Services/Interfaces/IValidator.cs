namespace Shared.Services.Interfaces;

public interface IValidator<in T>
{
    public void Validate(T value);
}

public interface IValidator<in T, in E>
{
    public void Validate(T value1, E value2);
}

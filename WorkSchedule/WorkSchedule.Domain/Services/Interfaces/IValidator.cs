using System.ComponentModel.DataAnnotations;
using WorkSchedule.Domain.Models;

namespace WorkSchedule.Domain.Services.Interfaces
{
    public interface IValidator<T>
    {
        public void Validate(T value);
    }

    public interface IValidator<T, E>
    {
        public void Validate(T value1, E value2);
    }

    public interface IValidator<T, E, R>
    {
        public void Validate(T value1, E value2, R value3);
    }
}

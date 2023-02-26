using System.ComponentModel.DataAnnotations;
using WorkSchedule.Domain.Models;

namespace WorkSchedule.Domain.Services.Interfaces
{
    public interface IValidationService<T> where T : class
    {
        public void Validate(T value);
    }
}

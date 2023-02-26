using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Models;
using WorkSchedule.Domain.Services.Interfaces;

namespace WorkSchedule.Domain.Services
{
    public class RemotenessValidationService : IValidationService<Remoteness>
    {
        public void Validate(Remoteness entity)
        {
            if (entity.Start == default)
                throw new DomainException("Invalid Start");
            if (entity.End == default)
                throw new DomainException("Invalid End");
            if (entity.Cause == default)
                throw new DomainException("Invalid Cause");
            if (entity.Employee == null)
                throw new DomainException("Invalid Employee");
        }
    }
}

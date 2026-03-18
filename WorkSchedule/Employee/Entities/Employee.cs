using Employee.Contracts.DataTransferObjects;
using Employee.Validators;
using Shared.Common;
using Shared.Entities;

namespace Employee.Entities;

public class Employee : BaseEntity, ITextSearcheable
{
    private static readonly EmployeeValidator validator = new();

    public string Code { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public bool IsPriority { get; private set; } = false;
    public string SearchText { get; set; } = string.Empty;

    public Employee()
    {
        //EF 
    }

    public Employee(CreateEmployeeCommand command) : base()
    {
        Code = command.Code;
        Name = command.Name.ToUpper();
        IsPriority = command.IsPriority;
        validator.Validate(this);
    }

    public Employee Update(UpdateEmployeeCommand command)
    {
        Update();
        Code = command.Code;
        Name = command.Name.ToUpper();
        IsPriority = !command.NotFirstSchedule;
        validator.Validate(this);
        return this;
    }

    public void CreateSearchText()
    {
        SearchText = string.Join("|",
            Code.RemoveDiacritics(),
            Name.RemoveDiacritics())
            .ToLowerInvariant();
    }
}
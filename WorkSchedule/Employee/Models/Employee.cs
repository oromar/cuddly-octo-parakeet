using Employee.Validators;
using Shared.Common;
using Shared.Models;

namespace Employee.Models;

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

    public Employee(string name, string code, bool isPriority)
    {
        Code = code;
        Name = name.ToUpper();
        IsPriority = isPriority;
        validator.Validate(this);
    }

    public Employee Update(string name, string code, bool isPriority)
    {
        Code = code;
        Name = name.ToUpper();
        IsPriority = isPriority;
        ChangeLastUpdate();
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
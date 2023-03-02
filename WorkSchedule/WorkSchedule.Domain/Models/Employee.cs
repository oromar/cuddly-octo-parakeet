using WorkSchedule.Domain.Common;
using WorkSchedule.Domain.Services.Validators;

namespace WorkSchedule.Domain.Models
{
    public class Employee: BaseEntity, ITextSearcheable
    {
        private static readonly EmployeeValidator validator = new();

        public string Name { get; private set; }
        public string EmployeeCode { get; private set; }
        public bool FirstSchedule { get; private set; }
        public string SearchText { get; set; }

        public Employee()
        {
            
        }

        public Employee(string name, string code, bool firstSchedule)
        {
            Name = name.ToUpper();
            EmployeeCode = code;
            FirstSchedule = firstSchedule;
            validator.Validate(this);
        }

        public void Update(string name, string code, bool firstSchedule)
        {
            Name = name.ToUpper();
            EmployeeCode = code;
            FirstSchedule = firstSchedule;
            validator.Validate(this);
        }

        public void CreateSearchText()
        {
            SearchText = string.Join(" ", EmployeeCode.RemoveDiacritics(), Name.RemoveDiacritics());
        }
    }
}
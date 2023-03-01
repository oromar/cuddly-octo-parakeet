namespace WorkSchedule.Application.DataTransferObjects
{
    public class DateOnNotice
    {
        public DateTime Date { get; set; }
        public List<EmployeeOnNotice> Employees { get; set; }

        public DateOnNotice()
        {
            Employees = new List<EmployeeOnNotice>();
        }
    }
}

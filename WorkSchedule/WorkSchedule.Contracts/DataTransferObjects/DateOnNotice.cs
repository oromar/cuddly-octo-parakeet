namespace WorkSchedule.Contracts.DataTransferObjects;
public record DateOnNotice(DateTime Date, List<EmployeeOnNotice> Employees);

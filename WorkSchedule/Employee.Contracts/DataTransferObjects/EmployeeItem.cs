namespace Employee.Contracts.DataTransferObjects;
public record EmployeeItem(Guid Id, string Name, string Code, bool FirstSchedule, string CreationTime);

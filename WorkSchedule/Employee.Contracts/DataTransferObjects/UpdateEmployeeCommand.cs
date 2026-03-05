namespace Employee.Contracts.DataTransferObjects;
public record UpdateEmployeeCommand (string Code, string Name, bool NotFirstSchedule);
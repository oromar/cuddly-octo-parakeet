namespace Employee.Contracts.DataTransferObjects;
public record CreateEmployeeCommand(string Name, string Code, bool IsPriority);

using Absence.Contracts.Enums;
namespace Absence.Contracts.DataTransferObjects;
public record CreateAbsenceCommand(string EmployeeCode, DateTime Start, DateTime End, AbsenceCause Cause);
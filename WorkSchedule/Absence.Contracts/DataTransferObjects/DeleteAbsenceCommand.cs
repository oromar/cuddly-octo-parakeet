using Absence.Contracts.Enums;
namespace Absence.Contracts.DataTransferObjects;
public record DeleteAbsenceCommand(string EmployeeCode, DateTime Start, DateTime End, AbsenceCause Cause);
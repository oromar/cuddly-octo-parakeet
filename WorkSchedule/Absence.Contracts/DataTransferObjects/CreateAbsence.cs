using Absence.Contracts.Enums;
namespace Absence.Contracts.DataTransferObjects;
public record CreateAbsence(string EmployeeCode, DateTime Start, DateTime End, AbsenceCause Cause);
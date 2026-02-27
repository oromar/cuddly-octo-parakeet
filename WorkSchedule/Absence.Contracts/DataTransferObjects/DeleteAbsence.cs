using Absence.Contracts.Enums;
namespace Absence.Contracts.DataTransferObjects;
public record DeleteAbsence(string EmployeeCode, DateTime Start, DateTime End, AbsenceCause Cause);
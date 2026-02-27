using Absence.Contracts.Enums;
namespace Absence.Contracts.DataTransferObjects;
public record AbsenceItem(string EmployeeCode, string EmployeeName, string Start, String End, AbsenceCause Cause, string CreationTime);
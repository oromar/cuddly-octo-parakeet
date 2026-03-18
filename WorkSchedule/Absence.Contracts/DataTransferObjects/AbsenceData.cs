using Absence.Contracts.Enums;
namespace Absence.Contracts.DataTransferObjects;
public record AbsenceData
(
    string EmployeeCode, 
    string EmployeeName, 
    string Start, 
    string End, 
    AbsenceCause Cause, 
    string LastUpdate
);
namespace WorkSchedule.Contracts.DataTransferObjects;
public record GenerateScheduleCommand(DateTime Start, DateTime End, bool IncludeWeekends);

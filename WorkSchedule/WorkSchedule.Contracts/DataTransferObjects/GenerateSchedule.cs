namespace WorkSchedule.DataTransferObjects;
public record GenerateSchedule(DateTime Start, DateTime End, bool IncludeWeekends);

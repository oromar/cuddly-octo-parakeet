namespace Shared.Common;

public static class DateTimeExtensions
{
    public static string ToSchedule(this DateTime source)
    {
        return source.Date.ToString("s");
    }
}

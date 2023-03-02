namespace WorkSchedule.Application.DataTransferObjects
{
    public class PaginationDTO<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}

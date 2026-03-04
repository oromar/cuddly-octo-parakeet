namespace Shared.DataTransferObjects;
public record Pagination<T>(int Total, IEnumerable<T> Items);
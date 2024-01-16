namespace Core.DTO.Output;

public class PaginatedResult<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
}

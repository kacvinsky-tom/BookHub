namespace Core.DTO.Output;

public class PaginatedResult<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; }

    public int TotalPages { get; set; }

    public int Page { get; set; }
}

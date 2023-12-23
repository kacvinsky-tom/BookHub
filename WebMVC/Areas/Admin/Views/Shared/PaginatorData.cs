namespace WebMVC.Areas.Admin.Views.Shared;

public class PaginatorData
{
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public string ModelName { get; set; } = "";
}

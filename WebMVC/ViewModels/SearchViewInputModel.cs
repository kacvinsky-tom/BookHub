namespace WebMVC.ViewModels;

public class SearchViewInputModel
{
    private string _query = "";

    public string Query
    {
        get => _query;
        set => _query = value.ToUpper();
    }
}

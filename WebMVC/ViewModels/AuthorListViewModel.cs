using Core.DTO.Output;

namespace WebMVC.ViewModels;

public class AuthorListViewModel : OutputDtoBase
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
}

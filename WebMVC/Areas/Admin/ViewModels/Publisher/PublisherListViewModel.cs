using Core.DTO.Output;

namespace WebMVC.Areas.Admin.ViewModels.Publisher;

public class PublisherListViewModel: OutputDtoBase
{
    public string Name { get; set; } = "";

    public string State { get; set; } = "";
}
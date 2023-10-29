using DataAccessLayer.Entity;
using WebAPI.DTO.Input.Publisher;

namespace WebAPI.Services;

public class PublisherService
{
    public Publisher Create(PublisherInputDto publisherCreateInput)
    {
        var publisher = new Publisher
        {
            Name = publisherCreateInput.Name,
            Email = publisherCreateInput.Email,
            State = publisherCreateInput.State
        };

        return publisher;
    }
    
    public void Update(PublisherInputDto publisherUpdateInput, Publisher publisher)
    {
        publisher.Name = publisherUpdateInput.Name;
        publisher.State = publisherUpdateInput.State;
        publisher.Email = publisherUpdateInput.Email;
    }
}
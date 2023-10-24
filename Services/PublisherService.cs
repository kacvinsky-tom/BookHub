using BookHub.DataAccessLayer.Dtos.Input;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.Services;

public class PublisherService
{
    public Publisher Create(PublisherInputDto publisherCreateInput)
    {
        var publisher = new Publisher
        {
            Name = publisherCreateInput.Name,
            Email = publisherCreateInput.Email,
            Address = publisherCreateInput.Address
        };

        return publisher;
    }
    
    public void Update(PublisherInputDto publisherUpdateInput, Publisher publisher)
    {
        publisher.Name = publisherUpdateInput.Name;
        publisher.Address = publisherUpdateInput.Address;
        publisher.Email = publisherUpdateInput.Email;
    }
}
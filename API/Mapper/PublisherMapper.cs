using BookHub.DataAccessLayer.Dtos;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class PublisherMapper
{
    public static PublisherListOutputDto MapList(Publisher publisher)
    {
        return new PublisherListOutputDto()
        {
            Id = publisher.Id,
            Name = publisher.Name,
            Address = publisher.Address,
            Email = publisher.Email
        };
    }
    
    public static PublisherDetailOutputDto MapDetail(Publisher publisher)
    {
        return new PublisherDetailOutputDto()
        {
            Id = publisher.Id,
            Name = publisher.Name,
            Address = publisher.Address,
            Email = publisher.Email
        };
    }
}
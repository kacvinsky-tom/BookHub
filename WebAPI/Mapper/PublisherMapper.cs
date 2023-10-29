﻿using DataAccessLayer.Entity;
using WebAPI.DTO.Output.Publisher;

namespace WebAPI.Mapper;

public static class PublisherMapper
{
    public static PublisherListOutputDto MapList(Publisher publisher)
    {
        return new PublisherListOutputDto()
        {
            Id = publisher.Id,
            Name = publisher.Name,
        };
    }
    
    public static PublisherDetailOutputDto MapDetail(Publisher publisher)
    {
        return new PublisherDetailOutputDto()
        {
            Id = publisher.Id,
            Name = publisher.Name,
            State = publisher.State,
            Email = publisher.Email
        };
    }
}
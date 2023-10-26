using BookHub.API.DTO.Output;
using BookHub.DataAccessLayer.Dtos;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class OrderMapper
{
    public static OrderListOutputDto MapList(Order order)
    {
        return new OrderListOutputDto()
        {
            // TODO
        };
    }
    
    
}
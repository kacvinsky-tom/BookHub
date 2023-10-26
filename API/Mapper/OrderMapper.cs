using BookHub.API.DTO.Output;
using BookHub.API.DTO.Output.Order;
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
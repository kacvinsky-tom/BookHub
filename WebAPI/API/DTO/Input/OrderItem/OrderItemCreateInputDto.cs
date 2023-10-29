﻿using BookHub.API.DTO.Output;
using BookHub.API.DTO.Output.Order;

namespace BookHub.API.DTO.Input;

public class OrderItemCreateInputDto
{
    public int Quantity { get; set; }
    public int Price { get; set; }
    public int BookId { get; set; }
    public int OrderId { get; set; }
}
﻿using DataAccessLayer.Entity;

namespace WebMVC.Areas.Shop.ViewModel.Order;

public class OrderDetailViewModel
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string? OrderStatus { get; set; }
    public required IEnumerable<OrderItem> OrderedBooks { get; set; }
}
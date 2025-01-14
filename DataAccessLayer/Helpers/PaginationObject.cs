﻿namespace DataAccessLayer.Helpers;

public class PaginationObject<T>
{
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<T> Items { get; set; } = new List<T>();
}

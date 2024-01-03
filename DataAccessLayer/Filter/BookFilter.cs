﻿namespace DataAccessLayer.Filter;

public class BookFilter : IFilter
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? PriceFrom { get; set; }

    public int? PriceTo { get; set; }

    public IEnumerable<int>? GenreIds { get; set; }

    public string? AuthorName { get; set; }

    public string? PublisherName { get; set; }
}

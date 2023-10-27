﻿namespace BookHub.API.DTO.Output.Book;

public class BookListOutputDto : OutputDtoBase
{
    public string Title { get; set; }
    public int Price { get; set; }
    public int ReleaseYear { get; set; }
    // TODO Fill in AuthorDto and GenreDto collections after they are implemented
}
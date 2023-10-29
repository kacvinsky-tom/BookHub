using BookHub.API.DTO.Output;
using DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public class GenreMapper
{
    public static GenreListOutputDto MapList(Genre genre)
    {
        return new GenreListOutputDto()
        {
            Id = genre.Id,
            Name = genre.Name,
        };
    }
    
    public static GenreDetailOutputDto MapDetail(Genre genre)
    {
        return new GenreDetailOutputDto()
        {
            Id = genre.Id,
            Name = genre.Name,
            Books = genre.Books.Select(BookMapper.MapListWithoutAuthor).ToList()
        };
    }
}
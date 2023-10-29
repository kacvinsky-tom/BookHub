using DataAccessLayer.Entity;
using WebAPI.DTO.Output.Genre;

namespace WebAPI.Mapper;

public static class GenreMapper
{
    public static GenreListOutputDto MapList(Genre genre)
    {
        return new GenreListOutputDto
        {
            Id = genre.Id,
            Name = genre.Name,
        };
    }
    
    public static GenreDetailOutputDto MapDetail(Genre genre)
    {
        return new GenreDetailOutputDto
        {
            Id = genre.Id,
            Name = genre.Name,
            Books = genre.Books.Select(BookMapper.MapListWithoutAuthor).ToList()
        };
    }
}
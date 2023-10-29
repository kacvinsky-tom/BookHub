using DataAccessLayer.Entity;
using WebAPI.DTO.Output.Author;

namespace WebAPI.Mapper;

public static class AuthorMapper
{
    public static AuthorListOutputDto MapList(Author author)
    {
        return new AuthorListOutputDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName
        };
    }
    
    public static AuthorDetailOutputDto MapDetail(Author author)
    {
        return new AuthorDetailOutputDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Books = author.Books.Select(BookMapper.MapListWithoutAuthor).ToList()
        };
    }
}
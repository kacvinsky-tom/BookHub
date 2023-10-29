using DataAccessLayer;
using DataAccessLayer.Entity;
using WebAPI.DTO.Input.Author;

namespace WebAPI.Services;

public class AuthorService
{
    private readonly UnitOfWork _unitOfWork;
    
    public AuthorService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Author Create(AuthorInputDto authorInputDto)
    {
        var author = new Author
        {
            FirstName = authorInputDto.FirstName,
            LastName = authorInputDto.LastName,
        };
        
        return author;
    }
    
    public Author Update(AuthorInputDto authorInputDto, Author author)
    {
        author.FirstName = authorInputDto.FirstName;
        author.LastName = authorInputDto.LastName;
        return author;
    }
}
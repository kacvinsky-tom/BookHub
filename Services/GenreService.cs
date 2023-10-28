using BookHub.API.DTO.Input;
using BookHub.DataAccessLayer;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.Services;

public class GenreService
{
    private readonly UnitOfWork _unitOfWork;
    
    public GenreService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Genre Create(GenreInputDto genreInputDto)
    {
        var genre = new Genre
        {
            Name = genreInputDto.Name,
        };
        
        return genre;
    }
    
    public Genre Update(GenreInputDto genreInputDto, Genre genre)
    {
        genre.Name = genreInputDto.Name;
        return genre;
    }
}
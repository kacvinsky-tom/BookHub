using BookHub.API.DTO.Input;
using DataAccessLayer.Entity;

namespace BookHub.Services;

public class GenreService
{
    public Genre Create(GenreInputDto genreInputDto)
    {
        var genre = new Genre
        {
            Name = genreInputDto.Name,
        };
        
        return genre;
    }
    
    public void Update(GenreInputDto genreInputDto, Genre genre)
    {
        genre.Name = genreInputDto.Name;
    }
}
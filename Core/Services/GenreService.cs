using Core.DTO.Input.Genre;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;

namespace Core.Services;

public class GenreService
{
    private readonly UnitOfWork _unitOfWork;

    public GenreService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Genre>> GetAll()
    {
        return await _unitOfWork.Genres.GetAll();
    }

    public async Task<Genre?> GetById(int id)
    {
        return await _unitOfWork.Genres.GetByIdWithRelations(id);
    }

    public async Task<Genre> Create(GenreInputDto genreInputDto)
    {
        var genre = new Genre { Name = genreInputDto.Name, };

        await _unitOfWork.Genres.Add(genre);
        await _unitOfWork.Complete();

        return genre;
    }

    public async Task<Genre> Update(GenreInputDto genreInputDto, int id)
    {
        var genre = await _unitOfWork.Genres.GetById(id);

        if (genre == null)
        {
            throw new EntityNotFoundException<Genre>(id);
        }

        genre.Name = genreInputDto.Name;

        await _unitOfWork.Complete();

        return genre;
    }

    public async Task Delete(int genreId)
    {
        var genre = await _unitOfWork.Genres.GetById(genreId);

        if (genre == null)
        {
            throw new EntityNotFoundException<Genre>(genreId);
        }

        _unitOfWork.Genres.Remove(genre);

        await _unitOfWork.Complete();
    }
}

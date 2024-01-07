using System.Linq.Expressions;
using AutoMapper;
using Core.DTO.Input.Genre;
using Core.DTO.Input.Search;
using Core.DTO.Output;
using Core.DTO.Output.Genre;
using Core.Exception;
using Core.Helpers;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;

namespace Core.Services;

public class GenreService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenreService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Genre>> GetAll(
        IEnumerable<Ordering<Genre>>? orderingExpressions = null
    )
    {
        if (orderingExpressions != null)
        {
            return await _unitOfWork.Genres.GetAllOrdered(orderingExpressions);
        }
        return await _unitOfWork.Genres.GetAll();
    }

    public async Task<Genre?> GetById(int id)
    {
        return await _unitOfWork.Genres.GetByIdWithRelations(id);
    }

    public async Task<PaginationObject<Genre>> GetAllPaginated(
        int page,
        int pageSize,
        Expression<Func<Genre, IComparable>>? orderingExpression = null,
        bool reverseOrder = false
    )
    {
        return await _unitOfWork.Genres.GetPaginated(
            page,
            pageSize,
            orderingExpression ?? (g => g.Name),
            reverseOrder
        );
    }

    public async Task<PaginatedResult<GenreListOutputDto>> Search(
        SearchQueryInputDto searchQuery,
        int page,
        int pageSize
    )
    {
        var paginatedGenresQuery = await _unitOfWork.Genres.GetPaginatedBySearchQuery(
            searchQuery.Query,
            page,
            pageSize
        );

        return new PaginatedResult<GenreListOutputDto>
        {
            Items = paginatedGenresQuery.Items.Select(_mapper.Map<GenreListOutputDto>),
            TotalCount = paginatedGenresQuery.TotalItems
        };
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

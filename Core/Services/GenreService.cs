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
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Services;

public class GenreService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public GenreService(UnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<Genre>> GetAll(
        IEnumerable<Ordering<Genre>>? orderingExpressions = null
    )
    {
        if (orderingExpressions != null)
        {
            return await _unitOfWork.Genres.GetAll(orderingExpressions: orderingExpressions);
        }
        return await _unitOfWork.Genres.GetAll();
    }

    public async Task<Genre?> GetById(int id)
    {
        if (_memoryCache.TryGetValue("genre-" + id, out Genre? cachedGenre))
        {
            return cachedGenre;
        }
        
        var genre = await _unitOfWork.Genres.GetByIdWithRelations(id);

        if (genre != null)
        {
            _memoryCache.Set("genre-" + id, genre);
        }
        
        return genre;
    }

    public async Task<PaginationObject<Genre>> GetAllPaginated(
        int page,
        int pageSize,
        Expression<Func<Genre, IComparable>>? orderingExpression = null,
        bool reverseOrder = false
    )
    {
        var ordering = new Ordering<Genre>
        {
            Expression = orderingExpression ?? (g => g.Name),
            Reverse = reverseOrder
        };

        return await _unitOfWork.Genres.GetAllPaginated(page, pageSize, order: new[] { ordering });
    }

    public async Task<PaginatedResult<GenreListOutputDto>> Search(
        SearchQueryInputDto searchQuery,
        int page,
        int pageSize
    )
    {
        var genreFilter = new GenreFilter { Name = searchQuery.Query };

        var paginatedGenresQuery = await _unitOfWork.Genres.GetAllPaginated(
            page,
            pageSize,
            genreFilter
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

        _memoryCache.Set("genre-" + id, genre);

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
        
        _memoryCache.Remove("genre-" + genreId);
    }
}

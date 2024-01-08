using System.Linq.Expressions;
using AutoMapper;
using Core.DTO.Input.Author;
using Core.DTO.Input.Search;
using Core.DTO.Output;
using Core.DTO.Output.Author;
using Core.Exception;
using Core.Helpers;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Services;

public class AuthorService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public AuthorService(UnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<Author>> GetAll(
        IEnumerable<Ordering<Author>>? orderingExpressions = null
    )
    {
        if (orderingExpressions != null)
        {
            return await _unitOfWork.Authors.GetAll(orderingExpressions: orderingExpressions);
        }
        return await _unitOfWork.Authors.GetAll();
    }

    public async Task<PaginationObject<Author>> GetAllPaginated(
        int page,
        int pageSize,
        Expression<Func<Author, IComparable>>? orderingExpression = null,
        bool reverseOrder = false
    )
    {
        var ordering = new Ordering<Author>
        {
            Expression = orderingExpression ?? (a => a.LastName + a.FirstName),
            Reverse = reverseOrder
        };

        return await _unitOfWork.Authors.GetAllPaginated(page, pageSize, order: new[] { ordering });
    }

    public async Task<Author?> GetById(int id)
    {
        if (_memoryCache.TryGetValue("author-" + id, out Author? cachedAuthor))
        {
            return cachedAuthor;
        }

        var author = await _unitOfWork.Authors.GetByIdWithRelations(id);

        if (author != null)
        {
            _memoryCache.Set("author-" + id, author);
        }

        return author;
    }

    public async Task<PaginatedResult<AuthorListOutputDto>> Search(
        SearchQueryInputDto searchQuery,
        int page,
        int pageSize
    )
    {
        var authorFilter = new AuthorFilter { Name = searchQuery.Query };

        var paginatedAuthorsQuery = await _unitOfWork.Authors.GetAllPaginated(
            page,
            pageSize,
            authorFilter
        );

        return new PaginatedResult<AuthorListOutputDto>
        {
            Items = paginatedAuthorsQuery.Items.Select(_mapper.Map<AuthorListOutputDto>),
            TotalCount = paginatedAuthorsQuery.TotalItems
        };
    }

    public async Task<Author> Create(AuthorInputDto authorInputDto)
    {
        var author = new Author
        {
            FirstName = authorInputDto.FirstName,
            LastName = authorInputDto.LastName,
        };

        await _unitOfWork.Authors.Add(author);

        await _unitOfWork.Complete();

        return author;
    }

    public async Task<Author> Update(AuthorInputDto authorInputDto, int authorId)
    {
        var author = await _unitOfWork.Authors.GetById(authorId);

        if (author == null)
        {
            throw new EntityNotFoundException<Author>(authorId);
        }

        author.FirstName = authorInputDto.FirstName;
        author.LastName = authorInputDto.LastName;

        await _unitOfWork.Complete();

        _memoryCache.Set("author-" + authorId, author);

        return author;
    }

    public async Task Delete(int authorId)
    {
        var author = await _unitOfWork.Authors.GetById(authorId);

        if (author == null)
        {
            throw new EntityNotFoundException<Author>(authorId);
        }

        _unitOfWork.Authors.Remove(author);

        await _unitOfWork.Complete();

        _memoryCache.Remove("author-" + authorId);
    }
}

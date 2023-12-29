using System.Linq.Expressions;
using Core.DTO.Input.Author;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;

namespace Core.Services;

public class AuthorService
{
    private readonly UnitOfWork _unitOfWork;

    public AuthorService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _unitOfWork.Authors.GetAll();
    }

    public async Task<PaginationObject<Author>> GetAllPaginated(
        int page,
        int pageSize,
        Expression<Func<Author, IComparable>>? orderingExpression = null,
        bool reverseOrder = false
    )
    {
        return await _unitOfWork.Authors.GetPaginated(
            page,
            pageSize,
            orderingExpression ?? (a => a.LastName + a.FirstName),
            reverseOrder
        );
    }

    public async Task<Author?> GetById(int id)
    {
        return await _unitOfWork.Authors.GetByIdWithRelations(id);
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
    }
}

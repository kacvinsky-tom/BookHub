using System.Linq.Expressions;
using Core.DTO.Input.Publisher;
using Core.Exception;
using Core.Helpers;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;

namespace Core.Services;

public class PublisherService
{
    private readonly UnitOfWork _unitOfWork;

    public PublisherService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Publisher>> GetAll(
        IEnumerable<Ordering<Publisher>>? orderingExpressions = null
    )
    {
        if (orderingExpressions != null)
        {
            return await _unitOfWork.Publishers.GetAll(orderingExpressions: orderingExpressions);
        }

        return await _unitOfWork.Publishers.GetAll();
    }

    public async Task<Publisher?> GetById(int id)
    {
        return await _unitOfWork.Publishers.GetById(id);
    }

    public async Task<PaginationObject<Publisher>> GetAllPaginated(
        int page,
        int pageSize,
        Expression<Func<Publisher, IComparable>>? orderingExpression = null,
        bool reverseOrder = false
    )
    {
        var ordering = new Ordering<Publisher>
        {
            Expression = orderingExpression ?? (p => p.Name),
            Reverse = reverseOrder
        };

        return await _unitOfWork.Publishers.GetAllPaginated(
            page,
            pageSize,
            order: new [] { ordering });
    }

    public async Task<Publisher> Create(PublisherInputDto publisherCreateInput)
    {
        var publisher = new Publisher
        {
            Name = publisherCreateInput.Name,
            Email = publisherCreateInput.Email,
            State = publisherCreateInput.State
        };

        await _unitOfWork.Publishers.Add(publisher);

        await _unitOfWork.Complete();

        return publisher;
    }

    public async Task<Publisher> Update(PublisherInputDto publisherUpdateInput, int publisherId)
    {
        var publisher = await _unitOfWork.Publishers.GetById(publisherId);

        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(publisherId);
        }

        publisher.Name = publisherUpdateInput.Name;
        publisher.State = publisherUpdateInput.State;
        publisher.Email = publisherUpdateInput.Email;

        await _unitOfWork.Complete();

        return publisher;
    }

    public async Task Delete(int publisherId)
    {
        var publisher = await _unitOfWork.Publishers.GetById(publisherId);

        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(publisherId);
        }

        _unitOfWork.Publishers.Remove(publisher);

        await _unitOfWork.Complete();
    }
}

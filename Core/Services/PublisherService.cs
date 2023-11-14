using Core.DTO.Input.Publisher;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;

namespace Core.Services;

public class PublisherService
{
    private readonly UnitOfWork _unitOfWork;

    public PublisherService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Publisher>> GetAll()
    {
        return await _unitOfWork.Publishers.GetAll();
    }

    public async Task<Publisher?> GetById(int id)
    {
        return await _unitOfWork.Publishers.GetById(id);
    }
    
    public async Task<Publisher> Create(PublisherInputDto publisherCreateInput)
    {
        var publisher = new Publisher
        {
            Name = publisherCreateInput.Name,
            Email = publisherCreateInput.Email,
            State = publisherCreateInput.State
        };

        _unitOfWork.Publishers.Add(publisher);

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
using BookHub.API.DTO.Input.Publisher;
using BookHub.API.Mapper;
using BookHub.DataAccessLayer;
using BookHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly PublisherService _publisherService;

    public PublisherController(UnitOfWork unitOfWork, PublisherService publisherService)
    {
        _unitOfWork = unitOfWork;
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var publishers = await _unitOfWork.Publishers.GetAll();

        return Ok(publishers.Select(PublisherMapper.MapList));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var publisher = await _unitOfWork.Publishers.GetById(id);

        if (publisher == null)
        {
          return NotFound();
        }

        return Ok(PublisherMapper.MapDetail(publisher));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PublisherInputDto publisherInputDto)
    {
        var publisher = _publisherService.Create(publisherInputDto);
        _unitOfWork.Publishers.Add(publisher);
        await _unitOfWork.Complete();
        return Ok(PublisherMapper.MapDetail(publisher));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PublisherInputDto publisherInputDto)
    {
        var publisher = await _unitOfWork.Publishers.GetById(id);

        if (publisher == null)
        {
          return NotFound();
        }
          
        _publisherService.Update(publisherInputDto, publisher);
        await _unitOfWork.Complete();
        return Ok(PublisherMapper.MapDetail(publisher));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var publisher = await _unitOfWork.Publishers.GetById(id);

        if (publisher == null)
        {
          return NotFound();
        }

        _unitOfWork.Publishers.Remove(publisher);

        await _unitOfWork.Complete();

        return Ok();
    }

}
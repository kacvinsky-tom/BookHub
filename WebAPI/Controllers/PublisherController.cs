using AutoMapper;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.Publisher;
using WebAPI.DTO.Output.Publisher;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly PublisherService _publisherService;
    private readonly IMapper _mapper;

    public PublisherController(UnitOfWork unitOfWork, PublisherService publisherService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _publisherService = publisherService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var publishers = await _unitOfWork.Publishers.GetAll();

        return Ok(publishers.Select(_mapper.Map<PublisherListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var publisher = await _unitOfWork.Publishers.GetById(id);

        if (publisher == null)
        {
          return NotFound();
        }

        return Ok(_mapper.Map<PublisherDetailOutputDto>(publisher));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PublisherInputDto publisherInputDto)
    {
        var publisher = _publisherService.Create(publisherInputDto);
        _unitOfWork.Publishers.Add(publisher);
        await _unitOfWork.Complete();
        return Ok(_mapper.Map<PublisherDetailOutputDto>(publisher));
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
        return Ok(_mapper.Map<PublisherDetailOutputDto>(publisher));
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
using AutoMapper;
using Core.DTO.Input.Publisher;
using Core.DTO.Output.Publisher;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController : ControllerBase
{
    private readonly PublisherService _publisherService;
    private readonly IMapper _mapper;

    public PublisherController(PublisherService publisherService, IMapper mapper)
    {
        _publisherService = publisherService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> FetchPaginated(int page, int pageSize)
    {
        var publishers = (await _publisherService.GetAllPaginated(page, pageSize)).Items;

        var publisherListDto = publishers.Select(_mapper.Map<PublisherListOutputDto>);

        return Ok(publisherListDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var publisher = await _publisherService.GetById(id);

        if (publisher == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PublisherDetailOutputDto>(publisher));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PublisherInputDto publisherInputDto)
    {
        var publisher = await _publisherService.Create(publisherInputDto);

        return Ok(_mapper.Map<PublisherDetailOutputDto>(publisher));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PublisherInputDto publisherInputDto)
    {
        try
        {
            var publisher = await _publisherService.Update(publisherInputDto, id);

            return Ok(_mapper.Map<PublisherDetailOutputDto>(publisher));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _publisherService.Delete(id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}

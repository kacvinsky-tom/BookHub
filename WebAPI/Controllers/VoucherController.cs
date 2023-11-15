using AutoMapper;
using Core.DTO.Input.Voucher;
using Core.DTO.Output.Voucher;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VoucherController : ControllerBase
{
    private readonly VoucherService _voucherService;
    private readonly IMapper _mapper;

    public VoucherController(VoucherService voucherService, IMapper mapper)
    {
        _voucherService = voucherService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var vouchers = await _voucherService.GetAll();

        return Ok(vouchers.Select(_mapper.Map<VoucherListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var voucher = await _voucherService.GetById(id);
        
        if (voucher == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<VoucherDetailOutputDto>(voucher));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VoucherInputDto voucherInputDto)
    {
        var voucher = await _voucherService.Create(voucherInputDto);

        return Ok(_mapper.Map<VoucherDetailOutputDto>(voucher));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] VoucherInputDto voucherInputDto)
    {
        try
        {
            var voucher = await _voucherService.Update(voucherInputDto, id);
        
            return Ok(_mapper.Map<VoucherDetailOutputDto>(voucher));
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
            await _voucherService.Delete(id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}
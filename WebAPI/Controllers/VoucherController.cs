using AutoMapper;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.Voucher;
using WebAPI.DTO.Output.Voucher;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VoucherController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly VoucherService _voucherService;
    private readonly IMapper _mapper;

    public VoucherController(UnitOfWork unitOfWork, VoucherService voucherService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _voucherService = voucherService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var vouchers = await _unitOfWork.Vouchers.GetAll();
        
        return Ok(vouchers.Select(_mapper.Map<VoucherListOutputDto>));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var voucher = await _unitOfWork.Vouchers.GetById(id);
        
        if (voucher == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<VoucherDetailOutputDto>(voucher));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VoucherInputDto voucherInputDto)
    {
        var voucher = _voucherService.Create(voucherInputDto);
        
        _unitOfWork.Vouchers.Add(voucher);

        await _unitOfWork.Complete();

        return Ok(_mapper.Map<VoucherDetailOutputDto>(voucher));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] VoucherInputDto voucherInputDto)
    {
        var voucher = await _unitOfWork.Vouchers.GetById(id);
        
        if (voucher == null)
        {
            return NotFound();
        }

        _voucherService.Update(voucher, voucherInputDto);
        
        await _unitOfWork.Complete();

        return Ok(_mapper.Map<VoucherDetailOutputDto>(voucher));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var voucher = await _unitOfWork.Vouchers.GetById(id);
        
        if (voucher == null)
        {
            return NotFound();
        }

        _unitOfWork.Vouchers.Remove(voucher);
        
        await _unitOfWork.Complete();

        return Ok();
    }
}
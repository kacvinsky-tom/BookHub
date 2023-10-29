using BookHub.API.DTO.Input;
using BookHub.API.Mapper;
using BookHub.Services;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VoucherController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly VoucherService _voucherService;
    
    public VoucherController(UnitOfWork unitOfWork, VoucherService voucherService)
    {
        _unitOfWork = unitOfWork;
        _voucherService = voucherService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var vouchers = await _unitOfWork.Vouchers.GetAll();
        
        return Ok(vouchers.Select(VoucherMapper.MapList));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var voucher = await _unitOfWork.Vouchers.GetById(id);
        
        if (voucher == null)
        {
            return NotFound();
        }

        return Ok(VoucherMapper.MapDetail(voucher));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VoucherInputDto voucherInputDto)
    {
        var voucher = _voucherService.Create(voucherInputDto);
        
        _unitOfWork.Vouchers.Add(voucher);

        await _unitOfWork.Complete();

        return Ok(VoucherMapper.MapDetail(voucher));
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

        return Ok(VoucherMapper.MapDetail(voucher));
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
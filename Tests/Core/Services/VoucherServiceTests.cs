using System.Runtime.InteropServices.JavaScript;
using Core.DTO.Input.Voucher;
using Core.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class VoucherServiceTests
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;
    private readonly BookHubDbContext _mockedContext;

    public VoucherServiceTests(){
        var options = MockedDbContext.GenerateNewInMemoryDbContextOptions();
        _mockedContext = MockedDbContext.CreateFromOptions(options);
        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
                .AddUnitOfWork()
                .AddAutoMapper()
                .AddRepositories()
                .AddServices()
                .AddMockedDbContext()
            ;
    }
    
    [Fact]
    public async Task GetAll_NonEmptyVouchers_ReturnsVoucherDTOs()
    {
        // Arrange
        var vouchers = VouchersTestData.GetFakeVouchers();
        var vouchersIds = vouchers
            .Select(v => v.Id)
            .ToList();

        var serviceProvider = _serviceProviderBuilder
            .AddScoped(_mockedContext)
            .Create();

        using var scope = serviceProvider.CreateScope();
        var voucherService = scope.ServiceProvider.GetRequiredService<VoucherService>();

        // Act
        var result = await voucherService.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(vouchers.Count, result.Count());
        Assert.All(result, voucherSummary => Assert.Contains(voucherSummary.Id, vouchersIds));
    }
    
    [Fact]
    public async Task GetById_ExistingVoucherId_ReturnsVoucherDTO()
    {
        // Arrange
        var existingVoucherId = VouchersTestData
            .GetFakeVouchers()
            .First()
            .Id;

        var serviceProvider = _serviceProviderBuilder
            .AddScoped(_mockedContext)
            .Create();

        using var scope = serviceProvider.CreateScope();
        var voucherService = scope.ServiceProvider.GetRequiredService<VoucherService>();

        // Act
        var result = await voucherService.GetById(existingVoucherId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(existingVoucherId, result.Id);
    }
    
    [Fact]
    public async Task GetById_NonExistingVoucherId_ReturnsNull()
    {
        
        // Arrange
        var fakeVouchers = VouchersTestData
            .GetFakeVouchers();
        
        var nonExistingVoucherId = FindNonExistingVoucherId(fakeVouchers);
        
        var serviceProvider = _serviceProviderBuilder
            .AddScoped(_mockedContext)
            .Create();

        using var scope = serviceProvider.CreateScope();
        var voucherService = scope.ServiceProvider.GetRequiredService<VoucherService>();

        // Act
        var result = await voucherService.GetById(nonExistingVoucherId);

        // Assert
        Assert.Null(result);
    }

    private static int FindNonExistingVoucherId(List<Voucher> fakeVouchers)
    {
        var nonExistingVoucherId = new Random().Next(int.MinValue, int.MaxValue);

        while (fakeVouchers.Any(v => v.Id == nonExistingVoucherId))
        {
            nonExistingVoucherId = new Random().Next(int.MinValue, int.MaxValue);
        }

        return nonExistingVoucherId;
    }

    [Fact]
    public async Task Create_ValidInput_ReturnsVoucher()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder
            .AddScoped(_mockedContext)
            .Create();
        var uniqueCode = $"Test_{Guid.NewGuid()}";
        var inputDto = new VoucherInputDto
        {
            Code = uniqueCode,
            Discount = 20,
            ExpirationDate = DateTime.Now,
            Quantity = 20,
            Type = VoucherType.FixedAmount
        };

        using var scope = serviceProvider.CreateScope();
        var voucherService = scope.ServiceProvider.GetRequiredService<VoucherService>();

        // Act
        var result = await voucherService.Create(inputDto);

        // Assert
        Assert.Equal(uniqueCode, result.Code);

        var resultDb = await _mockedContext.Vouchers.FirstOrDefaultAsync(v => v.Code == uniqueCode);
        Assert.NotNull(resultDb);
        Assert.Equal(result.Id, resultDb.Id);
    }
    
    [Fact]
    public async Task Delete_ValidVoucherId_DeletesVoucher()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder
            .AddScoped(_mockedContext)
            .Create();

        var voucherDb = _mockedContext.Vouchers.FirstOrDefaultAsync();
        
        using var scope = serviceProvider.CreateScope();
        var voucherService = scope.ServiceProvider.GetRequiredService<VoucherService>();

        // Act
        await voucherService.Delete(voucherDb.Id);

        // Assert
        var resultDb = await _mockedContext.Vouchers
            .FirstOrDefaultAsync(v => v.Id == voucherDb.Id);
        
        Assert.Null(resultDb);
    }
    
    [Fact]
    public async Task Update_ValidInput_ReturnsVoucher()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder
            .AddScoped(_mockedContext)
            .Create();

        var voucherBeforeUpdate = _mockedContext.Vouchers.First();
        
        var uniqueCode = $"Test_{Guid.NewGuid()}";
        var inputDto = new VoucherInputDto
        {
            Code = uniqueCode,
            Discount = 20,
            ExpirationDate = DateTime.Now,
            Quantity = 20,
            Type = VoucherType.FixedAmount
        };

        using var scope = serviceProvider.CreateScope();
        var voucherService = scope.ServiceProvider.GetRequiredService<VoucherService>();

        // Act
        var result = await voucherService.Create(inputDto);

        // Assert
        Assert.Equal(uniqueCode, result.Code);

        var resultDb = await _mockedContext.Vouchers.FirstOrDefaultAsync(v => v.Code == uniqueCode);
        Assert.NotNull(resultDb);
        Assert.Equal(result.Id, resultDb.Id);
    }
}
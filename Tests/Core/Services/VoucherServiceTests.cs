using Core.Services;
using DataAccessLayer;
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
    public async Task GetVouchers_ReturnsVoucherDTOs()
    {
        
        // Arrange
        var vouchers = VouchersTestData.GetFakeVouchers();
        var vouchersIds = vouchers
            .Select(a => a.Id)
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


}
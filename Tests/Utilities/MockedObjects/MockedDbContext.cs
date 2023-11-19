using DataAccessLayer;
using DataAccessLayer.Entity;
using EntityFrameworkCore.Testing.NSubstitute.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Tests.Utilities.Data;

namespace Tests.Utilities.MockedObjects;
public static class MockedDbContext
{
    public static string RandomDbName => Guid.NewGuid().ToString();

    public static DbContextOptions<BookHubDbContext> GenerateNewInMemoryDbContextOptions()
    {
        var dbContextOptions = new DbContextOptionsBuilder<BookHubDbContext>()
            .UseInMemoryDatabase(RandomDbName)
            .Options;

        return dbContextOptions;
    }

    public static BookHubDbContext CreateFromOptions(DbContextOptions<BookHubDbContext> options)
    {
        var dbContextToMock = new BookHubDbContext(options);

        var dbContext = new MockedDbContextBuilder<BookHubDbContext>()
            .UseDbContext(dbContextToMock)
            .UseConstructorWithParameters(options)
            .MockedDbContext;

        PrepareData(dbContext);

        return dbContext;
    }

    private static void PrepareData(BookHubDbContext dbContext)
    {
        dbContext.Vouchers.AddRange(VouchersTestData.GetFakeVouchers());

        dbContext.SaveChanges();
    }
    
}

using BookHub.DataAccessLayer.Repository;

namespace BookHub.DataAccessLayer;

public static class RepositoryConfig
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        services.AddScoped<IBookRepository, BookRepository>();
    }
}
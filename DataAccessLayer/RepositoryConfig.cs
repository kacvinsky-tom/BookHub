using BookHub.DataAccessLayer.Repository;

namespace BookHub.DataAccessLayer;

public static class RepositoryConfig
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        services.AddTransient<IBookRepository, BookRepository>();
    }
}
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class RepositoryConfig
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWishListRepository, WishListRepository>();
        services.AddScoped<IWishListItemRepository, WishListItemRepository>();
        services.AddScoped<IVoucherRepository, VoucherRepository>();
    }
}
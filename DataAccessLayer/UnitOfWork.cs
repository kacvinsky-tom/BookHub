using BookHub.DataAccessLayer.Repository;
using BookHub.DataAccessLayer.Repository.Interfaces;

namespace BookHub.DataAccessLayer;

public class UnitOfWork
{
    private readonly BookHubDbContext _context;

    public IBookRepository Books { get; }
    public IAuthorRepository Authors { get; }
    public IPublisherRepository Publishers { get; }
    public IGenreRepository Genres { get; }
    public IUserRepository Users { get; }
    public IOrderRepository Orders { get; }
    public IOrderItemRepository OrderItems { get; }
    public IWishListRepository WishLists { get; }
    public IWishListItemRepository WishListItems { get; }

    public IReviewRepository Reviews { get; }
    
    public IVoucherRepository Vouchers { get; }


    public UnitOfWork(BookHubDbContext context)
    {
        _context = context;
        
        Books = new BookRepository(_context);
        Publishers = new PublisherRepository(_context);
        Authors = new AuthorRepository(_context);
        Genres = new GenreRepository(_context);
        Orders = new OrderRepository(_context);
        OrderItems = new OrderItemRepository(_context);
        Users = new UserRepository(_context);
        WishLists = new WishListRepository(_context);
        WishListItems = new WishListItemRepository(_context);
        Reviews = new ReviewRepository(_context);
        Vouchers = new VoucherRepository(_context);
    }

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }
}
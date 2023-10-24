using BookHub.DataAccessLayer.Repository;

namespace BookHub.DataAccessLayer;

public class UnitOfWork
{
    private readonly BookHubDbContext _context;

    public IBookRepository Books { get; }
    public IAuthorRepository Authors { get; }
    public IGenreRepository Genres { get; }
    
    public IUserRepository Users { get; }
    
    public IWishListRepository WishLists { get;  }
    public IWishListItemRepository WishListItems { get; }
    
    
    public UnitOfWork(BookHubDbContext context)
    {
        _context = context;
        
        Books = new BookRepository(_context);
        Authors = new AuthorRepository(_context);
        Genres = new GenreRepository(_context);
        Users = new UserRepository(_context);
        WishLists = new WishListRepository(_context);
        WishListItems = new WishListItemRepository(_context);
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
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Interfaces;

namespace DataAccessLayer;

public class UnitOfWork
{
    private readonly BookHubDbContext _context;

    public IBookRepository Books { get; }
    public IAuthorRepository Authors { get; }
    public IPublisherRepository Publishers { get; }
    public IGenreRepository Genres { get; }
    public IUserRepository Users { get; }
    public ICartItemRepository CartItems { get; }
    public IOrderRepository Orders { get; }
    public IOrderItemRepository OrderItems { get; }
    public IWishListRepository WishLists { get; }
    public IWishListItemRepository WishListItems { get; }

    public IReviewRepository Reviews { get; }

    public IVoucherRepository Vouchers { get; }

    public UnitOfWork(
        BookHubDbContext context,
        IBookRepository bookRepository,
        IAuthorRepository authorRepository,
        IPublisherRepository publisherRepository,
        IGenreRepository genreRepository,
        ICartItemRepository cartItemRepository,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IUserRepository userRepository,
        IWishListRepository wishListRepository,
        IWishListItemRepository wishListItemRepository,
        IReviewRepository reviewRepository,
        IVoucherRepository voucherRepository
    )
    {
        _context = context;
        Books = bookRepository;
        Publishers = publisherRepository;
        Authors = authorRepository;
        Genres = genreRepository;
        Orders = orderRepository;
        OrderItems = orderItemRepository;
        Users = userRepository;
        CartItems = cartItemRepository;
        WishLists = wishListRepository;
        WishListItems = wishListItemRepository;
        Reviews = reviewRepository;
        Vouchers = voucherRepository;
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

using BookHub.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer;

public class BookHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<WishList> WishLists { get; set; } = null!;
    public DbSet<WishListItem> WishListItems { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var dbPath = Path.Join(Environment.GetFolderPath(folder), "BookHub.sqlite");

        optionsBuilder
            .UseSqlite($"Data Source={dbPath}")
            ;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        AddUpdatedAt();
        return base.SaveChanges();
    }

    private void AddUpdatedAt()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x is { Entity: BaseEntity, State: EntityState.Modified });

        foreach (var entity in entities)
        {
            var now = DateTime.Now;

            ((BaseEntity)entity.Entity).UpdatedAt = now;
        }
    }
}
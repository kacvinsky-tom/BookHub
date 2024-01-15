using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class BookHubDbContext : IdentityDbContext<LocalIdentityUser, LocalIdentityRole, string>
{
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Author> Authors { get; set; } = null!;
    public virtual DbSet<Publisher> Publishers { get; set; } = null!;
    public virtual DbSet<Book> Books { get; set; } = null!;
    public virtual DbSet<Genre> Genres { get; set; } = null!;
    public virtual DbSet<Order> Orders { get; set; } = null!;
    public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
    public virtual DbSet<CartItem> CartItems { get; set; } = null!;
    public virtual DbSet<Review> Reviews { get; set; } = null!;
    public virtual DbSet<WishList> WishLists { get; set; } = null!;
    public virtual DbSet<WishListItem> WishListItems { get; set; } = null!;
    public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

    public BookHubDbContext(DbContextOptions<BookHubDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (
            var relationship in modelBuilder
                .Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())
        )
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder
            .Entity<WishList>()
            .HasMany(wl => wl.WishListItems)
            .WithOne(wli => wli.WishList)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.Reviews)
            .WithOne(r => r.User)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.CartItems)
            .WithOne(ci => ci.User)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.WishLists)
            .WithOne(wl => wl.User)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BookGenre>().HasKey(bg => new { bg.BookId, bg.GenreId });

        modelBuilder
            .Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity<BookGenre>(
                r =>
                    r.HasOne(bg => bg.Genre)
                        .WithMany(x => x.BookGenres)
                        .HasForeignKey(e => e.GenreId),
                l =>
                    l.HasOne(bg => bg.Book).WithMany(x => x.BookGenres).HasForeignKey(e => e.BookId)
            );

        modelBuilder
            .Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity<BookAuthor>(
                r =>
                    r.HasOne(bg => bg.Author)
                        .WithMany(a => a.BookAuthors)
                        .HasForeignKey(e => e.AuthorId),
                l =>
                    l.HasOne(bg => bg.Book)
                        .WithMany(b => b.BookAuthors)
                        .HasForeignKey(e => e.BookId)
            );

        modelBuilder.Seed();

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker
            .Entries()
            .Where(x =>
                x is { Entity: BaseEntity, State: EntityState.Modified or EntityState.Added }
            );

        foreach (var entity in entities)
        {
            var now = DateTime.Now;

            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedAt = now;
            }

            ((BaseEntity)entity.Entity).UpdatedAt = now;
        }
    }
}

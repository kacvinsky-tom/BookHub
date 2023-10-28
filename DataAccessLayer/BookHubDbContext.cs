using BookHub.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer;

public class BookHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Publisher> Publishers { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<WishList> WishLists { get; set; } = null!;
    public DbSet<WishListItem> WishListItems { get; set; } = null!;
    
    public DbSet<Voucher> Vouchers { get; set; } = null!;
    

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

        modelBuilder.Entity<WishList>()
            .HasMany(wl => wl.WishListItems)
            .WithOne(wli => wli.WishList)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Reviews)
            .WithOne(r => r.User)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.CartItems)
            .WithOne(ci => ci.User)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.WishLists)
            .WithOne(wl => wl.User)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Seed();

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookGenre",
                r => r.HasOne<Genre>().WithMany().HasForeignKey("GenresId").OnDelete(DeleteBehavior.Restrict),
                l => l.HasOne<Book>().WithMany().HasForeignKey("BooksId").OnDelete(DeleteBehavior.Cascade),
                je =>
                {
                    je.HasKey("BooksId", "GenresId");
                    je.HasData(DataInitializer.BookGenreData());
                });

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookAuthor",
                r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorsId").OnDelete(DeleteBehavior.Restrict),
                l => l.HasOne<Book>().WithMany().HasForeignKey("BooksId").OnDelete(DeleteBehavior.Cascade),
                je =>
                {
                    je.HasKey("BooksId", "AuthorsId");
                    je.HasData(DataInitializer.BookAuthorData());
                });

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x is { Entity: BaseEntity, State: EntityState.Modified or EntityState.Added });
    
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
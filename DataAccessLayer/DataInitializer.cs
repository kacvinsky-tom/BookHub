using DataAccessLayer.DataSeed;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public static class DataInitializer
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var users = Users.PrepareModels();
        var genres = Genres.PrepareModels();
        var authors = Authors.PrepareModels();
        var publishers = Publishers.PrepareModels();
        var books = Books.PrepareModels();
        var wishLists = WishLists.PrepareModels();
        var wishListItems = WishListItems.PrepareModels();
        var reviews = Reviews.PrepareModels();
        var cartItems = CartItems.PrepareModels();
        var orders = Orders.PrepareModels();
        var orderItems = OrderItems.PrepareModels();
        var vouchers = Vouchers.PrepareModels();
        var bookGenres = BookGenres.PrepareRelations();
        var bookAuthors = BookAuthors.PrepareRelations();
        var roleModels = IdentityRoles.PrepareModels();
        var identityUsers = IdentityUsers.PrepareModels();
        var userRoles = UserRoles.PrepareRelations();

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Genre>().HasData(genres);
        modelBuilder.Entity<Author>().HasData(authors);
        modelBuilder.Entity<Publisher>().HasData(publishers);
        modelBuilder.Entity<Book>().HasData(books);
        modelBuilder.Entity<WishList>().HasData(wishLists);
        modelBuilder.Entity<WishListItem>().HasData(wishListItems);
        modelBuilder.Entity<Review>().HasData(reviews);
        modelBuilder.Entity<CartItem>().HasData(cartItems);
        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
        modelBuilder.Entity<Voucher>().HasData(vouchers);
        modelBuilder.Entity<BookGenre>().HasData(bookGenres);
        modelBuilder.Entity<BookAuthor>().HasData(bookAuthors);
        modelBuilder.Entity<LocalIdentityRole>().HasData(roleModels);
        modelBuilder.Entity<LocalIdentityUser>().HasData(identityUsers);
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}

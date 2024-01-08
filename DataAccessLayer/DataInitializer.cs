using DataAccessLayer.Entity;
using DataAccessLayer.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public static class DataInitializer
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var users = PrepareUserModels();
        var genres = PrepareGenreModels();
        var authors = PrepareAuthorModels();
        var publishers = PreparePublisherModels();
        var books = PrepareBookModels();
        var wishLists = PrepareWishListModels();
        var wishListItems = PrepareWishListItemModels();
        var reviews = PrepareReviewModels();
        var cartItems = PrepareCartItemModels();
        var orders = PrepareOrderModels();
        var orderItems = PrepareOrderItemModels();
        var vouchers = PrepareVoucherModels();
        var bookGenres = PrepareBookGenreRelations();
        var bookAuthors = PrepareBookAuthorRelations();
        var roleModels = PrepareRoles();
        var identityUsers = PrepareLocalIdentityUserModels();
        var userRoles = PrepareUserRoles();

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

    private static IEnumerable<IdentityUserRole<string>> PrepareUserRoles()
    {
        return new List<IdentityUserRole<string>>()
        {
            // John Doe, Admin
            new IdentityUserRole<string>()
            {
                RoleId = "86718895-f083-4ba8-8452-b7a4dc9ca99c",
                UserId = "0d8fb324-0996-465b-a7b1-aeaaf327e6a8"
            }
        };
    }

    private static IEnumerable<LocalIdentityRole> PrepareRoles()
    {
        return new List<LocalIdentityRole>
        {
            new()
            {
                Id = "86718895-f083-4ba8-8452-b7a4dc9ca99c",
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new()
            {
                Id = "cb9a0fb7-cd3e-498f-9b3e-ef3c9809708d",
                Name = "User",
                NormalizedName = "USER",
            }
        };
    }

    private static IEnumerable<BookGenre> PrepareBookGenreRelations()
    {
        return new List<BookGenre>
        {
            new() { BookId = 1, GenreId = 2 },
            new() { BookId = 1, GenreId = 8 },
            new() { BookId = 2, GenreId = 2 },
            new() { BookId = 2, GenreId = 8 },
            new() { BookId = 3, GenreId = 2 },
            new() { BookId = 3, GenreId = 8 },
            new() { BookId = 3, GenreId = 9 },
            new() { BookId = 4, GenreId = 1 },
            new() { BookId = 4, GenreId = 5 },
            new() { BookId = 4, GenreId = 6 },
            new() { BookId = 4, GenreId = 7 },
            new() { BookId = 5, GenreId = 2 },
            new() { BookId = 5, GenreId = 8 },
            new() { BookId = 6, GenreId = 2 },
            new() { BookId = 6, GenreId = 8 },
            new() { BookId = 7, GenreId = 2 },
            new() { BookId = 7, GenreId = 8 },
            new() { BookId = 8, GenreId = 2 },
            new() { BookId = 8, GenreId = 8 },
            new() { BookId = 9, GenreId = 2 },
            new() { BookId = 9, GenreId = 8 },
            new() { BookId = 10, GenreId = 2 },
            new() { BookId = 10, GenreId = 8 },
            new() { BookId = 11, GenreId = 2 },
            new() { BookId = 11, GenreId = 8 },
        };
    }

    private static IEnumerable<BookAuthor> PrepareBookAuthorRelations()
    {
        return new List<BookAuthor>
        {
            new() { BookId = 1, AuthorId = 1 },
            new() { BookId = 1, AuthorId = 2 },
            new() { BookId = 2, AuthorId = 3 },
            new() { BookId = 2, AuthorId = 4 },
            new() { BookId = 3, AuthorId = 1 },
            new() { BookId = 3, AuthorId = 2 },
            new() { BookId = 3, AuthorId = 3 },
            new() { BookId = 4, AuthorId = 4 },
            new() { BookId = 4, AuthorId = 1 },
            new() { BookId = 4, AuthorId = 2 },
            new() { BookId = 4, AuthorId = 3 },
            new() { BookId = 5, AuthorId = 4 },
            new() { BookId = 5, AuthorId = 1 },
            new() { BookId = 6, AuthorId = 2 },
            new() { BookId = 6, AuthorId = 3 },
            new() { BookId = 7, AuthorId = 4 },
            new() { BookId = 7, AuthorId = 1 },
            new() { BookId = 8, AuthorId = 2 },
            new() { BookId = 8, AuthorId = 3 },
            new() { BookId = 9, AuthorId = 4 },
            new() { BookId = 9, AuthorId = 1 },
            new() { BookId = 10, AuthorId = 2 },
            new() { BookId = 10, AuthorId = 3 },
            new() { BookId = 11, AuthorId = 4 },
            new() { BookId = 11, AuthorId = 1 },
        };
    }

    private static IEnumerable<User> PrepareUserModels()
    {
        var users = new List<User>
        {
            new()
            {
                Id = 1,
                Username = "john.doe",
                Email = "john.doe@gmail.com",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "752 685 143",
            },
            new()
            {
                Id = 2,
                Username = "jane.doe",
                Email = "jane.doe@gmai.com",
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "746 692 352",
            },
            new()
            {
                Id = 3,
                Username = "pavel.kraus",
                Email = "pavel.kraus@gmail.com",
                FirstName = "Pavel",
                LastName = "Kraus",
                PhoneNumber = "748 242 562",
            },
            new()
            {
                Id = 4,
                Username = "jarda.novak",
                Email = "jarda@novak.cz",
                FirstName = "Jarda",
                LastName = "Novák",
                PhoneNumber = "742 942 934",
            }
        };
        users.ForEach(
            user => user.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );

        return users;
    }

    private static IEnumerable<LocalIdentityUser> PrepareLocalIdentityUserModels()
    {
        // PW to default accounts: "P@ssw0rd"
        var users = PrepareUserModels();
        var preparedData = new Dictionary<int, List<string>>()
        {
            {
                1,
                new()
                {
                    "0d8fb324-0996-465b-a7b1-aeaaf327e6a8",
                    "52f29df2-7b85-4f2d-b925-d861e125ad37",
                    "AQAAAAIAAYagAAAAENvJRIhW0HvRBoR6q6bmwLyxK6FOQd+ENX5fY0zExhUbq9q8JsCo8Gz0CxOH5O6xCA==",
                    "e34b0df2-8863-4466-ae5a-92686ddb52e4",
                }
            },
            {
                2,
                new()
                {
                    "551d86f0-c626-4dcf-bb4e-5fb3d05666cd",
                    "2ca69a27-f75d-4b17-89e1-e3a4c9da44d9",
                    "AQAAAAIAAYagAAAAEAEyiPBPZx6HbMCOq2MmaqxdciGpSUbhoX01VRjU4hGjXRdOh3ou7Lg3QwhfcRkA3w==",
                    "4bac5dda-ba34-433d-9f68-0bd4abf58c1c"
                }
            },
            {
                3,
                new()
                {
                    "996aa4ee-3b11-4e0f-b307-63bad603f850",
                    "f350415d-efed-44bf-b92c-8e61f19b2469",
                    "AQAAAAIAAYagAAAAEJa0udvFKhAgafmNjFzwoPR4YnCskaTHKP0CmpjH2h4BOOWz4kHEO3EF8JjGcLrUpg==",
                    "51f9b5e5-8609-4c04-9800-500cfee2f599"
                }
            },
            {
                4,
                new()
                {
                    "caac826e-f9a3-4d6f-a521-e35be632b112",
                    "cdedf214-b574-4988-86c3-81a44173688a",
                    "AQAAAAIAAYagAAAAEJJZ5PWdW8XhdfuYU6UkWnkqBwOcsPHWIErN+0r6boR5bc2QMD750v7PB2cL4NLeIA==",
                    "fe71b0a1-d7fa-4017-a0f1-95b23f05f8fe"
                }
            }
        };
        var identityUsers = users
            .Select(
                u =>
                    new LocalIdentityUser()
                    {
                        Id = preparedData[u.Id][0],
                        UserName = u.Username,
                        NormalizedUserName = u.Username.ToUpper(),
                        Email = u.Email,
                        NormalizedEmail = u.Email.ToUpper(),
                        EmailConfirmed = true,
                        UserId = u.Id,
                        ConcurrencyStamp = preparedData[u.Id][1],
                        PasswordHash = preparedData[u.Id][2],
                        SecurityStamp = preparedData[u.Id][3],
                    }
            )
            .ToList();
        return identityUsers;
    }

    private static IEnumerable<Genre> PrepareGenreModels()
    {
        var genres = new List<Genre>
        {
            new() { Id = 1, Name = "Horor", },
            new() { Id = 2, Name = "Fantasy", },
            new() { Id = 3, Name = "Sci-Fi", },
            new() { Id = 4, Name = "Romantické", },
            new() { Id = 5, Name = "Krimi", },
            new() { Id = 6, Name = "Mysteriózní", },
            new() { Id = 7, Name = "Thriller", },
            new() { Id = 8, Name = "Dobrodružné", },
            new() { Id = 9, Name = "Akční", },
            new() { Id = 10, Name = "Komedie", },
            new() { Id = 11, Name = "Drama", },
            new() { Id = 12, Name = "Biografie", },
            new() { Id = 13, Name = "Historické romány", },
            new() { Id = 14, Name = "Poezie", }
        };
        genres.ForEach(
            genre => genre.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return genres;
    }

    private static IEnumerable<Author> PrepareAuthorModels()
    {
        var authors = new List<Author>
        {
            new()
            {
                Id = 1,
                FirstName = "Stephen",
                LastName = "King",
            },
            new()
            {
                Id = 2,
                FirstName = "J. K.",
                LastName = "Rowling",
            },
            new()
            {
                Id = 3,
                FirstName = "George R. R.",
                LastName = "Martin",
            },
            new()
            {
                Id = 4,
                FirstName = "Terry",
                LastName = "Pratchett",
            }
        };
        authors.ForEach(
            author => author.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return authors;
    }

    private static IEnumerable<Publisher> PreparePublisherModels()
    {
        var publishers = new List<Publisher>
        {
            new()
            {
                Id = 1,
                Name = "Talpress",
                State = "Czech Republic",
                Email = "eshop@talpress.cz"
            },
            new()
            {
                Id = 2,
                Name = "Albatros",
                State = "Czech Republic",
                Email = "albatros@albatrosmedia.cz"
            },
            new()
            {
                Id = 3,
                Name = "Argo",
                State = "Czech Republic",
                Email = "argo@argo.cz"
            }
        };
        publishers.ForEach(
            publisher =>
                publisher.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return publishers;
    }

    private static IEnumerable<Book> PrepareBookModels()
    {
        var books = new List<Book>
        {
            new()
            {
                Id = 1,
                Title = "Barva kouzel",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Ve světě, který leží na krunýři obrovské želvy, se vydává na cestu rozverná, temperamentní a neuvěřitelně výstřední výprava. Setkáte se s lakomým a naprosto neschopným čarodějem Mrakoplašem, naivním turistou Dvoukvítkem, jehož Zavazadlo za ním běhá jako pes na stovce malých nožiček, s draky, kteří existují, pokud na ně opravdu věříte, a samozřejmě dojdete až na okraj této podivné planety.",
                Price = 399,
                Quantity = 7,
                ReleaseYear = 1993,
                PublisherId = 1,
            },
            new()
            {
                Id = 2,
                Title = "Harry Potter a Kámen mudrců",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Harry Potter je sirotek, který žije u svých příbuzných Dursleyových. Jeho rodiče byli mocní čarodějové, kteří zahynuli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harryho rodiče zanechali svého syna v péči svého přítele, kouzelníka Albusa Brumbála, ředitele Školy čar a kouzel v Bradavicích. Harryho příbuzní o jeho magických schopnostech nevědí, protože se bojí, že by ho mohli zavděčit. Harryho život je plný ponižování a šikany, ale v den jeho jedenáctých narozenin se vše změní. Harry dostane dopis od Brumbála, který ho pozve na Školu čar a kouzel v Bradavicích. Harry se dozví, že je čaroděj a že jeho rodiče zemřeli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harry se vydává do Bradavic, kde se seznámí s Ronem Weasleym a Hermionou Grangerovou, kteří se stanou jeho nejlepšími přáteli. Harry se také dozví, že Voldemort přežil a že se chystá získat Kámen mudrců, který mu pomůže znovu získat svou moc.",
                Price = 399,
                Quantity = 17,
                ReleaseYear = 1997,
                PublisherId = 2,
            },
            new()
            {
                Id = 3,
                Title = "Hra o trůny",
                ISBN = "978-80-257-2891-5",
                Description =
                    "Když král Robert rozhodne, že jeho nejstarší přítel Eddard Stark bude jeho pravou rukou, nevědomky odstartuje události, které otřesou celým kontinentem. Eddard se totiž snaží vyšetřit tajemnou smrt předchozího krájů a nastoupit na své nové místo, ale brzy zjistí, že je vše mnohem složitější, než se zdálo. Na jihu se totiž připravuje vzpoura a v záloze číhá starodávné zlo, které se probouzí.",
                Price = 699,
                Quantity = 15,
                ReleaseYear = 1996,
                PublisherId = 3,
            },
            new()
            {
                Id = 4,
                Title = "To",
                ISBN = "978-80-7197-614-1",
                Description =
                    "V roce 1958 se sedmička přátel z Derry, malého městečka v americkém státě Maine, vydává do kanalizace, aby zničila zlého klauna Pennywaise, který se zde ukrývá. Sedmička však zjistí, že Pennywise je jen jedním z mnoha podob zla, které se ukrývá v Derry. Ze slibu se však stane kletba a sedmička se musí v roce 1985 vrátit do Derry, aby zlo zničila jednou provždy.",
                Price = 799,
                Quantity = 2,
                ReleaseYear = 1986,
                PublisherId = 1,
            },
            new()
            {
                Id = 5,
                Title = "Harry Potter a Tajemná komnata",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Harry Potter, Ron Weasley a Hermiona Grangerová se vrací do Bradavic, kde se dozvědí o Tajemné komnatě, která je úzce spojena s Harrym. Harry se rozhodne najít Tajemnou komnatu a zjistit, co se tam skrývá. Harryho plán je však zmařen, když se objeví záhadný písař. Harryho přítel Ron je napaden a jeho sestra Ginny zmizí. Harry, Ron a Hermiona se tak vydávají do Tajemné komnaty, aby zjistili, co se tam skrývá a zachránili Ginny.",
                Price = 399,
                Quantity = 9,
                ReleaseYear = 1998,
                PublisherId = 2,
            },
            new()
            {
                Id = 6,
                Title = "Harry Potter a vězeň z Azkabanu",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Harry Potter se vrací do Bradavic, ale tentokrát se musí vyhýbat nebezpečnému vězni jménem Sirius Black, který utekl z Azkabanu. Harry se dozví, že Sirius byl vězněn kvůli tomu, že zradil jeho rodiče a že se chystá Harryho zabít. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že Sirius není tím, za koho se vydává.",
                Price = 399,
                Quantity = 11,
                ReleaseYear = 1999,
                PublisherId = 2,
            },
            new()
            {
                Id = 7,
                Title = "Harry Potter a Ohnivý pohár",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Harry Potter se vrací do Bradavic, kde se má konat Turnaj tří kouzelníků. Harry se však dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů.",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2000,
                PublisherId = 2,
            },
            new()
            {
                Id = 8,
                Title = "Harry Potter a Fénixův řád",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Do Bradavic přišly temné časy. Po útoku mozkomorů na bratrance Dudleyho Harry ví, že Voldemort udělá cokoli, jen aby ho našel. Mnozí jeho návrat popírají, ale Harry přesto není sám: na Grimmauldově náměstí se schází tajný řád, který chce bojovat proti temným silám. Harry se musí od profesora Snapea naučit, jak se chránit před Voldemortovými útoky na jeho duši. Jenže Pán zla je den ode dne silnější a Harrymu dochází čas…",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2000,
                PublisherId = 2,
            },
            new()
            {
                Id = 9,
                Title = "Harry Potter a princ dvojí krve",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Moc Lorda Voldemorta stále roste a smrtijedi působí spoušť ve světě mudlů i kouzelníků. Když Harry Potter objeví starou učebnici lektvarů patřící tajemnému princi dvojí krve, spoléhá na její kouzla i přes varování svých kamarádů. Profesor Brumbál poodhaluje Voldemortovu minulost a s Harryho pomocí se snaží odkrýt tajemství jeho nesmrtelnosti. Jenže zlo se dere k moci stále silněji, neštěstí se blíží a Bradavice už nikdy nebudou jako dřív.",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2005,
                PublisherId = 2,
            },
            new()
            {
                Id = 10,
                Title = "Harry Potter a Relikvie smrti",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Harry Potter se vydává na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců. Harry se musí vydat na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců.",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2007,
                PublisherId = 2,
            },
            new()
            {
                Id = 11,
                Title = "Harry Potter a prokleté dítě",
                ISBN = "978-80-7197-614-1",
                Description =
                    "Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje. Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje.",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2016,
                PublisherId = 2,
            },
        };
        books.ForEach(
            book => book.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return books;
    }

    private static IEnumerable<WishList> PrepareWishListModels()
    {
        var wishlists = new List<WishList>
        {
            new()
            {
                Id = 1,
                Name = "Můj seznam přání",
                UserId = 2,
            },
            new()
            {
                Id = 2,
                Name = "Zbývající harry potter knížky",
                UserId = 2,
            },
        };
        wishlists.ForEach(
            wishlist => wishlist.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return wishlists;
    }

    private static IEnumerable<WishListItem> PrepareWishListItemModels()
    {
        var wishlistItems = new List<WishListItem>
        {
            new()
            {
                Id = 1,
                WishListId = 1,
                BookId = 1,
            },
            new()
            {
                Id = 2,
                WishListId = 1,
                BookId = 3,
            },
            new()
            {
                Id = 3,
                WishListId = 2,
                BookId = 8,
            },
            new()
            {
                Id = 4,
                WishListId = 2,
                BookId = 9,
            },
            new()
            {
                Id = 5,
                WishListId = 2,
                BookId = 10,
            },
            new()
            {
                Id = 6,
                WishListId = 2,
                BookId = 11,
            },
        };
        wishlistItems.ForEach(
            wishlistItem =>
                wishlistItem.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return wishlistItems;
    }

    private static IEnumerable<Review> PrepareReviewModels()
    {
        var reviews = new List<Review>
        {
            new()
            {
                Id = 1,
                BookId = 1,
                UserId = 1,
                Rating = 5,
                Comment =
                    "Barva kouzel od Terryho Pratchetta je brilantní kombinací fantasy a humoru. Pratchettova schopnost tvořit fantastické světy a vtipně komentovat naši skutečnost je prostě neuvěřitelná. Tato kniha je nesmírně zábavná a zároveň hluboká.",
            },
            new()
            {
                Id = 2,
                BookId = 1,
                UserId = 2,
                Rating = 5,
                Comment =
                    "Když jsem poprvé četl Barvu kouzel, byl jsem ohromen Pratchettovým talentem. Jeho postavy jsou živé, zápletka je originální a humor je úžasný. V průběhu knihy jsem se smál na každé stránce.",
            },
            new()
            {
                Id = 3,
                BookId = 1,
                UserId = 3,
                Rating = 4,
                Comment =
                    "Barva kouzel je úžasným začátkem dlouhé série knih ze Zeměplochy od Terryho Pratchetta. Kniha je plná vtipných narážek, alegorií a skvělých postav. Pratchettova imaginace je prostě neomezená.",
            },
            new()
            {
                Id = 4,
                BookId = 1,
                UserId = 4,
                Rating = 4,
                Comment =
                    "Terry Pratchett byl génius a Barva kouzel to dokazuje. Jeho schopnost kombinovat fantasy s komedií a zároveň skvěle komentovat různé aspekty naší společnosti je úžasná. Tato kniha je klenotem a musí pro všechny fanoušky fantasy a humoru.",
            },
            new()
            {
                Id = 5,
                BookId = 7,
                UserId = 1,
                Rating = 5,
                Comment =
                    "Harry Potter a Ohnivý pohár je zlomovým dílem v sérii. Rowlingova schopnost rozvíjet svět čarodějů a postavy je úžasná. Tato kniha je plná napětí, dobrodružství a emocí. Nemohl jsem se od ní odtrhnout.",
            },
            new()
            {
                Id = 6,
                BookId = 7,
                UserId = 2,
                Rating = 4,
                Comment =
                    "Kniha Harry Potter a Ohnivý pohár je nejen temnější než předchozí díly, ale také daleko složitější. Rowling zde ukazuje, že její příběh není určen jen pro děti. Děj je napínavý a postavy procházejí důležitými změnami.",
            },
            new()
            {
                Id = 7,
                BookId = 7,
                UserId = 3,
                Rating = 5,
                Comment =
                    "Harry Potterova čtvrtá dobrodružství v Ohnivém poháru jsou fantastická. Tato kniha se vyznačuje neuvěřitelným nasazením a soubojem na Turnaji tří kouzel. Rowlingova schopnost vytvořit komplexní a poutavý příběh zůstává nepřekonaná.",
            },
            new()
            {
                Id = 8,
                BookId = 7,
                UserId = 4,
                Rating = 5,
                Comment =
                    "Harry Potter a Ohnivý pohár je dalším důkazem Rowlinginy brilantní schopnosti psát pro různé věkové kategorie. Tato kniha je poutavá, plná tajemství a emocí, a dokazuje, proč je série Harryho Pottera tak oblíbená po celém světě.",
            },
        };
        reviews.ForEach(
            review => review.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return reviews;
    }

    private static IEnumerable<CartItem> PrepareCartItemModels()
    {
        var cartItems = new List<CartItem>
        {
            new()
            {
                Id = 1,
                BookId = 7,
                UserId = 4,
                Quantity = 1,
            },
            new()
            {
                Id = 2,
                BookId = 1,
                UserId = 4,
                Quantity = 2,
            },
            new()
            {
                Id = 3,
                BookId = 2,
                UserId = 2,
                Quantity = 1,
            }
        };
        cartItems.ForEach(
            cartItem => cartItem.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return cartItems;
    }

    private static IEnumerable<Order> PrepareOrderModels()
    {
        var orders = new List<Order>
        {
            new()
            {
                Id = 1,
                UserId = 3,
                Status = OrderStatus.Pending,
                TotalPrice = 798
            },
            new()
            {
                Id = 2,
                UserId = 4,
                Status = OrderStatus.Completed,
                TotalPrice = 699
            },
            new()
            {
                Id = 3,
                UserId = 2,
                Status = OrderStatus.Cancelled,
                TotalPrice = 399
            }
        };
        orders.ForEach(
            order => order.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return orders;
    }

    private static IEnumerable<OrderItem> PrepareOrderItemModels()
    {
        var orderItems = new List<OrderItem>
        {
            new()
            {
                Id = 1,
                OrderId = 1,
                BookId = 10,
                Quantity = 1,
                Price = 399,
                Title = "Harry Potter a Relikvie smrti",
                ISBN = "978-80-7197-614-1",
            },
            new()
            {
                Id = 2,
                OrderId = 1,
                BookId = 11,
                Quantity = 1,
                Price = 399,
                Title = "Harry Potter a Prokleté Dítě",
                ISBN = "978-80-7197-613-4",
            },
            new()
            {
                Id = 3,
                OrderId = 2,
                BookId = 3,
                Quantity = 1,
                Price = 699,
                Title = "Hra o trůny",
                ISBN = "978-80-7197-612-7",
            },
            new()
            {
                Id = 4,
                OrderId = 3,
                BookId = 1,
                Quantity = 1,
                Price = 399,
                Title = "Barva kouzel",
                ISBN = "978-80-7197-611-0",
            }
        };
        orderItems.ForEach(
            orderItem =>
                orderItem.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return orderItems;
    }

    private static IEnumerable<Voucher> PrepareVoucherModels()
    {
        var vouchers = new List<Voucher>()
        {
            new()
            {
                Id = 1,
                Code = "VANOCE10",
                Discount = 10,
                ExpirationDate = new DateTime(2023, 12, 24, 12, 00, 00, DateTimeKind.Utc),
                Type = VoucherType.Percentage
            },
            new()
            {
                Id = 2,
                Code = "KILODOLU",
                Discount = 100,
                ExpirationDate = new DateTime(2023, 11, 1, 0, 0, 0, DateTimeKind.Utc),
                Type = VoucherType.FixedAmount
            },
            new()
            {
                Id = 3,
                Code = "ZIMNISLEVA",
                Discount = 20,
                ExpirationDate = new DateTime(2024, 1, 31, 0, 0, 0, DateTimeKind.Utc),
                Type = VoucherType.Percentage
            },
        };
        vouchers.ForEach(
            v => v.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return vouchers;
    }
}

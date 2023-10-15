using BookHub.DataAccessLayer.Entity;
using BookHub.Enum;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer;

public static class DataInitializer
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var users = PrepareUserModels();
        var genres = PrepareGenreModels();
        var authors = PrepareAuthorModels();
        var books = PrepareBookModels();
        var wishLists = PrepareWishListModels();
        var wishListItems = PrepareWishListItemModels();
        var reviews = PrepareReviewModels();
        var cartItems = PrepareCartItemModels();
        var orders = PrepareOrderModels();
        var orderItems = PrepareOrderItemModels();
        
        modelBuilder.Entity<User>()
            .HasData(users);
        modelBuilder.Entity<Genre>()
            .HasData(genres);
        modelBuilder.Entity<Author>()
            .HasData(authors);
        modelBuilder.Entity<Book>()
            .HasData(books);
        modelBuilder.Entity<WishList>()
            .HasData(wishLists);
        modelBuilder.Entity<WishListItem>()
            .HasData(wishListItems);
        modelBuilder.Entity<Review>()
            .HasData(reviews);
        modelBuilder.Entity<CartItem>()
            .HasData(cartItems);
        modelBuilder.Entity<Order>()
            .HasData(orders);
        modelBuilder.Entity<OrderItem>()
            .HasData(orderItems);
    }

    private static IEnumerable<User> PrepareUserModels()
    {
        return new List<User>
        {
            new()
            {
                Id = 1,
                Username = "john.doe",
                Email = "john.doe@gmail.com",
                Password = "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", //heslo1234
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "752 685 143",
                IsAdmin = true,
            },
            new()
            {
                Id = 2,
                Username = "jane.doe",
                Email = "jane.doe@gmai.com",
                Password = "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", //heslo1234
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "746 692 352",
                IsAdmin = false,
            },
            new()
            {
                Id = 3,
                Username = "pavel.kraus",
                Email = "pavel.kraus@gmail.com",
                Password = "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", //heslo1234
                FirstName = "Pavel",
                LastName = "Kraus",
                PhoneNumber = "748 242 562",
                IsAdmin = false,
            },
            new()
            {
                Id = 4,
                Username = "jarda.novak",
                Email = "jarda@novak.cz",
                Password = "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", //heslo1234
                FirstName = "Jarda",
                LastName = "Novák",
                PhoneNumber = "742 942 934",
                IsAdmin = false,
            }
        };
    }

    private static IEnumerable<Genre> PrepareGenreModels()
    {
        return new List<Genre>
        {
            new()
            {
                Id = 1,
                Name = "Horor",
            },
            new()
            {
                Id = 2,
                Name = "Fantasy",
            },
            new()
            {
                Id = 3,
                Name = "Sci-Fi",
            },
            new()
            {
                Id = 4,
                Name = "Romantické",
            },
            new()
            {
                Id = 5,
                Name = "Krimi",
            },
            new()
            {
                Id = 6,
                Name = "Mysteriózní",
            },
            new()
            {
                Id = 7,
                Name = "Thriller",
            },
            new()
            {
                Id = 8,
                Name = "Dobrodružné",
            },
            new()
            {
                Id = 9,
                Name = "Akční",
            },
            new()
            {
                Id = 10,
                Name = "Komedie",
            },
            new()
            {
                Id = 11,
                Name = "Drama",
            },
            new()
            {
                Id = 12,
                Name = "Biografie",
            },
            new()
            {
                Id = 13,
                Name = "Historické romány",
            },
            new()
            {
                Id = 14,
                Name = "Poezie",
            }
        };
    }

    private static IEnumerable<Author> PrepareAuthorModels()
    {
        return new List<Author>
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
    }

    private static IEnumerable<Book> PrepareBookModels()
    {
        return new List<Book>
        {
            new()
            {
                Id = 1,
                Title = "Barva kouzel",
                ISBN = "978-80-7197-614-1",
                Description = "Ve světě, který leží na krunýři obrovské želvy, se vydává na cestu rozverná, temperamentní a neuvěřitelně výstřední výprava. Setkáte se s lakomým a naprosto neschopným čarodějem Mrakoplašem, naivním turistou Dvoukvítkem, jehož Zavazadlo za ním běhá jako pes na stovce malých nožiček, s draky, kteří existují, pokud na ně opravdu věříte, a samozřejmě dojdete až na okraj této podivné planety.",
                Price = 399,
                Quantity = 7,
                Publisher = "Talpress",
                ReleaseYear = 1993,
                AuthorId = 4,
            },
            new()
            {
                Id = 2,
                Title = "Harry Potter a Kámen mudrců",
                ISBN = "978-80-7197-614-1",
                Description = "Harry Potter je sirotek, který žije u svých příbuzných Dursleyových. Jeho rodiče byli mocní čarodějové, kteří zahynuli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harryho rodiče zanechali svého syna v péči svého přítele, kouzelníka Albusa Brumbála, ředitele Školy čar a kouzel v Bradavicích. Harryho příbuzní o jeho magických schopnostech nevědí, protože se bojí, že by ho mohli zavděčit. Harryho život je plný ponižování a šikany, ale v den jeho jedenáctých narozenin se vše změní. Harry dostane dopis od Brumbála, který ho pozve na Školu čar a kouzel v Bradavicích. Harry se dozví, že je čaroděj a že jeho rodiče zemřeli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harry se vydává do Bradavic, kde se seznámí s Ronem Weasleym a Hermionou Grangerovou, kteří se stanou jeho nejlepšími přáteli. Harry se také dozví, že Voldemort přežil a že se chystá získat Kámen mudrců, který mu pomůže znovu získat svou moc.",
                Price = 399,
                Quantity = 17,
                Publisher = "Albatros",
                ReleaseYear = 1997,
                AuthorId = 2,
            },
            new()
            {
                Id = 3,
                Title = "Hra o trůny",
                ISBN = "978-80-257-2891-5",
                Description = "Když král Robert rozhodne, že jeho nejstarší přítel Eddard Stark bude jeho pravou rukou, nevědomky odstartuje události, které otřesou celým kontinentem. Eddard se totiž snaží vyšetřit tajemnou smrt předchozího krájů a nastoupit na své nové místo, ale brzy zjistí, že je vše mnohem složitější, než se zdálo. Na jihu se totiž připravuje vzpoura a v záloze číhá starodávné zlo, které se probouzí.",
                Price = 699,
                Quantity = 15,
                Publisher = "Argo",
                ReleaseYear = 1996,
                AuthorId = 3,
            },
            new()
            {
                Id = 4,
                Title = "To",
                ISBN = "978-80-7197-614-1",
                Description = "V roce 1958 se sedmička přátel z Derry, malého městečka v americkém státě Maine, vydává do kanalizace, aby zničila zlého klauna Pennywaise, který se zde ukrývá. Sedmička však zjistí, že Pennywise je jen jedním z mnoha podob zla, které se ukrývá v Derry. Ze slibu se však stane kletba a sedmička se musí v roce 1985 vrátit do Derry, aby zlo zničila jednou provždy.",
                Price = 799,
                Quantity = 2,
                Publisher = "Talpress",
                ReleaseYear = 1986,
                AuthorId = 1,
            },
            new()
            {
                Id = 5,
                Title = "Harry Potter a Tajemná komnata",
                ISBN = "978-80-7197-614-1",
                Description = "Harry Potter, Ron Weasley a Hermiona Grangerová se vrací do Bradavic, kde se dozvědí o Tajemné komnatě, která je úzce spojena s Harrym. Harry se rozhodne najít Tajemnou komnatu a zjistit, co se tam skrývá. Harryho plán je však zmařen, když se objeví záhadný písař. Harryho přítel Ron je napaden a jeho sestra Ginny zmizí. Harry, Ron a Hermiona se tak vydávají do Tajemné komnaty, aby zjistili, co se tam skrývá a zachránili Ginny.",
                Price = 399,
                Quantity = 9,
                Publisher = "Albatros",
                ReleaseYear = 1998,
                AuthorId = 2,
            },
            new()
            {
                Id = 6,
                Title = "Harry Potter a vězeň z Azkabanu",
                ISBN = "978-80-7197-614-1",
                Description = "Harry Potter se vrací do Bradavic, ale tentokrát se musí vyhýbat nebezpečnému vězni jménem Sirius Black, který utekl z Azkabanu. Harry se dozví, že Sirius byl vězněn kvůli tomu, že zradil jeho rodiče a že se chystá Harryho zabít. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že Sirius není tím, za koho se vydává.",
                Price = 399,
                Quantity = 11,
                Publisher = "Albatros",
                ReleaseYear = 1999,
                AuthorId = 2,
            },
            new()
            {
                Id = 7,
                Title = "Harry Potter a Ohnivý pohár",
                ISBN = "978-80-7197-614-1",
                Description = "Harry Potter se vrací do Bradavic, kde se má konat Turnaj tří kouzelníků. Harry se však dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů.",
                Price = 399,
                Quantity = 13,
                Publisher = "Albatros",
                ReleaseYear = 2000,
                AuthorId = 2,
            },
            new()
            {
                Id = 8,
                Title = "Harry Potter a Fénixův řád",
                ISBN = "978-80-7197-614-1",
                Description = "Do Bradavic přišly temné časy. Po útoku mozkomorů na bratrance Dudleyho Harry ví, že Voldemort udělá cokoli, jen aby ho našel. Mnozí jeho návrat popírají, ale Harry přesto není sám: na Grimmauldově náměstí se schází tajný řád, který chce bojovat proti temným silám. Harry se musí od profesora Snapea naučit, jak se chránit před Voldemortovými útoky na jeho duši. Jenže Pán zla je den ode dne silnější a Harrymu dochází čas…",
                Price = 399,
                Quantity = 13,
                Publisher = "Albatros",
                ReleaseYear = 2000,
                AuthorId = 2,
            },
            new()
            {
                Id = 9,
                Title = "Harry Potter a princ dvojí krve",
                ISBN = "978-80-7197-614-1",
                Description = "Moc Lorda Voldemorta stále roste a smrtijedi působí spoušť ve světě mudlů i kouzelníků. Když Harry Potter objeví starou učebnici lektvarů patřící tajemnému princi dvojí krve, spoléhá na její kouzla i přes varování svých kamarádů. Profesor Brumbál poodhaluje Voldemortovu minulost a s Harryho pomocí se snaží odkrýt tajemství jeho nesmrtelnosti. Jenže zlo se dere k moci stále silněji, neštěstí se blíží a Bradavice už nikdy nebudou jako dřív.",
                Price = 399,
                Quantity = 13,
                Publisher = "Albatros",
                ReleaseYear = 2005,
                AuthorId = 2,
            },
            new()
            {
                Id = 10,
                Title = "Harry Potter a Relikvie smrti",
                ISBN = "978-80-7197-614-1",
                Description = "Harry Potter se vydává na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců. Harry se musí vydat na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců.",
                Price = 399,
                Quantity = 13,
                Publisher = "Albatros",
                ReleaseYear = 2007,
                AuthorId = 2,
            },
            new()
            {
                Id = 11,
                Title = "Harry Potter a prokleté dítě",
                ISBN = "978-80-7197-614-1",
                Description = "Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje. Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje.",
                Price = 399,
                Quantity = 13,
                Publisher = "Albatros",
                ReleaseYear = 2016,
                AuthorId = 2,
            },
        };
    }

    private static IEnumerable<WishList> PrepareWishListModels()
    {
        return new List<WishList>
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
    }

    private static IEnumerable<WishListItem> PrepareWishListItemModels()
    {
        return new List<WishListItem>
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
    }

    private static IEnumerable<Review> PrepareReviewModels()
    {
        return new List<Review>
        {
            new()
            {
                Id = 1,
                BookId = 1,
                UserId = 1,
                Rating = 5,
                Comment = "Barva kouzel od Terryho Pratchetta je brilantní kombinací fantasy a humoru. Pratchettova schopnost tvořit fantastické světy a vtipně komentovat naši skutečnost je prostě neuvěřitelná. Tato kniha je nesmírně zábavná a zároveň hluboká.",
            },
            new()
            {
                Id = 2,
                BookId = 1,
                UserId = 2,
                Rating = 5,
                Comment = "Když jsem poprvé četl Barvu kouzel, byl jsem ohromen Pratchettovým talentem. Jeho postavy jsou živé, zápletka je originální a humor je úžasný. V průběhu knihy jsem se smál na každé stránce.",
            },
            new()
            {
                Id = 3,
                BookId = 1,
                UserId = 3,
                Rating = 4,
                Comment = "Barva kouzel je úžasným začátkem dlouhé série knih ze Zeměplochy od Terryho Pratchetta. Kniha je plná vtipných narážek, alegorií a skvělých postav. Pratchettova imaginace je prostě neomezená.",
            },
            new()
            {
                Id = 4,
                BookId = 1,
                UserId = 4,
                Rating = 4,
                Comment = "Terry Pratchett byl génius a Barva kouzel to dokazuje. Jeho schopnost kombinovat fantasy s komedií a zároveň skvěle komentovat různé aspekty naší společnosti je úžasná. Tato kniha je klenotem a musí pro všechny fanoušky fantasy a humoru.",
            },
            new()
            {
                Id = 5,
                BookId = 7,
                UserId = 1,
                Rating = 5,
                Comment = "Harry Potter a Ohnivý pohár je zlomovým dílem v sérii. Rowlingova schopnost rozvíjet svět čarodějů a postavy je úžasná. Tato kniha je plná napětí, dobrodružství a emocí. Nemohl jsem se od ní odtrhnout.",
            },
            new()
            {
                Id = 6,
                BookId = 7,
                UserId = 2,
                Rating = 4,
                Comment = "Kniha Harry Potter a Ohnivý pohár je nejen temnější než předchozí díly, ale také daleko složitější. Rowling zde ukazuje, že její příběh není určen jen pro děti. Děj je napínavý a postavy procházejí důležitými změnami.",
            },
            new()
            {
                Id = 7,
                BookId = 7,
                UserId = 3,
                Rating = 5,
                Comment = "Harry Potterova čtvrtá dobrodružství v Ohnivém poháru jsou fantastická. Tato kniha se vyznačuje neuvěřitelným nasazením a soubojem na Turnaji tří kouzel. Rowlingova schopnost vytvořit komplexní a poutavý příběh zůstává nepřekonaná.",
            },
            new()
            {
                Id = 8,
                BookId = 7,
                UserId = 4,
                Rating = 5,
                Comment = "Harry Potter a Ohnivý pohár je dalším důkazem Rowlinginy brilantní schopnosti psát pro různé věkové kategorie. Tato kniha je poutavá, plná tajemství a emocí, a dokazuje, proč je série Harryho Pottera tak oblíbená po celém světě.",
            },
        };
    }

    private static IEnumerable<CartItem> PrepareCartItemModels()
    {
        return new List<CartItem>
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
    }

    private static IEnumerable<Order> PrepareOrderModels()
    {
        return new List<Order>
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
    }

    private static IEnumerable<OrderItem> PrepareOrderItemModels()
    {
        return new List<OrderItem>
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
    }
}
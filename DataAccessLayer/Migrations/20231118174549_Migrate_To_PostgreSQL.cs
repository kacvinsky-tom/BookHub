using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migrate_To_PostgreSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ISBN = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    PublisherId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    VoucherUsedId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Vouchers_VoucherUsedId",
                        column: x => x.VoucherUsedId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WishListId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishListItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WishListItems_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ISBN = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Stephen", "King", null },
                    { 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "J. K.", "Rowling", null },
                    { 3, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "George R. R.", "Martin", null },
                    { 4, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Terry", "Pratchett", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Horor", null },
                    { 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Fantasy", null },
                    { 3, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Sci-Fi", null },
                    { 4, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Romantické", null },
                    { 5, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Krimi", null },
                    { 6, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Mysteriózní", null },
                    { 7, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Thriller", null },
                    { 8, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Dobrodružné", null },
                    { 9, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Akční", null },
                    { 10, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Komedie", null },
                    { 11, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Drama", null },
                    { 12, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Biografie", null },
                    { 13, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Historické romány", null },
                    { 14, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Poezie", null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "State", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "eshop@talpress.cz", "Talpress", "Czech Republic", null },
                    { 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "albatros@albatrosmedia.cz", "Albatros", "Czech Republic", null },
                    { 3, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "argo@argo.cz", "Argo", "Czech Republic", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsAdmin", "LastName", "Password", "PhoneNumber", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "john.doe@gmail.com", "John", true, "Doe", "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", "752 685 143", null, "john.doe" },
                    { 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "jane.doe@gmai.com", "Jane", false, "Doe", "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", "746 692 352", null, "jane.doe" },
                    { 3, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "pavel.kraus@gmail.com", "Pavel", false, "Kraus", "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", "748 242 562", null, "pavel.kraus" },
                    { 4, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "jarda@novak.cz", "Jarda", false, "Novák", "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", "742 942 934", null, "jarda.novak" }
                });

            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "Id", "Code", "CreatedAt", "Discount", "ExpirationDate", "Quantity", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "VANOCE10", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 10, new DateTime(2023, 12, 24, 12, 0, 0, 0, DateTimeKind.Utc), 0, 0, null },
                    { 2, "KILODOLU", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 100, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, 1, null },
                    { 3, "ZIMNISLEVA", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 20, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAt", "Description", "ISBN", "Image", "IsDeleted", "Price", "PublisherId", "Quantity", "ReleaseYear", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Ve světě, který leží na krunýři obrovské želvy, se vydává na cestu rozverná, temperamentní a neuvěřitelně výstřední výprava. Setkáte se s lakomým a naprosto neschopným čarodějem Mrakoplašem, naivním turistou Dvoukvítkem, jehož Zavazadlo za ním běhá jako pes na stovce malých nožiček, s draky, kteří existují, pokud na ně opravdu věříte, a samozřejmě dojdete až na okraj této podivné planety.", "978-80-7197-614-1", null, false, 399, 1, 7, 1993, "Barva kouzel", null },
                    { 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Harry Potter je sirotek, který žije u svých příbuzných Dursleyových. Jeho rodiče byli mocní čarodějové, kteří zahynuli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harryho rodiče zanechali svého syna v péči svého přítele, kouzelníka Albusa Brumbála, ředitele Školy čar a kouzel v Bradavicích. Harryho příbuzní o jeho magických schopnostech nevědí, protože se bojí, že by ho mohli zavděčit. Harryho život je plný ponižování a šikany, ale v den jeho jedenáctých narozenin se vše změní. Harry dostane dopis od Brumbála, který ho pozve na Školu čar a kouzel v Bradavicích. Harry se dozví, že je čaroděj a že jeho rodiče zemřeli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harry se vydává do Bradavic, kde se seznámí s Ronem Weasleym a Hermionou Grangerovou, kteří se stanou jeho nejlepšími přáteli. Harry se také dozví, že Voldemort přežil a že se chystá získat Kámen mudrců, který mu pomůže znovu získat svou moc.", "978-80-7197-614-1", null, false, 399, 2, 17, 1997, "Harry Potter a Kámen mudrců", null },
                    { 3, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Když král Robert rozhodne, že jeho nejstarší přítel Eddard Stark bude jeho pravou rukou, nevědomky odstartuje události, které otřesou celým kontinentem. Eddard se totiž snaží vyšetřit tajemnou smrt předchozího krájů a nastoupit na své nové místo, ale brzy zjistí, že je vše mnohem složitější, než se zdálo. Na jihu se totiž připravuje vzpoura a v záloze číhá starodávné zlo, které se probouzí.", "978-80-257-2891-5", null, false, 699, 3, 15, 1996, "Hra o trůny", null },
                    { 4, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "V roce 1958 se sedmička přátel z Derry, malého městečka v americkém státě Maine, vydává do kanalizace, aby zničila zlého klauna Pennywaise, který se zde ukrývá. Sedmička však zjistí, že Pennywise je jen jedním z mnoha podob zla, které se ukrývá v Derry. Ze slibu se však stane kletba a sedmička se musí v roce 1985 vrátit do Derry, aby zlo zničila jednou provždy.", "978-80-7197-614-1", null, false, 799, 1, 2, 1986, "To", null },
                    { 5, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Harry Potter, Ron Weasley a Hermiona Grangerová se vrací do Bradavic, kde se dozvědí o Tajemné komnatě, která je úzce spojena s Harrym. Harry se rozhodne najít Tajemnou komnatu a zjistit, co se tam skrývá. Harryho plán je však zmařen, když se objeví záhadný písař. Harryho přítel Ron je napaden a jeho sestra Ginny zmizí. Harry, Ron a Hermiona se tak vydávají do Tajemné komnaty, aby zjistili, co se tam skrývá a zachránili Ginny.", "978-80-7197-614-1", null, false, 399, 2, 9, 1998, "Harry Potter a Tajemná komnata", null },
                    { 6, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Harry Potter se vrací do Bradavic, ale tentokrát se musí vyhýbat nebezpečnému vězni jménem Sirius Black, který utekl z Azkabanu. Harry se dozví, že Sirius byl vězněn kvůli tomu, že zradil jeho rodiče a že se chystá Harryho zabít. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že Sirius není tím, za koho se vydává.", "978-80-7197-614-1", null, false, 399, 2, 11, 1999, "Harry Potter a vězeň z Azkabanu", null },
                    { 7, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Harry Potter se vrací do Bradavic, kde se má konat Turnaj tří kouzelníků. Harry se však dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů.", "978-80-7197-614-1", null, false, 399, 2, 13, 2000, "Harry Potter a Ohnivý pohár", null },
                    { 8, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Do Bradavic přišly temné časy. Po útoku mozkomorů na bratrance Dudleyho Harry ví, že Voldemort udělá cokoli, jen aby ho našel. Mnozí jeho návrat popírají, ale Harry přesto není sám: na Grimmauldově náměstí se schází tajný řád, který chce bojovat proti temným silám. Harry se musí od profesora Snapea naučit, jak se chránit před Voldemortovými útoky na jeho duši. Jenže Pán zla je den ode dne silnější a Harrymu dochází čas…", "978-80-7197-614-1", null, false, 399, 2, 13, 2000, "Harry Potter a Fénixův řád", null },
                    { 9, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Moc Lorda Voldemorta stále roste a smrtijedi působí spoušť ve světě mudlů i kouzelníků. Když Harry Potter objeví starou učebnici lektvarů patřící tajemnému princi dvojí krve, spoléhá na její kouzla i přes varování svých kamarádů. Profesor Brumbál poodhaluje Voldemortovu minulost a s Harryho pomocí se snaží odkrýt tajemství jeho nesmrtelnosti. Jenže zlo se dere k moci stále silněji, neštěstí se blíží a Bradavice už nikdy nebudou jako dřív.", "978-80-7197-614-1", null, false, 399, 2, 13, 2005, "Harry Potter a princ dvojí krve", null },
                    { 10, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Harry Potter se vydává na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců. Harry se musí vydat na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců.", "978-80-7197-614-1", null, false, 399, 2, 13, 2007, "Harry Potter a Relikvie smrti", null },
                    { 11, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje. Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje.", "978-80-7197-614-1", null, false, 399, 2, 13, 2016, "Harry Potter a prokleté dítě", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "Status", "TotalPrice", "UpdatedAt", "UserId", "VoucherUsedId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 0, 798, null, 3, null },
                    { 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, 699, null, 4, null },
                    { 3, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 2, 399, null, 2, null }
                });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Můj seznam přání", null, 2 },
                    { 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Zbývající harry potter knížky", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 7 },
                    { 1, 9 },
                    { 1, 11 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 6 },
                    { 2, 8 },
                    { 2, 10 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 6 },
                    { 3, 8 },
                    { 3, 10 },
                    { 4, 2 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 7 },
                    { 4, 9 },
                    { 4, 11 }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 8 },
                    { 2, 2 },
                    { 2, 8 },
                    { 3, 2 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 1 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 5, 2 },
                    { 5, 8 },
                    { 6, 2 },
                    { 6, 8 },
                    { 7, 2 },
                    { 7, 8 },
                    { 8, 2 },
                    { 8, 8 },
                    { 9, 2 },
                    { 9, 8 },
                    { 10, 2 },
                    { 10, 8 },
                    { 11, 2 },
                    { 11, 8 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "BookId", "CreatedAt", "Quantity", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, null, 4 },
                    { 2, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 2, null, 4 },
                    { 3, 2, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "BookId", "CreatedAt", "ISBN", "OrderId", "Price", "Quantity", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "978-80-7197-614-1", 1, 399, 1, "Harry Potter a Relikvie smrti", null },
                    { 2, 11, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "978-80-7197-613-4", 1, 399, 1, "Harry Potter a Prokleté Dítě", null },
                    { 3, 3, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "978-80-7197-612-7", 2, 699, 1, "Hra o trůny", null },
                    { 4, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), "978-80-7197-611-0", 3, 399, 1, "Barva kouzel", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "CreatedAt", "Rating", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Barva kouzel od Terryho Pratchetta je brilantní kombinací fantasy a humoru. Pratchettova schopnost tvořit fantastické světy a vtipně komentovat naši skutečnost je prostě neuvěřitelná. Tato kniha je nesmírně zábavná a zároveň hluboká.", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 5, null, 1 },
                    { 2, 1, "Když jsem poprvé četl Barvu kouzel, byl jsem ohromen Pratchettovým talentem. Jeho postavy jsou živé, zápletka je originální a humor je úžasný. V průběhu knihy jsem se smál na každé stránce.", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 5, null, 2 },
                    { 3, 1, "Barva kouzel je úžasným začátkem dlouhé série knih ze Zeměplochy od Terryho Pratchetta. Kniha je plná vtipných narážek, alegorií a skvělých postav. Pratchettova imaginace je prostě neomezená.", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 4, null, 3 },
                    { 4, 1, "Terry Pratchett byl génius a Barva kouzel to dokazuje. Jeho schopnost kombinovat fantasy s komedií a zároveň skvěle komentovat různé aspekty naší společnosti je úžasná. Tato kniha je klenotem a musí pro všechny fanoušky fantasy a humoru.", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 4, null, 4 },
                    { 5, 7, "Harry Potter a Ohnivý pohár je zlomovým dílem v sérii. Rowlingova schopnost rozvíjet svět čarodějů a postavy je úžasná. Tato kniha je plná napětí, dobrodružství a emocí. Nemohl jsem se od ní odtrhnout.", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 5, null, 1 },
                    { 6, 7, "Kniha Harry Potter a Ohnivý pohár je nejen temnější než předchozí díly, ale také daleko složitější. Rowling zde ukazuje, že její příběh není určen jen pro děti. Děj je napínavý a postavy procházejí důležitými změnami.", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 4, null, 2 },
                    { 7, 7, "Harry Potterova čtvrtá dobrodružství v Ohnivém poháru jsou fantastická. Tato kniha se vyznačuje neuvěřitelným nasazením a soubojem na Turnaji tří kouzel. Rowlingova schopnost vytvořit komplexní a poutavý příběh zůstává nepřekonaná.", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 5, null, 3 },
                    { 8, 7, "Harry Potter a Ohnivý pohár je dalším důkazem Rowlinginy brilantní schopnosti psát pro různé věkové kategorie. Tato kniha je poutavá, plná tajemství a emocí, a dokazuje, proč je série Harryho Pottera tak oblíbená po celém světě.", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), 5, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "WishListItems",
                columns: new[] { "Id", "BookId", "CreatedAt", "UpdatedAt", "WishListId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, 1 },
                    { 2, 3, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, 1 },
                    { 3, 8, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, 2 },
                    { 4, 9, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, 2 },
                    { 5, 10, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, 2 },
                    { 6, 11, new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenreId",
                table: "BookGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VoucherUsedId",
                table: "Orders",
                column: "VoucherUsedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_BookId",
                table: "WishListItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_WishListId",
                table: "WishListItems",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WishListItems");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

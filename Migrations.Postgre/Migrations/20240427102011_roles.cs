using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Postgre.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "WishLists",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WishLists",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "WishListItems",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WishListItems",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vouchers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Vouchers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Vouchers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reviews",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reviews",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Publishers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Publishers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItems",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItems",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Genres",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Genres",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "CartItems",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Books",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Books",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Authors",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Authors",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "86718895-f083-4ba8-8452-b7a4dc9ca99c", "0d8fb324-0996-465b-a7b1-aeaaf327e6a8" });

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 1 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 7, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 11, 2 },
                column: "IsPrimary",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "In a world supported on the back of a giant turtle (sex unknown), a gleeful, explosive, wickedly eccentric expedition sets out. There's an avaricious but inept wizard, a naive tourist whose luggage moves on hundreds of dear little legs, dragons who only exist if you believe in them, and of course THE EDGE of the planet...", "9780060855925", "The Color of Magic" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!", "9781338878929", "Harry Potter and the Sorcerer’s Stone" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Long ago, in a time forgotten, a preternatural event threw the seasons out of balance. In a land where summers can last decades and winters a lifetime, trouble is brewing. The cold is returning, and in the frozen wastes to the north of Winterfell, sinister forces are massing beyond the kingdom’s protective Wall. To the south, the king’s powers are failing—his most trusted adviser dead under mysterious circumstances and his enemies emerging from the shadows of the throne.", "9780553897845", "A Game of Thrones" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Welcome to Derry, Maine ... It’s a small city, a place as hauntingly familiar as your own hometown. Only in Derry the haunting is real ... They were seven teenagers when they first stumbled upon the horror. Now they are grown-up men and women who have gone out into the big world to gain success and happiness. But none of them can withstand the force that has drawn them back to Derry to face the nightmare without an end, and the evil without a name.", "9780450411434", "It" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. But just as he’s packing his bags, Harry receives a warning from a strange impish creature who says that if Harry returns to Hogwarts, disaster will strike.", "9781781100226", "Harry Potter and the Chamber of Secrets" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry Potter, along with his best friends, Ron and Hermione, is about to start his third year at Hogwarts School of Witchcraft and Wizardry. Harry can't wait to get back to school after the summer holidays. (Who wouldn't if they lived with the horrible Dursleys?) But when Harry gets to Hogwarts, the atmosphere is tense. There's an escaped mass murderer on the loose, and the sinister prison guards of Azkaban have been called in to guard the school...", "9781484476253", "Harry Potter and the Prisoner of Azkaban" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "It is the summer holidays and soon Harry Potter will be starting his fourth year at Hogwarts School of Witchcraft and Wizardry. Harry is counting the days: there are new spells to be learnt, more Quidditch to be played, and Hogwarts castle to continue exploring. But Harry needs to be careful - there are unexpected dangers lurking...", "9781781105672", "Harry Potter and the Goblet of Fire" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Dark times have come to Hogwarts. After the Dementors' attack on his cousin Dudley, Harry Potter knows that Voldemort will stop at nothing to find him. There are many who deny the Dark Lord's return, but Harry is not alone: a secret order gathers at Grimmauld Place to fight against the Dark forces. Harry must allow Professor Snape to teach him how to protect himself from Voldemort's savage assaults on his mind. But they are growing stronger by the day and Harry is running out of time ...", "9781338878967", "Harry Potter and the Order of the Phoenix" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "It is the middle of the summer, but there is an unseasonal mist pressing against the windowpanes. Harry Potter is waiting nervously in his bedroom at the Dursleys' house in Privet Drive for a visit from Professor Dumbledore himself. One of the last times he saw the Headmaster, he was in a fierce one-to-one duel with Lord Voldemort, and Harry can't quite believe that Professor Dumbledore will actually appear at the Dursleys' of all places. Why is the Professor coming to visit him now? What is it that cannot wait until Harry returns to Hogwarts in a few weeks' time? Harry's sixth year at Hogwarts has already got off to an unusual start, as the worlds of Muggle and magic start to intertwine...", "9781781100257", "Harry Potter and the Half-Blood Prince" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry has been burdened with a dark, dangerous and seemingly impossible task: that of locating and destroying Voldemort's remaining Horcruxes. Never has Harry felt so alone, or faced a future so full of shadows. But Harry must somehow find within himself the strength to complete the task he has been given. He must leave the warmth, safety and companionship of The Burrow and follow without fear or hesitation the inexorable path laid out for him...", "9781781100264", "Harry Potter and the Deathly Hallows" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "The eighth story, nineteen years later... It was always difficult being Harry Potter, and it isn't much easier now that he is an overworked employee of the Ministry of Magic, a husband, and a father of three school-age children. While Harry grapples with a past that refuses to stay where it belongs, his youngest son, Albus, must struggle with the weight of a family legacy he never wanted. As past and present fuse ominously, both father and son learn the uncomfortable truth: sometimes, darkness comes from unexpected places.", "9780751565362", "Harry Potter and the Cursed Child" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Horror");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Romance");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Crime");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Mystery");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Adventure");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Action");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Humor and Comedy");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Biography");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Historical novels");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Poetry");

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "9781781100264", "Harry Potter and the Deathly Hallows" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "9780751565362", "Harry Potter and the Cursed Child" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "9780553897845", "A Game of Thrones" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "9780060855925", "The Color of Magic" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "State" },
                values: new object[] { "ScribnerPublicity@SimonandSchuster.com", "Scribner", "New York" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name", "State" },
                values: new object[] { "help@pottermore.com", "Pottermore Publishing", "London" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Name", "State" },
                values: new object[] { "BBDPublicity@randomhouse.com", "Bantam", "New York" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Comment",
                value: "Terry Pratchett's The Colour of Magic is a brilliant combination of fantasy and humour. Pratchett's ability to create fantastical worlds and humorously comment on our reality is simply incredible. This book is extremely entertaining and profound at the same time.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Comment",
                value: "When I first read The Colour of Magic, I was amazed by Pratchett's talent. His characters are vivid, the plot is original, and the humor is wonderful. Throughout the book, I laughed at every page.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Comment",
                value: "Mr. Pratchett created a very interesting place with the Discworld series, populated with very interesting and thoroughly human characters, with all the weaknesses of humans, whose activities are written about in a spirit of tremendous humor. I'm glad to have found the series and will enjoy reading more books in it.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Comment",
                value: "Terry Pratchett was a genius and The Colour of Magic proves it. His ability to combine fantasy with comedy while brilliantly commenting on various aspects of our society is amazing. This book is a gem and a must for all fans of fantasy and humor.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Comment",
                value: "Harry Potter and the Goblet of Fire is a turning point in the series. Rowling's ability to develop the world of wizards and characters is amazing. This book is full of suspense, adventure and emotion. I couldn't tear myself away from it.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "Comment",
                value: "Harry Potter and the Goblet of Fire is not only darker than the previous books, but also far more complex. Rowling shows here that her story is not just for children. The plot is suspenseful and the characters go through important changes.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "Comment",
                value: "Harry Potter's fourth adventures in the Goblet of Fire are fantastic. This book features incredible dedication and dueling at the Tournament of Three Spells. Rowling's ability to create a complex and engaging story remains unsurpassed.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "Comment",
                value: "Harry Potter and the Goblet of Fire is further proof of Rowling's brilliant ability to write for a variety of ages. This book is engaging, full of mystery and emotion, and proves why the Harry Potter series is so popular around the world.");

            migrationBuilder.UpdateData(
                table: "Vouchers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "CHRISTMAS");

            migrationBuilder.UpdateData(
                table: "Vouchers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "SALE10");

            migrationBuilder.UpdateData(
                table: "Vouchers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "WINTERSALE");

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "My wish list");

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "The Remaining Harry Potter Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "86718895-f083-4ba8-8452-b7a4dc9ca99c", "0d8fb324-0996-465b-a7b1-aeaaf327e6a8" });

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "WishLists",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WishLists",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "WishListItems",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WishListItems",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vouchers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Vouchers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Vouchers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Publishers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Publishers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItems",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItems",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Genres",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Genres",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "CartItems",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Books",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 1 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 7, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 11, 2 },
                column: "IsPrimary",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Ve světě, který leží na krunýři obrovské želvy, se vydává na cestu rozverná, temperamentní a neuvěřitelně výstřední výprava. Setkáte se s lakomým a naprosto neschopným čarodějem Mrakoplašem, naivním turistou Dvoukvítkem, jehož Zavazadlo za ním běhá jako pes na stovce malých nožiček, s draky, kteří existují, pokud na ně opravdu věříte, a samozřejmě dojdete až na okraj této podivné planety.", "978-80-7197-614-1", "Barva kouzel" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry Potter je sirotek, který žije u svých příbuzných Dursleyových. Jeho rodiče byli mocní čarodějové, kteří zahynuli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harryho rodiče zanechali svého syna v péči svého přítele, kouzelníka Albusa Brumbála, ředitele Školy čar a kouzel v Bradavicích. Harryho příbuzní o jeho magických schopnostech nevědí, protože se bojí, že by ho mohli zavděčit. Harryho život je plný ponižování a šikany, ale v den jeho jedenáctých narozenin se vše změní. Harry dostane dopis od Brumbála, který ho pozve na Školu čar a kouzel v Bradavicích. Harry se dozví, že je čaroděj a že jeho rodiče zemřeli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harry se vydává do Bradavic, kde se seznámí s Ronem Weasleym a Hermionou Grangerovou, kteří se stanou jeho nejlepšími přáteli. Harry se také dozví, že Voldemort přežil a že se chystá získat Kámen mudrců, který mu pomůže znovu získat svou moc.", "978-80-7197-614-1", "Harry Potter a Kámen mudrců" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Když král Robert rozhodne, že jeho nejstarší přítel Eddard Stark bude jeho pravou rukou, nevědomky odstartuje události, které otřesou celým kontinentem. Eddard se totiž snaží vyšetřit tajemnou smrt předchozího krájů a nastoupit na své nové místo, ale brzy zjistí, že je vše mnohem složitější, než se zdálo. Na jihu se totiž připravuje vzpoura a v záloze číhá starodávné zlo, které se probouzí.", "978-80-257-2891-5", "Hra o trůny" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "V roce 1958 se sedmička přátel z Derry, malého městečka v americkém státě Maine, vydává do kanalizace, aby zničila zlého klauna Pennywaise, který se zde ukrývá. Sedmička však zjistí, že Pennywise je jen jedním z mnoha podob zla, které se ukrývá v Derry. Ze slibu se však stane kletba a sedmička se musí v roce 1985 vrátit do Derry, aby zlo zničila jednou provždy.", "978-80-7197-614-1", "To" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry Potter, Ron Weasley a Hermiona Grangerová se vrací do Bradavic, kde se dozvědí o Tajemné komnatě, která je úzce spojena s Harrym. Harry se rozhodne najít Tajemnou komnatu a zjistit, co se tam skrývá. Harryho plán je však zmařen, když se objeví záhadný písař. Harryho přítel Ron je napaden a jeho sestra Ginny zmizí. Harry, Ron a Hermiona se tak vydávají do Tajemné komnaty, aby zjistili, co se tam skrývá a zachránili Ginny.", "978-80-7197-614-1", "Harry Potter a Tajemná komnata" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry Potter se vrací do Bradavic, ale tentokrát se musí vyhýbat nebezpečnému vězni jménem Sirius Black, který utekl z Azkabanu. Harry se dozví, že Sirius byl vězněn kvůli tomu, že zradil jeho rodiče a že se chystá Harryho zabít. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že Sirius není tím, za koho se vydává.", "978-80-7197-614-1", "Harry Potter a vězeň z Azkabanu" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry Potter se vrací do Bradavic, kde se má konat Turnaj tří kouzelníků. Harry se však dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů.", "978-80-7197-614-1", "Harry Potter a Ohnivý pohár" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Do Bradavic přišly temné časy. Po útoku mozkomorů na bratrance Dudleyho Harry ví, že Voldemort udělá cokoli, jen aby ho našel. Mnozí jeho návrat popírají, ale Harry přesto není sám: na Grimmauldově náměstí se schází tajný řád, který chce bojovat proti temným silám. Harry se musí od profesora Snapea naučit, jak se chránit před Voldemortovými útoky na jeho duši. Jenže Pán zla je den ode dne silnější a Harrymu dochází čas…", "978-80-7197-614-1", "Harry Potter a Fénixův řád" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Moc Lorda Voldemorta stále roste a smrtijedi působí spoušť ve světě mudlů i kouzelníků. Když Harry Potter objeví starou učebnici lektvarů patřící tajemnému princi dvojí krve, spoléhá na její kouzla i přes varování svých kamarádů. Profesor Brumbál poodhaluje Voldemortovu minulost a s Harryho pomocí se snaží odkrýt tajemství jeho nesmrtelnosti. Jenže zlo se dere k moci stále silněji, neštěstí se blíží a Bradavice už nikdy nebudou jako dřív.", "978-80-7197-614-1", "Harry Potter a princ dvojí krve" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry Potter se vydává na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců. Harry se musí vydat na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců.", "978-80-7197-614-1", "Harry Potter a Relikvie smrti" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ISBN", "Title" },
                values: new object[] { "Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje. Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje.", "978-80-7197-614-1", "Harry Potter a prokleté dítě" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Horor");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Romantické");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Krimi");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Mysteriózní");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Dobrodružné");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Akční");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Komedie");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Biografie");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Historické romány");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Poezie");

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978-80-7197-614-1", "Harry Potter a Relikvie smrti" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978-80-7197-613-4", "Harry Potter a Prokleté Dítě" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978-80-7197-612-7", "Hra o trůny" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978-80-7197-611-0", "Barva kouzel" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "State" },
                values: new object[] { "eshop@talpress.cz", "Talpress", "Czech Republic" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name", "State" },
                values: new object[] { "albatros@albatrosmedia.cz", "Albatros", "Czech Republic" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Name", "State" },
                values: new object[] { "argo@argo.cz", "Argo", "Czech Republic" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Comment",
                value: "Barva kouzel od Terryho Pratchetta je brilantní kombinací fantasy a humoru. Pratchettova schopnost tvořit fantastické světy a vtipně komentovat naši skutečnost je prostě neuvěřitelná. Tato kniha je nesmírně zábavná a zároveň hluboká.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Comment",
                value: "Když jsem poprvé četl Barvu kouzel, byl jsem ohromen Pratchettovým talentem. Jeho postavy jsou živé, zápletka je originální a humor je úžasný. V průběhu knihy jsem se smál na každé stránce.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Comment",
                value: "Barva kouzel je úžasným začátkem dlouhé série knih ze Zeměplochy od Terryho Pratchetta. Kniha je plná vtipných narážek, alegorií a skvělých postav. Pratchettova imaginace je prostě neomezená.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Comment",
                value: "Terry Pratchett byl génius a Barva kouzel to dokazuje. Jeho schopnost kombinovat fantasy s komedií a zároveň skvěle komentovat různé aspekty naší společnosti je úžasná. Tato kniha je klenotem a musí pro všechny fanoušky fantasy a humoru.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Comment",
                value: "Harry Potter a Ohnivý pohár je zlomovým dílem v sérii. Rowlingova schopnost rozvíjet svět čarodějů a postavy je úžasná. Tato kniha je plná napětí, dobrodružství a emocí. Nemohl jsem se od ní odtrhnout.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "Comment",
                value: "Kniha Harry Potter a Ohnivý pohár je nejen temnější než předchozí díly, ale také daleko složitější. Rowling zde ukazuje, že její příběh není určen jen pro děti. Děj je napínavý a postavy procházejí důležitými změnami.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "Comment",
                value: "Harry Potterova čtvrtá dobrodružství v Ohnivém poháru jsou fantastická. Tato kniha se vyznačuje neuvěřitelným nasazením a soubojem na Turnaji tří kouzel. Rowlingova schopnost vytvořit komplexní a poutavý příběh zůstává nepřekonaná.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "Comment",
                value: "Harry Potter a Ohnivý pohár je dalším důkazem Rowlinginy brilantní schopnosti psát pro různé věkové kategorie. Tato kniha je poutavá, plná tajemství a emocí, a dokazuje, proč je série Harryho Pottera tak oblíbená po celém světě.");

            migrationBuilder.UpdateData(
                table: "Vouchers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "VANOCE10");

            migrationBuilder.UpdateData(
                table: "Vouchers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "KILODOLU");

            migrationBuilder.UpdateData(
                table: "Vouchers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "ZIMNISLEVA");

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Můj seznam přání");

            migrationBuilder.UpdateData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Zbývající harry potter knížky");
        }
    }
}

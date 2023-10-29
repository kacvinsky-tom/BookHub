using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookHub.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2391), "Stephen", "King", null },
                    { 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2395), "J. K.", "Rowling", null },
                    { 3, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2397), "George R. R.", "Martin", null },
                    { 4, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2399), "Terry", "Pratchett", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2360), "Horor", null },
                    { 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2363), "Fantasy", null },
                    { 3, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2365), "Sci-Fi", null },
                    { 4, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2367), "Romantické", null },
                    { 5, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2368), "Krimi", null },
                    { 6, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2373), "Mysteriózní", null },
                    { 7, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2375), "Thriller", null },
                    { 8, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2377), "Dobrodružné", null },
                    { 9, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2378), "Akční", null },
                    { 10, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2381), "Komedie", null },
                    { 11, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2383), "Drama", null },
                    { 12, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2385), "Biografie", null },
                    { 13, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2386), "Historické romány", null },
                    { 14, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2388), "Poezie", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsAdmin", "LastName", "Password", "PhoneNumber", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2302), "john.doe@gmail.com", "John", true, "Doe", "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", "752 685 143", null, "john.doe" },
                    { 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2348), "jane.doe@gmai.com", "Jane", false, "Doe", "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", "746 692 352", null, "jane.doe" },
                    { 3, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2351), "pavel.kraus@gmail.com", "Pavel", false, "Kraus", "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", "748 242 562", null, "pavel.kraus" },
                    { 4, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2354), "jarda@novak.cz", "Jarda", false, "Novák", "$2a$12$9NC8nfoll0NYTn40Jc79gu7BL9sXfrZTtuhHvuT9O0uDT0/rTCOJi", "742 942 934", null, "jarda.novak" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Description", "ISBN", "Image", "IsDeleted", "Price", "Publisher", "Quantity", "ReleaseYear", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2405), "Ve světě, který leží na krunýři obrovské želvy, se vydává na cestu rozverná, temperamentní a neuvěřitelně výstřední výprava. Setkáte se s lakomým a naprosto neschopným čarodějem Mrakoplašem, naivním turistou Dvoukvítkem, jehož Zavazadlo za ním běhá jako pes na stovce malých nožiček, s draky, kteří existují, pokud na ně opravdu věříte, a samozřejmě dojdete až na okraj této podivné planety.", "978-80-7197-614-1", null, false, 399, "Talpress", 7, 1993, "Barva kouzel", null },
                    { 2, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2413), "Harry Potter je sirotek, který žije u svých příbuzných Dursleyových. Jeho rodiče byli mocní čarodějové, kteří zahynuli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harryho rodiče zanechali svého syna v péči svého přítele, kouzelníka Albusa Brumbála, ředitele Školy čar a kouzel v Bradavicích. Harryho příbuzní o jeho magických schopnostech nevědí, protože se bojí, že by ho mohli zavděčit. Harryho život je plný ponižování a šikany, ale v den jeho jedenáctých narozenin se vše změní. Harry dostane dopis od Brumbála, který ho pozve na Školu čar a kouzel v Bradavicích. Harry se dozví, že je čaroděj a že jeho rodiče zemřeli při souboji s nejtemnějším čarodějem všech dob, Lordem Voldemortem. Harry se vydává do Bradavic, kde se seznámí s Ronem Weasleym a Hermionou Grangerovou, kteří se stanou jeho nejlepšími přáteli. Harry se také dozví, že Voldemort přežil a že se chystá získat Kámen mudrců, který mu pomůže znovu získat svou moc.", "978-80-7197-614-1", null, false, 399, "Albatros", 17, 1997, "Harry Potter a Kámen mudrců", null },
                    { 3, 3, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2416), "Když král Robert rozhodne, že jeho nejstarší přítel Eddard Stark bude jeho pravou rukou, nevědomky odstartuje události, které otřesou celým kontinentem. Eddard se totiž snaží vyšetřit tajemnou smrt předchozího krájů a nastoupit na své nové místo, ale brzy zjistí, že je vše mnohem složitější, než se zdálo. Na jihu se totiž připravuje vzpoura a v záloze číhá starodávné zlo, které se probouzí.", "978-80-257-2891-5", null, false, 699, "Argo", 15, 1996, "Hra o trůny", null },
                    { 4, 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2418), "V roce 1958 se sedmička přátel z Derry, malého městečka v americkém státě Maine, vydává do kanalizace, aby zničila zlého klauna Pennywaise, který se zde ukrývá. Sedmička však zjistí, že Pennywise je jen jedním z mnoha podob zla, které se ukrývá v Derry. Ze slibu se však stane kletba a sedmička se musí v roce 1985 vrátit do Derry, aby zlo zničila jednou provždy.", "978-80-7197-614-1", null, false, 799, "Talpress", 2, 1986, "To", null },
                    { 5, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2421), "Harry Potter, Ron Weasley a Hermiona Grangerová se vrací do Bradavic, kde se dozvědí o Tajemné komnatě, která je úzce spojena s Harrym. Harry se rozhodne najít Tajemnou komnatu a zjistit, co se tam skrývá. Harryho plán je však zmařen, když se objeví záhadný písař. Harryho přítel Ron je napaden a jeho sestra Ginny zmizí. Harry, Ron a Hermiona se tak vydávají do Tajemné komnaty, aby zjistili, co se tam skrývá a zachránili Ginny.", "978-80-7197-614-1", null, false, 399, "Albatros", 9, 1998, "Harry Potter a Tajemná komnata", null },
                    { 6, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2425), "Harry Potter se vrací do Bradavic, ale tentokrát se musí vyhýbat nebezpečnému vězni jménem Sirius Black, který utekl z Azkabanu. Harry se dozví, že Sirius byl vězněn kvůli tomu, že zradil jeho rodiče a že se chystá Harryho zabít. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že Sirius není tím, za koho se vydává.", "978-80-7197-614-1", null, false, 399, "Albatros", 11, 1999, "Harry Potter a vězeň z Azkabanu", null },
                    { 7, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2453), "Harry Potter se vrací do Bradavic, kde se má konat Turnaj tří kouzelníků. Harry se však dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů. Harry se vydává na cestu, která ho zavede do minulosti, kde se dozví, že se do turnaje dostal podvodem a že se musí zúčastnit tří nebezpečných úkolů.", "978-80-7197-614-1", null, false, 399, "Albatros", 13, 2000, "Harry Potter a Ohnivý pohár", null },
                    { 8, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2457), "Do Bradavic přišly temné časy. Po útoku mozkomorů na bratrance Dudleyho Harry ví, že Voldemort udělá cokoli, jen aby ho našel. Mnozí jeho návrat popírají, ale Harry přesto není sám: na Grimmauldově náměstí se schází tajný řád, který chce bojovat proti temným silám. Harry se musí od profesora Snapea naučit, jak se chránit před Voldemortovými útoky na jeho duši. Jenže Pán zla je den ode dne silnější a Harrymu dochází čas…", "978-80-7197-614-1", null, false, 399, "Albatros", 13, 2000, "Harry Potter a Fénixův řád", null },
                    { 9, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2460), "Moc Lorda Voldemorta stále roste a smrtijedi působí spoušť ve světě mudlů i kouzelníků. Když Harry Potter objeví starou učebnici lektvarů patřící tajemnému princi dvojí krve, spoléhá na její kouzla i přes varování svých kamarádů. Profesor Brumbál poodhaluje Voldemortovu minulost a s Harryho pomocí se snaží odkrýt tajemství jeho nesmrtelnosti. Jenže zlo se dere k moci stále silněji, neštěstí se blíží a Bradavice už nikdy nebudou jako dřív.", "978-80-7197-614-1", null, false, 399, "Albatros", 13, 2005, "Harry Potter a princ dvojí krve", null },
                    { 10, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2463), "Harry Potter se vydává na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců. Harry se musí vydat na nebezpečnou cestu, aby zničil poslední Voldemortovy viteály. Společně s Ronem a Hermionou hledá zbytek Voldemortovy duše, který se ukrývá v tělech jeho nejmocnějších stoupenců.", "978-80-7197-614-1", null, false, 399, "Albatros", 13, 2007, "Harry Potter a Relikvie smrti", null },
                    { 11, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2466), "Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje. Harry Potter je zaměstnán v Ministerstvu kouzel a má tři školáky. Jeho minulost ho však neustále pronásleduje.", "978-80-7197-614-1", null, false, 399, "Albatros", 13, 2016, "Harry Potter a prokleté dítě", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "Status", "TotalPrice", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2519), 0, 798, null, 3 },
                    { 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2522), 1, 699, null, 4 },
                    { 3, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2524), 2, 399, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2472), "Můj seznam přání", null, 2 },
                    { 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2476), "Zbývající harry potter knížky", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "BookId", "CreatedAt", "Quantity", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2512), 1, null, 4 },
                    { 2, 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2515), 2, null, 4 },
                    { 3, 2, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2517), 1, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "BookId", "CreatedAt", "ISBN", "OrderId", "Price", "Quantity", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2527), "978-80-7197-614-1", 1, 399, 1, "Harry Potter a Relikvie smrti", null },
                    { 2, 11, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2530), "978-80-7197-613-4", 1, 399, 1, "Harry Potter a Prokleté Dítě", null },
                    { 3, 3, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2533), "978-80-7197-612-7", 2, 699, 1, "Hra o trůny", null },
                    { 4, 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2535), "978-80-7197-611-0", 3, 399, 1, "Barva kouzel", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "CreatedAt", "Rating", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Barva kouzel od Terryho Pratchetta je brilantní kombinací fantasy a humoru. Pratchettova schopnost tvořit fantastické světy a vtipně komentovat naši skutečnost je prostě neuvěřitelná. Tato kniha je nesmírně zábavná a zároveň hluboká.", new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2492), 5, null, 1 },
                    { 2, 1, "Když jsem poprvé četl Barvu kouzel, byl jsem ohromen Pratchettovým talentem. Jeho postavy jsou živé, zápletka je originální a humor je úžasný. V průběhu knihy jsem se smál na každé stránce.", new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2496), 5, null, 2 },
                    { 3, 1, "Barva kouzel je úžasným začátkem dlouhé série knih ze Zeměplochy od Terryho Pratchetta. Kniha je plná vtipných narážek, alegorií a skvělých postav. Pratchettova imaginace je prostě neomezená.", new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2498), 4, null, 3 },
                    { 4, 1, "Terry Pratchett byl génius a Barva kouzel to dokazuje. Jeho schopnost kombinovat fantasy s komedií a zároveň skvěle komentovat různé aspekty naší společnosti je úžasná. Tato kniha je klenotem a musí pro všechny fanoušky fantasy a humoru.", new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2500), 4, null, 4 },
                    { 5, 7, "Harry Potter a Ohnivý pohár je zlomovým dílem v sérii. Rowlingova schopnost rozvíjet svět čarodějů a postavy je úžasná. Tato kniha je plná napětí, dobrodružství a emocí. Nemohl jsem se od ní odtrhnout.", new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2502), 5, null, 1 },
                    { 6, 7, "Kniha Harry Potter a Ohnivý pohár je nejen temnější než předchozí díly, ale také daleko složitější. Rowling zde ukazuje, že její příběh není určen jen pro děti. Děj je napínavý a postavy procházejí důležitými změnami.", new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2504), 4, null, 2 },
                    { 7, 7, "Harry Potterova čtvrtá dobrodružství v Ohnivém poháru jsou fantastická. Tato kniha se vyznačuje neuvěřitelným nasazením a soubojem na Turnaji tří kouzel. Rowlingova schopnost vytvořit komplexní a poutavý příběh zůstává nepřekonaná.", new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2506), 5, null, 3 },
                    { 8, 7, "Harry Potter a Ohnivý pohár je dalším důkazem Rowlinginy brilantní schopnosti psát pro různé věkové kategorie. Tato kniha je poutavá, plná tajemství a emocí, a dokazuje, proč je série Harryho Pottera tak oblíbená po celém světě.", new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2508), 5, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "WishListItems",
                columns: new[] { "Id", "BookId", "CreatedAt", "UpdatedAt", "WishListId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2479), null, 1 },
                    { 2, 3, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2482), null, 1 },
                    { 3, 8, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2484), null, 2 },
                    { 4, 9, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2485), null, 2 },
                    { 5, 10, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2487), null, 2 },
                    { 6, 11, new DateTime(2023, 10, 15, 20, 41, 45, 921, DateTimeKind.Local).AddTicks(2489), null, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WishListItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

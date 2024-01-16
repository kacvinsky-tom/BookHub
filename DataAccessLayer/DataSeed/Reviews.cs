using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class Reviews
{
    public static IEnumerable<Review> PrepareModels()
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
        reviews.ForEach(review =>
            review.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return reviews;
    }
}

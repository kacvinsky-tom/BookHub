using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class Books
{
    public static IEnumerable<Book> PrepareModels()
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
        books.ForEach(book =>
            book.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return books;
    }
}

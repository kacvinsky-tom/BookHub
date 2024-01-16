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
                Title = "The Color of Magic",
                ISBN = "9780060855925",
                Description =
                    "In a world supported on the back of a giant turtle (sex unknown), a gleeful, explosive, wickedly eccentric expedition sets out. There's an avaricious but inept wizard, a naive tourist whose luggage moves on hundreds of dear little legs, dragons who only exist if you believe in them, and of course THE EDGE of the planet...",
                Price = 399,
                Quantity = 7,
                ReleaseYear = 1993,
                PublisherId = 1,
            },
            new()
            {
                Id = 2,
                Title = "Harry Potter and the Sorcerer’s Stone",
                ISBN = "9781338878929",
                Description =
                    "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!",
                Price = 399,
                Quantity = 17,
                ReleaseYear = 1997,
                PublisherId = 2,
            },
            new()
            {
                Id = 3,
                Title = "A Game of Thrones",
                ISBN = "9780553897845",
                Description =
                    "Long ago, in a time forgotten, a preternatural event threw the seasons out of balance. In a land where summers can last decades and winters a lifetime, trouble is brewing. The cold is returning, and in the frozen wastes to the north of Winterfell, sinister forces are massing beyond the kingdom’s protective Wall. To the south, the king’s powers are failing—his most trusted adviser dead under mysterious circumstances and his enemies emerging from the shadows of the throne.",
                Price = 699,
                Quantity = 15,
                ReleaseYear = 1996,
                PublisherId = 3,
            },
            new()
            {
                Id = 4,
                Title = "It",
                ISBN = "9780450411434",
                Description =
                    "Welcome to Derry, Maine ... It’s a small city, a place as hauntingly familiar as your own hometown. Only in Derry the haunting is real ... They were seven teenagers when they first stumbled upon the horror. Now they are grown-up men and women who have gone out into the big world to gain success and happiness. But none of them can withstand the force that has drawn them back to Derry to face the nightmare without an end, and the evil without a name.",
                Price = 799,
                Quantity = 2,
                ReleaseYear = 1986,
                PublisherId = 1,
            },
            new()
            {
                Id = 5,
                Title = "Harry Potter and the Chamber of Secrets",
                ISBN = "9781781100226",
                Description =
                    "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. But just as he’s packing his bags, Harry receives a warning from a strange impish creature who says that if Harry returns to Hogwarts, disaster will strike.",
                Price = 399,
                Quantity = 9,
                ReleaseYear = 1998,
                PublisherId = 2,
            },
            new()
            {
                Id = 6,
                Title = "Harry Potter and the Prisoner of Azkaban",
                ISBN = "9781484476253",
                Description =
                    "Harry Potter, along with his best friends, Ron and Hermione, is about to start his third year at Hogwarts School of Witchcraft and Wizardry. Harry can't wait to get back to school after the summer holidays. (Who wouldn't if they lived with the horrible Dursleys?) But when Harry gets to Hogwarts, the atmosphere is tense. There's an escaped mass murderer on the loose, and the sinister prison guards of Azkaban have been called in to guard the school...",
                Price = 399,
                Quantity = 11,
                ReleaseYear = 1999,
                PublisherId = 2,
            },
            new()
            {
                Id = 7,
                Title = "Harry Potter and the Goblet of Fire",
                ISBN = "9781781105672",
                Description =
                    "It is the summer holidays and soon Harry Potter will be starting his fourth year at Hogwarts School of Witchcraft and Wizardry. Harry is counting the days: there are new spells to be learnt, more Quidditch to be played, and Hogwarts castle to continue exploring. But Harry needs to be careful - there are unexpected dangers lurking...",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2000,
                PublisherId = 2,
            },
            new()
            {
                Id = 8,
                Title = "Harry Potter and the Order of the Phoenix",
                ISBN = "9781338878967",
                Description =
                    "Dark times have come to Hogwarts. After the Dementors' attack on his cousin Dudley, Harry Potter knows that Voldemort will stop at nothing to find him. There are many who deny the Dark Lord's return, but Harry is not alone: a secret order gathers at Grimmauld Place to fight against the Dark forces. Harry must allow Professor Snape to teach him how to protect himself from Voldemort's savage assaults on his mind. But they are growing stronger by the day and Harry is running out of time ...",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2000,
                PublisherId = 2,
            },
            new()
            {
                Id = 9,
                Title = "Harry Potter and the Half-Blood Prince",
                ISBN = "9781781100257",
                Description =
                    "It is the middle of the summer, but there is an unseasonal mist pressing against the windowpanes. Harry Potter is waiting nervously in his bedroom at the Dursleys' house in Privet Drive for a visit from Professor Dumbledore himself. One of the last times he saw the Headmaster, he was in a fierce one-to-one duel with Lord Voldemort, and Harry can't quite believe that Professor Dumbledore will actually appear at the Dursleys' of all places. Why is the Professor coming to visit him now? What is it that cannot wait until Harry returns to Hogwarts in a few weeks' time? Harry's sixth year at Hogwarts has already got off to an unusual start, as the worlds of Muggle and magic start to intertwine...",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2005,
                PublisherId = 2,
            },
            new()
            {
                Id = 10,
                Title = "Harry Potter and the Deathly Hallows",
                ISBN = "9781781100264",
                Description =
                    "Harry has been burdened with a dark, dangerous and seemingly impossible task: that of locating and destroying Voldemort's remaining Horcruxes. Never has Harry felt so alone, or faced a future so full of shadows. But Harry must somehow find within himself the strength to complete the task he has been given. He must leave the warmth, safety and companionship of The Burrow and follow without fear or hesitation the inexorable path laid out for him...",
                Price = 399,
                Quantity = 13,
                ReleaseYear = 2007,
                PublisherId = 2,
            },
            new()
            {
                Id = 11,
                Title = "Harry Potter and the Cursed Child",
                ISBN = "9780751565362",
                Description =
                    "The eighth story, nineteen years later... It was always difficult being Harry Potter, and it isn't much easier now that he is an overworked employee of the Ministry of Magic, a husband, and a father of three school-age children. While Harry grapples with a past that refuses to stay where it belongs, his youngest son, Albus, must struggle with the weight of a family legacy he never wanted. As past and present fuse ominously, both father and son learn the uncomfortable truth: sometimes, darkness comes from unexpected places.",
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

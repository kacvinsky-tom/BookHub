using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class IdentityUsers
{
    public static IEnumerable<LocalIdentityUser> PrepareModels()
    {
        // PW to default accounts: "P@ssw0rd"
        var users = Users.PrepareModels();
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
            .Select(u => new LocalIdentityUser()
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
            })
            .ToList();
        return identityUsers;
    }
}

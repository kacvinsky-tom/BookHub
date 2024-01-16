using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.DataSeed;

internal static class UserRoles
{
    public static IEnumerable<IdentityUserRole<string>> PrepareRelations()
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
}

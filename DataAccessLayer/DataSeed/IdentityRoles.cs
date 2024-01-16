using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class IdentityRoles
{
    public static IEnumerable<LocalIdentityRole> PrepareModels()
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
}

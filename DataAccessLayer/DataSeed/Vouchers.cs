using DataAccessLayer.Entity;
using DataAccessLayer.Enum;

namespace DataAccessLayer.DataSeed;

internal static class Vouchers
{
    public static IEnumerable<Voucher> PrepareModels()
    {
        var vouchers = new List<Voucher>()
        {
            new()
            {
                Id = 1,
                Code = "VANOCE10",
                Discount = 10,
                ExpirationDate = new DateTime(2023, 12, 24, 12, 00, 00, DateTimeKind.Utc),
                Type = VoucherType.Percentage
            },
            new()
            {
                Id = 2,
                Code = "KILODOLU",
                Discount = 100,
                ExpirationDate = new DateTime(2023, 11, 1, 0, 0, 0, DateTimeKind.Utc),
                Type = VoucherType.FixedAmount
            },
            new()
            {
                Id = 3,
                Code = "ZIMNISLEVA",
                Discount = 20,
                ExpirationDate = new DateTime(2024, 1, 31, 0, 0, 0, DateTimeKind.Utc),
                Type = VoucherType.Percentage
            },
        };
        vouchers.ForEach(v =>
            v.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return vouchers;
    }
}

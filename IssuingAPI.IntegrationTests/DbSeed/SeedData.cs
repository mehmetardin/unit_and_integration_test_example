using Issuing.Domain.Entities;
using Issuing.Persistence;

namespace IssuingAPI.IntegrationTests.DbSeed
{
    public class SeedData
    {
        internal static void PopulateTestData(StoreContext appDb)
        {
            appDb.Cards.Add(new Card { Bin = "abcd", CardNo = "123456" });
            appDb.SaveChangesAsync();
        }
    }
}

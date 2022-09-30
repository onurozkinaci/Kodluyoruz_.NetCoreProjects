using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context)
        {
           context.Siparisler.AddRange(
              new Siparislerim{
              CustomerId = 1,
              FilmId = 1,
              Fiyat = 145.4,
              SatinAlmaTarihi = new DateTime(2022,09,24)
            },
            new Siparislerim
            {
                CustomerId = 1,
                FilmId = 2,
                Fiyat = 150,
                SatinAlmaTarihi = new DateTime(2022,08,22),
                //IsActive = false
            },
            new Siparislerim
            {
                CustomerId = 2,
                FilmId = 2,
                Fiyat = 150,
                SatinAlmaTarihi = new DateTime(2022,09,23)
            },
            new Siparislerim
            {
                CustomerId = 3,
                FilmId = 3,
                Fiyat = 95,
                SatinAlmaTarihi = new DateTime(2022,09,23)
            });
        }
    }
}
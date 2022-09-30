using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
           context.Oyuncular.AddRange(
              new Oyuncu{Name = "Brad",Surname = "Pitt"},
              new Oyuncu{Name = "Edward",Surname = "Norton"},
              new Oyuncu{Name = "Haluk",Surname = "Bilginer"},
              new Oyuncu{Name = "Derya",Surname = "Alabora"}
           );
        }
    }
}
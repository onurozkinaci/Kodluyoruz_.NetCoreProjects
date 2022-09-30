using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class ActorMovies
    {
        public static void AddActorMovies(this MovieStoreDbContext context) //MovieStoreDbContext uzerinden extension metot olarak cagrilabilecek.
        {
           context.OyuncuFilm.AddRange(
               new OyuncuFilm{OyuncuId = 1,FilmId = 1},
               new OyuncuFilm{OyuncuId = 1,FilmId = 2},
               new OyuncuFilm{OyuncuId = 2,FilmId = 1},
               new OyuncuFilm{OyuncuId = 3,FilmId = 3},
               new OyuncuFilm{OyuncuId = 4,FilmId = 3}
           );
        }
    }
}
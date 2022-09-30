using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
           context.Films.AddRange(
              new Film{ Name = "Fight Club",GenreId = 5, Price = 145.4,YonetmenId = 1},
              new Film{ Name = "Seven",GenreId = 5,Price = 150,YonetmenId = 1},
              new Film{Name = "Masumiyet",GenreId = 6,Price = 95,YonetmenId = 2}
           );
        }
    }
}
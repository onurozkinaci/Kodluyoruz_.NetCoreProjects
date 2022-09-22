using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{
     public static class Genres
     {
        //BookStoreDbContext uzerinden erisilebilecek bir extension metot yaratildi("this" keyword'unu parametre olarak bu objenin basinda kullanarak);
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
             new Genre{Name = "Personal Growth",},
             new Genre{ Name = "Science Fiction",},
             new Genre{Name = "Roman"});
        }
      }
}
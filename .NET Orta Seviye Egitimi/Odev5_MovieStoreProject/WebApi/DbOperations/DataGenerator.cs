using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
  public class DataGenerator
  {
     public static void Initialize(IServiceProvider serviceProvider)
     {
        using(var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
        {
           if(context.Films.Any()) //db'deki Films tablosunda veri mevcutsa yeniden eklemeyecek, mevcut degilse ekleme yapacak.
              return;
          
          context.Genres.AddRange(
             new Genre{Name = "Science Fiction"}, new Genre{Name = "Romance"},
             new Genre{Name = "Comedy"}, new Genre{Name = "Horror"}, 
             new Genre{Name = "Action"}, new Genre{Name = "Dram"}
           );

          context.Yonetmenler.AddRange(
             new Yonetmen
             {
                Name = "David",
                Surname = "Fincher",
                //YonetilenFilmler = {context.Films.SingleOrDefault(x=>x.Id == 1),context.Films.SingleOrDefault(x=>x.Id == 2)}
             },
             new Yonetmen
             {
                Name = "Zeki",
                Surname = "Demirkubuz",
                //YonetilenFilmler = {context.Films.SingleOrDefault(x=>x.Id == 3)}
             }
          );
        
        context.Films.AddRange(
            new Film
            {
              Name = "Fight Club",
              GenreId = 5, //Action
              Price = 145.4,
              YonetmenId = 1,
            },
            new Film
            {
              Name = "Seven",
              GenreId = 5, //Action
              Price = 150,
              YonetmenId = 1,
            },
            new Film
            {
              Name = "Masumiyet",
              GenreId = 6, //Dram
              Price = 95,
              YonetmenId = 2,
            }
          );

          context.Oyuncular.AddRange(
            new Oyuncu
            {
              Name = "Brad",
              Surname = "Pitt"
            },
            new Oyuncu
            {
              Name = "Edward",
              Surname = "Norton"
            },
            new Oyuncu
            {
              Name = "Haluk",
              Surname = "Bilginer"
            },
            new Oyuncu
            {
              Name = "Derya",
              Surname = "Alabora"
            }
          );
          
          //context.SaveChanges(); //context uzerinden genrelara ulasabilmek icin bir kez calistiriyoruz.
          context.Customers.AddRange(
            new Customer
            {
              Name = "Onur",
              Surname = "Ozk",
              Email = "onrozk@gmail.com"
              /*FavoriteGenres = {context.Genres.SingleOrDefault(x=>x.Id == 1), context.Genres.SingleOrDefault(x=>x.Id == 2),
                 context.Genres.SingleOrDefault(x =>x.Id == 3)}*/
            },
            new Customer
            {
              Name = "Tugce",
              Surname = "Kazakci",
              Email = "tkazakci@gmail.com" /*,
              FavoriteGenres = {context.Genres.SingleOrDefault(x=>x.Id == 1)} */
            },
            new Customer
            {
              Name = "Ali",
              Surname = "Derman",
              Email = "aderman@gmail.com" /*,
              FavoriteGenres = {context.Genres.SingleOrDefault(x=>x.Id == 3)} */
            }
          );

          context.Siparisler.AddRange(
            new Siparislerim
            {
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

            context.OyuncuFilm.AddRange(
                new OyuncuFilm
                {
                OyuncuId = 1,
                FilmId = 1
                },
                new OyuncuFilm
                {
                OyuncuId = 1,
                FilmId = 2
                },
                new OyuncuFilm
                {
                OyuncuId = 2,
                FilmId = 1
                },
                new OyuncuFilm
                {
                OyuncuId = 3,
                FilmId = 3
                },
                new OyuncuFilm
                {
                OyuncuId = 4,
                FilmId = 3
                }
            );

            context.SaveChanges(); //commitler gibi db'ye ekliyoruz.
         }
    }
  }
}
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DbOperations
{
  public class DataGenerator
  {
     public static void Initialize(IServiceProvider serviceProvider)
     {
        using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
           if(context.Books.Any()) //db'deki Books tablosunda veri mevcutsa yeniden eklemeyecek, mevcut degilse ekleme yapacak.
              return;
           
           context.Books.AddRange(
                new Book
            {
                //Id = 1, //Book class'inda id property'sinin auto increment ile eklenecegi belirtildiginden artik id'lere deger vermemize gerek yok!
                Title = "Lean Startup",
                GenreId = 1, //Personal Growth
                PageCount = 200,
                PublishDate = new DateTime(2001,06,12)
                },
                new Book
                {
                //Id = 2,
                Title = "Herland",
                GenreId = 2, //Science Fiction
                PageCount = 250,
                PublishDate = new DateTime(2010,05,23)
                },
                new Book
                {
                //Id = 3,
                Title = "Dune",
                GenreId = 2, //Science Fiction
                PageCount = 540,
                PublishDate = new DateTime(2001,12,21)
                }
              );
            context.SaveChanges(); //commitler gibi db'ye ekliyoruz.
         }
    }
  }
}
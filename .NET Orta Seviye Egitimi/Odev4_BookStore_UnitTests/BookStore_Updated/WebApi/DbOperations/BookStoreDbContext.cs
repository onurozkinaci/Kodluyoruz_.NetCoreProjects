using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
   //=> "**UT(Unit Test) kapsaminda" bagimliliklari yok etmek icin tanimladigimiz IBookStoreDbContext interface'indeki
   //SaveChanges() metodunu da miras aldik;
   public class BookStoreDbContext:DbContext,IBookStoreDbContext
   {
      
      public BookStoreDbContext(DbContextOptions<BookStoreDbContext>options):base(options)
      {}
      public DbSet<Book>Books {get; set;} //Book entity'si bu context'e eklendi ve bu, db'deki Books objesinin replikasi,koddan ulasilabilecek karsiligidir.
      public DbSet<Genre>Genres {get; set;}
      public DbSet<Author> Authors { get; set;}

      //**UT(Unit Test) kapsaminda;
      //"override" keyword'unu ekleme sebebimiz DbContext icinde de SaveChanges() metodu oldugundan, onu degil de
      //interface olarak Unit Test kapsaminda bagimliliklari yok etmek icin tanimladigimiz IBookStoreDbContext interface'indeki
      //SaveChanges() metodunu override etmek istememiz;
      public override int SaveChanges()
      {
         return base.SaveChanges(); //DbContext.SaveChanges() yani, tum yapmak istedigimiz islemler onunla ayni cunku!
      }
    }
}
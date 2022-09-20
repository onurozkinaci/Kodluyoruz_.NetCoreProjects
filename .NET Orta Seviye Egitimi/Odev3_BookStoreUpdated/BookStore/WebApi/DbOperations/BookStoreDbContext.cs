using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
   public class BookStoreDbContext:DbContext
   {
      public BookStoreDbContext(DbContextOptions<BookStoreDbContext>options):base(options)
      {}
      public DbSet<Book>Books {get; set;} //Book entity'si bu context'e eklendi ve bu, db'deki Books objesinin replikasi,koddan ulasilabilecek karsiligidir.
      public DbSet<Genre>Genres {get; set;}
      public DbSet<Author> Authors { get; set;}
      
   }
}
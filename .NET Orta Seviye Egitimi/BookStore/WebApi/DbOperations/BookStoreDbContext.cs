using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations
{
   public class BookStoreDbContext:DbContext
   {
      public BookStoreDbContext(DbContextOptions<BookStoreDbContext>options):base(options)
      {}
      public DbSet<Book>Books {get; set;} //Book entity'si bu context'e eklendi ve bu, db'deki Books objesinin replikasi,koddan ulasilabilecek karsiligidir.
      
   }
}
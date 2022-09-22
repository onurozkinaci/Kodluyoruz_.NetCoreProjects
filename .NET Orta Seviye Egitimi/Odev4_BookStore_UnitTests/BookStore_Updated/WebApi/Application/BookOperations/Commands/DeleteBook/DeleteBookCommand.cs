using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
   public class DeleteBookCommand
   {
     //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
     private readonly IBookStoreDbContext _dbContext;
     public int BookId { get; set; }
     public DeleteBookCommand(IBookStoreDbContext dbContext)
     {
       _dbContext = dbContext;
     }
     public void Handle()
     {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
         if(book is null)
            throw new InvalidOperationException("Silinecek kitap bulunamadi!");
                 
         _dbContext.Books.Remove(book);
         _dbContext.SaveChanges();
     }
   }
}
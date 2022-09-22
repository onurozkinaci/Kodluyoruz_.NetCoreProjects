using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
       public int GenreId {get;set;}

       //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
       private readonly IBookStoreDbContext _context;
       public DeleteGenreCommand(IBookStoreDbContext context)
       {
          _context = context;
       }
       public void Handle()
       {
          var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
          if(genre is null)
              throw new InvalidOperationException("Kitap turu bulunamadi!");
          _context.Genres.Remove(genre);
          _context.SaveChanges(); 
       }
    }
}
using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
      public CreateGenreModel Model {get;set;}

      //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
      private readonly IBookStoreDbContext _context;
      
      public CreateGenreCommand(IBookStoreDbContext context)
      {
         _context = context;
      }
      public void Handle()
      {
         var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
         if(genre is not null)
            throw new InvalidOperationException("Kitap turu zaten mevcut!");

         genre = new Entities.Genre();
         genre.Name = Model.Name;
         _context.Genres.Add(genre);
         _context.SaveChanges();  
      }
    }

    public class CreateGenreModel
    {
      public string Name {get; set;}
    }
}
using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
      public int GenreId {get;set;}
      public UpdateGenreModel Model {get;set;}

      //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
      private readonly IBookStoreDbContext _context;

      public UpdateGenreCommand(IBookStoreDbContext context)
      {
         _context = context;
      }

      public void Handle()
      {
         var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
         if(genre is null)
            throw new InvalidOperationException("Guncellenecek kitap turu bulunamadi!");
         
         if(_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId)) //iletilen tur ismi baska bir id ile zaten tanimlanmissa tur isminin guncellenmesine izin verilmez!
            throw new InvalidOperationException("Ayni isimli bir kitap turu zaten mevcut!");

         genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name; //sadece IsActive degerinin gonderilmesini/guncellenmesini de bir secenek olarak vermek icin.
         genre.IsActive = Model.IsActive;
         _context.SaveChanges();
      }
    }

    public class UpdateGenreModel 
    {
       public string Name { get; set; } 
       public bool IsActive { get; set; } = true; //default degeri true, hic bir sey gonderilmezse user tarafindan.
    }
}
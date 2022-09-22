using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}
        
        //**UT(Unit Test) kapsaminda)-BookStoreDbContext'i direkt degil de interface uzerinden(IBookStoreDbContext) eklemek daha dogru olur, bagimliligi engellemek icin;
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper; //dep. injection kullanilarak AutoMapper eklendi.
        public CreateBookCommand(IBookStoreDbContext dbContext,IMapper mapper)
        {
          _dbContext = dbContext;
          _mapper = mapper;
        }
        public void Handle()
        {
           var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title); //model tipinde kullanicidan veri alinan bidy kismindan gelen title ile db'den cekilen kayitlari kiyaslar.
           if(book is not null) //"book != null" eklenen kitap onceden db'de mevcut ise tekrar eklenmesine izin verme!
              throw new InvalidOperationException("Kitap zaten mevcut!");
           book = _mapper.Map<Book>(Model); //Model ile gelen veriyi Book objesine convert edecek/mapleyecek, AutoMapper ile(MappingProfile'da belirttik bunu).
           _dbContext.Books.Add(book);
           _dbContext.SaveChanges();
        }
    }

    //ViewModel ile donecek object icin degil de kullanicidan FromBody ile parametre olarak alinan
    //body icerisindeki object'te neler gerektigine karar verecek model yapisi asagida tanimlandi;
    public class CreateBookModel
    {
       public string Title { get; set;}  
       public int GenreId { get; set;}  

       public int PageCount { get; set;}

       public DateTime PublishDate { get; set;}
    }
}

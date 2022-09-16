using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
    
       public MappingProfile()
       {
         CreateMap<CreateBookModel,Book>(); //CreateBookModel objesi Book objesine maplenebilir hale getiriliyor.

         //**Bu sefer usttekinden farkli olarak Book'u VM objesine donusturuyoruz. Cunku GetBookDetailQuery.cs-Handle() metodu geriye ViewModel'i donuyor.
         //**Ayrica, asagidaki gibi ForMember icerisinde yaptigimiz mapleme konfigurasyonunu ozellestirebiliriz. VM'de GenreId'yi enum uzerinden string olarak aldigimiz
         //kismi burada belirterek ayni islevi gormesini sagladik;
         CreateMap<Book,BookDetailViewModel>()
         .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
         
         //Tum kitaplari donmek icin(liste halinde);
         CreateMap<Book, BooksViewModel>()
         .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

         //For update;
         CreateMap<UpdateBookModel,Book>();
         //.ForMember(dest => dest.GenreId,opt => opt.Condition(src => (src.GenreId != default)));

      }
  }
}
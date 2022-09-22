using Application.GenreOperations.Queries.GetGenreDetail;
using Application.GenreOperations.Queries.GetGenres;
using AutoMapper;
using WebApi.Application.AuthorOperations.GetAuthorDetail;
using WebApi.Application.AuthorOperations.GetAuthors;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.Commands.CreateAuthor;
using WebApi.Application.Commands.UpdateAuthor;
using WebApi.Entities;

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
         .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
          
         //Tum kitaplari donmek icin(liste halinde);
         CreateMap<Book, BooksViewModel>()
         .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

         //For update;
         CreateMap<UpdateBookModel,Book>();
         //.ForMember(dest => dest.GenreId,opt => opt.Condition(src => (src.GenreId != default)));

         //-----------------Genres;-------------
          CreateMap<Genre,GenresViewModel>();
          CreateMap<Genre,GenreDetailViewModel>();      

         //-----------------Authors;---------------
          CreateMap<Author,AuthorVM>()
          .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Ad + " " + src.Soyad))
          .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));

          CreateMap<Author,AuthorDetailVM>()
          .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Ad + " " + src.Soyad))
          .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));

          CreateMap<CreateAuthorModel,Author>();
          CreateMap<UpdateAuthorModel,Author>();
      }
  }
}
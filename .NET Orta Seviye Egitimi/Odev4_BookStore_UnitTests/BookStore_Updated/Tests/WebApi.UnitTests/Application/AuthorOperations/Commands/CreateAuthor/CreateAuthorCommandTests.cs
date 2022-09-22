using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.Commands.CreateAuthor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
  public class CreateAuthorCommandTests:IClassFixture<CommonTestFixture>
  {
     private readonly BookStoreDbContext _context;
     private readonly IMapper _mapper;

     public CreateAuthorCommandTests(CommonTestFixture fixture)
     {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
     }

     [Theory] //Author create edilirken hata alinabilecek tum durumlar bu metoda iletilen parametreler uzerinden incelenecek;
     [InlineData("Burak","Duzgun",4)] //ayni ad-soyad ile yazar old. icin hata verir.
     [InlineData("Elif","Dogru",1)] //1 id'li kitabin atanmis bir yazari(default verildi/TestSetup.Authors icinde)old. hata verir.
     [InlineData("Fisun","Belova",38)] //38 id'li bir kitap olmadigindan hata verir.
     public void WhenGivenInputsAreAlreadyExists_InvalidOperationException_ShouldBeReturned(string name, string surname, int bookId)
     {
         //Arrange;
         //Bosta/yeni book id olmasi adina bir tane kitap ekledik ve bu sayede bookId 4 verilirse (ornegin) hata vermeyecek, diger parametreler hata verecek;
         var book = new Book(){Title = " WhenGivenInputsAreAlreadyExists_InvalidOperationException_ShouldBeReturned", PageCount = 100,
         PublishDate = new System.DateTime(1990,01,10),GenreId = 1};
         _context.Books.Add(book);
         _context.SaveChanges();
         
         CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
         command.Model = new CreateAuthorModel(){Ad = name, Soyad = surname, BookId = bookId, DogumTarihi = new DateTime(1970,02,28)};
         
         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
                     .Should().Throw<InvalidOperationException>(); //hepsi icin bu hata firlatiliyor.
     }

     [Fact]
     public void WhenGivenInputsAreAppropriate_Author_ShouldBeCreated()
     {
         //Arrange;
         var book = new Book(){Title = "Test_WhenGivenInputsAreAppropriate_Author_ShouldBeCreated", PageCount = 100,
         PublishDate = new System.DateTime(1985,05,10),GenreId = 2};
         _context.Books.Add(book);
         _context.SaveChanges();

         CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
         CreateAuthorModel model = new CreateAuthorModel(){Ad = "Onur", Soyad = "Ozk", BookId = 4};
         command.Model = model;

         //Act;
         FluentActions.Invoking(() => command.Handle()).Invoke();
        
         //Assert;
         var author = _context.Authors.SingleOrDefault(x => x.Ad == model.Ad && x .Soyad == model.Soyad);
         author.Should().NotBeNull();
     }
  }
}
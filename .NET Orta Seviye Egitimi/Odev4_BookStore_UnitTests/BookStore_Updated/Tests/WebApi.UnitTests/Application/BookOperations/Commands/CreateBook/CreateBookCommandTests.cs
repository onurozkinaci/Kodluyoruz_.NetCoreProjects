using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
       //=>Unit testlerde inmemory db kullanilabilir ve bu database'e ekleme/yazma islemi yapiyor gibi
       //davranmak icin mocking mantigi ile hareket edilir ve boylece injection yapildiktan sonra(config ayari sonrasinda)
       //kullanilan dbcontext ve mapperlarin kullanimi ile test edilen CreateBookCommand'in instance'i alinabilir, cunku onun
       //constructor'i parametre olarak context ve mapper bekler. Bu islemi mocking ile test amacli olarak, yapmis gibi davraniyoruz da denebilir.
       //bu dbcontext ve mapper'a da eklemis oldugumuz TestSetup/CommonTestFixture.cs dosyasinda tanimlanan configler uzerinden ulasacagiz;
       
       private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;

       public CreateBookCommandTests(CommonTestFixture testFixture)
       {
         //CommonTestFixture parametre olarak verilip onun constructor'i calistirilmis oldu ve boylece config ayarlari yapildi/calistirildi;
          _context = testFixture.Context;
          _mapper = testFixture.Mapper;
       }

       [Fact] //metodun test metodu oldugunu belirtmek icin gerekli;
       public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturned()
       {
          //3A(Arrange,Act,Assert);
          //Arrange => Hazirlik
          //Test icerisinde calistirilip, test bittiginde yasam suresi bitecek bir obje olusturduk;
           var book = new Book(){Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturned", PageCount = 100,
           PublishDate = new System.DateTime(1990,01,10),GenreId = 1};
          _context.Books.Add(book);
          _context.SaveChanges();

          CreateBookCommand command = new CreateBookCommand(_context,_mapper);
          command.Model = new CreateBookModel(){Title = book.Title}; //hata alinmasinin test edilebilmesi icin ayni title ile kitap verildi
          
          //*"Act(Calistirma) ve Assert(Dogrulama)" implemente edilen FluetAssertion kutuphanesi ile birlikte ayni anda calistirilabiliyor;
          FluentActions
                  .Invoking(() => command.Handle())
                  .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut!");
       }

       //Her kosulun dogru calistigi/basarili caseler icin test metodu("Happy Path);
       [Fact]
       public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
       {
          //Arrange;
          CreateBookCommand command = new CreateBookCommand(_context,_mapper);
          CreateBookModel model = new CreateBookModel(){Title="Hobbit",PageCount=1000,PublishDate=DateTime.Now.Date.AddYears(-10),GenreId=2};
          command.Model = model;

          //Act;
          //FluenActions'ta Should kullanilip assert calistirilmayacaksa, sadece act islemi icin en son Invoke()'u kullanip cagrim yapmak gerekiyor;
          FluentActions.Invoking(() => command.Handle()).Invoke();

          //Assert;
          var book = _context.Books.SingleOrDefault(book => book.Title == model.Title); //yeni eklemis oldugumuz kitap eklenmis mi kontrolu yapilir.
          book.Should().NotBeNull();
          book.PageCount.Should().Be(model.PageCount);
          book.PublishDate.Should().Be(model.PublishDate);
          book.GenreId.Should().Be(model.GenreId);
       }
    }
}
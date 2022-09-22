using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.Commands.CreateAuthor;
using WebApi.Application.Commands.DeleteAuthor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
   public class DeleteAuthorCommandTests:IClassFixture<CommonTestFixture>
   {
      private readonly BookStoreDbContext _context;
      public DeleteAuthorCommandTests(CommonTestFixture fixture)
      {
          _context = fixture.Context;
      }

      [Fact]
      public void WhenTheAuthorIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
        //Arrange;
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
        int authorId = 15; //test db'sinde mevcut olmayan bir id verilir, hata alinabilmesi icin.
        command.AuthorId = authorId;
        
        //Act & Assert;
        FluentActions
                 .Invoking(() => command.Handle())
                 .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinmek istenen yazar bulunamadi!");
      }
      
      [Fact]
      public void WhenTheBookIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
        //Arrange;
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
        int authorId = 1; //guncel kitabi bulunan bir yazar oldugu icin silinemez ve hata verir.
        command.AuthorId = authorId;
        
        //Act & Assert;
        FluentActions
                 .Invoking(() => command.Handle())
                 .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncel kitabi bulunan yazar silinemez, once kitap silinmeli!");
      }

      [Fact]
      //Happy Path-Conditions occured accurately, without any errors;
      public void WhenInputsAreFound_InvalidOperationException_ShouldBeDeleted()
      {
        //Arrange;
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
        int authorId = 3; //test db'de mevcut olan ve aktif book id'si olmayan bir yazar verildi.
        command.AuthorId = authorId;
        
        /*var book = _context.Books.SingleOrDefault(x=>x.Id == 1); //author_id=1 olan yazarin kitabi once silinir, guncel kitabi bulunmadigindan sonrasinda yazar silinebilir.
        _context.Books.Remove(book);
        _context.SaveChanges();*/

        //Act;
        FluentActions.Invoking(()=>command.Handle()).Invoke();

        //Assert => dogrulama;
        var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
        author.Should().BeNull(); //silinen bir yazar oldugu icin kayit olmamali, null donmeli.
      }
   }
}
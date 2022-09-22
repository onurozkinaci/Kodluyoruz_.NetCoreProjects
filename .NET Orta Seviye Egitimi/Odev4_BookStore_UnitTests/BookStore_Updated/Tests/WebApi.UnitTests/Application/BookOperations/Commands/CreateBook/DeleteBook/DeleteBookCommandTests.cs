using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.DbOperations;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests:IClassFixture<CommonTestFixture>
    {
      private readonly BookStoreDbContext _context;
      public DeleteBookCommandTests(CommonTestFixture fixture)
      {
          _context = fixture.Context;
      }

      [Fact]
      public void WhenTheBookIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
        //Arrange;
        DeleteBookCommand command = new DeleteBookCommand(_context);
        int bookId = 15; //test db'sinde mevcut olmayan bir id verilir, hata alinabilmesi icin.
        command.BookId = bookId;
        
        //Act & Assert;
        FluentActions
                 .Invoking(() => command.Handle())
                 .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap bulunamadi!");
      }

      [Fact]
      //Happy Path-Conditions occured accurately, without any errors;
      public void WhenValidIdIsGiven_Book_ShouldBeDeleted()
      {
        //Arrange;
        DeleteBookCommand command = new DeleteBookCommand(_context);
        int bookId = 1; //test db'de mevcut olan bir book id verildi
        command.BookId = bookId;

        //Act;
        FluentActions.Invoking(()=>command.Handle()).Invoke();

        //Assert => dogrulama;
        var book = _context.Books.SingleOrDefault(x => x.Id == bookId);
        book.Should().BeNull(); //silinen bir kitap oldugu icin kayit olmamali, null donmeli.
      }
    }
}
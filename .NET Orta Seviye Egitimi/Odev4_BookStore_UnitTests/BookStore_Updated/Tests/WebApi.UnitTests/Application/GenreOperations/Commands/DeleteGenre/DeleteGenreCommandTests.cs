using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DbOperations;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

      [Fact]
      public void WhenTheGenreIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
        //Arrange;
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        int genreId = 15; //test db'sinde mevcut olmayan bir id verilir, hata alinabilmesi icin.
        command.GenreId = genreId;
        
        //Act & Assert;
        FluentActions
                 .Invoking(() => command.Handle())
                 .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap turu bulunamadi!");
      }

      [Fact]
      //Happy Path-Conditions occured accurately, without any errors;
      public void WhenTheGenreIsFound_Book_ShouldBeDeleted()
      {
        //Arrange;
        DeleteGenreCommand command = new DeleteGenreCommand(_context);
        int genreId = 1; //test db'de mevcut olan bir genre id verildi
        command.GenreId = genreId;

        //Act;
        FluentActions.Invoking(()=>command.Handle()).Invoke();

        //Assert => dogrulama;
        var book = _context.Books.SingleOrDefault(x => x.Id == genreId);
        book.Should().BeNull(); //silinen bir kitap turu oldugu icin kayit olmamali, null donmeli.
      }

    }
}
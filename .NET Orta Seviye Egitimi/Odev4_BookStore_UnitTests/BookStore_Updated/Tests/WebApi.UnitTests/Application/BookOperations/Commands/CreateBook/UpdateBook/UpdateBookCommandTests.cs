using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests:IClassFixture<CommonTestFixture>
    {
      private readonly BookStoreDbContext _context;
      private readonly IMapper _mapper;
      public UpdateBookCommandTests(CommonTestFixture fixture)
      {
          _context = fixture.Context;
          _mapper = fixture.Mapper;
      }

      [Fact]
      public void WhenTheUpdatedBookIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
        //Arrange;
        UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
        int bookId = 15; //test db'sinde mevcut olmayan bir id verilir, hata alinabilmesi icin.
        command.BookId = bookId;
        
        //Act & Assert;
        FluentActions
                 .Invoking(() => command.Handle())
                 .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek Kitap bulunamadi!");
      }

      [Fact]
      //Happy Path-Conditions occured accurately, without any errors;
      public void WhenValidBookIdIsGiven_Book_ShouldBeUpdated()
      {
         //Arrange;
         UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
         int updatedBookId = 1; //test db'de mevcut olan bir book id verildi
         command.BookId = updatedBookId;
         UpdateBookModel model = new UpdateBookModel(){Title = "LOTR", GenreId = 2};
         command.Model = model;

         //Act;
         FluentActions.Invoking(() => command.Handle()).Invoke();

         //Assert => dogrulama;
         var book = _context.Books.SingleOrDefault(x => x.Id == updatedBookId);
         book.Should().NotBeNull();
         book.Title.Should().Be(model.Title);
         book.GenreId.Should().Be(model.GenreId);
      }
    }
}
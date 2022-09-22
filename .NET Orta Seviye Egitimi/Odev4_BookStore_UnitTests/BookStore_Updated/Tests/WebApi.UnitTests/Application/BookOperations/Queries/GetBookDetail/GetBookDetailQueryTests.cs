using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.DbOperations;

namespace Application.BookOperations.Queries.GetBookDetail
{
   public class GetBookDetailQueryTests:IClassFixture<CommonTestFixture>
   {
      private readonly BookStoreDbContext _context;
      private readonly IMapper _mapper;
      public GetBookDetailQueryTests(CommonTestFixture fixture)
      {
         _context = fixture.Context;
         _mapper = fixture.Mapper;
      }

      [Fact]
      public void WhenSearchedBookIdIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
         //Arrange(Hazirlik);
         GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
         query.BookId = 35; //Hata alinmasi icin test db'de mevcut olmayan bir kitap id'si verildi.

         //Act & Assert;
         FluentActions.Invoking(() => query.Handle())
                      .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap mevcut degil!");
      }
      
      [Fact]
      public void WhenSearchedBookIdIsFound_Book_ShouldBeReturned()
      {
         //Arrange(Hazirlik);
         GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
         int bookId = 1;
         query.BookId = bookId; //basarili islem yapilabilmesi icin test db'de mevcut olan bir kitap id verildi.

         //Act;
         FluentActions.Invoking(() => query.Handle()).Invoke();

         //Assert;
         var book = _context.Books.SingleOrDefault(x => x.Id == bookId);
         book.Should().NotBeNull();
      }
      
   }
}
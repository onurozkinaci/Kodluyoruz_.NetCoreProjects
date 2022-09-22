using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DbOperations;

namespace Application.GenreOperations.Queries.GetGenreDetail
{
   public class GetGenreDetailQueryTests:IClassFixture<CommonTestFixture>
   {
      private readonly BookStoreDbContext _context;
      private readonly IMapper _mapper;
      public GetGenreDetailQueryTests(CommonTestFixture fixture)
      {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
      }

      [Fact]
      public void WhenSearchedGenreIdIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
         //Arrange(Hazirlik);
         GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
         query.GenreId = 35; //Hata alinmasi icin test db'de mevcut olmayan bir genre id verildi.

         //Act & Assert;
         FluentActions.Invoking(() => query.Handle())
                      .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap turu bulunamadi!");
      }
      
      [Fact]
      public void WhenSearchedGenreIdIsFound_Genre_ShouldBeReturned()
      {
         //Arrange(Hazirlik);
         GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
         int genreId = 1; //dogru calismasi icin test db'de var olan bir genre id verildi.
         query.GenreId = genreId;

         //Act;
         FluentActions.Invoking(() => query.Handle()).Invoke();

         //Assert;
         var genre = _context.Genres.SingleOrDefault(x => x.Id == genreId);
         genre.Should().NotBeNull();
      }
   }
}
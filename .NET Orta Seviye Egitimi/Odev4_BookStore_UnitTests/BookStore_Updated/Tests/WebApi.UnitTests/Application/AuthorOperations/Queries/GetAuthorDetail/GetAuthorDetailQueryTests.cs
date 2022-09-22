using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.GetAuthorDetail;
using WebApi.Application.Commands.UpdateAuthor;
using WebApi.DbOperations;

namespace Application.AuthorOperations.Queries.GetAuthorDetail
{
   public class GetAuthorDetailQueryTests:IClassFixture<CommonTestFixture>
   {
      private readonly BookStoreDbContext _context;
      private readonly IMapper _mapper;
      public GetAuthorDetailQueryTests(CommonTestFixture fixture)
      {
          _context = fixture.Context;
          _mapper = fixture.Mapper;
      }

      [Fact]
      public void WhenAuthorIdIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
         //Arrange(Hazirlik);
         GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
         query.AuthorId = 35; //Hata alinmasi icin test db'de mevcut olmayan bir author id verildi.

         //Act & Assert;
         FluentActions.Invoking(() => query.Handle())
                      .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu id'ye ait yazar bulunamadi!");
      }

      [Fact]
      //Happy Path-Conditions occured accurately, without any errors;
      public void WhenAuthorIdIsFound_Author_ShouldBeReturned()
      {
         //Arrange(Hazirlik);
         GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
         query.AuthorId = 1; //Test db'de mevcut olan bir author id verildi.

         //Act;
         FluentActions.Invoking(() => query.Handle()).Invoke();

         //Assert => dogrulama;
         var author = _context.Authors.SingleOrDefault(x => x.Id == query.AuthorId);
         author.Should().NotBeNull();
      }
   }
}

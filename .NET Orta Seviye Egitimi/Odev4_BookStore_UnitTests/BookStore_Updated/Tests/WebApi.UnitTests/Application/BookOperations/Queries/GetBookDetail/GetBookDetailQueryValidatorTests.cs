using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.DbOperations;

namespace Application.BookOperations.Queries.GetBookDetail
{
   public class GetBookDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Fact]
      public void WhenInvaliIdInputIsGiven_GetBookDetailValidator_ShouldReturnError()
      {
         //Arrange;
         GetBookDetailQuery query = new GetBookDetailQuery(null,null);
         query.BookId = 0;

         //Act;
         GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
         var result = validator.Validate(query);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //En az bir hata alacagini belirtir.
      }

       [Fact]
       public void WhenValidIdInputIsGiven_Validator_ShouldNotReturnError()
       {
          //Arrange;
          GetBookDetailQuery query = new GetBookDetailQuery(null,null);
          query.BookId = 1;
          
          //Act;
          GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
          var result = validator.Validate(query);

          //Assert;
          result.Errors.Count.Should().Be(0); //Hata/error donmemeli(0 hata doner).
       }
   }
}
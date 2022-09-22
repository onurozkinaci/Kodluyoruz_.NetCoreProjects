using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.GenreOperations.Queries.GetGenreDetail
{
   public class GetGenreDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
   {
     [Fact]
      public void WhenInvaliIdInputIsGiven_GetGenreDetailValidator_ShouldReturnError()
      {
         //Arrange;
         GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
         query.GenreId = 0; //Invalid genre id is given as an input.

         //Act;
         GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
         var result = validator.Validate(query);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //En az bir hata alacagini belirtir.
      }

       [Fact]
       public void WhenValidIdInputIsGiven_GetGenreDetailValidator_ShouldNotReturnError()
       {
          //Arrange;
          GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
          query.GenreId = 1; //valid genre id is given as an input.
          
          //Act;
          GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
          var result = validator.Validate(query);

          //Assert;
          result.Errors.Count.Should().Be(0); //Hata/error donmemeli(0 hata doner).
       }
   }
}
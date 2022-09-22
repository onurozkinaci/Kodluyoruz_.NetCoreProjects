using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.GetAuthorDetail;
using WebApi.Application.Commands.UpdateAuthor;
using WebApi.DbOperations;

namespace Application.AuthorOperations.Queries.GetAuthorDetail
{
   public class GetAuthorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
   {
       [Fact]
       public void WhenInvaliIdInputIsGiven_GetBookDetailValidator_ShouldReturnError()
       {
         //Arrange;
         GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
         query.AuthorId = 0;

         //Act;
         GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
         var result = validator.Validate(query);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //En az bir hata alacagini belirtir.
       }

       [Fact]
       public void WhenValidIdInputIsGiven_Validator_ShouldNotReturnError()
       {
          //Arrange;
          GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
          query.AuthorId = 1;
          
          //Act;
          GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
          var result = validator.Validate(query);

          //Assert;
          result.Errors.Count.Should().Be(0); //Hata/error donmemeli(0 hata doner).
       }
   }
}
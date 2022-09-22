using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DbOperations;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
       [Fact]
       public void WhenIdInputIsInvalid_DeleteGenreValidator_ShoulReturnError()
       {
          //Arrange;
          DeleteGenreCommand command = new DeleteGenreCommand(null);
          command.GenreId = 0; //invalid id is given (<0).

          //Act;
          DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0); //en az 1 tane hata firlatmali.
       }

       [Fact]
       public void WhenIdInputIsValid_DeleteGenreValidator_ShoulNotReturnError()
       {
          //Arrange;
          DeleteGenreCommand command = new DeleteGenreCommand(null);
          command.GenreId = 10; //valid id is given (>0).

          //Act;
          DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().Be(0); //hata firlatmamali(0 hata).
       }
    }
}
using FluentAssertions;
using TestSetup;
using WebApi.Application.FilmOperations.Commands.DeleteFilm;

namespace Application.FilmOperations.Commands.DeleteFilm
{
  public class DeleteFilmCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
      [Fact]
      public void WhenGivenFilmIdIsInvalid_Validator_ShouldGiveAnError()
      {
          //Arrange;
          DeleteFilmCommand command = new DeleteFilmCommand(null);
          command.FilmId = 0; //invalid in terms of validator rule(id is less than zero), it will give an error.

          //Act;
          DeleteFilmCommandValidator validator = new DeleteFilmCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0);
      }

      [Fact]
      public void WhenGivenFilmIdIsValid_Validator_ShouldNotGiveAnError()
      {
          //Arrange;
          DeleteFilmCommand command = new DeleteFilmCommand(null);
          command.FilmId = 1; //valid in terms of validator rule(), it will not give an error.

          //Act;
          DeleteFilmCommandValidator validator = new DeleteFilmCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().Be(0);
      }
  }
}
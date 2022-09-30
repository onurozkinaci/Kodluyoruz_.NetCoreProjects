using FluentAssertions;
using TestSetup;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;

namespace Application.ActorOperations.Commands.DeleteActor
{
  public class DeleteDirectorCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
      [Fact]
      public void WhenGivenDirectorIdIsInvalid_Validator_ShouldGiveAnError()
      {
          //Arrange;
          DeleteDirectorCommand command = new DeleteDirectorCommand(null);
          command.DirectorId = 0; //invalid in terms of validator rule(id is less than zero), it will give an error.

          //Act;
          DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0);
      }

      [Fact]
      public void WhenGivenDirectorIdIsValid_Validator_ShouldNotGiveAnError()
      {
          //Arrange;
          DeleteDirectorCommand command = new DeleteDirectorCommand(null);
          command.DirectorId = 1; //valid in terms of validator rule(), it will not give an error.

          //Act;
          DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().Be(0);
      }
  }
}
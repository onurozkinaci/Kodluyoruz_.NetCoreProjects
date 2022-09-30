using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.DbOperations;

namespace Application.ActorOperations.Commands.DeleteActor
{
  public class DeleteActorCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
      [Fact]
      public void WhenGivenActorIdIsInvalid_Validator_ShouldGiveAnError()
      {
          //Arrange;
          DeleteActorCommand command = new DeleteActorCommand(null);
          command.ActorId = 0; //invalid in terms of validator rule(id is less than zero), it will give an error.

          //Act;
          DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0);
      }

      [Fact]
      public void WhenGivenActorIdIsValid_Validator_ShouldNotGiveAnError()
      {
          //Arrange;
          DeleteActorCommand command = new DeleteActorCommand(null);
          command.ActorId = 1; //valid in terms of validator rule(), it will not give an error.

          //Act;
          DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().Be(0);
      }
  }
}
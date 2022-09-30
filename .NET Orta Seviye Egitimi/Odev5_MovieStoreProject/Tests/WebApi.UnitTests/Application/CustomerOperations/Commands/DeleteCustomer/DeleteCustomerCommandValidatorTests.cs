using FluentAssertions;
using TestSetup;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;

namespace Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
      [Fact]
      public void WhenGivenActorIdIsInvalid_Validator_ShouldGiveAnError()
      {
          //Arrange;
          DeleteCustomerCommand command = new DeleteCustomerCommand(null);
          command.CustomerId = 0; //invalid in terms of validator rule(id is less than zero), it will give an error.

          //Act;
          DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0);
      }

      [Fact]
      public void WhenGivenActorIdIsValid_Validator_ShouldNotGiveAnError()
      {
          //Arrange;
          DeleteCustomerCommand command = new DeleteCustomerCommand(null);
          command.CustomerId = 1; //valid in terms of validator rule(), it will not give an error.

          //Act;
          DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().Be(0);
      }   
    }
}
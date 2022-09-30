using FluentAssertions;
using TestSetup;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;

namespace Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
       [Theory]
       [InlineData("","","","")]
       [InlineData("","ozkn","oozkn@gmail.com","123456")]
       [InlineData("onur","ozk","oozkn@gmail.com","123456")]
       [InlineData("onur","ozkn","oozk","123456")]
       [InlineData("onur","ozkn","oozkn@gmail.com","1234")] //password 4 karakter old. icin hata alinir, en az 5 karakter olmali.
       public void WhenGivenInputsAreInvalid_CustomerValidator_ShouldGiveErrors(string name, string surname, string email, string password)
       {
          //Arrange;
          CreateCustomerCommand command = new CreateCustomerCommand(null,null);
          command.Model = new CreateCustomerModel(){Name = name, Surname = surname, Email = email, Password = password};
          
          //Act;
          CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
          var result = validator.Validate(command);

          //Arrange;
          result.Errors.Count.Should().BeGreaterThan(0); //at least one error is given.
       }   

       public void WhenGivenInputsAreValid_CustomerValidator_ShouldNotGiveErrors()
       {
          //Arrange;
          CreateCustomerCommand command = new CreateCustomerCommand(null,null);
          //valid inputs are given;
          command.Model = new CreateCustomerModel(){Name = "Orhan", Surname = "Durdu", Email = "odurdu@gmail.com", Password = "1234567"};
          
          //Act;
          CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
          var result = validator.Validate(command);

          //Arrange;
          result.Errors.Count.Should().Be(0); //no error 
       } 
    }
}
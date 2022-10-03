using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.DepartmentOperations.Commands.CreateDepartment;
using WebApi.Application.DepartmentOperations.CreateDepartment;

namespace Tests.WebApi.UnitTests.Application.DepartmentOperations.Commands.CreateDepartment
{
   public class CreateDepartmentCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Fact]
      public void WhenDepartmentNameIsInvalid_DepartmentValidator_ShouldReturnError()
      {
         //Arrange;
         CreateDepartmentCommand command = new CreateDepartmentCommand(null,null);
         command.Model = new CreateDepartmentModel(){DeptName = "abc"}; //invalid in terms of validator's rule.

         //Act;
         CreateDepartmentCommandValidator validator = new CreateDepartmentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenDepartmentNameIsValid_DepartmentValidator_ShouldNotReturnError()
      {
         //Arrange;
         CreateDepartmentCommand command = new CreateDepartmentCommand(null,null);
         command.Model = new CreateDepartmentModel(){DeptName = "Softw. Engineering"};

         //Act;
         CreateDepartmentCommandValidator validator = new CreateDepartmentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez.
      }
   }
}
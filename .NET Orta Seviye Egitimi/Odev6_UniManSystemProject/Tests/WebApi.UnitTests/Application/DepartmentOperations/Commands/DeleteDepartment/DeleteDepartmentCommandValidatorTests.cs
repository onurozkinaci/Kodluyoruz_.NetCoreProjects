using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.DepartmentOperations.Commands.DeleteDepartment;
using WebApi.Application.DepartmentOperations.DeleteDepartment;

namespace Tests.WebApi.UnitTests.Application.DepartmentOperations.Commands.DeleteDepartment
{
   public class DeleteDepartmentCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Fact]
      public void WhenDepartmentIdIsInvalid_CourseValidator_ShouldReturnErrors()
      {
         //Arrange;
         DeleteDepartmentCommand command = new DeleteDepartmentCommand(null);
         command.DepartmentId = 0;

         //Act;
         DeleteDepartmentCommandValidator validator = new DeleteDepartmentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenDepartmentIdValid_CourseValidator_ShouldNotReturnError()
      {
         //Arrange;
         DeleteDepartmentCommand command = new DeleteDepartmentCommand(null);
         command.DepartmentId = 1;

         //Act;
         DeleteDepartmentCommandValidator validator = new DeleteDepartmentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez(0 hata).
      }
   }
}
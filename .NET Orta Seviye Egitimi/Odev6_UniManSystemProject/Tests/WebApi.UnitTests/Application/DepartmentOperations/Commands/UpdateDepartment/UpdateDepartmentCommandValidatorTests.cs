using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.DepartmentOperations.Commands.UpdateDepartment;
using WebApi.Application.DepartmentOperations.UpdateDepartment;

namespace Tests.WebApi.UnitTests.Application.DepartmentOperations.Commands.UpdateDepartment
{
   public class UpdateCourseCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData(0,"Softw.Eng.")] //deptId>0 olmadigi icin hata verir.
      [InlineData(1,"sfw")] //deptName.length<4 old. icin hata verir.
      [InlineData(0,"")] //her iki inputtan dolayi hata verir.
      public void WhenInputsAreInvalid_DepartmentValidator_ShouldReturnErrors(int deptId,string deptName)
      {
         //Arrange;
         UpdateDepartmentCommand command = new UpdateDepartmentCommand(null,null);
         command.DeptId = deptId;
         command.Model = new UpdateDepartmentModel(){DeptName = deptName};

         //Act;
         UpdateDepartmentCommandValidator validator = new UpdateDepartmentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_CourseValidator_ShouldNotReturnError()
      {
         //Arrange;
         UpdateDepartmentCommand command = new UpdateDepartmentCommand(null,null);
         command.DeptId = 1; //valid
         command.Model = new UpdateDepartmentModel(){DeptName = "Softw. Engineering"}; //valid

         //Act;
         UpdateDepartmentCommandValidator validator = new UpdateDepartmentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez.
      }
   }
}
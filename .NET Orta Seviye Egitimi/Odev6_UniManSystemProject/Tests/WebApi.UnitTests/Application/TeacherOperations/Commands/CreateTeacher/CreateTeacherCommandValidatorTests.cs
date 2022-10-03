using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.TeacherOperations.Command.CreateTeacher;
using WebApi.Application.TeacherOperations.CreateTeacher;

namespace Tests.WebApi.UnitTests.Application.TeacherOperations.Commands.CreateTeacher
{
   public class CreateTeacherCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData("","Ozkn",10,1)]
      [InlineData("Onur","",10,1)]
      [InlineData("Onur","Ozkn",0,1)]
      [InlineData("Onur","Ozkn",10,0)]
      [InlineData("","Ozk",0,0)]//all inputs will give an error.
      public void WhenInputsAreInvalid_TeacherValidator_ShouldReturnErrors(string name, string surname, int experience, int deptId)
      {
         //Arrange;
         CreateTeacherCommand command = new CreateTeacherCommand(null,null);
         command.Model = new CreateTeacherModel
         {
            Name = name,
            Surname = surname,
            YearsOfExperience = experience,
            DepartmentId= deptId
         };

         //Act;
         CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_TeacherValidator_ShouldNotReturnErrors()
      {
         //Arrange;
         CreateTeacherCommand command = new CreateTeacherCommand(null,null);
         command.Model = new CreateTeacherModel
         {
            Name = "Onur",
            Surname = "Ozkn",
            YearsOfExperience = 10,
            DepartmentId= 1
         };

         //Act;
         CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez.
      }
   }
}
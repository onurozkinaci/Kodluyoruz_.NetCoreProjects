using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using WebApi.Application.TeacherOperations.UpdateTeacher;

namespace Tests.WebApi.UnitTests.Application.TeacherOperations.Commands.UpdateTeacher
{
   public class UpdateTeacherCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData(0,"Onur","Ozkn",10,1)]
      [InlineData(1,"","Ozkn",10,1)]
      [InlineData(1,"Onur","",10,1)]
      [InlineData(1,"Onur","Ozkn",0,1)]
      [InlineData(1,"Onur","Ozkn",10,0)]
      [InlineData(0,"","Ozk",0,0)]//all inputs will give an error.
      public void WhenInputsAreInvalid_UpdateTeacherValidator_ShouldReturnErrors(int teacherId,string name, string surname, int experience, int deptId)
      {
         //Arrange;
         UpdateTeacherCommand command = new UpdateTeacherCommand(null,null);
         command.TeacherId = teacherId;
         command.Model = new UpdateTeacherModel
         {
            Name = name,
            Surname = surname,
            YearsOfExperience = experience,
            DepartmentId= deptId
         };

         //Act;
         UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_UpdateTeacherValidator_ShouldNotReturnErrors()
      {
         //Arrange;
         UpdateTeacherCommand command = new UpdateTeacherCommand(null,null);
         command.TeacherId = 1; //valid input(>0).
         command.Model = new UpdateTeacherModel //valid inputs are also given for model.
         {
            Name = "Onur",
            Surname = "Ozkn",
            YearsOfExperience = 10,
            DepartmentId= 1
         };

         //Act;
         UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez.
      }
   }
}
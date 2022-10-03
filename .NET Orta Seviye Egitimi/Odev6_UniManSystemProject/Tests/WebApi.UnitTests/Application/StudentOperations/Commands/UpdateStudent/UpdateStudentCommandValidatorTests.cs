using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.Application.StudentOperations.UpdateStudent;

namespace Tests.WebApi.UnitTests.Application.StudentOperations.Commands.UpdateStudent
{
   public class UpdateStudentCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData(0,"Onur","Ozkn","onroz@gmail.com","123456",4,3.30)]
      [InlineData(1,"","Ozkn","onroz@gmail.com","123456",4,3.30)]
      [InlineData(1,"Onur","","onroz@gmail.com","123456",4,3.30)]
      [InlineData(1,"Onur","Ozkn","","123456",4,3.30)]
      [InlineData(1,"Onur","Ozkn","onroz@gmail.com","",4,3.30)]
      [InlineData(1,"Onur","Ozkn","onroz@gmail.com","123456",0,3.30)]
      [InlineData(1,"Onur","Ozkn","onroz@gmail.com","123456",4,0)]
      [InlineData(0,"","afa","onr","123",0,0)] //all inputs will give an error.
      public void WhenInputsAreInvalid_UpdateCourseValidator_ShouldReturnErrors(int studentId, string name, string surname, string email, string password, int currentGrade, double gpa)
      {
         //Arrange;
         UpdateStudentCommand command = new UpdateStudentCommand(null,null);
         command.StudentId = studentId;
         command.Model = new UpdateStudentModel
         {
            Name = name,
            Surname = surname,
            Email = email,
            Password = password,
            CurrentGrade = currentGrade,
            GPA = gpa
         };

         //Act;
         UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_UpdateCourseValidator_ShouldNotReturnErrors()
      {
         //Arrange;
         UpdateStudentCommand command = new UpdateStudentCommand(null,null);
         command.StudentId = 1; //valid studentId(>0)
         command.Model = new UpdateStudentModel //valid inputs are given as studentId in terms of validator's defined rules.
         {
            Name = "Onur",
            Surname = "Ozkn",
            Email = "onrozk@gmail.com",
            Password = "12345",
            CurrentGrade = 4,
            GPA = 3.45
         };

         //Act;
         UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez.
      }
   }
}
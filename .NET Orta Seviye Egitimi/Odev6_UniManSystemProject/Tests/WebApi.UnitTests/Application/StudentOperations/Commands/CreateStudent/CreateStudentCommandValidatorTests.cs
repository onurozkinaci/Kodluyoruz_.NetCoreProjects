using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.StudentOperations.CreateStudent;

namespace Tests.WebApi.UnitTests.Application.StudentOperations.Commands.CreateStudent
{
   public class CreateStudentCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData("","Ozkn","onroz@gmail.com","123456",4,3.30)]
      [InlineData("Onur","","onroz@gmail.com","123456",4,3.30)]
      [InlineData("Onur","Ozkn","","123456",4,3.30)]
      [InlineData("Onur","Ozkn","onroz@gmail.com","",4,3.30)]
      [InlineData("Onur","Ozkn","onroz@gmail.com","123456",0,3.30)]
      [InlineData("Onur","Ozkn","onroz@gmail.com","123456",4,0)]
      [InlineData("","afa","onr","123",0,0)] //all inputs will give an error.
      public void WhenInputsAreInvalid_CourseValidator_ShouldReturnErrors(string name, string surname, string email, string password, int currentGrade, double gpa)
      {
         //Arrange;
         CreateStudentCommand command = new CreateStudentCommand(null,null);
         command.Model = new CreateStudentModel
         {
            Name = name,
            Surname = surname,
            Email = email,
            Password = password,
            CurrentGrade = currentGrade,
            GPA = gpa
         };

         //Act;
         CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_CourseValidator_ShouldNotReturnErrors()
      {
         //Arrange;
         CreateStudentCommand command = new CreateStudentCommand(null,null);
         command.Model = new CreateStudentModel
         {
            Name = "Onur",
            Surname = "Ozkn",
            Email = "onrozk@gmail.com",
            Password = "12345",
            CurrentGrade = 4,
            GPA = 3.45
         };

         //Act;
         CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez.
      }
   }
}
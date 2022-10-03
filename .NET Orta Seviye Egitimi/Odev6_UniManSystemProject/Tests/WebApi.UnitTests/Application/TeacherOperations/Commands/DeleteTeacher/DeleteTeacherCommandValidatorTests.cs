using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.TeacherOperations.Commands.DeleteTeacher;
using WebApi.Application.TeacherOperations.DeleteTeacher;

namespace Tests.WebApi.UnitTests.Application.TeacherOperations.Commands.DeleteTeacher
{
   public class DeleteTeacherCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Fact]
      public void WhenTeacherIdIsInvalid_TeacherValidator_ShouldReturnErrors()
      {
         //Arrange;
         DeleteTeacherCommand command = new DeleteTeacherCommand(null);
         command.TeacherId = 0;

         //Act;
         DeleteTeacherCommandValidator validator = new DeleteTeacherCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenTeacherIdIsValid_TeacherValidator_ShouldNotReturnError()
      {
         //Arrange;
         DeleteTeacherCommand command = new DeleteTeacherCommand(null);
         command.TeacherId = 1;

         //Act;
         DeleteTeacherCommandValidator validator = new DeleteTeacherCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez(0 hata).
      }
   }
}
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.Application.StudentOperations.DeleteStudent;

namespace Tests.WebApi.UnitTests.Application.StudentOperations.Commands.DeleteStudent
{
   public class DeleteStudentCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Fact]
      public void WhenStudentIdIsInvalid_StudentValidator_ShouldReturnErrors()
      {
         //Arrange;
         DeleteStudentCommand command = new DeleteStudentCommand(null);
         command.StudentId = 0;

         //Act;
         DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenStudentIdIsValid_StudentValidator_ShouldNotReturnError()
      {
         //Arrange;
         DeleteStudentCommand command = new DeleteStudentCommand(null);
         command.StudentId = 1;

         //Act;
         DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez(0 hata).
      }
   }
}
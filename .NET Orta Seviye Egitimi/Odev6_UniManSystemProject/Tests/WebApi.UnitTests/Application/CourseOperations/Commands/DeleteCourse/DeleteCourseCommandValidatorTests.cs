using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.CourseOperations.DeleteCourse;

namespace Tests.WebApi.UnitTests.Application.CourseOperations.Commands.DeleteCourse
{
   public class DeleteCourseCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Fact]
      public void WhenCourseIdIsInvalid_CourseValidator_ShouldReturnErrors()
      {
         //Arrange;
         DeleteCourseCommand command = new DeleteCourseCommand(null);
         command.CourseId = 0;

         //Act;
         DeleteCourseCommandValidator validator = new DeleteCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_CourseValidator_ShouldNotReturnError()
      {
         //Arrange;
         DeleteCourseCommand command = new DeleteCourseCommand(null);
         command.CourseId = 1;

         //Act;
         DeleteCourseCommandValidator validator = new DeleteCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez(0 hata).
      }
   }
}
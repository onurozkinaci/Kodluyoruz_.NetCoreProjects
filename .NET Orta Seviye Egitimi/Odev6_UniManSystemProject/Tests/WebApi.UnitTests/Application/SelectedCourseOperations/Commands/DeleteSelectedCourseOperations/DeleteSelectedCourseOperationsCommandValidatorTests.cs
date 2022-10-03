using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.SelectedCourseOperations.Commands.DeleteSelectedCourse;
using WebApi.Application.SelectedCourseOperations.CreateSelectedCourse;

namespace Tests.WebApi.UnitTests.Application.SelectedCourseOperations
.Commands.DeleteSelectedCourseOperations
{
   public class DeleteSelectedCourseCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData(0,1)]
      [InlineData(1,0)]
      [InlineData(0,0)] //iki input da hata verir.
      public void WhenInputsAreInvalid_DeleteSelectedCourseValidator_ShouldReturnErrors(int studentId, int courseId)
      {
         //Arrange;
         DeleteSelectedCourseCommand command = new DeleteSelectedCourseCommand(null);
         command.StudentId = studentId;
         command.CourseId = courseId;

         //Act;
         DeleteSelectedCourseCommandValidator validator = new DeleteSelectedCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_DeleteSelectedCourseValidator_ShouldNotReturnErrors()
      {
         //Arrange;
         DeleteSelectedCourseCommand command = new DeleteSelectedCourseCommand(null);
         command.StudentId = 1; //valid input (>0)
         command.CourseId = 1; //valid input (>0)

         //Act;
         DeleteSelectedCourseCommandValidator validator = new DeleteSelectedCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez(0 hata).
      }
   }
}
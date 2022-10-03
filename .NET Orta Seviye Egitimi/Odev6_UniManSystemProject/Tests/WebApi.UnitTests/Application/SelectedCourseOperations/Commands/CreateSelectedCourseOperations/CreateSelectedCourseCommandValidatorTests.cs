using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.SelectedCourseOperations.Commands.CreateSelectedCourse;
using WebApi.Application.SelectedCourseOperations.CreateSelectedCourse;

namespace Tests.WebApi.UnitTests.Application.SelectedCourseOperations
.Commands.CreateSelectedCourseOperations
{
   public class CreateSelectedCourseCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData(0,1)]
      [InlineData(1,0)]
      [InlineData(0,0)] //iki input da hata verir.
      public void WhenInputsAreInvalid_SelectedCourseValidator_ShouldReturnErrors(int studentId, int courseId)
      {
         //Arrange;
         CreateSelectedCourseCommand command = new CreateSelectedCourseCommand(null,null);
         command.Model = new CreateSelectedCourseModel{StudentId = studentId, CourseId = courseId};

         //Act;
         CreateSelectedCourseCommandValidator validator = new CreateSelectedCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_SelectedCourseValidator_ShouldNotReturnErrors()
      {
         //Arrange;
         CreateSelectedCourseCommand command = new CreateSelectedCourseCommand(null,null);
         command.Model = new CreateSelectedCourseModel{StudentId = 1, CourseId = 1}; //valid inputs are given.

         //Act;
         CreateSelectedCourseCommandValidator validator = new CreateSelectedCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez(0 hata).
      }
   }
}
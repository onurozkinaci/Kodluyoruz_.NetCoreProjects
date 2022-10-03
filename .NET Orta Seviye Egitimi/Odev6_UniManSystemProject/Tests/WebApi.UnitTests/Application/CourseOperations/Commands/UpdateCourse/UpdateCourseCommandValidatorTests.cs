using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.Application.CourseOperations.UpdateCourse;

namespace Tests.WebApi.UnitTests.Application.CourseOperations.Commands.CreateCourse
{
   public class UpdateCourseCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData(0,"Advanced Java","SEN4025",2,1,1)]
      [InlineData(1,"","SEN4025",2,1,1)]
      [InlineData(1,"Advanced Java","",2,1,1)]
      [InlineData(1,"Advanced Java","SEN4025",0,1,1)]
      [InlineData(1,"Advanced Java","SEN4025",2,0,1)]
      [InlineData(1,"Advanced Java","SEN4025",2,1,0)]
      [InlineData(0,"adv","sen",0,0,0)] //all inputs will give an error.
      public void WhenInputsAreInvalid_CourseValidator_ShouldReturnErrors(int courseId,string courseName, string courseCode, int hours, int teacherId, int deptId)
      {
         //Arrange;
         UpdateCourseCommand command = new UpdateCourseCommand(null,null);
         command.CourseId = courseId;
         command.Model = new UpdateCourseModel
         {
            CourseName = courseName, 
            CourseCode = courseCode,
            HowManyHours = hours,
            TeacherId = teacherId,
            DepartmentId = deptId
         };

         //Act;
         UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_CourseValidator_ShouldNotReturnError()
      {
         //Arrange;
         UpdateCourseCommand command = new UpdateCourseCommand(null,null);
         command.CourseId = 1;
         command.Model = new UpdateCourseModel
         {
            CourseName = "Advanced Java", 
            CourseCode = "SEN4024",
            HowManyHours = 3,
            TeacherId = 1,
            DepartmentId = 1
         };

         //Act;
         UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez.
      }
   }
}
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.CreateCourse;

namespace Tests.WebApi.UnitTests.Application.CourseOperations.Commands.CreateCourse
{
   public class CreateCourseCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
      [Theory]
      [InlineData("","SEN4025",2,1,1)]
      [InlineData("Advanced Java","",2,1,1)]
      [InlineData("Advanced Java","SEN4025",0,1,1)]
      [InlineData("Advanced Java","SEN4025",2,0,1)]
      [InlineData("Advanced Java","SEN4025",2,1,0)]
      [InlineData("adv","sen",0,0,0)] //all inputs will give an error.
      public void WhenInputsAreInvalid_CourseValidator_ShouldReturnErrors(string courseName, string courseCode, int hours, int teacherId, int deptId)
      {
         //Arrange;
         CreateCourseCommand command = new CreateCourseCommand(null,null);
         command.Model = new CreateCourseModel
         {
            CourseName = courseName, 
            CourseCode = courseCode,
            HowManyHours = hours,
            TeacherId = teacherId,
            DepartmentId = deptId
         };

         //Act;
         CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().BeGreaterThan(0); //en az bir tane hata verir.
      }

      [Fact]
      public void WhenInputsAreValid_CourseValidator_ShouldNotReturnError()
      {
         //Arrange;
         CreateCourseCommand command = new CreateCourseCommand(null,null);
         command.Model = new CreateCourseModel
         {
            CourseName = "Advanced Java", 
            CourseCode = "SEN4024",
            HowManyHours = 3,
            TeacherId = 1,
            DepartmentId = 1
         };

         //Act;
         CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
         var result = validator.Validate(command);

         //Assert;
         result.Errors.Count.Should().Be(0); //hata vermez.
      }
   }
}
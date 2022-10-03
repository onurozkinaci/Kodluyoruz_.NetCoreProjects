using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.SelectedCourseOperations.Commands.DeleteSelectedCourse;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.SelectedCourseOperations.Commands.DeleteSelectedCourseOperations
{
    public class DeleteSelectedCourseCommandTests:IClassFixture<CommonTestFixture>
    {
         private readonly UniManSystemDbContext _context;
         public DeleteSelectedCourseCommandTests(CommonTestFixture fixture)
         {
            _context = fixture.Context;
         }

         [Fact]
         public void WhenDepartmentIdAndStudentIdPairIsNotExist_InvalidOperationException_ShouldBeReturned()
         {
            //Arrange;
            DeleteSelectedCourseCommand command = new DeleteSelectedCourseCommand(_context);
            command.StudentId = 25;
            command.CourseId = 30;

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek olan secilmis ders kaydi bulunamadi!");
         }

         [Fact]
         public void WhenDepartmentIdAndStudentIdPairExists_SelectedCourse_ShouldBeDeleted()
         {
            //Arrange;
            DeleteSelectedCourseCommand command = new DeleteSelectedCourseCommand(_context);
            command.StudentId = 1;
            command.CourseId = 1;
            //(1,1) ikilisi key olarak test db'de SelectedCourses tablosunda var oldugundan hata alinmaz ve secilmis olan ders silinir.

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var selectedCourse = _context.SelectedCourses.SingleOrDefault(x=>x.StudentId == command.StudentId && x.CourseId == command.CourseId);
            selectedCourse.Should().BeNull(); //silindigi icin null olmali.
         }
    }
}
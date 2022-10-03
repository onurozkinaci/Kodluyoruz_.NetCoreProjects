using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.DbOperations;
using WebApi.Entites;

namespace Tests.WebApi.UnitTests.Application.CourseOperations.Commands.DeleteCourse
{
   public class DeleteCourseCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
        public DeleteCourseCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenCourseIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            command.CourseId = 25;
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kurs bulunamadi!");
        }

        [Fact]
        public void WhenCourseIdExistOnSelectedLecturesTable_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            command.CourseId = 1; //Selected Lectures tablosunda mevcut bir CourseId oldugundan silinmek istendiginde
            //asagidaki hatayi verecek;
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Ilgili kurs, oncelikle 'Secilen Dersler' tablosundan silinmelidir!");
        }

        [Fact]
        public void WhenAllInputsAreAppropriate_Course_ShouldBeDeleted()
        {
            //Arrange;
            //SelectedLecture tablosunda var olan bir CourseId olmamasi icin yeni bir CourseId olusturuldu,
            //onun id'si de 4 olacak ve o silinecek;
            var newCourse = new Course{
                CourseName = "Advanced Java", 
                CourseCode = "SEN4038",
                HowManyHours = 3,
                TeacherId = 1,
                DepartmentId = 1
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();

            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            command.CourseId = 4;
            
            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();
    
            //Assert;
            var course = _context.Courses.SingleOrDefault(x=>x.Id == command.CourseId);
            course.Should().BeNull();
        }
    }
}

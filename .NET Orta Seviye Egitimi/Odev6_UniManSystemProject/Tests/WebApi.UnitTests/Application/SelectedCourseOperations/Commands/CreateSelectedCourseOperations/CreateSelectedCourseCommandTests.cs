using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.SelectedCourseOperations.Commands.CreateSelectedCourse;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.SelectedCourseOperations.Commands.CreateSelectedCourseOperations
{
    public class CreateSelectedCourseCommandTests:IClassFixture<CommonTestFixture>
    {
         private readonly UniManSystemDbContext _context;
         private readonly IMapper _mapper;

         public CreateSelectedCourseCommandTests(CommonTestFixture fixture)
         {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
         }

         [Fact]
         public void WhenDepartmentIdAndStudentIdAlreadyExist_InvalidOperationException_ShouldBeReturned()
         {
            //Arrange;
            CreateSelectedCourseCommand command = new CreateSelectedCourseCommand(_context,_mapper);
            command.Model = new CreateSelectedCourseModel {StudentId = 1, CourseId = 1};

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Belirtilen ders zaten secilmis!");
         }

         [Fact]
         public void WhenStudentIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
         {
            //Arrange;
            CreateSelectedCourseCommand command = new CreateSelectedCourseCommand(_context,_mapper);
            command.Model = new CreateSelectedCourseModel {StudentId = 24, CourseId = 1};
            //verilen studentId test db'de mevcut olmadigindan hata alinacak.

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Girilen ogrenci bilgisi mevcut degil!");
         }

         [Fact]
         public void WhenDepartmentIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
         {
            //Arrange;
            CreateSelectedCourseCommand command = new CreateSelectedCourseCommand(_context,_mapper);
            command.Model = new CreateSelectedCourseModel {StudentId = 1, CourseId = 24};
            //verilen courseId test db'de mevcut olmadigindan hata alinacak.

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Girilen kurs/ders bilgisi mevcut degil!");
         }

         [Fact]
         public void WhenAllInputsAreAppropriate_SelectedCourse_ShouldBeCreated()
         {
            //Arrange;
            CreateSelectedCourseCommand command = new CreateSelectedCourseCommand(_context,_mapper);
            command.Model = new CreateSelectedCourseModel {StudentId = 3, CourseId = 3};
            //test db'de mevcut bir kayit olmadigindan(3,3 ikilisi) hata alinmaz ve secilmis ders kaydi olusur.

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var selectedCourse = _context.SelectedCourses.SingleOrDefault(x=>x.StudentId == command.Model.StudentId && x.CourseId == command.Model.CourseId);
            selectedCourse.Should().NotBeNull();
         }
    }
}
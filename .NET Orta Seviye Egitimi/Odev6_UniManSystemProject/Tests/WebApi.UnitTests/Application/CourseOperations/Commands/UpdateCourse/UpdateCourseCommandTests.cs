using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.CourseOperations.Commands.UpdateCourse
{
   public class UpdateCourseCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
       private readonly IMapper _mapper;
        public UpdateCourseCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenCourseIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            UpdateCourseCommand command = new UpdateCourseCommand(_context,_mapper);
            command.CourseId = 15; //test db'de mevcut olmayan bir courseId verildiginden hata alinir.
            command.Model = new UpdateCourseModel{CourseName = "Adv.Python", CourseCode ="SEN4020", HowManyHours = 3 ,TeacherId = 1 ,DepartmentId = 1};
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek kurs bulunamadi!");
        }

        [Fact]
        public void WhenTeacherIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            UpdateCourseCommand command = new UpdateCourseCommand(_context,_mapper);
            command.CourseId = 1;
            command.Model = new UpdateCourseModel{CourseName = "Adv.Python", CourseCode ="SEN4012", HowManyHours = 3 ,TeacherId = 18 ,DepartmentId = 1};
            //test db'de Teachers tablosunda mevcut olmayan bir TeacherId verildigi icin hata alinir.
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Girilen ogretmen bilgisi mevcut degil!");
        }
        [Fact]
        public void WhenDepartmentIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            UpdateCourseCommand command = new UpdateCourseCommand(_context,_mapper);
            command.CourseId = 1;
            command.Model = new UpdateCourseModel{CourseName = "Adv.Python", CourseCode ="SEN4010", HowManyHours = 3 ,TeacherId = 1 ,DepartmentId = 16};
            //test db'de Departments tablosunda mevcut olmayan bir DepartmentId verildigi icin hata alinir.
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Girilen departman bilgisi mevcut degil!");
        }

        [Fact]
        public void WhenAllInputsAreAppropriate_Course_ShouldBeUpdated()
        {
            //Arrange;
            UpdateCourseCommand command = new UpdateCourseCommand(_context,_mapper);
            command.CourseId = 1;
            command.Model = new UpdateCourseModel{CourseName = "Adv.Python", CourseCode ="SEN4014", HowManyHours = 3 ,TeacherId = 1 ,DepartmentId = 1};
            //test db'sinde olusturmak uzere tum property degerleri uygun bir sekilde verildi.

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var course = _context.Courses.SingleOrDefault(x=>x.Id == command.CourseId);
            course.CourseName.Should().Be(command.Model.CourseName);
            course.CourseCode.Should().Be(command.Model.CourseCode);
            course.HowManyHours.Should().Be(command.Model.HowManyHours);
            course.TeacherId.Should().Be(command.Model.TeacherId);
            course.DepartmentId.Should().Be(command.Model.DepartmentId);
        }
    }
}
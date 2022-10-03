using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.CourseOperations.Commands.CreateCourse
{
   public class CreateCourseCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
       private readonly IMapper _mapper;
        public CreateCourseCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenCourseCodeAlreadyExists_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            CreateCourseCommand command = new CreateCourseCommand(_context,_mapper);
            command.Model = new CreateCourseModel{CourseName = "Adv.Python", CourseCode ="SEN4020", HowManyHours = 3 ,TeacherId = 1 ,DepartmentId = 1};
            //test db'de Courses tablosunda mevcut olan bir CourseCode verildigi icin hata alinir.
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu kod ile bir ders kaydi zaten mevcut!");
        }

        [Fact]
        public void WhenTeacherIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            CreateCourseCommand command = new CreateCourseCommand(_context,_mapper);
            command.Model = new CreateCourseModel{CourseName = "Adv.Python", CourseCode ="SEN4012", HowManyHours = 3 ,TeacherId = 18 ,DepartmentId = 1};
            //test db'de Teachers tablosunda mevcut olmayan bir TeacherId verildigi icin hata alinir.
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Girilen ogretmen bilgisi mevcut degil!");
        }
        [Fact]
        public void WhenDepartmentIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            CreateCourseCommand command = new CreateCourseCommand(_context,_mapper);
            command.Model = new CreateCourseModel{CourseName = "Adv.Python", CourseCode ="SEN4010", HowManyHours = 3 ,TeacherId = 1 ,DepartmentId = 16};
            //test db'de Departments tablosunda mevcut olmayan bir DepartmentId verildigi icin hata alinir.
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Girilen departman bilgisi mevcut degil!");
        }

        [Fact]
        public void WhenAllInputsAreAppropriate_Course_ShouldBeCreated()
        {
            //Arrange;
            CreateCourseCommand command = new CreateCourseCommand(_context,_mapper);
            command.Model = new CreateCourseModel{CourseName = "Adv.Python", CourseCode ="SEN4014", HowManyHours = 3 ,TeacherId = 1 ,DepartmentId = 1};
            //test db'sinde olusturmak uzere tum property degerleri uygun bir sekilde verildi.

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var course = _context.Courses.SingleOrDefault(x=>x.CourseCode == command.Model.CourseCode);
            course.CourseName.Should().Be(command.Model.CourseName);
            course.HowManyHours.Should().Be(command.Model.HowManyHours);
            course.TeacherId.Should().Be(command.Model.TeacherId);
            course.DepartmentId.Should().Be(command.Model.DepartmentId);
        }
    }
}
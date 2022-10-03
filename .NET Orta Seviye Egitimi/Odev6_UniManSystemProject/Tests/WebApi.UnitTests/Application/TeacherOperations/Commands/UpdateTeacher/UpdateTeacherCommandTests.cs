using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.TeacherOperations.Commands.UpdateTeacher
{
   public class UpdateTeacherCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
       private readonly IMapper _mapper;
        public UpdateTeacherCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenTeacherIdIsNotFound_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context,_mapper);
            command.TeacherId = 25; //test db'de mevcut olmayan bir teacherId verildiginden hata alinir.
            command.Model = new UpdateTeacherModel{
               Name = "Ali", Surname = "Cuneyt", YearsOfExperience = 10, DepartmentId = 1
            };

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek ogretmen bulunamadi!");
        }

        [Fact]
        public void WhenDepartmentIdOfTeacherIsNotFound_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context,_mapper);
            command.TeacherId = 1;
            command.Model = new UpdateTeacherModel{
               Name = "Ali", Surname = "Cuneyt", YearsOfExperience = 10, DepartmentId = 25
            };
            //test db'de mevcut olmayan bir departmentId verildiginden hata alinir.

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Girilen departman bilgisi mevcut degil!");
        }

        [Fact]
        public void WhenInputsAreAppropriate_Teacher_ShouldBeUpdated()
        {
            //Arrange;
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context,_mapper);
            command.TeacherId = 1;
            command.Model = new UpdateTeacherModel{
               Name = "Ali", Surname = "Cuneyt", YearsOfExperience = 10, DepartmentId = 1
            };

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var teacher = _context.Teachers.SingleOrDefault(x=>x.Id == command.TeacherId);
            teacher.Name.Should().Be(command.Model.Name);
            teacher.Surname.Should().Be(command.Model.Surname);
            teacher.YearsOfExperience.Should().Be(command.Model.YearsOfExperience);
            teacher.DepartmentId.Should().Be(command.Model.DepartmentId);
        }
    }
}
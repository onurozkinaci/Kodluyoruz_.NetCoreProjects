using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.StudentOperations.Commands.UpdateStudent
{
   public class UpdateStudentCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
       private readonly IMapper _mapper;
        public UpdateStudentCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenStudentIdIsNotFound_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            UpdateStudentCommand command = new UpdateStudentCommand(_context,_mapper);
            command.StudentId = 25; //test db'de mevcut olmayan bir studentId verildiginden hata alinir.
            command.Model = new UpdateStudentModel
            {
               Name = "Ali", Surname = "Bora", Email = "abora12@gmail.com", 
               Password = "123456", CurrentGrade = 4, GPA = 3.34 
            };

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek ogrenci mevcut degil!");
        }

        [Fact]
        public void WhenStudentIdIsFound_Student_ShouldBeUpdated()
        {
            //Arrange;
            UpdateStudentCommand command = new UpdateStudentCommand(_context,_mapper);
            command.StudentId = 1;
            command.Model = new UpdateStudentModel
            {
               Name = "Ahmet", Surname = "Duran", Email = "aduran@gmail.com", 
               Password = "123456", CurrentGrade = 4, GPA = 3.34 
            };

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var student = _context.Students.SingleOrDefault(x=>x.Id == command.StudentId);
            student.Name.Should().Be(command.Model.Name);
            student.Surname.Should().Be(command.Model.Surname);
            student.Email.Should().Be(command.Model.Email);
            student.Password.Should().Be(command.Model.Password);
            student.CurrentGrade.Should().Be(command.Model.CurrentGrade);
            student.GPA.Should().Be(command.Model.GPA);
        }
    }
}
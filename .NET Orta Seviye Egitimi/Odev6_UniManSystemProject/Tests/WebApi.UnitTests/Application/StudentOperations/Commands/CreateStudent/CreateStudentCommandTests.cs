using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.StudentOperations.Commands.CreateStudent
{
   public class CreateStudentCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
       private readonly IMapper _mapper;
        public CreateStudentCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenFullnameOfStudentAlreadyExists_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            CreateStudentCommand command = new CreateStudentCommand(_context,_mapper);
            command.Model = new CreateStudentModel
            {
               Name = "Ali", Surname = "Bora", Email = "abora12@gmail.com", 
               Password = "123456", CurrentGrade = 4, GPA = 3.34 
            };
            //test db'de Students tablosunda name-surname olarak mevcut olan bir kayit verildiginden hata alinir.
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu ad-soyad ile bir ogrenci kaydi zaten mevcut!");
        }

        [Fact]
        public void WhenAllInputsAreAppropriate_Student_ShouldBeCreated()
        {
            //Arrange;
            CreateStudentCommand command = new CreateStudentCommand(_context,_mapper);
            command.Model = new CreateStudentModel
            {
               Name = "Ahmet", Surname = "Duran", Email = "aduran@gmail.com", 
               Password = "123456", CurrentGrade = 4, GPA = 3.34 
            };

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var student = _context.Students.SingleOrDefault(x=>x.Name == command.Model.Name && x.Surname == command.Model.Surname);
            student.Name.Should().Be(command.Model.Name);
            student.Surname.Should().Be(command.Model.Surname);
            student.Email.Should().Be(command.Model.Email);
            student.Password.Should().Be(command.Model.Password);
            student.CurrentGrade.Should().Be(command.Model.CurrentGrade);
            student.GPA.Should().Be(command.Model.GPA);
        }
    }
}
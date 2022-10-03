using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.TeacherOperations.Command.CreateTeacher;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.TeacherOperations.Commands.CreateTeacher
{
   public class CreateTeacherCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
       private readonly IMapper _mapper;
       public CreateTeacherCommandTests(CommonTestFixture fixture)
       {
          _context = fixture.Context;
          _mapper = fixture.Mapper;
       }

    [Fact]
    public void WhenFullnameOfTeacherAlreadyExists_InvalidOperationException_ShouldBeReturned()
    {
        //Arrange;
        CreateTeacherCommand command = new CreateTeacherCommand(_context,_mapper);
        command.Model = new CreateTeacherModel{
           Name = "Ali", Surname = "Deniz", YearsOfExperience = 10, DepartmentId = 1
        };
        //Test db'de verilen ad-soyad kaydi mevcut oldugundan hata alinir.
        
        //Act & Assert;
        FluentActions.Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu ad-soyad ile bir ogretmen kaydi zaten mevcut!");
    }

    [Fact]
    public void WhenDepartmentIdOfTeacherDoesNotExist_InvalidOperationException_ShouldBeReturned()
    {
        //Arrange;
        CreateTeacherCommand command = new CreateTeacherCommand(_context,_mapper);
        command.Model = new CreateTeacherModel{
           Name = "Ali", Surname = "Cuneyt", YearsOfExperience = 10, DepartmentId = 25
        };
        //Test db'de Departments tablosunda mevcut olmayan bir departmentId verildigi icin hata alinir.
        
        //Act & Assert;
        FluentActions.Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Girilen departman bilgisi mevcut degil!");
    }

    [Fact]
    public void WhenInputsAreAppropriate_Teacher_ShouldBeCreated()
    {
        //Arrange;
        CreateTeacherCommand command = new CreateTeacherCommand(_context,_mapper);
        command.Model = new CreateTeacherModel{
           Name = "Ali", Surname = "Cuneyt", YearsOfExperience = 10, DepartmentId = 1
        };

        //Act;
        FluentActions.Invoking(() => command.Handle()).Invoke();

        //Assert;
        var course = _context.Teachers.SingleOrDefault(x=>x.Name == command.Model.Name && x.Surname == command.Model.Surname);
        course.YearsOfExperience.Should().Be(command.Model.YearsOfExperience);
        course.DepartmentId.Should().Be(command.Model.DepartmentId);
    }
  }
}
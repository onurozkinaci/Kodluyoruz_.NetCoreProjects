using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.DepartmentOperations.Commands.CreateDepartment;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.DepartmentOperations.Commands.CreateDepartment
{
   public class CreateDepartmentCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
       private readonly IMapper _mapper;
       public CreateDepartmentCommandTests(CommonTestFixture fixture)
       {
          _context = fixture.Context;
          _mapper = fixture.Mapper;
       }

    [Fact]
    public void WhenDepartmentNameAlreadyExists_InvalidOperationException_ShouldBeReturned()
    {
        //Arrange;
        CreateDepartmentCommand command = new CreateDepartmentCommand(_context,_mapper);
        command.Model = new CreateDepartmentModel{DeptName = "Software Engineering"};
        //test db'de mevcut olan bir deptName verildi ve bu sebeple hata alinacak.
        
        //Act & Assert;
        FluentActions.Invoking(() => command.Handle())
        .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu departman ismi ile bir kayit zaten mevcut!");
    }

    [Fact]
    public void WhenDepartmentNameDoesNotExist_Department_ShouldBeCreated()
    {
        //Arrange;
        CreateDepartmentCommand command = new CreateDepartmentCommand(_context,_mapper);
        command.Model = new CreateDepartmentModel{DeptName = "New Department"};
        //test db'de mevcut olmayan bir deptName verildi, hata alinmaz ve yeni departman kaydi test db'ye eklenir.

        //Act;
        FluentActions.Invoking(() => command.Handle()).Invoke();

        //Assert;
        var course = _context.Departments.SingleOrDefault(x=>x.DeptName == command.Model.DeptName);
        course.Should().NotBeNull();
    }
  }
}
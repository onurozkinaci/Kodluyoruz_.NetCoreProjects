using AutoMapper;
using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.DepartmentOperations.Commands.UpdateDepartment;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.DepartmentOperations.Commands.UpdateDepartment
{
   public class UpdateDepartmentCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
       private readonly IMapper _mapper;
        public UpdateDepartmentCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenDepartmentIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            UpdateDepartmentCommand command = new UpdateDepartmentCommand(_context,_mapper);
            command.DeptId = 15; //test db'de mevcut olmayan bir deptId(departman id) verildiginden hata alinir.
            command.Model = new UpdateDepartmentModel{DeptName = "Social Science"};
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek departman bulunamadi!");
        }
    
        [Fact]
        public void WhenDepartmentIdExists_Department_ShouldBeUpdated()
        {
            //Arrange;
            UpdateDepartmentCommand command = new UpdateDepartmentCommand(_context,_mapper);
            command.DeptId = 1;
            command.Model = new UpdateDepartmentModel{DeptName = "Social Science"};
            //test db'sinde olusturmak uzere property degeri uygun bir sekilde verildi.

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var dept = _context.Departments.SingleOrDefault(x=>x.Id == command.DeptId);
            dept.DeptName.Should().Be(command.Model.DeptName);
        }
    }
}
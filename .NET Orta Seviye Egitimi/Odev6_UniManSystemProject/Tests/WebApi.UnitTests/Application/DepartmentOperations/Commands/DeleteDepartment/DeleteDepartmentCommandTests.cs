using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.DepartmentOperations.Commands.DeleteDepartment;
using WebApi.DbOperations;
using WebApi.Entites;

namespace Tests.WebApi.UnitTests.Application.DepartmentOperations.Commands.DeleteDepartment
{
   public class DeleteDepartmentCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
        public DeleteDepartmentCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenDepartmentIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            DeleteDepartmentCommand command = new DeleteDepartmentCommand(_context);
            command.DepartmentId = 25;
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek departman bulunamadi!");
        }

        [Fact]
        public void WhenDepartmentIdExists_Department_ShouldBeDeleted()
        {
            //Arrange;
            DeleteDepartmentCommand command = new DeleteDepartmentCommand(_context);
            command.DepartmentId = 3;
            
            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();
    
            //Assert;
            var course = _context.Courses.SingleOrDefault(x=>x.Id == command.DepartmentId);
            course.Should().BeNull();
        }
    }
}

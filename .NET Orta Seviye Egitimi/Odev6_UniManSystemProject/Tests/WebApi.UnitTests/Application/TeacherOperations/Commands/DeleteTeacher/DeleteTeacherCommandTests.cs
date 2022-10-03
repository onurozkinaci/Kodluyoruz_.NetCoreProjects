using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.TeacherOperations.Commands.DeleteTeacher;
using WebApi.DbOperations;

namespace Tests.WebApi.UnitTests.Application.TeacherOperations.Commands.DeleteTeacher
{
   public class DeleteTeacherCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
        public DeleteTeacherCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenTeacherIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
            command.TeacherId = 25; //test db'de mevcut olmayan bir teacherId verildiginden hata alinir.
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek ogretmen bulunamadi!");
        }

        [Fact]
        public void WhenTeacherIdExists_Teacher_ShouldBeDeleted()
        {
            //Arrange;
            DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
            command.TeacherId = 1; //test db'de mevcut olan bir teacherId verildi ve bu sebeple ilgili teacher/ogretmen kaydi silinir, hata alinmaz.
            
            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var teacher = _context.Teachers.SingleOrDefault(x=>x.Id == command.TeacherId);
            teacher.Should().BeNull(); //silindigi icin null olmali bu id'ye ait kayit test db'de.
        }
    }
}

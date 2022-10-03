using FluentAssertions;
using Test.WebApi.UnitTests.TestSetup;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.DbOperations;
using WebApi.Entites;

namespace Tests.WebApi.UnitTests.Application.StudentOperations.Commands.DeleteStudent
{
   public class DeleteStudentCommandTests:IClassFixture<CommonTestFixture>
   {
       private readonly UniManSystemDbContext _context;
        public DeleteStudentCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenStudentIdDoesNotExist_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = 25;
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek ogrenci mevcut degil!");
        }

        [Fact]
        public void WhenStudentIdExistOnSelectedLecturesTable_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = 1; //Selected Lectures tablosunda mevcut bir StudentId oldugundan silinmek istendiginde
            //asagidaki hatayi verecek;
            
            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Ilgili ogrenci, oncelikle 'Secilen Dersler' tablosundan silinmelidir!");
        }

        [Fact]
        public void WhenAllInputsAreAppropriate_Student_ShouldBeDeleted()
        {
            //Arrange;
            //SelectedLecture tablosunda var olan bir StudentId olmamasi icin yeni bir Student olusturuldu,
            //onun id'si de 4 olacak ve o silinecek;
            var newStudent = new Student {Name = "Ayse", Surname = "Alici", Email = "aalici@gmail.com", Password = "12345",
                            CurrentGrade = 3, GPA = 3.24};
            _context.Students.Add(newStudent);
            _context.SaveChanges();

            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = 4;
            
            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();
    
            //Assert;
            var student = _context.Students.SingleOrDefault(x=>x.Id == command.StudentId);
            student.Should().BeNull();
        }
    }
}

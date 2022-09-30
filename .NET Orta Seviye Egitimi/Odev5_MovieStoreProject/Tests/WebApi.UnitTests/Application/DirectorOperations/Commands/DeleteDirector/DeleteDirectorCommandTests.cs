using FluentAssertions;
using TestSetup;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.DirectorOperations.Commands.CreateDirector
{
  public class DeleteDirectorCommandTests:IClassFixture<CommonTestFixture>
  {
     private readonly MovieStoreDbContext _context;

     public DeleteDirectorCommandTests(CommonTestFixture fixture)
     {
        _context = fixture.Context;
     }
     
     [Fact]
     public void WhenGivenDirectorIdIsNotFound_InvalidOperationException_ShouldBeGiven()
     {
         //Arrange;
         DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
         command.DirectorId = 25; //test db'de mevcut olmayan directorId.

         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek yonetmen bulunamadi!");
     }

     [Fact]
     public void WhenGivenDirectorIdExistsInFilmTable_InvalidOperationException_ShouldBeGiven()
     {
         //Arrange;
         DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
         command.DirectorId = 1; //test db'de 'Film' tablosunda bu actorid mevcut oldugundan direkt sildirmez ve hata verir.

         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Filmi bulunan bir yonetmen direkt buradan silinemez, oncelikle ilgili tablodan silinmelidir!");
     }

     [Fact]
     public void WhenGivenActorIdIsAppropriateForDeleting_Actor_ShouldBeDeleted()
     {
         //Arrange;
         //Yeni bir yonetmen/director olusturulup o silindi(Film tablosunda da kaydinin olmamasi idin).
         //2 tane default olusturuldugundan bunun id'si 3 olur;
         var directorNew = new Yonetmen(){Name = "Ali", Surname = "Cevrim"};
         _context.Yonetmenler.Add(directorNew);
         _context.SaveChanges();

         DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
         command.DirectorId = 3; //test db'de 'Yonetmenler' tablosunda mevcut olan bir director id verildi.

         //Act;
         FluentActions.Invoking(() => command.Handle()).Invoke();

         //Assert;
         var director = _context.Yonetmenler.SingleOrDefault(x=>x.Id == command.DirectorId);
         director.Should().BeNull();
     }
  }
}

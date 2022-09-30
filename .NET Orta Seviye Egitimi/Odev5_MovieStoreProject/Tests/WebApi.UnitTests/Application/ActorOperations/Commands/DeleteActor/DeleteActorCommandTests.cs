using FluentAssertions;
using TestSetup;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.ActorOperations.Commands.DeleteActor
{
  public class DeleteActorCommandTests:IClassFixture<CommonTestFixture>
  {
     private readonly MovieStoreDbContext _context;

     public DeleteActorCommandTests(CommonTestFixture fixture)
     {
        _context = fixture.Context;
     }
     
     [Fact]
     public void WhenGivenActorIdIsNotFound_InvalidOperationException_ShouldBeGiven()
     {
         //Arrange;
         DeleteActorCommand command = new DeleteActorCommand(_context);
         command.ActorId = 25; //test db'de 'Actors' tablosunda icin mevcut olmayan bir actorId verildi.

         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek oyuncu/aktor bulunamadi!");
     }

     [Fact]
     public void WhenGivenActorIdExistsInOyuncuFilmTable_InvalidOperationException_ShouldBeGiven()
     {
         //Arrange;
         DeleteActorCommand command = new DeleteActorCommand(_context);
         command.ActorId = 1; //test db'de 'OyuncuFilm' tablosunda bu actorid mevcut oldugundan direkt sildirmez ve hata verir.

         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu oyuncu filmlerle iliskili oldugundan direkt buradan silinemez, oncelikle iliskili tablodan silinmelidir!");
     }

     [Fact]
     public void WhenGivenActorIdIsAppropriateForDeleting_Actor_ShouldBeDeleted()
     {
         //Arrange;
         //Yeni bir aktor olusturulup o silindi(OyuncuFilm tablosunda da mevcut olmamasi adina),
         //4 tane default olusturuldugundan bunun id'si 5 olur;
         var actorNew = new Oyuncu(){Name = "Arda", Surname = "Usta"};
         _context.Oyuncular.Add(actorNew);
         _context.SaveChanges();

         DeleteActorCommand command = new DeleteActorCommand(_context);
         command.ActorId = 5; //test db'de 'Actors' tablosunda mevcut olan bir actor id verildi.

         //Act;
         FluentActions.Invoking(() => command.Handle()).Invoke();

         //Assert;
         var actor = _context.Oyuncular.SingleOrDefault(x=>x.Id == command.ActorId);
         actor.Should().BeNull();
     }

  }
}
using FluentAssertions;
using TestSetup;
using WebApi.Application.FilmOperations.Commands.DeleteFilm;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.FilmOperations.Commands.DeleteFilm
{
  public class DeleteFilmCommandTests:IClassFixture<CommonTestFixture>
  {
     private readonly MovieStoreDbContext _context;

     public DeleteFilmCommandTests(CommonTestFixture fixture)
     {
        _context = fixture.Context;
     }
     
     [Fact]
     public void WhenGivenFilmIdIsNotFound_InvalidOperationException_ShouldBeGiven()
     {
         //Arrange;
         DeleteFilmCommand command = new DeleteFilmCommand(_context);
         command.FilmId = 25; //test db'de mevcut olmayan filmId.

         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek film bulunamadi!");
     }

     [Fact]
     public void WhenGivenFilmIdExistsInOyuncuFilmTable_InvalidOperationException_ShouldBeGiven()
     {
         //Arrange;
         DeleteFilmCommand command = new DeleteFilmCommand(_context);
         command.FilmId = 1; //test db'de 'OyuncuFilm' tablosunda bu filmid mevcut oldugundan direkt buradan sildirmez ve hata verir.

         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu film oyuncularla iliskili oldugundan direkt buradan silinemez, oncelikle iliskili tablodan silinmelidir!");
     }

     [Fact]
     public void WhenGivenFilmIdExistsInSiparislerTable_InvalidOperationException_ShouldBeGiven()
     {
         //Arrange;
         DeleteFilmCommand command = new DeleteFilmCommand(_context);
         command.FilmId = 1; //test db'de 'Siparisler' tablosunda bu filmid mevcut oldugundan direkt buradan sildirmez ve hata verir.

         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Satin alinan bir film buradan direkt silinemez, oncelikle siparislerden silinmelidir!");
     }

     [Fact]
     public void WhenGivenFilmIdIsAppropriateForDeleting_Film_ShouldBeDeleted()
     {
            //Arrange;
            //Yeni bir film olusturulup o silindi(Diger tablolarda da (OyuncuFilm,Siparisler) kaydinin olmamasi icin).
            //3 tane default olusturuldugundan bunun id'si 4 olur;
            var filmNew = new Film{ Name = "Departed",GenreId = 2, Price = 250,YonetmenId = 1};
            _context.Films.Add(filmNew);
            _context.SaveChanges();

            DeleteFilmCommand command = new DeleteFilmCommand(_context);
            command.FilmId = 4; //yeni olusturulan(ustteki) film'in id'si verildi.

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var film = _context.Films.SingleOrDefault(x=>x.Id == command.FilmId);
            film.Should().BeNull(); //silindigi icin kayit donmemeli.
     }

  }
}

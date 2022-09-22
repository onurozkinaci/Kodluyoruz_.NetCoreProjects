using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenGivenGenreIdIsNotFound_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 15; //test db'de mevcut olmayan bir genre id verilip hata alinip alinmadigi test edilir.

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
              .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek kitap turu bulunamadi!");
        }

        [Fact]
        public void WhenGivenGenreNameAlreadyExists_InvalidOperationException_ShouldBeReturned()
        {
           //Arrange;
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 1; //test db'de mevcut olan bir id verilir.
            UpdateGenreModel model = new UpdateGenreModel(){Name = "Science Fiction"}; //mevcut bir isim verildi, hata donmeli.
            command.Model = model;

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
              .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Ayni isimli bir kitap turu zaten mevcut!");
        }

        //Happy path;
        [Fact]
        public void WhenNameAndIdAreGivenAppropriately_Genre_ShouldBeUpdated()
        {
           //Arrange;
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 1; //test db'de mevcut olan bir id verilir.
            UpdateGenreModel model = new UpdateGenreModel(){Name = "Adventure"}; //mevcut bir isim verildi, hata donmeli.
            command.Model = model;

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle()).Invoke();

           //Assert;
           var genre = _context.Genres.SingleOrDefault(x=>x.Name == model.Name);
           genre.Should().NotBeNull(); //Update(command.Handle) sonrasinda verdigimiz isimle genre olustugunu teyit etmek icin.
        }
    }
}
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.FilmOperations.Commands.UpdateFilm;
using WebApi.DbOperations;

namespace Application.FilmOperations.Commands.UpdateFilm
{
    public class UpdateFilmCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateFilmCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenUpdatedFilmIdIsNotFound_InvalidOperationException_ShouldBeGiven()
        {
           //Arrange;
           UpdateFilmCommand command = new UpdateFilmCommand(_context,_mapper);
           command.FilmId = 30; //test db'de mevcut olmayan bir film id oldugundan hata verilecek, guncellenemez.
           command.Model = new UpdateFilmModel(){Name = "Deneme1",GenreId=1,Price=250,YonetmenId=1};

           //Act & Assert;
           FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek film bulunamadi!");
        }

        [Fact]
        public void WhenUpdatedFilmIdIsFound_Film_ShouldBeUpdated()
        {
            //Arrange;
            UpdateFilmCommand command = new UpdateFilmCommand(_context,_mapper);
            command.FilmId =  1; //test db'de mevcut bir director id oldugundan guncelleme saglanir, hata vermez.
            command.Model = new UpdateFilmModel(){Name = "Deneme1",GenreId=1,Price=250,YonetmenId=1};

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var film = _context.Films.SingleOrDefault(x=>x.Id == command.FilmId);
            film.Name.Should().Be(command.Model.Name);
            film.GenreId.Should().Be(command.Model.GenreId);
            film.YonetmenId.Should().Be(command.Model.YonetmenId);
        }
    }
}
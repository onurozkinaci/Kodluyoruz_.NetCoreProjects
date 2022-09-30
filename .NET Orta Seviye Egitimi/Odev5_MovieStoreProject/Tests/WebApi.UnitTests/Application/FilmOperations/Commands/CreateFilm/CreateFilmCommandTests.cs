using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.FilmOperations.Commands.CreateFilm;
using WebApi.DbOperations;

namespace Application.FilmOperations.Commands.CreateFilm
{
    public class CreateFilmCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateFilmCommandTests(CommonTestFixture fixture)
        {
           _context = fixture.Context;
           _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenFilmNameIsAlreadyExists_InvalidOperationException_ShouldBeGiven()
        {
            //Arrange;
            CreateFilmCommand command = new CreateFilmCommand(_context,_mapper);
            command.Model = new CreateFilmModel()
            { Name = "Fight Club", //test db'de mevcut bir film ismi oldugundan hata alinacak.
                GenreId = 5,
                Price = 150,
                YonetmenId = 1
            };

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isimde bir film zaten mevcut!");
        }

        [Fact]
        public void WhenFilmNameDoesNotExist_Film_ShouldBeCreated()
        {
            //Arrange;
            CreateFilmCommand command = new CreateFilmCommand(_context,_mapper);
            command.Model = new CreateFilmModel()
            { Name = "Uncharted", //test db'de mevcut olmayan bir film ismi verildi.
                GenreId = 5,
                Price = 450,
                YonetmenId = 1
            };

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var film = _context.Films.SingleOrDefault(x=>x.Name == command.Model.Name);
            film.Should().NotBeNull();
        }
    }
}
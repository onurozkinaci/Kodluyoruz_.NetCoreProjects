using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.DbOperations;

namespace Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDirectorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenUpdatedDirectorIdIsNotFound_InvalidOperationException_ShouldBeGiven()
        {
           //Arrange;
           UpdateDirectorCommand command = new UpdateDirectorCommand(_context,_mapper);
           command.DirectorId = 30; //test db'de mevcut olmayan bir director id oldugundan hata verilecek, guncellenemez.
           command.Model = new UpdateDirectorModel(){Name = "Onr", Surname = "Ozk"};

           //Act & Assert;
           FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek oyuncu/aktor bulunamadi!");
        }

        [Fact]
        public void WhenUpdatedDirectorIdIsFound_Actor_ShouldBeUpdated()
        {
            //Arrange;
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context,_mapper);
            command.DirectorId =  1; //test db'de mevcut bir director id oldugundan guncelleme saglanir, hata vermez.
            command.Model = new UpdateDirectorModel(){Name = "Onr", Surname = "Ozk"};

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var director = _context.Yonetmenler.SingleOrDefault(x=>x.Id == command.DirectorId);
            director.Name.Should().Be(command.Model.Name);
            director.Surname.Should().Be(command.Model.Surname);
        }
    }
}
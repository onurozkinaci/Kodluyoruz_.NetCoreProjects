using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using WebApi.DbOperations;

namespace Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateActorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenUpdatedActorIdIsNotFound_InvalidOperationException_ShouldBeGiven()
        {
           //Arrange;
           UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
           command.ActorId = 30; //test db'de mevcut olmayan bir actor id oldugundan hata verilecek, guncellenemez.
           command.Model = new UpdateActorModel(){Name = "Onr", Surname = "Ozk"};

           //Act & Assert;
           FluentActions.Invoking(() => command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek oyuncu/aktor bulunamadi!");
        }

        [Fact]
        public void WhenUpdatedActorIdIsFound_Actor_ShouldBeUpdated()
        {
            //Arrange;
            UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
            command.ActorId =  1; //test db'de mevcut bir actor id oldugundan guncelleme saglanir, hata vermez.
            command.Model = new UpdateActorModel(){Name = "Onr", Surname = "Ozk"};

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var actor = _context.Oyuncular.SingleOrDefault(x=>x.Id == command.ActorId);
            actor.Name.Should().Be(command.Model.Name);
            actor.Surname.Should().Be(command.Model.Surname);
        }
    }
}
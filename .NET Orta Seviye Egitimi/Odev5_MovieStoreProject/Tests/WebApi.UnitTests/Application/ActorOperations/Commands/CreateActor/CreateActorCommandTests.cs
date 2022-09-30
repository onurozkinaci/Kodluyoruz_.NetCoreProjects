using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.DbOperations;

namespace Application.ActorOperations.Commands.CreateActor
{
  public class CreateActorCommandTests:IClassFixture<CommonTestFixture>
  {
     private readonly MovieStoreDbContext _context;
     private readonly IMapper _mapper;

     public CreateActorCommandTests(CommonTestFixture fixture)
     {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
     }

     [Fact]
     public void WhenGivenFullNameIsAlreadyExists_InvalidOperationException_ShouldBeReturned()
     {
         //Arrange;         
         CreateActorCommand command = new CreateActorCommand(_context,_mapper);
         command.Model = new CreateActorModel(){ Name = "Brad",Surname = "Pitt"}; //test db'de mevcut bir ad-soyad oldugundan hata verilecek

         //Act & Assert;
         FluentActions.Invoking(() => command.Handle())
                     .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu ad-soyad ile bir oyuncu kaydi zaten mevcut!");
     }

     [Fact]
     public void WhenGivenFullNameIsNotExist_Actor_ShouldBeCreated()
     {
         //Arrange;         
         CreateActorCommand command = new CreateActorCommand(_context,_mapper);
         CreateActorModel model = new CreateActorModel(){ Name = "Ayse",Surname = "Deniz"}; //test db'de mevcut bir kullanici olmadigindan olusturulacak.
         command.Model = model;

         //Act;
         FluentActions.Invoking(() => command.Handle()).Invoke();
        
         //Assert => 'actor' un olusturuldugunu test etmek icin;
         var actor = _context.Oyuncular.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);
         actor.Should().NotBeNull();
     }
  }
}
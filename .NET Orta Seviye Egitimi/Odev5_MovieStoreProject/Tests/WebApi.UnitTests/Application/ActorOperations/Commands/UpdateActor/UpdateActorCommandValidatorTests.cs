using FluentAssertions;
using TestSetup;
using WebApi.Application.ActorOperations.Commands.UpdateActor;

namespace Application.ActorOperations.Commands.UpdateActor
{
  public class CreateActorCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
     [Theory]
     [InlineData(0,"onur","ozkn")] //authorid hata verir.
     [InlineData(0,"","")] //burada hepsinden dolayi hata verir(authorid,name,surname).
     [InlineData(1,"onr","ozk")] //name ve surname hata verir.
     [InlineData(1,"onur","ozk")] //surname hata verir.
     [InlineData(1,"","ozkn")] //name hata verir(bos/empty).
     public void WhenUpdatedInputsAreInvalid_ActorValidator_ShouldReturnErrors(int actorId, string name, string surname)
     {
        //Arrange;
        UpdateActorCommand command = new UpdateActorCommand(null,null);
        command.ActorId = actorId;
        command.Model = new UpdateActorModel(){Name = name, Surname = surname};

        //Act;
        UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().BeGreaterThan(0); //hata sayisi en az 1 olur, hata alinir.
     }

     [Fact]
     public void WhenUpdatedInputsAreValid_ActorValidator_ShouldNotReturnErrors()
     {
        //Arrange;
        UpdateActorCommand command = new UpdateActorCommand(null,null);
        command.ActorId = 1; //valid
        command.Model = new UpdateActorModel(){Name = "ONUR", Surname = "OZKN"}; //valid name and surname

        //Act;
        UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().Be(0); //hata vermez.
     }
  }
}
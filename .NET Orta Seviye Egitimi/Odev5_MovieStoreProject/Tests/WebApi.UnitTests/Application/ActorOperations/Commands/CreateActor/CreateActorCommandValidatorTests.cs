using FluentAssertions;
using TestSetup;
using WebApi.Application.ActorOperations.Commands.CreateActor;

namespace Application.ActorOperations.Commands.CreateActor
{
  public class CreateActorCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
     [Theory]
     [InlineData("","")] //name ve surname bos verildigi icin hata alinir.
     [InlineData("onr","")] //onr, 4 harften kucuk old. icin hata verir.
     [InlineData("onur","ozk")] //ozk, 4 harften kucuk old. icin hata verir.
     public void WhenInputsAreGivenInvalid_ActorValidator_ShouldReturnErrors(string name, string surname)
     {
        //Arrange;
        CreateActorCommand command = new CreateActorCommand(null,null);
        command.Model = new CreateActorModel(){Name = name, Surname = surname};

        //Act;
        CreateActorCommandValidator validator = new CreateActorCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().BeGreaterThan(0); //hata sayisi en az 1 olur, hata alinir.
     }

     [Fact]
     public void WhenInputsAreValid_ActorValidator_ShouldNotReturnErrors()
     {
        //Arrange;
        CreateActorCommand command = new CreateActorCommand(null,null);
        command.Model = new CreateActorModel(){Name = "ONUR", Surname = "OZKN"}; //dogru verildigi icin validator hata firlatmaz.

        //Act;
        CreateActorCommandValidator validator = new CreateActorCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().Be(0); //hata donmez(0 hata).
     }
  }
}
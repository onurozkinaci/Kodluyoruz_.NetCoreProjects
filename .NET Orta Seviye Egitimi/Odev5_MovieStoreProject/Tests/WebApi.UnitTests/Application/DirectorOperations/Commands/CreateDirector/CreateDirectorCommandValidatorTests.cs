using FluentAssertions;
using TestSetup;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;

namespace Application.DirectorOperations.Commands.CreateDirector
{
  public class CreateDirectorCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
     [Theory]
     [InlineData("","")] //name ve surname bos verildigi icin hata alinir.
     [InlineData("onr","")] //onr, 4 harften kucuk old. icin hata verir.
     [InlineData("onur","ozk")] //ozk, 4 harften kucuk old. icin hata verir.
     public void WhenInputsAreGivenInvalid_DirectorValidator_ShouldReturnErrors(string name, string surname)
     {
        //Arrange;
        CreateDirectorCommand command = new CreateDirectorCommand(null,null);
        command.Model = new CreateDirectorModel(){Name = name, Surname = surname};

        //Act;
        CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().BeGreaterThan(0); //hata sayisi en az 1 olur, hata alinir.
     }

     [Fact]
     public void WhenInputsAreValid_ActorValidator_ShouldNotReturnErrors()
     {
        //Arrange;
        CreateDirectorCommand command = new CreateDirectorCommand(null,null);
        command.Model = new CreateDirectorModel(){Name = "ONUR", Surname = "OZKN"}; //dogru verildigi icin validator hata firlatmaz.

        //Act;
        CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().Be(0); //hata donmez(0 hata).
     }
  }
}
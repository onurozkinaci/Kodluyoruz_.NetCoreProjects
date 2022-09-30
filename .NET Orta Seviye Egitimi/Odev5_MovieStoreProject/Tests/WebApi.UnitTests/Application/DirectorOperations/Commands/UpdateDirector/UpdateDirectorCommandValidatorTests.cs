using FluentAssertions;
using TestSetup;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;

namespace Application.DirectorOperations.Commands.UpdateDirector
{
  public class UpdateDirectorCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
     [Theory]
     [InlineData(0,"onur","ozkn")] //directorid hata verir.
     [InlineData(0,"","")] //burada hepsinden dolayi hata verir(authorid,name,surname).
     [InlineData(1,"onr","ozk")] //name ve surname hata verir.
     [InlineData(1,"onur","ozk")] //surname hata verir.
     [InlineData(1,"","ozkn")] //name hata verir(bos/empty).
     public void WhenUpdatedInputsAreInvalid_ActorValidator_ShouldReturnErrors(int directorId, string name, string surname)
     {
        //Arrange;
        UpdateDirectorCommand command = new UpdateDirectorCommand(null,null);
        command.DirectorId = directorId;
        command.Model = new UpdateDirectorModel(){Name = name, Surname = surname};

        //Act;
        UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().BeGreaterThan(0); //hata sayisi en az 1 olur, hata alinir.
     }

     [Fact]
     public void WhenUpdatedInputsAreValid_ActorValidator_ShouldNotReturnErrors()
     {
        //Arrange;
        UpdateDirectorCommand command = new UpdateDirectorCommand(null,null);
        command.DirectorId = 1; //valid
        command.Model = new UpdateDirectorModel(){Name = "ONUR", Surname = "OZKN"}; //valid name and surname

        //Act;
        UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().Be(0); //hata vermez.
     }
  }
}
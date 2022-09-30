using FluentAssertions;
using TestSetup;
using WebApi.Application.FilmOperations.Commands.CreateFilm;

namespace Application.FilmOperations.Commands.CreateFilm
{
  public class CreateFilmCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
     [Theory]
     [InlineData("",2,200,1)] //name bos verildigi icin hata alinir.
     [InlineData("onur",0,250,2)] //genreId = 0 verildigi icin hata alinir(>0 olmali).
     [InlineData("onur",1,0,2)] //price = 0 verildigi icin hata alinir(>0 olmali).
     [InlineData("onur",1,1,0)] //yonetmenId = 0 verildigi icin hata alinir(>0 olmali).
     [InlineData("",0,-10,-2)] //parametrelerin/inputlarin hepsi hata verir.
     public void WhenInputsAreGivenInvalid_FilmValidator_ShouldReturnErrors(string name, int genreId, double price, int yonetmenId)
     {
        //Arrange;
        CreateFilmCommand command = new CreateFilmCommand(null,null);
        command.Model = new CreateFilmModel(){Name = name, GenreId = genreId, Price = price, YonetmenId = yonetmenId};

        //Act;
        CreateFilmCommandValidator validator = new CreateFilmCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().BeGreaterThan(0); //hata sayisi en az 1 olur, hata alinir.
     }

     [Fact]
     public void WhenInputsAreValid_ActorValidator_ShouldNotReturnErrors()
     {
        //Arrange;
        CreateFilmCommand command = new CreateFilmCommand(null,null);
        command.Model = new CreateFilmModel()
        {   Name = "Uncharted", //4 harften buyuk ve idler de 0'dan buyuk old. sorun olmayacak, film kaydi olusturulacak.
            GenreId = 5,
            Price = 450,
            YonetmenId = 1
        };

        //Act;
        CreateFilmCommandValidator validator = new CreateFilmCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().Be(0); //hata donmez(0 hata).
     }
  }
}
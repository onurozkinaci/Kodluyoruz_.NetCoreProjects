using FluentAssertions;
using TestSetup;
using WebApi.Application.FilmOperations.Commands.UpdateFilm;

namespace Application.FilmOperations.Commands.UpdateFilm
{
  public class UpdateFilmCommandValidatorTests:IClassFixture<CommonTestFixture>
  {
     [Theory]
     [InlineData(0,"onur",2,200,1)] //filmId 0 old. icin hata verir(validator'daki rule'a gore >0 olmali).
     [InlineData(1,"",1,250,2)]
     [InlineData(1,"onur",0,1,2)]
     [InlineData(1,"onur",1,0,2)]
     [InlineData(1,"onur",1,1,0)]
     [InlineData(0,"",0,-10,-2)] //parametrelerin/inputlarin hepsi hata verir.
     public void WhenUpdatedInputsAreInvalid_FilmValidator_ShouldReturnErrors(int filmId, string name, int genreId, double price, int yonetmenId)
     {
        //Arrange;
        UpdateFilmCommand command = new UpdateFilmCommand(null,null);
        command.FilmId = filmId;
        command.Model = new UpdateFilmModel(){Name = name, GenreId= genreId, Price = price, YonetmenId = yonetmenId};

        //Act;
        UpdateFilmCommandValidator validator = new UpdateFilmCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().BeGreaterThan(0); //hata sayisi en az 1 olur, hata alinir.
     }

     [Fact]
     public void WhenUpdatedInputsAreValid_FilmValidator_ShouldNotReturnErrors()
     {
        //Arrange;
        UpdateFilmCommand command = new UpdateFilmCommand(null,null);
        command.FilmId = 1; //valid
        command.Model = new UpdateFilmModel(){Name = "Deneme1",GenreId=1,Price=250,YonetmenId=1}; //valid inputs are given.

        //Act;
        UpdateFilmCommandValidator validator = new UpdateFilmCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().Be(0); //hata vermez.
     }
  }
}
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"LTR")] //name, bos veya 4 harften fazla gonderilebilir, bos gonderilmesi de yalnizca id'nin guncellenebilmesine olanak saglamak.
        [InlineData(1,"LTR")]
        [InlineData(0,"")] //id'den dolayi hata verir, name bos gonderilebilir.
        public void WhenInvalidInputsAreGiven_GenreValidator_ShouldReturnErrors(int genreId, string genreName)
        {
           //Arrange;
           UpdateGenreCommand command = new UpdateGenreCommand(null);
           command.GenreId = genreId;
           command.Model = new UpdateGenreModel(){Name = genreName};

           //Act;
           UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
           var result = validator.Validate(command);

           //Assert;
           result.Errors.Count.Should().BeGreaterThan(0); //en az 1 tane hata vermeli, hatali inputlar gonderildigi icin inlinedata araciligiyla.
        }

        [Fact]
        public void WhenValidInputsAreGiven_GenreValidator_ShouldNotReturnErrors()
        {
           //Arrange;
           UpdateGenreCommand command = new UpdateGenreCommand(null);
           command.GenreId = 1;
           command.Model = new UpdateGenreModel(){Name = "Biograph"};

           //Act;
           UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
           var result = validator.Validate(command);

           //Assert;
           result.Errors.Count.Should().Be(0); //Hata donmemeli(0 hata).
    }
 }
} 
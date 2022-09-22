using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DbOperations;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenNameInputIsGivenInvalid_GenreValidator_ShouldReturnError()
        {
           //Arrange;
           CreateGenreCommand command = new CreateGenreCommand(null);
           command.Model = new CreateGenreModel(){Name = ""};

           //Act;
           CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
           var result = validator.Validate(command);

           //Assert;
           result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenNameInputIsGivenValid_GenreValidator_ShouldNotReturnError()
        {
           //Arrange;
           CreateGenreCommand command = new CreateGenreCommand(null);
           command.Model = new CreateGenreModel(){Name = "History"};

           //Act;
           CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
           var result = validator.Validate(command);

           //Assert;
           result.Errors.Count.Should().Be(0);
        }
    }
}
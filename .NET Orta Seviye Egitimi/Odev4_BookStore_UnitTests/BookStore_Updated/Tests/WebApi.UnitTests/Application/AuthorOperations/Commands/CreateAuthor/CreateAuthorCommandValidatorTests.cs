using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.Commands.CreateAuthor;
using WebApi.Application.GenreOperations.Commands.CreateGenre;

namespace Application.GenreOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","",4)]
        [InlineData("Deniz"," ",4)]
        [InlineData("","Demir",1)]
        [InlineData("Halil","Avci",0)]
         public void WhenInputsAreGivenInvalid_AuthorValidator_ShouldReturnErrors(string name, string surname, int bookId)
         {
           //Arrange;
           CreateAuthorCommand command = new CreateAuthorCommand(null,null);
           command.Model = new CreateAuthorModel(){Ad =name, Soyad = surname, BookId = bookId};

           //Act;
           CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
           var result = validator.Validate(command);

           //Assert;
           result.Errors.Count.Should().BeGreaterThan(0);
         }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldReturnError()
        {
           //Arrange;
           CreateAuthorCommand command = new CreateAuthorCommand(null,null);
           command.Model = new CreateAuthorModel()
           {
             Ad = "Onur", Soyad = "Ozk", DogumTarihi = DateTime.Now.Date, BookId = 4
           };
           
           //Act;
           CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
           var result = validator.Validate(command);
           
           //Assert;
           result.Errors.Count.Should().BeGreaterThan(0); //en az 1 tane error/hata donmeli.
        }

         [Fact]
         public void WhenNameInputIsGivenValid_AuthorValidator_ShouldNotReturnErrors()
         {
           //Arrange;
           CreateAuthorCommand command = new CreateAuthorCommand(null,null);
           command.Model = new CreateAuthorModel()
           {
             Ad = "Onur", Soyad = "Ozk", DogumTarihi = DateTime.Now.Date.AddYears(-2), BookId = 4
           };

           //Act;
           CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
           var result = validator.Validate(command);

           //Assert;
           result.Errors.Count.Should().Be(0);
         }
   } 
}
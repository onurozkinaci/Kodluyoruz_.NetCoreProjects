using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.DeleteBook;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidIdIsGiven_Validator_ShouldReturnError()
       {
          //Arrange;
          DeleteBookCommand command = new DeleteBookCommand(null);
          int id = -1; //id, 0'dan buyuk girilmeli DeleteBookCommandValidator'da verilen kurallara/rule gore.
          command.BookId = id;

          //Act;
          DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
          var result = validator.Validate(command);
          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0); //0'dan cok yani en az 1 tane hata firlatilmali demis olduk.
       }

       [Fact]
        public void WhenValidIdIsGiven_Validator_ShouldNotReturnError()
       {
          //Arrange;
          DeleteBookCommand command = new DeleteBookCommand(null);
          int id = 10; //0'dan buyuk yani valid bir id verildi, validasyon kapsaminda hata vermez, db'de olup olmamasi DeleteBookCommandTests.cs'de yazilan baska bir unit test'in concern'u.
          command.BookId = id;

          //Act;
          DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
          var result = validator.Validate(command);
          
          //Assert;
          result.Errors.Count.Should().Be(0);
       }
    }
}
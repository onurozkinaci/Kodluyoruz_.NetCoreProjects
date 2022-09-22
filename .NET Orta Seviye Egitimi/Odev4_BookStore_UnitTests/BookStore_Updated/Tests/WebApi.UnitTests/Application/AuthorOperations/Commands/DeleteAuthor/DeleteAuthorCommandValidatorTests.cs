using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.Commands.CreateAuthor;
using WebApi.Application.Commands.DeleteAuthor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
   public class DeleteAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
        [Fact]
        public void WhenInvalidIdIsGiven_Validator_ShouldReturnError()
        {
          //Arrange;
          DeleteAuthorCommand command = new DeleteAuthorCommand(null);
          int id = 0;
          command.AuthorId= id;

          //Act;
          DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
          var result = validator.Validate(command);
          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidIdIsGiven_Validator_ShouldNotReturnError()
        {
          //Arrange;
          DeleteAuthorCommand command = new DeleteAuthorCommand(null);
          int id = 10;
          command.AuthorId = id;

          //Act;
          DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
          var result = validator.Validate(command);
          
          //Assert;
          result.Errors.Count.Should().Be(0);
        }
   }
}
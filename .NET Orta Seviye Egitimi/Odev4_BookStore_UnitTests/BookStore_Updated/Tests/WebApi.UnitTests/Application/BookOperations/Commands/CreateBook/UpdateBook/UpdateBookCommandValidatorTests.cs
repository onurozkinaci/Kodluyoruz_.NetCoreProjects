using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"LOTR",1)]
        [InlineData(0,"LOTR",0)]
        [InlineData(0,"",0)]
        [InlineData(1,"",1)]
        [InlineData(1,"",0)]
        [InlineData(1," ",1)]
        [InlineData(1,"LOTR",0)]
        public void WhenInvalidInputsAreGiven_UpdateValidator_ShouldReturnErrors(int bookId, string title, int genreId)
        {
          //Arrange;
          UpdateBookCommand command = new UpdateBookCommand(null,null);
          command.BookId=bookId;
          command.Model = new UpdateBookModel(){Title = title,GenreId = genreId};
        
          //Act;
          UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0); //0'dan cok yani en az 1 tane hata firlatilmali demis olduk.
       }

       [Fact]
       public void WhenValidInputsAreGiven_UpdateValidator_ShouldNotReturnError()
       {
          //Arrange;
          UpdateBookCommand command = new UpdateBookCommand(null,null);
          command.BookId=1;
          command.Model = new UpdateBookModel(){Title = "LOTR",GenreId = 1};
        
          //Act;
          UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().Be(0); //Hata donmemeli(0 hata).
       }
    }
}
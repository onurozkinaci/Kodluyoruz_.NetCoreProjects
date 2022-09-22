using FluentAssertions;
using TestSetup;
using WebApi.Application.Commands.UpdateAuthor;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
   public class UpdateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
   {
        [Theory]
        [InlineData(0,"test1","test1v1",1)]
        [InlineData(1,"","test2v2",1)]
        [InlineData(1," ","test3v3",1)]
        [InlineData(1,"test4","",1)]
        [InlineData(1,"test5","test5v5",0)]
        [InlineData(0,""," ",0)]
        public void WhenInvalidInputsAreGiven_UpdateAuthorValidator_ShouldReturnErrors(int authorId, string name, string surname, int bookId)
        {
          //Arrange;
          UpdateAuthorCommand command = new UpdateAuthorCommand(null,null);
          command.AuthorId=authorId;
          command.Model = new UpdateAuthorModel(){Ad = name, Soyad = surname, BookId = bookId};
        
          //Act;
          UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0); //0'dan cok yani en az 1 tane hata firlatilmali demis olduk.
       }

       [Fact]
       public void WhenValidInputsAreGiven_UpdateAuthorValidator_ShouldNotReturnErrors()
       {
          //Arrange;
          UpdateAuthorCommand command = new UpdateAuthorCommand(null,null);
          command.AuthorId=1;
          command.Model = new UpdateAuthorModel(){Ad = "Onur", Soyad = "Ozk", BookId = 1}; //valid inputs acc. to the given rules with Fluent Validator in "UpdateAuthorCommandValidator.cs" class.
        
          //Act;
          UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().Be(0); //Hata donmemeli(0 hata).
       }
   }
}
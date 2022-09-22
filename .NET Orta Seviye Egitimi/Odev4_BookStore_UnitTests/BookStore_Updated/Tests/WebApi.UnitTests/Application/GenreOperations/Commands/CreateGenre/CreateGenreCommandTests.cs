using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DbOperations;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
       private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;
       public CreateGenreCommandTests(CommonTestFixture fixture)
       {
          _context = fixture.Context;
          _mapper = fixture.Mapper;
       } 
      [Fact]
      public void WhenGenreNameAlreadyExists_InvalidOperationException_ShouldBeReturned()
      {
        //Arrange;
        CreateGenreCommand command = new CreateGenreCommand(_context);
        command.Model = new CreateGenreModel(){Name = "Science Fiction"}; //already exists, gives an error.
        
        //Act & Assert;
        FluentActions
                 .Invoking(() => command.Handle())
                 .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap turu zaten mevcut!");
      }

      [Fact]
      //Happy Path-Conditions occured accurately, without any errors;
      public void WhenGenreNameDoesNotExist_Genre_ShouldBeCreated()
      {
         //Arrange;
         CreateGenreCommand command = new CreateGenreCommand(_context);
         CreateGenreModel model = new CreateGenreModel(){Name = "Adventure"}; //test db'de mevcut olmayan bir genre/kitap turu.
         command.Model = model;

         //Act;
         FluentActions.Invoking(() => command.Handle()).Invoke();

         //Assert => dogrulama;
         var book = _context.Genres.SingleOrDefault(x => x.Name == model.Name);
         book.Should().NotBeNull();
      }
    }
}
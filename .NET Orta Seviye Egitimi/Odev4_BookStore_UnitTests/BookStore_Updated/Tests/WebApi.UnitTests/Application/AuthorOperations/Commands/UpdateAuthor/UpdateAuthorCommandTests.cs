using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.Commands.UpdateAuthor;
using WebApi.DbOperations;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
   public class UpdateAuthorCommandTests:IClassFixture<CommonTestFixture>
   {
      private readonly BookStoreDbContext _context;
      private readonly IMapper _mapper;
      public UpdateAuthorCommandTests(CommonTestFixture fixture)
      {
          _context = fixture.Context;
          _mapper = fixture.Mapper;
      }

      [Fact]
      public void WhenUpdatedAuthorIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
        //Arrange;
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
        int authorId = 30; //test db'sinde mevcut olmayan bir id verilir, hata alinabilmesi icin.
        command.AuthorId = authorId;
        
        //Act & Assert;
        FluentActions
                 .Invoking(() => command.Handle())
                 .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Guncellenecek yazar bulunamadi!");
      }

      [Fact]
      public void WhenUpdatedBookIsNotFound_InvalidOperationException_ShouldBeReturned()
      {
        //Arrange;
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
        int authorId = 1; //test db'sinde mevcut olmayan bir id verilir, hata alinabilmesi icin.
        command.AuthorId = authorId;
        UpdateAuthorModel model = new UpdateAuthorModel(){Ad = "Onur", Soyad = "Demir", BookId = 30}; //mevcut olmayan bir book id verildigi icin hata verecek.
        command.Model = model;
     
        //Act & Assert;
        FluentActions
                 .Invoking(() => command.Handle())
                 .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Mevcut olmayan bir kitap icin guncelleme yapilamaz!");
      }

      [Fact]
      //Happy Path-Conditions occured accurately, without any errors;
      public void WhenInputsAreFound_Author_ShouldBeUpdated()
      {
         //Arrange;
         UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
         int authorId = 1; //test db'de mevcut olan bir author id verildi
         command.AuthorId = authorId;
         UpdateAuthorModel model = new UpdateAuthorModel(){Ad = "Onur", Soyad = "Demir", BookId = 2};
         command.Model = model;

         //Act;
         FluentActions.Invoking(() => command.Handle()).Invoke();

         //Assert => dogrulama;
         var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
         author.Should().NotBeNull();
         author.Ad.Should().Be(model.Ad);
         author.Soyad.Should().Be(model.Soyad);
         author.BookId.Should().Be(model.BookId);
      }
   }
}
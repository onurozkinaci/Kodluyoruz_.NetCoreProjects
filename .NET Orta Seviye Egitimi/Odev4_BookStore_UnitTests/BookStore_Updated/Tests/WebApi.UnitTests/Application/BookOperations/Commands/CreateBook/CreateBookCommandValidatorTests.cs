using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
       /*[Fact] //Test metodunun birden fazla veri icin calismasini istiyorsak Fact yerine Theory attirbute'u bu metot icin verilir.
       public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
       {
          //Arrange;
          CreateBookCommand command = new CreateBookCommand(null,null); //context ve mapper null gonderilebilir cunku inputlari incelememiz gerekiyor, bunlari degil.
          //Buna ragmen command olusturma sebebimiz, Controller'daki validasyon kontrolumuzu baz alip oradaki gibi Validation'a command gondermemiz gerekesiniminden kaynaklaniyor;
          //Tum inputlar hatayi almak adina hatali verildi;
          command.Model = new CreateBookModel()
          {
            Title = "", PageCount=0,PublishDate=DateTime.Now.Date,GenreId=0
          };
        
          //Act;
          CreateBookCommandValidator validator = new CreateBookCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0); //0'dan cok yani en az 1 tane hata firlatilmali demis olduk.
       }
       */

       /**Her input icin degisebilecek versiyonlar oldugundan(Title gonderilip digerlerinin gonderilmemesi gibi, ayri ayri [Fact] verip benzer test metotlari yazmak yerine
         direkt [Theory] ile islem yapabiliyoruz ve InlineData verebiliyoruz. InlineData ile de metot parametrelerine argument olarak deger atamis oluyoruz aslinda.
         Bu sekilde Fact ile tekte yapamadigin ve ayri ayri benzer test metotlari yazman gereken durumlari/varyasyonlari InlineData ile farkli durumlar icin deger gondererek tek test metodu uzerinden
         test edebiliyorsun. Stres testi yapip zorluyoruz yani aslinda test metodunu bu varyasyonlari gondererek;
       */    

       [Theory]
       /*DateTime tipindeki publishDate'i parametre ve inline data icinde vermeme sebebimiz
         DateTime.Now gibi bir kullanimin devamli degisen saat ve tarih bilgisine bagli oldugundan
         dependency yaratmasindan kaynaklaniyor.
       */
       [InlineData("Lord Of The Rings",0,0)]
       [InlineData("Lord Of The Rings",0,1)]
       [InlineData("Lord Of The Rings",100,0)]
       [InlineData("",0,0)]
       [InlineData("",100,1)]
       [InlineData("",0,1)]
       [InlineData("LTR",100,1)]
       [InlineData("LOTR",100,0)]
       [InlineData("LOTR",0,1)]
       [InlineData(" ",100,1)]
       //[InlineData("LOTR",100,1)] //her sey valid old. icin hata vermez ve bu sebeple test metodu hata verir, fail alir, hata firlatilmadigi icin.

       public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string title, int pageCount, int genreId)
       {
          //Arrange;
          CreateBookCommand command = new CreateBookCommand(null,null); //context ve mapper null gonderilebilir cunku inputlari incelememiz gerekiyor, bunlari degil.
          //Buna ragmen command olusturma sebebimiz, Controller'daki validasyon kontrolumuzu baz alip oradaki gibi Validation'a command gondermemiz gerekesiniminden kaynaklaniyor;
          //Tum inputlar hatayi almak adina hatali verildi;
          command.Model = new CreateBookModel()
          {
            Title = title, 
            PageCount = pageCount,
            PublishDate=DateTime.Now.Date.AddYears(-1), //bugunun tarihinden bir yil oncesini baz alir, hata firlatmaz validasyonda(parametre olarak vermedigimizden hatayi bundan firlatmadik).
            GenreId = genreId
          };
        
          //Act;
          CreateBookCommandValidator validator = new CreateBookCommandValidator();
          var result = validator.Validate(command);

          //Assert;
          result.Errors.Count.Should().BeGreaterThan(0); //0'dan cok yani en az 1 tane hata firlatilmali demis olduk.
       }

       [Fact]
       public void WhenDateTimeEqualNowIsGiven_Validator_ShouldReturnError()
       {
        //Bir test icinde bir case cover edilmeli, bu sebeple diger propertyleri dogru gonderip, publishdate'i yanlis gonderiyoruz.
        //DateTime.Now gonderildiginde validator'in hata firlatip firlatmadigini test etmek icin;
         CreateBookCommand command = new CreateBookCommand(null,null);
         command.Model = new CreateBookModel()
          {
            Title = "title", 
            PageCount = 100,
            PublishDate=DateTime.Now.Date,
            GenreId = 1
          };
          
          CreateBookCommandValidator validator = new CreateBookCommandValidator();
          var result = validator.Validate(command);
          result.Errors.Count.Should().BeGreaterThan(0);
       }

       //Her kosulun dogru calistigi/basarili caseler icin test metodu("Happy Path);
       [Fact]
       public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError()
       {
        //Bir test icinde bir case cover edilmeli, bu sebeple diger propertyleri dogru gonderip, publishdate'i yanlis gonderiyoruz.
        //DateTime.Now gonderildiginde validator'in hata firlatip firlatmadigini test etmek icin;
         CreateBookCommand command = new CreateBookCommand(null,null);
         command.Model = new CreateBookModel()
          {
            Title = "title", 
            PageCount = 100,
            PublishDate=DateTime.Now.Date.AddYears(-2),
            GenreId = 1
          };
          
          CreateBookCommandValidator validator = new CreateBookCommandValidator();
          var result = validator.Validate(command);
          result.Errors.Count.Should().Be(0); //Should().Equals(0)
       }
    }
}
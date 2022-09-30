using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.DbOperations;

namespace Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        
     [Theory]
     [InlineData(0,1,250)] //customerId, 0'dan buyuk olmalidir, 0 olarak gonderildiginden hata alinir.
     [InlineData(1,0,250)]
     [InlineData(0,0,250)]
     [InlineData(1,2,0)]
     [InlineData(0,0,0)] //hepsinden dolayi hata verir(id degerleri ve price degeri 0'dan buyuk olmali, valiadtor'daki rule'a gore).
     public void WhenInputsAreGivenInvalid_OrderValidator_ShouldReturnErrors(int customerId, int filmId, double fiyat)
     {
        //Arrange;
        CreateOrderCommand command = new CreateOrderCommand(null,null);
        command.Model = new CreateOrderModel()
        {
            CustomerId = customerId, FilmId = filmId, 
            Fiyat = fiyat, 
            SatinAlmaTarihi = DateTime.Now.Date.AddDays(-2)
        };

        //Act;
        CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().BeGreaterThan(0); //hata sayisi en az 1 olur, hata alinir.
     }

     //**Bugunun tarihini vermek aslinda bir bagimlilik oldugundan yukaridaki Theory altindaki InlineData'da verilen
     //parametrelerle birlikte DateTime tipindeki 'SatinAlmaTarihi'ni parametre olarak verilmedi, ayri bir Unit Test'te
     //asagidaki gibi onun testi saglandi. Bu sekilde hareket etme sebebimiz 'dependency injection' kapsaminda Unit Test ile
     //birlikte bagimliliklardan soyutlanip bagimliliklardan uzaklasmak;
     [Fact]
     public void WhenOrderDateIsInvalid_OrderValidator_ShouldReturnError()
     {
        //Arrange;
        CreateOrderCommand command = new CreateOrderCommand(null,null);
        command.Model = new CreateOrderModel()
        {   
            CustomerId = 3, 
            FilmId = 1, 
            Fiyat = 250, 
            SatinAlmaTarihi = DateTime.Now.Date //validator'daki rule'a gore SatinAlmaTarihi guncel tarihten kucuk olmalidir.
        };

        //Act;
        CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().BeGreaterThan(0); //hata doner.
     }

     [Fact]
     public void WhenInputsAreValid_OrderValidator_ShouldNotReturnErrors()
     {
        //Arrange;
        CreateOrderCommand command = new CreateOrderCommand(null,null);
        command.Model = new CreateOrderModel()
        {   
            CustomerId = 3, 
            FilmId = 1, 
            Fiyat = 250, 
            SatinAlmaTarihi = DateTime.Now.Date.AddDays(-2)
        };

        //Act;
        CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
        var result = validator.Validate(command);

        //Assert;
        result.Errors.Count.Should().Be(0); //hata donmez(0 hata).
     }
  }
}
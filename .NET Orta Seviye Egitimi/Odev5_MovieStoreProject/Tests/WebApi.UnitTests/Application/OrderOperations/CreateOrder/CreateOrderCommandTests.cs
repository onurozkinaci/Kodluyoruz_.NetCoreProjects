using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.DbOperations;

namespace Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommandTests(CommonTestFixture fixture)
        {
           _context = fixture.Context;
           _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenCustomerIdIsNotFound_InvalidOperationException_ShouldBeReturned()
        {
           //Arrange;
           CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
           command.Model = new CreateOrderModel()
           {
              CustomerId = 25, //Customer tablosunda bulunamayan bir id oldugundan Order tablosuna eklenemez!
              FilmId = 2, 
              Fiyat = 300,
              SatinAlmaTarihi = new DateTime(2022,09,23)
           };
           //Act & Assert;
           FluentActions.Invoking(()=>command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri bulunamadı!");
        }

        [Fact]
        public void WhenFilmIdIsNotFound_InvalidOperationException_ShouldBeReturned()
        {
           //Arrange;
           CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
           command.Model = new CreateOrderModel()
           {
              CustomerId = 1, 
              FilmId = 25, //Film tablosunda bulunamayan bir id oldugundan Order tablosuna eklenemez! 
              Fiyat = 300,
              SatinAlmaTarihi = new DateTime(2022,09,23)
           };
           //Act & Assert;
           FluentActions.Invoking(()=>command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film bulunamadı!");
        }

        [Fact]
        public void WhenOrderExists_InvalidOperationException_ShouldBeReturned()
        {
            //If the given customerId and filmId combination already exists as a key for 
            //Order(Siparis)
           //Arrange;
           CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
           //"CustomerId = 1, FilmId = 1" icin zaten bir order kaydi mevcut oldugundan tekrar ekleme yapilamaz!;
           command.Model = new CreateOrderModel()
           {
              CustomerId = 1, 
              FilmId = 1,
              Fiyat = 300,
              SatinAlmaTarihi = new DateTime(2022,09,23)
           };
           //Act & Assert;
           FluentActions.Invoking(()=>command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu musteri-film icin bir kayit zaten mevcut!");
        }

        [Fact]
        public void WhenGivenOrderInfosAreAppropriate_Order_ShouldBeCreated()
        {
            //Arrange
            CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
            command.Model = new CreateOrderModel()
            {
                CustomerId = 3, 
                FilmId = 2,
                Fiyat = 175.4,
                SatinAlmaTarihi = new DateTime(2022,09,25)
            };

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();
     
            //Assert;
            var order = _context.Siparisler.SingleOrDefault(x => x.CustomerId == command.Model.CustomerId && x.FilmId == command.Model.FilmId);
            order.Fiyat.Should().Be(command.Model.Fiyat);
            order.SatinAlmaTarihi.Should().Be(command.Model.SatinAlmaTarihi);
        }
    }
}
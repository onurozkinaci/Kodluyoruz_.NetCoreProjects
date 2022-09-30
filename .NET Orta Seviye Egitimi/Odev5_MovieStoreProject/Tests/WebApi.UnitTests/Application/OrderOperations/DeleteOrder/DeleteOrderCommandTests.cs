using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.DbOperations;

namespace Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteOrderCommandTests(CommonTestFixture fixture)
        {
           _context = fixture.Context;
        }

        //**Asagidaki metotlarin isminde order key denme sebebi, hata kontrolunun customerId ve filmId
        //ikilisi uzerinden yapiliyor olmasi. Order aslinda tek key gibi customerId-filmId pair'i tutuyor
        //ve kontrollerimizi bunun uzerinden yapiyoruz;
        [Fact]
        public void WhenGivenOrderKeyDoesNotExistInvalidOperationException_ShouldBeGiven()
        {
            //Arrange;
            //'CustomerId=2,FilmId=1' pair olarak test db'de Siparislerde mevcut olmadigindan hata alinir;
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.CustomerId = 2;
            command.FilmId = 1;

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek siparis bulunamadi!");
        }

        [Fact]
        public void WhenGivenOrderKeyExists_Order_ShouldBeDeleted()
        {
            //Arrange;
            //'CustomerId=1,FilmId=1' pair olarak test db'de Siparislerde mevcut oldugundan hata alinmaz/silinebilir;
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.CustomerId = 1;
            command.FilmId = 1;

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var order = _context.Siparisler.SingleOrDefault(x=>x.CustomerId == command.CustomerId && x.FilmId == command.FilmId);
            order.IsActive.Should().Be(false); //siparisin/order silinmis olmasi(statusunun false olmasi) gerekiyor.
        }
    }
}
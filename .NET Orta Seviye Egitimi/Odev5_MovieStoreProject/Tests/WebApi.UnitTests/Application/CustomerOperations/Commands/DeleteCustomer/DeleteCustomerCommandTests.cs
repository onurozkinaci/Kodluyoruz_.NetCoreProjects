using FluentAssertions;
using TestSetup;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteCustomerCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        } 

        [Fact]
        public void WhenGivenCustomerrIdIsNotFound_InvalidOperationException_ShouldBeGiven()
        {
            //Arrange;
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = 25; //test db'de 'Customers' tablosunda mevcut olmayan bir customerId verildi.

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek musteri bulunamadi!");
        }

        [Fact]
        public void WhenGivenCustomerIdIsActiveOnOrdersTable_InvalidOperationException_ShouldBeGiven()
        {
            //Arrange;
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = 1; //test db'de bu customer id Orders tablosunda mevcut ve statusu aktiftir, once siparis silinip statu pasif yapilmalidir ki buradan silinebilsin.

            //Act & Assert;
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film satin almis bir musteri buradan direkt silinemez, oncelikle siparislerden kaydi silinmelidir!");
        }

        [Fact]
        public void WhenGivenCustomerIdIsAppropriateForDeleting_Customer_ShouldBeDeleted()
        {
            //Arrange;
            //Yeni bir customer olusturuldu, sorunsuz silinebildiginin test edilebilmesi icin;
            var customerNew = new Customer(){Name = "Zeynep", Surname = "Borekci",Email="zborkeci@gmail.com",Password="123456"};
            _context.Customers.Add(customerNew);
            _context.SaveChanges();

            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = 4;

            //Act;
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert;
            var customer = _context.Customers.SingleOrDefault(x=>x.Id == command.CustomerId);
            customer.Should().BeNull();
        }

    }
}
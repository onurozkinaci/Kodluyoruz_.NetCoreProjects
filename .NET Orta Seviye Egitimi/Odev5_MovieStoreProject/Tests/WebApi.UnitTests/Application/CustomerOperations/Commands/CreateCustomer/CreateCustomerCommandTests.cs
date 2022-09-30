using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.DbOperations;

namespace Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }    

        [Fact]
        public void WhenEmailAlreadyExists_InvalidOperationException_ShouldBeReturned()
        {
           //Arrange;
           CreateCustomerCommand command = new CreateCustomerCommand(_context,_mapper);
           command.Model = new CreateCustomerModel(){Name = "Ahmet", Surname = "Demir", Email = "ademir@gmail.com", Password = "123456"};
           //test db'de mevcut olan bir email verildiginden hata alinacak.

           //Act & Assert;
           FluentActions.Invoking(() => command.Handle())
                   .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu email ile bir kullanici zaten mevcut!");
        }

        [Fact]
        public void WhenEmailIsNotExist_Customer_ShouldBeCreated()
        {
           //Arrange;
           CreateCustomerCommand command = new CreateCustomerCommand(_context,_mapper);
           command.Model = new CreateCustomerModel(){Name = "Gizem", Surname = "Sucu", Email = "gsucu@gmail.com", Password = "123456"};
           //test db'de mevcut olmayan bir email verildiginden hata alinmaz ve musteri/customer olusturulur.

           //Act;
           FluentActions.Invoking(() => command.Handle()).Invoke();

           //Assert;
           var customer = _context.Customers.SingleOrDefault(x => x.Email == command.Model.Email);
           customer.Should().NotBeNull();
        }
    }
}
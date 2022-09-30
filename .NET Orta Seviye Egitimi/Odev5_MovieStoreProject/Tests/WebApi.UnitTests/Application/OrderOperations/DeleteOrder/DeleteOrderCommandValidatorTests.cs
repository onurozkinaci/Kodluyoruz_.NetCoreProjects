using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.DbOperations;

namespace Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,1)]
        [InlineData(0,0)]
        [InlineData(1,0)]
        public void WhenInputsAreInvalid_DeleteOrderValidator_ShouldReturnErrors(int customerId, int filmId)
        {
            //Arrange;
            DeleteOrderCommand command = new DeleteOrderCommand(null);
            command.CustomerId = customerId;
            command.FilmId = filmId;

            //Act;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            var result = validator.Validate(command);

            //Assert;
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInputsAreValid_DeleteOrderValidator_ShouldNotReturnErrors()
        {
            //Arrange;
            DeleteOrderCommand command = new DeleteOrderCommand(null);
            command.CustomerId = 1; //>0 old. hata vermez.
            command.FilmId = 1; //>0 old. hata vermez.

            //Act;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            var result = validator.Validate(command);

            //Assert;
            result.Errors.Count.Should().Be(0);
        }


    }
}
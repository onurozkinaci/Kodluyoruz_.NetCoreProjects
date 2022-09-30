using System;
using FluentValidation;

namespace WebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
           RuleFor(command => command.CustomerId).GreaterThan(0);
           RuleFor(command => command.FilmId).GreaterThan(0);
        }
    }
}
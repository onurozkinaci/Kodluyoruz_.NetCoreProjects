using System;
using FluentValidation;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
           RuleFor(command => command.Model.CustomerId).GreaterThan(0);
           RuleFor(command => command.Model.FilmId).GreaterThan(0);
           RuleFor(command => command.Model.Fiyat).GreaterThan(0);
           RuleFor(command => command.Model.SatinAlmaTarihi).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
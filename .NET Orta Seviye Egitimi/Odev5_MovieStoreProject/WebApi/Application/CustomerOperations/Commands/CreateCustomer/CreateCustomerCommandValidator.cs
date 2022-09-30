using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
           RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(5);
           RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(5);
        }
    }
}
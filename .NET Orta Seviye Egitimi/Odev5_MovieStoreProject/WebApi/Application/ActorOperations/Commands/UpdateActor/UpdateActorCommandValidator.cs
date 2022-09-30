using FluentValidation;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator:AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
           RuleFor(command => command.ActorId).GreaterThan(0);
           RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
        }
    }
}
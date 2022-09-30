using FluentValidation;

namespace WebApi.Application.FilmOperations.Commands.CreateFilm
{
    public class CreateFilmCommandValidator:AbstractValidator<CreateFilmCommand>
    {
        public CreateFilmCommandValidator()
        {
           RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.GenreId).GreaterThan(0);
           RuleFor(command => command.Model.Price).GreaterThan(0);
           RuleFor(command => command.Model.YonetmenId).GreaterThan(0);
        }
    }
}
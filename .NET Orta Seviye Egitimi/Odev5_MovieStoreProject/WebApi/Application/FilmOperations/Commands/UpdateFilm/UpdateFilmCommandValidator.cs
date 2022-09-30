using FluentValidation;

namespace WebApi.Application.FilmOperations.Commands.UpdateFilm
{
    public class UpdateFilmCommandValidator:AbstractValidator<UpdateFilmCommand>
    {
        public UpdateFilmCommandValidator()
        {
           RuleFor(command => command.FilmId).GreaterThan(0);
           RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.GenreId).GreaterThan(0);
           RuleFor(command => command.Model.Price).GreaterThan(0);
           RuleFor(command => command.Model.YonetmenId).GreaterThan(0);
        }
    }
}
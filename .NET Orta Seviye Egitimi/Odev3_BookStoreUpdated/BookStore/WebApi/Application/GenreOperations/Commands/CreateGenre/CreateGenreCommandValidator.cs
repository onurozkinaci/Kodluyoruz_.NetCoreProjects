using System;
using System.Linq;
using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
       public CreateGenreCommandValidator()
       {
          RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
       } 
    }   
}
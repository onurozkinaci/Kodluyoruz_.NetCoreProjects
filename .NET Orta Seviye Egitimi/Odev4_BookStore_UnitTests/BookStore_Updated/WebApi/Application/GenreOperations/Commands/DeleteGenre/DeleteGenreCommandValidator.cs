using System;
using System.Linq;
using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
       public DeleteGenreCommandValidator()
       {
          RuleFor(command => command.GenreId).GreaterThan(0);
       } 
    }   
}
using System;
using System.Linq;
using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
   public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
   {
      public DeleteBookCommandValidator()
      {
        RuleFor(command => command.BookId).GreaterThan(0);
      }
   }
}
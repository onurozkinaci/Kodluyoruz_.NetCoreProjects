using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.Application.Commands.DeleteAuthor;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.DeleteAuthor
{
   public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommand>
   {
       public DeleteAuthorCommandValidator()
       {
          RuleFor(command => command.AuthorId).GreaterThan(0);
       }
   }
}
using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.UpdateAuthor
{
   public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
   {
       public UpdateAuthorCommandValidator()
       {
         RuleFor(command => command.AuthorId).GreaterThan(0);
         RuleFor(command => command.Model.BookId).GreaterThan(0);
         RuleFor(command=>command.Model.Ad).NotEmpty();
         RuleFor(command=>command.Model.Soyad).NotEmpty();
         RuleFor(command => command.Model.BookId).GreaterThan(0);
       }  
   }
}
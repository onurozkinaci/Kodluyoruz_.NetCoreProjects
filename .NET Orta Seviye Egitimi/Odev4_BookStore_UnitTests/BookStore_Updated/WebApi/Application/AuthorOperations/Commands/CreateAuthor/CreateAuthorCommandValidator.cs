using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.Commands.CreateAuthor
{
   public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
   {
     public CreateAuthorCommandValidator()
     {
        RuleFor(command => command.Model.BookId).GreaterThan(0).When(x=>x.Model.BookId != default);
        RuleFor(command => command.Model.Ad).NotEmpty();
        RuleFor(command => command.Model.Soyad).NotEmpty();
        RuleFor(command => command.Model.DogumTarihi).NotEmpty().LessThan(DateTime.Now.Date);
     }
   }
}
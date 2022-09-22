using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
       public UpdateBookCommandValidator()
       {
          RuleFor(command => command.BookId).GreaterThan(0).WithMessage("The book id must be bigger than zero!"); //WithMessage = custom error message
          RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4); //bos ve 4'ten az olursa ikisini de kapsayacak bir hata doner!
          RuleFor(command => command.Model.GenreId).GreaterThan(0).WithMessage("The genre id must be bigger than zero!");;
       }
    }
}
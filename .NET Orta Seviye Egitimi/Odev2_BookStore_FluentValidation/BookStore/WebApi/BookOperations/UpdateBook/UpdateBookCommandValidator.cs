using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
       public UpdateBookCommandValidator()
       {
          RuleFor(command => command.BookId).GreaterThan(0).WithMessage("The book id must be bigger than zero!"); //WithMessage = custom error message
          RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4).WithMessage("The title length cannot be less than 4!");
          RuleFor(command => command.Model.GenreId).GreaterThan(0).WithMessage("The genre id must be bigger than zero!");;
       }
    }
}
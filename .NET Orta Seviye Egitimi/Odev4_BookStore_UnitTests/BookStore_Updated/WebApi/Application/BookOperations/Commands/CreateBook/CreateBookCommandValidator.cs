using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
           RuleFor(command => command.Model.GenreId).GreaterThan(0);
           RuleFor(command => command.Model.PageCount).GreaterThan(0);
           RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date); //kitabin basim tarihi bos olamaz ve bugunku tarihten kucuk olmali
           RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4); //4 karakterden kucuk kitap ismi olamaz
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail
{
   public class GetBookDetailQueryValidation:AbstractValidator<GetBookDetailQuery>
   {
      public GetBookDetailQueryValidation()
      {
         RuleFor(query => query.BookId).GreaterThan(0).WithMessage("The book id must be bigger than zero!"); //WithMessage = custom error message
      }
   }
}
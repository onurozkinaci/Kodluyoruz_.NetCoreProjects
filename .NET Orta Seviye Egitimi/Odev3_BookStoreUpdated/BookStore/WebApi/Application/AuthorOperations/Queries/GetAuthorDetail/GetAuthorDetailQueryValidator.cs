using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator:AbstractValidator<GetAuthorDetailQuery>
   {
     public GetAuthorDetailQueryValidator()
     {
        RuleFor(query => query.AuthorId).GreaterThan(0);
     }
   }
}
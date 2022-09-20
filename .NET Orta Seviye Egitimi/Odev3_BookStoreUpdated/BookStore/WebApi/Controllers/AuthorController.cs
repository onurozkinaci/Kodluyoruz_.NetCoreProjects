using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.GetAuthorDetail;
using WebApi.Application.AuthorOperations.GetAuthors;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.Commands.CreateAuthor;
using WebApi.Application.Commands.DeleteAuthor;
using WebApi.Application.Commands.UpdateAuthor;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
  [ApiController]
  [Route("[controller]s")]

  public class AuthorController:ControllerBase
  {
      private readonly BookStoreDbContext _context;
      private readonly IMapper _mapper;
      public AuthorController(BookStoreDbContext context, IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
      }

      [HttpGet]
      public IActionResult GetAuthors()
      {
         GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
         var result = query.Handle();
         return Ok(result);
      }

     [HttpGet("{id}")]
      public IActionResult GetAuthorDetail(int id)
      {
         GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
         query.AuthorId = id;
         GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
         validator.ValidateAndThrow(query);
         AuthorDetailVM author = query.Handle();
         return Ok(author);
      }

      [HttpPost]
      public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
      {
         CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
         command.Model = newAuthor;
         CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
         validator.ValidateAndThrow(command);
         command.Handle();
         return Ok();
      }

      [HttpPut("{id}")]
      public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
      {
         UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
         command.AuthorId = id;
         command.Model = updatedAuthor;
         UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
         validator.ValidateAndThrow(command);
         command.Handle();
         return Ok();
      }

      [HttpDelete("id")]
      public IActionResult DeleteAuthor(int id)
      {
         DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
         command.AuthorId = id;
         DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
         validator.ValidateAndThrow(command);
         command.Handle();
         return Ok();
      }
  }
}
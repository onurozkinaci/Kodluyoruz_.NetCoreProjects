using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.FilmOperations.Commands.CreateFilm;
using WebApi.Application.FilmOperations.Commands.DeleteFilm;
using WebApi.Application.FilmOperations.Commands.UpdateFilm;
using WebApi.Application.FilmOperations.Queries.GetFilms;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class FilmController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public FilmController(MovieStoreDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }   

        [HttpGet]
        public IActionResult GetFilms()
        {
           GetFilmsQuery query = new GetFilmsQuery(_context,_mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpPost]
        public IActionResult AddFilm(CreateFilmModel newFilm)
        {
           
            CreateFilmCommand command = new CreateFilmCommand(_context,_mapper);
            command.Model = newFilm;
            CreateFilmCommandValidator validator = new CreateFilmCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, UpdateFilmModel updatedModel)
        {
            UpdateFilmCommand command = new UpdateFilmCommand(_context,_mapper);
            command.FilmId = id;
            command.Model = updatedModel;
            UpdateFilmCommandValidator validator = new UpdateFilmCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            DeleteFilmCommand command = new DeleteFilmCommand(_context);
            command.FilmId = id;
            DeleteFilmCommandValidator validator = new DeleteFilmCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
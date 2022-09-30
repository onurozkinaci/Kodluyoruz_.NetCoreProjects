using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorController(MovieStoreDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }   

        [HttpGet]
        public IActionResult GetDirectors()
        {
           GetDirectorsQuery query = new GetDirectorsQuery(_context,_mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDirector(CreateDirectorModel newDirector)
        {
           CreateDirectorCommand command = new CreateDirectorCommand(_context,_mapper);
           command.Model = newDirector;
           CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
           validator.ValidateAndThrow(command);
           command.Handle();
           return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, UpdateDirectorModel updatedModel)
        {
           UpdateDirectorCommand command = new UpdateDirectorCommand(_context,_mapper);
           command.DirectorId = id;
           command.Model = updatedModel;
           UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
           validator.ValidateAndThrow(command);
           command.Handle();
           return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
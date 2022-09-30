using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(MovieStoreDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }   

        [HttpGet]
        public IActionResult GetActors()
        {
           GetActorsQuery query = new GetActorsQuery(_context,_mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpPost]
        public IActionResult AddActor(CreateActorModel newActor)
        {
           //try{
           CreateActorCommand command = new CreateActorCommand(_context,_mapper);
           command.Model = newActor;

           //*Buradaki try-catch daha sonra kaldirilacak-middleware eklenince;
           CreateActorCommandValidator validator = new CreateActorCommandValidator();
           validator.ValidateAndThrow(command);
           command.Handle();
           //}
           /*catch(Exception ex)
           {
             throw new InvalidOperationException(ex.Message);
           }*/
           return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, UpdateActorModel updatedModel)
        {
           //try{
           UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
           command.ActorId = id;
           command.Model = updatedModel;

           //*Buradaki try-catch daha sonra kaldirilacak-middleware eklenince;
           UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
           validator.ValidateAndThrow(command);
           command.Handle();
           //}
           /*catch(Exception ex)
           {
              throw new InvalidOperationException(ex.Message);
           }*/
           return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
           //try{
           DeleteActorCommand command = new DeleteActorCommand(_context);
           command.ActorId = id;
           DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
           validator.ValidateAndThrow(command);
           command.Handle();
           //}
           /*catch(Exception ex)
           {
              throw new InvalidOperationException(ex.Message);
           }*/
           return Ok();
        }
    }
}
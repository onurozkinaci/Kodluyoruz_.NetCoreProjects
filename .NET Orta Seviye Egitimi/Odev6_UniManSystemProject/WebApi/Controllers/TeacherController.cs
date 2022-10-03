using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Queries.GetTeachers;
using WebApi.Application.TeacherOperations.Command.CreateTeacher;
using WebApi.Application.TeacherOperations.Commands.DeleteTeacher;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using WebApi.Application.TeacherOperations.CreateTeacher;
using WebApi.Application.TeacherOperations.DeleteTeacher;
using WebApi.Application.TeacherOperations.UpdateTeacher;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class TeacherController:ControllerBase
    {
       private readonly IUniManSystemDbContext _context; //bu interface'in kullandigi servis UniManSystemDbContext sinifimizin kendisi ve bu, program.cs'de
       //servis olarak eklenerek belirtildi. Controller calistiginda otomatik olarak constructor'inda bu servise atama saglanir ve boylece
       //dependency injection onlenir.
       private readonly IMapper _mapper;
       public TeacherController(IUniManSystemDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }

       [HttpGet]
       public IActionResult GetTeachers()
       {
          GetTeachersQuery query = new GetTeachersQuery(_context, _mapper);
          var result = query.Handle();
          return Ok(result);
       }

       [HttpPost]
       public IActionResult AddTeacher([FromBody] CreateTeacherModel model)
       {
            CreateTeacherCommand command = new CreateTeacherCommand(_context,_mapper);
            command.Model = model;
            CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }

       [HttpPut("{id}")]
       public IActionResult UpdateTeacher(int id,[FromBody] UpdateTeacherModel updatedModel)
       {
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context,_mapper);
            command.TeacherId = id;
            command.Model = updatedModel;
            UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }

       [HttpDelete("{id}")]
       public IActionResult DeleteTeacher(int id)
       {
            DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
            command.TeacherId = id;
            DeleteTeacherCommandValidator validator = new DeleteTeacherCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }
       
    }
}
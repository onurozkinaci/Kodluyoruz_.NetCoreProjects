using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.Application.CourseOperations.CreateCourse;
using WebApi.Application.CourseOperations.DeleteCourse;
using WebApi.Application.CourseOperations.UpdateCourse;
using WebApi.CourseOperations.Queries.GetCourses;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CourseController:ControllerBase
    {
       private readonly IUniManSystemDbContext _context; //bu interface'in kullandigi servis UniManSystemDbContext sinifimizin kendisi ve bu, program.cs'de
       //servis olarak eklenerek belirtildi. Controller calistiginda otomatik olarak constructor'inda bu servise atama saglanir ve boylece
       //dependency injection onlenir.
       private readonly IMapper _mapper;
       public CourseController(IUniManSystemDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }

       [HttpGet]
       public IActionResult GetCourses()
       {
          GetCoursesQuery query = new GetCoursesQuery(_context, _mapper);
          var result = query.Handle();
          return Ok(result);
       }
       
       [HttpPost]
       public IActionResult AddCourse([FromBody] CreateCourseModel model)
       {
          CreateCourseCommand command = new CreateCourseCommand(_context,_mapper);
          command.Model = model;
          CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
          validator.ValidateAndThrow(command);               
          command.Handle();
          return Ok();
       }

       [HttpPut("{id}")]
       public IActionResult UpdateCourse(int id,[FromBody] UpdateCourseModel updatedModel)
       {
            UpdateCourseCommand command = new UpdateCourseCommand(_context,_mapper);
            command.CourseId = id;
            command.Model = updatedModel;
            UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
            validator.ValidateAndThrow(command);   
            command.Handle();
            return Ok();
       }

       [HttpDelete("{id}")]
       public IActionResult DeleteDepartment(int id)
       {
            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            command.CourseId = id;
            DeleteCourseCommandValidator validator = new DeleteCourseCommandValidator();
            validator.ValidateAndThrow(command);   
            command.Handle();
            return Ok();
       }
    }
}
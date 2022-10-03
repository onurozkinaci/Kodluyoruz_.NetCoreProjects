using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.SelectedCourseOperations.Commands.CreateSelectedCourse;
using WebApi.Application.SelectedCourseOperations.Commands.DeleteSelectedCourse;
using WebApi.Application.SelectedCourseOperations.CreateSelectedCourse;
using WebApi.Application.SelectedCourseOperations.Queries.GetSelectedCourses;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    //[Authorize] //Student, token almadiysa ders secimi gerceklestiremez, token almadan istek gonderilemez!
    [ApiController]
    [Route("[controller]s")]
    public class CourseSelectionController:ControllerBase
    {
       private readonly IUniManSystemDbContext _context; //bu interface'in kullandigi servis UniManSystemDbContext sinifimizin kendisi ve bu, program.cs'de
       //servis olarak eklenerek belirtildi. Controller calistiginda otomatik olarak constructor'inda bu servise atama saglanir ve boylece
       //dependency injection onlenir.
       private readonly IMapper _mapper;
       public CourseSelectionController(IUniManSystemDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }

       //[Authorize] => tum class'a degil de metoda ozgu olarak da verilebilir;
       [HttpGet]
       public IActionResult GetSelectedCourses()
       {
          GetSelectedCoursesQuery query = new GetSelectedCoursesQuery(_context, _mapper);
          var result = query.Handle();
          return Ok(result);
       }

       [HttpPost]
       public IActionResult AddSelectedCourse([FromBody] CreateSelectedCourseModel model)
       {
            CreateSelectedCourseCommand command = new CreateSelectedCourseCommand(_context,_mapper);
            command.Model = model;
            CreateSelectedCourseCommandValidator validator = new CreateSelectedCourseCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }

       [HttpDelete("{studentId}/{courseId}")]
       public IActionResult DeleteSelectedCourse(int studentId, int courseId)
       {
            DeleteSelectedCourseCommand command = new DeleteSelectedCourseCommand(_context);
            command.StudentId = studentId;
            command.CourseId = courseId;
            DeleteSelectedCourseCommandValidator validator = new DeleteSelectedCourseCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }
    }
}
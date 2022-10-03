using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations.Commands.RefreshToken;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.Application.StudentOperations.CreateStudent;
using WebApi.Application.StudentOperations.DeleteStudent;
using WebApi.Application.StudentOperations.Queries.GetStudents;
using WebApi.Application.StudentOperations.UpdateStudent;
using WebApi.DbOperations;
using WebApi.StudentOperations.Commands.CreateToken;
using WebApi.TokenOperations.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class StudentController:ControllerBase
    {
       private readonly IUniManSystemDbContext _context; //bu interface'in kullandigi servis UniManSystemDbContext sinifimizin kendisi ve bu, program.cs'de
       //servis olarak eklenerek belirtildi. Controller calistiginda otomatik olarak constructor'inda bu servise atama saglanir ve boylece
       //dependency injection onlenir.
       private readonly IMapper _mapper;
       private readonly IConfiguration _configuration;
       public StudentController(IUniManSystemDbContext context, IMapper mapper, IConfiguration configuration)
       {
          _context = context;
          _mapper = mapper;
          _configuration = configuration;
       }

       [HttpGet]
       public IActionResult GetStudents()
       {
          GetStudentsQuery query = new GetStudentsQuery(_context, _mapper);
          var result = query.Handle();
          return Ok(result);
       }

       [HttpPost]
       public IActionResult AddTeacher([FromBody] CreateStudentModel model)
       {
            CreateStudentCommand command = new CreateStudentCommand(_context,_mapper);
            command.Model = model;
            CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }

       [HttpPut("{id}")]
       public IActionResult UpdateTeacher(int id,[FromBody] UpdateStudentModel updatedModel)
       {
            UpdateStudentCommand command = new UpdateStudentCommand(_context,_mapper);
            command.StudentId = id;
            command.Model = updatedModel;
            UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }

       [HttpDelete("{id}")]
       public IActionResult DeleteTeacher(int id)
       {
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            command.StudentId = id;
            DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }

       //---For the authentication operations;
        [HttpPost("connect/token")] //iki tane post islemi oldugundan, birisini ornegin parametre yollayip  ozellestirmezsen iki tane ayni HTTP metodu endpointlere kullanildigindan hata verir. 
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,  _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        //**Access token alindiginda onunla birlikte olusturulan refresh token araciligiyla mevcut access token'i refresh
        //etmek icin kullanilacak endpoint;
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
}
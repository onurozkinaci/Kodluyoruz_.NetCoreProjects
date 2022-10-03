using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DepartmentOperations.Commands.CreateDepartment;
using WebApi.Application.DepartmentOperations.Commands.DeleteDepartment;
using WebApi.Application.DepartmentOperations.Commands.UpdateDepartment;
using WebApi.Application.DepartmentOperations.CreateDepartment;
using WebApi.Application.DepartmentOperations.DeleteDepartment;
using WebApi.Application.DepartmentOperations.Queries;
using WebApi.Application.DepartmentOperations.UpdateDepartment;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DepartmentController:ControllerBase
    {
       private readonly IUniManSystemDbContext _context; //bu interface'in kullandigi servis UniManSystemDbContext sinifimizin kendisi ve bu, program.cs'de
       //servis olarak eklenerek belirtildi. Controller calistiginda otomatik olarak constructor'inda bu servise atama saglanir ve boylece
       //dependency injection onlenir.
       private readonly IMapper _mapper;
       public DepartmentController(IUniManSystemDbContext context, IMapper mapper)
       {
          _context = context;
          _mapper = mapper;
       }

       [HttpGet]
       public IActionResult GetDepartments()
       {
          GetDepartmentsQuery query = new GetDepartmentsQuery(_context, _mapper);
          var result = query.Handle();
          return Ok(result);
       }

       [HttpPost]
       public IActionResult AddDepartment([FromBody] CreateDepartmentModel model)
       {
          CreateDepartmentCommand command = new CreateDepartmentCommand(_context,_mapper);
          command.Model = model;
          CreateDepartmentCommandValidator validator = new CreateDepartmentCommandValidator();
          validator.ValidateAndThrow(command);
          command.Handle();
          return Ok();
       }

       [HttpPut("{id}")]
       public IActionResult UpdateDepartment(int id,[FromBody] UpdateDepartmentModel updatedModel)
       {
         UpdateDepartmentCommand command = new UpdateDepartmentCommand(_context,_mapper);
         command.DeptId = id;
         command.Model = updatedModel;
         UpdateDepartmentCommandValidator validator = new UpdateDepartmentCommandValidator();
         validator.ValidateAndThrow(command);
         command.Handle();
         return Ok();
       }

       [HttpDelete("{id}")]
       public IActionResult DeleteDepartment(int id)
       {
            DeleteDepartmentCommand command = new DeleteDepartmentCommand(_context);
            command.DepartmentId = id;
            DeleteDepartmentCommandValidator validator = new DeleteDepartmentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
       }
       
    }
}
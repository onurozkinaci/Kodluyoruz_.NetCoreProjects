using FluentValidation;
using WebApi.Application.DepartmentOperations.Commands.CreateDepartment;

namespace WebApi.Application.DepartmentOperations.CreateDepartment
{
    public class CreateDepartmentCommandValidator:AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
           RuleFor(command => command.Model.DeptName).NotEmpty().MinimumLength(4);
        }
    }
}
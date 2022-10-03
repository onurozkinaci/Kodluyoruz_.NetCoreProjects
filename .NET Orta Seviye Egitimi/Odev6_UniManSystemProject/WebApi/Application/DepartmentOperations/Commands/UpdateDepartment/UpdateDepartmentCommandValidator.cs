using FluentValidation;
using WebApi.Application.DepartmentOperations.Commands.UpdateDepartment;

namespace WebApi.Application.DepartmentOperations.UpdateDepartment
{
    public class UpdateDepartmentCommandValidator:AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
           RuleFor(command => command.DeptId).GreaterThan(0);
           RuleFor(command => command.Model.DeptName).NotEmpty().MinimumLength(4);
        }
    }
}
using FluentValidation;
using WebApi.Application.DepartmentOperations.Commands.DeleteDepartment;

namespace WebApi.Application.DepartmentOperations.DeleteDepartment
{
    public class DeleteDepartmentCommandValidator:AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
           RuleFor(command => command.DepartmentId).GreaterThan(0);
        }
    }
}
using FluentValidation;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;

namespace WebApi.Application.StudentOperations.DeleteStudent
{
    public class DeleteStudentCommandValidator:AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
           RuleFor(command => command.StudentId).GreaterThan(0);
        }
    }
}
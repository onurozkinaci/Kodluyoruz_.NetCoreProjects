using FluentValidation;
using WebApi.Application.TeacherOperations.Commands.DeleteTeacher;

namespace WebApi.Application.TeacherOperations.DeleteTeacher
{
    public class DeleteTeacherCommandValidator:AbstractValidator<DeleteTeacherCommand>
    {
        public DeleteTeacherCommandValidator()
        {
           RuleFor(command => command.TeacherId).GreaterThan(0);
        }
    }
}

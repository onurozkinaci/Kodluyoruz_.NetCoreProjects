using FluentValidation;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;

namespace WebApi.Application.TeacherOperations.UpdateTeacher
{
    public class UpdateTeacherCommandValidator:AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
           RuleFor(command => command.TeacherId).GreaterThan(0);
           RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.YearsOfExperience).GreaterThan(0);
           RuleFor(command => command.Model.DepartmentId).GreaterThan(0);
        }
    }
}

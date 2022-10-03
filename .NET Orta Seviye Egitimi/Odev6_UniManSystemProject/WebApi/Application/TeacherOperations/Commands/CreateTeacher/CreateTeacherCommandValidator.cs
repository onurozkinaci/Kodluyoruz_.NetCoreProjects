using FluentValidation;
using WebApi.Application.TeacherOperations.Command.CreateTeacher;

namespace WebApi.Application.TeacherOperations.CreateTeacher
{
    public class CreateTeacherCommandValidator:AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
           RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.YearsOfExperience).GreaterThan(0);
           RuleFor(command => command.Model.DepartmentId).GreaterThan(0);
        }
    }
}

using FluentValidation;
using WebApi.Application.StudentOperations.Commands.CreateStudent;

namespace WebApi.Application.StudentOperations.CreateStudent
{
    public class CreateStudentCommandValidator:AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
           RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.CurrentGrade).GreaterThan(0);
           RuleFor(command => command.Model.GPA).GreaterThan(0);
        }
    }
}
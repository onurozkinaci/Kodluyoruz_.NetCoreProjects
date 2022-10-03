using FluentValidation;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;

namespace WebApi.Application.StudentOperations.UpdateStudent
{
    public class UpdateStudentCommandValidator:AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
           RuleFor(command => command.StudentId).GreaterThan(0);
           RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.CurrentGrade).GreaterThan(0);
           RuleFor(command => command.Model.GPA).GreaterThan(0);
        }
    }
}
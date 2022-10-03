using FluentValidation;
using WebApi.Application.CourseOperations.Commands.CreateCourse;

namespace WebApi.Application.CourseOperations.CreateCourse
{
    public class CreateCourseCommandValidator:AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
           RuleFor(command => command.Model.CourseName).NotEmpty().MinimumLength(4);
           RuleFor(command => command.Model.CourseCode).NotEmpty().MinimumLength(7); //SEN4019 gibi
           RuleFor(command => command.Model.HowManyHours).GreaterThan(0);
           RuleFor(command => command.Model.TeacherId).GreaterThan(0);
           RuleFor(command => command.Model.DepartmentId).GreaterThan(0);
        }
    }
}
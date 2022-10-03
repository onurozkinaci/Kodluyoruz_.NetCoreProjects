using FluentValidation;
using WebApi.Application.SelectedCourseOperations.Commands.CreateSelectedCourse;

namespace WebApi.Application.SelectedCourseOperations.CreateSelectedCourse
{
    public class CreateSelectedCourseCommandValidator:AbstractValidator<CreateSelectedCourseCommand>
    {
        public CreateSelectedCourseCommandValidator()
        {
            RuleFor(command => command.Model.StudentId).GreaterThan(0);
            RuleFor(command => command.Model.CourseId).GreaterThan(0);
        }
    }
}
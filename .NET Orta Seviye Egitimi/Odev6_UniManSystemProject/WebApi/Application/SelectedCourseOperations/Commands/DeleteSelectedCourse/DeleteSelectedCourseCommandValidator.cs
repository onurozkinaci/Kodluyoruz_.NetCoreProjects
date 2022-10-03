using FluentValidation;
using WebApi.Application.SelectedCourseOperations.Commands.DeleteSelectedCourse;

namespace WebApi.Application.SelectedCourseOperations.CreateSelectedCourse
{
    public class DeleteSelectedCourseCommandValidator:AbstractValidator<DeleteSelectedCourseCommand>
    {
        public DeleteSelectedCourseCommandValidator()
        {
           RuleFor(command => command.StudentId).GreaterThan(0);
           RuleFor(command => command.CourseId).GreaterThan(0);
        }
    }
}
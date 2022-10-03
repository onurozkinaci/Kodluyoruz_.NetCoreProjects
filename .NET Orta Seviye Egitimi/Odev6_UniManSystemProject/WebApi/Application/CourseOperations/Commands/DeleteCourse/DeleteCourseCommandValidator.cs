using FluentValidation;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;

namespace WebApi.Application.CourseOperations.DeleteCourse
{
    public class DeleteCourseCommandValidator:AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
           RuleFor(command => command.CourseId).GreaterThan(0);
        }
    }
}
using WebApi.DbOperations;
using WebApi.Entites;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class SelectedCourses
    {
        public static void AddSelectedCourses(this UniManSystemDbContext context)
        {
            context.SelectedCourses.AddRange(
                new SelectedCourse {StudentId = 1, CourseId = 1},
                new SelectedCourse {StudentId = 1, CourseId = 2},
                new SelectedCourse {StudentId = 2, CourseId = 3},
                new SelectedCourse {StudentId = 2, CourseId = 1},
                new SelectedCourse {StudentId = 3, CourseId = 2}
             );
        }
    }
}
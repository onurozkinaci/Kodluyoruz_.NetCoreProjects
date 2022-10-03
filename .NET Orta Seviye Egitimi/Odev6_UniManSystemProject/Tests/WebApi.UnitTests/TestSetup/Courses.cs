using WebApi.DbOperations;
using WebApi.Entites;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Courses
    {
        //Extension metot, static class icerisinde yazilir.
        public static void AddCourses(this UniManSystemDbContext context)
        {
           context.Courses.AddRange(
              new Course {CourseName = "Advanced Python", CourseCode ="SEN4020", HowManyHours = 3 ,TeacherId = 1 ,DepartmentId = 1},
              new Course {CourseName = "Production Strategies", CourseCode ="IND4052", HowManyHours = 2 ,TeacherId = 2 ,DepartmentId = 2},
              new Course {CourseName = "Psychology Fundamentals", CourseCode ="PSY4020", HowManyHours = 2 ,TeacherId = 3 ,DepartmentId = 3}
           );
        }
    }
}
using WebApi.DbOperations;
using WebApi.Entites;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Students
    {
        public static void AddStudents(this UniManSystemDbContext context)
        {
            context.Students.AddRange(
                new Student {Name = "Onur", Surname = "Ozkn", Email = "onrozk@gmail.com", Password = "123456",
                            CurrentGrade = 4, GPA = 3.74},
                new Student {Name = "Ali", Surname = "Bora", Email = "abora@gmail.com", Password = "12345",
                            CurrentGrade = 3, GPA = 3.45},
                new Student {Name = "Elif", Surname = "Duzgun", Email = "eduzgun@gmail.com", Password = "23456",
                            CurrentGrade = 2, GPA = 3.18}
            );
        }
    }
}
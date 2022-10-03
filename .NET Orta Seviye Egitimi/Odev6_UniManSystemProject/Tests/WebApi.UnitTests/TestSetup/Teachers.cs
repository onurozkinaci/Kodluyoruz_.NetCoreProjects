using WebApi.DbOperations;
using WebApi.Entites;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Teachers
    {
        public static void AddTeachers(this UniManSystemDbContext context)
        {
            context.Teachers.AddRange(
                new Teacher {Name = "Ali", Surname = "Deniz", YearsOfExperience = 5, DepartmentId = 1},
                new Teacher {Name = "Melis", Surname ="Alici", YearsOfExperience = 4, DepartmentId = 2},
                new Teacher {Name = "Halit", Surname = "Koruyan", YearsOfExperience = 8, DepartmentId = 3}
            );
        }
    }
}
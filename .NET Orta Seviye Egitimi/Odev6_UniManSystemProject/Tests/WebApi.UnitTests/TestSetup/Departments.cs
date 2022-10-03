using WebApi.DbOperations;
using WebApi.Entites;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Departments
    {
        public static void AddDepartments(this UniManSystemDbContext context)
        {
            context.Departments.AddRange(
                new Department {DeptName = "Software Engineering"},
                new Department{DeptName = "Industrial Engineering"},
                new Department{DeptName = "Psychology"}
            );
        }
    }
}
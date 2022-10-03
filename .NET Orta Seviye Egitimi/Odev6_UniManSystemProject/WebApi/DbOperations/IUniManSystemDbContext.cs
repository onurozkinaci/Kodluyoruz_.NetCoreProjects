using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DbOperations
{
    public interface IUniManSystemDbContext
    {
        DbSet<Course> Courses {get; set;}
        DbSet<Department> Departments {get;set;}
        DbSet<SelectedCourse> SelectedCourses {get;set;}
        DbSet<Student> Students {get;set;}
        //DbSet<StudentTeacher>StudentTeachers {get;set;}
        DbSet<Teacher> Teachers {get;set;}
        int SaveChanges();
    }
}
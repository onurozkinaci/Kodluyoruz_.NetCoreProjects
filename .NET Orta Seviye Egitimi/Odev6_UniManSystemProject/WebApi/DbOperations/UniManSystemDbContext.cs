using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DbOperations
{
    public class UniManSystemDbContext:DbContext,IUniManSystemDbContext
    {
        public UniManSystemDbContext(DbContextOptions<UniManSystemDbContext>options):base(options)
        {}
        public DbSet<Course> Courses {get; set ;}
        public DbSet<Department> Departments {get; set;}
        public DbSet<SelectedCourse> SelectedCourses {get; set;}
        public DbSet<Student> Students {get; set;}
        //public DbSet<StudentTeacher> StudentTeachers {get; set;}
        public DbSet<Teacher> Teachers {get; set;} 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //modelBuilder.Entity<StudentTeacher>().HasKey(sc => new {sc.StudentId, sc.TeacherId});
          modelBuilder.Entity<SelectedCourse>().HasKey(sc => new {sc.StudentId, sc.CourseId});
        }

        public override int SaveChanges()
        { 
          return base.SaveChanges(); //base olarak verildi cunku yapilacak islemler DbContext(parent class).SaveChanges() ile ayni.
        }
    }
}
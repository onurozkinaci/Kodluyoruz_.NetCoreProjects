//*Program.cs icerisinde bu class bir servis olarak eklenerek, uygulama baslatildiginda db'deki
//table'lara default olarak burada belirtilen veriler eklenecek;

using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DbOperations
{
    public static class DataGenerator
    {
       public static void Initialize(IServiceProvider serviceProvider)
       {
          using(var context = new UniManSystemDbContext(serviceProvider.GetRequiredService<DbContextOptions<UniManSystemDbContext>>()))
          {
              if(context.SelectedCourses.Any()) //secilmis dersler bos degilse zaten kayit default olarak eklenmis demektir, tekrar ekleme demis oluyoruz.
                 return;

              //--Departments--;
              context.Departments.AddRange(
                  new Department {DeptName = "Software Engineering"},
                  new Department{DeptName = "Industrial Engineering"},
                  new Department{DeptName = "Psychology"}
              );

              //--Teachers--;
              context.Teachers.AddRange(
                  new Teacher {Name = "Ali", Surname = "Deniz", YearsOfExperience = 5, DepartmentId = 1},
                  new Teacher {Name = "Melis", Surname ="Alici", YearsOfExperience = 4, DepartmentId = 2},
                  new Teacher {Name = "Halit", Surname = "Koruyan", YearsOfExperience = 8, DepartmentId = 3}
              );

              //--Courses--;
              context.Courses.AddRange(
                  new Course {CourseName = "Advanced Python", CourseCode ="SEN4020", HowManyHours = 3 ,TeacherId = 1 ,DepartmentId = 1},
                  new Course {CourseName = "Production Strategies", CourseCode ="IND4052", HowManyHours = 2 ,TeacherId = 2 ,DepartmentId = 2},
                  new Course {CourseName = "Psychology Fundamentals", CourseCode ="PSY4020", HowManyHours = 2 ,TeacherId = 3 ,DepartmentId = 3}
              );
              
              //--Students--;
              context.Students.AddRange(
                  new Student {Name = "Onur", Surname = "Ozkn", Email = "onrozk@gmail.com", Password = "123456",
                               CurrentGrade = 4, GPA = 3.74},
                  new Student {Name = "Ali", Surname = "Bora", Email = "abora@gmail.com", Password = "12345",
                               CurrentGrade = 3, GPA = 3.45},
                  new Student {Name = "Elif", Surname = "Duzgun", Email = "eduzgun@gmail.com", Password = "23456",
                               CurrentGrade = 2, GPA = 3.18}
              );

              //--SelectedCourses (Ara tablo - many to many iliski)--;
              context.SelectedCourses.AddRange(
                  new SelectedCourse {StudentId = 1, CourseId = 1},
                  new SelectedCourse {StudentId = 1, CourseId = 2},
                  new SelectedCourse {StudentId = 2, CourseId = 3},
                  new SelectedCourse {StudentId = 2, CourseId = 1},
                  new SelectedCourse {StudentId = 3, CourseId = 2}
              );
              context.SaveChanges();
          }
       }
    }
}
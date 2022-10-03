using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{
    public class Teacher
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       public string Name { get; set; }  
       public string Surname { get; set; }
       public int YearsOfExperience { get; set; }
       public int DepartmentId { get; set; } //One to Many iliski, Foreign Key
       public Department Department { get; set; }
       public ICollection<Course> Courses { get; set; } //one to many iliski.
       
       //public ICollection<StudentTeacher> StudentTeachers { get; set; }  
    }
}
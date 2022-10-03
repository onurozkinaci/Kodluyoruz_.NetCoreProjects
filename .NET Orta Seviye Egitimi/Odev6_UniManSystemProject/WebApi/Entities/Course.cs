using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{
    public class Course
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       public string CourseName { get; set; }  
       public string CourseCode { get; set; }  
       public int HowManyHours { get; set; } //kursun kac saat surdugu bilgisini tutar.
       public int TeacherId { get; set; } //asagida Teacher class'ini da vererek one to many iliskiden TeacherId 
       //foreign key olarak verilmis oldu.
       public Teacher Teacher { get; set; }
       public int DepartmentId { get; set; } //One to many iliski - Foreign Key
       public Department Department { get; set; }
       public ICollection<SelectedCourse> SelectedCourses { get; set; } 
    }
}
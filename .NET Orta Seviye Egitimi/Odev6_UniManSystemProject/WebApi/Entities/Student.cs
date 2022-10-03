using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{
    public class Student
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       public string Name { get; set; } 
       public string Surname { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public int CurrentGrade { get; set; } //guncel olarak ogrencinin kacinci sinifta old. bilgisi.

       //public bool isGraduated { get; set;}
       public double GPA { get; set; } //ogrencinin genel ortalamasi.

       //*Authentication icin student'a token vermek adina;
       public string? RefreshToken { get; set; } 
       public DateTime? RefreshTokenExpireDate { get; set; } 

       //public ICollection<StudentTeacher> StudentTeachers { get; set; }     
       public ICollection<SelectedCourse> SelectedCourses { get; set; }     
    }
}
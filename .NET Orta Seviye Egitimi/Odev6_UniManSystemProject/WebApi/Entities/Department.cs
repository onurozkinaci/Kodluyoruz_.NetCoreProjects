using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DeptName { get; set; }
        public ICollection<Course> Courses { get; set; } //one to many iliski.
        public ICollection<Teacher> Teachers { get; set; } //one to many iliski.
    }
}
//Student'in secmis oldugu Course bilgisini tutan entity'dir. Bir ogrenci birden cok ders secebilecegi
//gibi, bir dersi birden cok ogrenci de secebilir;
//Many to many iliski sebebiyle Student ve Course tablolari arasinda olusturulan bir 'ara tablo'dur;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entites
{
    public class SelectedCourse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
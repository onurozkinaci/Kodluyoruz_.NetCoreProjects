using WebApi.DbOperations;

namespace WebApi.Application.SelectedCourseOperations.Commands.DeleteSelectedCourse
{
    public class DeleteSelectedCourseCommand
    {
        private readonly IUniManSystemDbContext _context;
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DeleteSelectedCourseCommand(IUniManSystemDbContext context)
        {
           _context = context;
        }
        public void Handle()
        {
          //'student id' ve 'course id', pair halinde bir key olarak SelectedCourse tablosunda mevcut ise;
           var selectedCourse = _context.SelectedCourses.SingleOrDefault(x=>x.StudentId == StudentId && x.CourseId == CourseId);
           if(selectedCourse is null)
              throw new InvalidOperationException("Silinecek olan secilmis ders kaydi bulunamadi!");

           _context.SelectedCourses.Remove(selectedCourse);
           _context.SaveChanges();
        }
    }
}
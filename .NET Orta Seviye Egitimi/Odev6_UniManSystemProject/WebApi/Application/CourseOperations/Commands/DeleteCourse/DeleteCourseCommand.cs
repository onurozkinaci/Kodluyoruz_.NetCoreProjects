using WebApi.DbOperations;

namespace WebApi.Application.CourseOperations.Commands.DeleteCourse
{
    public class DeleteCourseCommand
    {
        private readonly IUniManSystemDbContext _context;
        public int CourseId { get; set; }
        public DeleteCourseCommand(IUniManSystemDbContext context)
        {
           _context = context;
        }
        public void Handle()
        {
           var course = _context.Courses.SingleOrDefault(x=>x.Id == CourseId);
           if(course is null)
              throw new InvalidOperationException("Silinecek kurs bulunamadi!");

           if(_context.SelectedCourses.Any(x => x.CourseId == CourseId))
              throw new InvalidOperationException("Ilgili kurs, oncelikle 'Secilen Dersler' tablosundan silinmelidir!");

           _context.Courses.Remove(course);
           _context.SaveChanges();
        }
    }
}
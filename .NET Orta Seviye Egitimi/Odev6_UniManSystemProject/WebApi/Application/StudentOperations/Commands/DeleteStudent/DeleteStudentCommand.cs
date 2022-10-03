using WebApi.DbOperations;

namespace WebApi.Application.StudentOperations.Commands.DeleteStudent
{
    public class DeleteStudentCommand
    {
        private readonly IUniManSystemDbContext _context;
        public int StudentId { get; set; }
        public DeleteStudentCommand(IUniManSystemDbContext context)
        {
           _context = context;
        }
        public void Handle()
        {
           var student = _context.Students.SingleOrDefault(x=>x.Id == StudentId);
           if(student is null)
              throw new InvalidOperationException("Silinecek ogrenci mevcut degil!");

           if(_context.SelectedCourses.Any(x => x.StudentId == StudentId))
              throw new InvalidOperationException("Ilgili ogrenci, oncelikle 'Secilen Dersler' tablosundan silinmelidir!");
            
           _context.Students.Remove(student);
           _context.SaveChanges();
        }
    }
}
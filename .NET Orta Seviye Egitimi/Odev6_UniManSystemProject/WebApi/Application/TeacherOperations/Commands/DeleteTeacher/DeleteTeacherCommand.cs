using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.TeacherOperations.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand
    {
        private readonly IUniManSystemDbContext _context;
        public int TeacherId {get; set;}
        public DeleteTeacherCommand(IUniManSystemDbContext context)
        {
           _context = context;
        }
        public void Handle()
        {
           var teacher = _context.Teachers.SingleOrDefault(x => x.Id == TeacherId);
           if(teacher is null)  
             throw new InvalidOperationException("Silinecek ogretmen bulunamadi!");
             
           _context.Teachers.Remove(teacher);
           _context.SaveChanges();
        }
    }
}
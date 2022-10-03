using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.TeacherOperations.Commands.UpdateTeacher
{
    public class UpdateTeacherCommand
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public int TeacherId { get; set; }
        public UpdateTeacherModel Model {get;set;}
        public UpdateTeacherCommand(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public void Handle()
        {
           var teacher = _context.Teachers.SingleOrDefault(x => x.Id == TeacherId);
           if(teacher is null)
              throw new InvalidOperationException("Guncellenecek ogretmen bulunamadi!");

           if(!(_context.Departments.Any(x=>x.Id == Model.DepartmentId)))
             throw new InvalidOperationException("Girilen departman bilgisi mevcut degil!");
         
           _mapper.Map(Model,teacher);
           _context.SaveChanges();
        }
    }
    public class UpdateTeacherModel
    {
       public string Name {get; set;}  
       public string Surname {get; set;}  
       public int YearsOfExperience { get; set; }
       public int DepartmentId { get; set; }
    }
}
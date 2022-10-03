using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.TeacherOperations.Command.CreateTeacher
{
    public class CreateTeacherCommand
    {
       private readonly IUniManSystemDbContext _context;
       private readonly IMapper _mapper;
       public CreateTeacherModel Model {get;set;}
       public CreateTeacherCommand(IUniManSystemDbContext context, IMapper mapper)
       {
           _context = context;
           _mapper = mapper;
       }
       public void Handle()
       {
          var teacher = _context.Teachers.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
          if(teacher is not null)
             throw new InvalidOperationException("Bu ad-soyad ile bir ogretmen kaydi zaten mevcut!");

          if(!(_context.Departments.Any(x=>x.Id == Model.DepartmentId)))
            throw new InvalidOperationException("Girilen departman bilgisi mevcut degil!");
         
           teacher = _mapper.Map<Teacher>(Model);
          _context.Teachers.Add(teacher);
          _context.SaveChanges();
       }
    }
    public class CreateTeacherModel
    {
       public string Name {get; set;}  
       public string Surname {get; set;}  
       public int YearsOfExperience { get; set; }
       public int DepartmentId { get; set; }
    }
}
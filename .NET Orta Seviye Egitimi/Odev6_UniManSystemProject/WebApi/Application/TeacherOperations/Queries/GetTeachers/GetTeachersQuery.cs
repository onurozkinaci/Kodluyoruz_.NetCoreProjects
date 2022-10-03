using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.Queries.GetTeachers
{
    public class GetTeachersQuery
    {
       private readonly IUniManSystemDbContext _context;
       private readonly IMapper _mapper;
        public GetTeachersQuery(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public List<TeacherVM> Handle()
        {
           var teachers = _context.Teachers.Include(x => x.Department).OrderBy(x => x.Id).ToList<Teacher>();
           List<TeacherVM> vm = _mapper.Map<List<TeacherVM>>(teachers);
           return vm;
        }
    }
    public class TeacherVM
    {
       public string FullName {get; set;}  
       public int YearsOfExperience { get; set; }
       public string Department { get; set;}
    }
}
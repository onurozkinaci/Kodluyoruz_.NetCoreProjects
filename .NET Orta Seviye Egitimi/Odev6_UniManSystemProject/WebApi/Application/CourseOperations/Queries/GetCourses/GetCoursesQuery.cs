using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.CourseOperations.Queries.GetCourses
{
    public class GetCoursesQuery
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public GetCoursesQuery(IUniManSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CourseVM> Handle()
        {
           var courses = _context.Courses.Include(x => x.Teacher).Include(x => x.Department)
                         .OrderBy(x=>x.Id).ToList<Course>();
           List<CourseVM> vm = _mapper.Map<List<CourseVM>>(courses);
           return vm;
        }
    }
    public class CourseVM
    {
       public string CourseName { get; set; }  
       public string CourseCode { get; set; }  
       public int HowManyHours { get; set; } //kursun kac saat surdugu bilgisini tutar.
       public string Teacher {get;set;}
       public string Department {get;set;}
    }
}
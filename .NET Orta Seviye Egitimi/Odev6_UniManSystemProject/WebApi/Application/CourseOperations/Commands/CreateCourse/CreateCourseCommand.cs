using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.CourseOperations.Commands.CreateCourse
{
    public class CreateCourseCommand
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public CreateCourseModel Model {get;set;}

        public CreateCourseCommand(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public void Handle()
        {
           var course = _context.Courses.SingleOrDefault(x=>x.CourseCode == Model.CourseCode);
           if(course is not null)
              throw new InvalidOperationException("Bu kod ile bir ders kaydi zaten mevcut!");

           if(!(_context.Teachers.Any(x => x.Id == Model.TeacherId)))
              throw new InvalidOperationException("Girilen ogretmen bilgisi mevcut degil!");

           if(!(_context.Departments.Any(x => x.Id == Model.DepartmentId)))
              throw new InvalidOperationException("Girilen departman bilgisi mevcut degil!");
           
            course = _mapper.Map<Course>(Model);
           _context.Courses.Add(course);
           _context.SaveChanges();
        }
    }
    public class CreateCourseModel
    {
       public string CourseName { get; set; }  
       public string CourseCode { get; set; }  
       public int HowManyHours { get; set; } //kursun kac saat surdugu bilgisini tutar.
       public int TeacherId {get;set;}
       public int DepartmentId {get;set;}
    }
}
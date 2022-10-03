using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CourseOperations.Commands.UpdateCourse
{
    public class UpdateCourseCommand
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public int CourseId { get; set; }
        public UpdateCourseModel Model {get;set;}

        public UpdateCourseCommand(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public void Handle()
        {
           var course = _context.Courses.SingleOrDefault(x=>x.Id == CourseId);
           if(course is null)
              throw new InvalidOperationException("Guncellenecek kurs bulunamadi!");

           if(!(_context.Teachers.Any(x => x.Id == Model.TeacherId)))
              throw new InvalidOperationException("Girilen ogretmen bilgisi mevcut degil!");

           if(!(_context.Departments.Any(x => x.Id == Model.DepartmentId)))
              throw new InvalidOperationException("Girilen departman bilgisi mevcut degil!");
           
           _mapper.Map(Model,course);
           _context.SaveChanges();
        }
    }
    public class UpdateCourseModel
    {
       public string CourseName { get; set; }  
       public string CourseCode { get; set; }  
       public int HowManyHours { get; set; } //kursun kac saat surdugu bilgisini tutar.
       public int TeacherId {get;set;}
       public int DepartmentId {get;set;}
    }
}
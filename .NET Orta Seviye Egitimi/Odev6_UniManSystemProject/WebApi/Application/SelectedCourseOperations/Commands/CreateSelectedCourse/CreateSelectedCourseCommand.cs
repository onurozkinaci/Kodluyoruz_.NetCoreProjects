using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.SelectedCourseOperations.Commands.CreateSelectedCourse
{
    public class CreateSelectedCourseCommand
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public CreateSelectedCourseModel Model {get;set;}

        public CreateSelectedCourseCommand(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public void Handle()
        {
           //'student id' ve 'course id', pair halinde bir key olarak SelectedCourse tablosunda mevcut ise;
           var selectedCourse = _context.SelectedCourses.SingleOrDefault(x=>x.StudentId == Model.StudentId && x.CourseId == Model.CourseId);
           if(selectedCourse is not null)
              throw new InvalidOperationException("Belirtilen ders zaten secilmis!");

           if(!(_context.Students.Any(x => x.Id == Model.StudentId)))
              throw new InvalidOperationException("Girilen ogrenci bilgisi mevcut degil!");

           if(!(_context.Courses.Any(x => x.Id == Model.CourseId)))
              throw new InvalidOperationException("Girilen kurs/ders bilgisi mevcut degil!");
           
            selectedCourse = _mapper.Map<SelectedCourse>(Model);
           _context.SelectedCourses.Add(selectedCourse);
           _context.SaveChanges();
        }
    }
    public class CreateSelectedCourseModel
    {
       public int StudentId {get; set;}
       public int CourseId {get; set;}
    }
}
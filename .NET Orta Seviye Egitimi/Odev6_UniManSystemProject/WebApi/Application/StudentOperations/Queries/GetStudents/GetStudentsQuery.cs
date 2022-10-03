using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.StudentOperations.Queries.GetStudents
{
   public class GetStudentsQuery
   {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public GetStudentsQuery(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public List<StudentVM> Handle()
        {
           var students = _context.Students.OrderBy(x=>x.Id).ToList<Student>();  
           List<StudentVM> vm = _mapper.Map<List<StudentVM>>(students);
           return vm;
        }
   }

   public class StudentVM
   {
      public string FullName { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
      public int CurrentGrade { get; set; } //guncel olarak ogrencinin kacinci sinifta old. bilgisi.
      public double GPA { get; set; } //ogrencinin genel ortalamasi.

   }
}
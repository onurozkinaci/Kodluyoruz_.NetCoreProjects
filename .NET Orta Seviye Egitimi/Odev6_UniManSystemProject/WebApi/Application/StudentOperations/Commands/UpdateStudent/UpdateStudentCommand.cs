using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommand
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public int StudentId { get; set; }
        public UpdateStudentModel Model {get;set;}

        public UpdateStudentCommand(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public void Handle()
        {
           var student = _context.Students.SingleOrDefault(x=>x.Id == StudentId);
           if(student is null)
              throw new InvalidOperationException("Guncellenecek ogrenci mevcut degil!");
           
            _mapper.Map(Model,student);
           _context.SaveChanges();
        }
    }
    public class UpdateStudentModel
    {
       public string Name { get; set; } 
       public string Surname { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public int CurrentGrade { get; set; } //guncel olarak ogrencinin kacinci sinifta old. bilgisi.
       public double GPA { get; set; } //ogrencinin genel ortalamasi.
    }
}
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.StudentOperations.Commands.CreateStudent
{
    public class CreateStudentCommand
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public CreateStudentModel Model {get;set;}

        public CreateStudentCommand(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public void Handle()
        {
           var student = _context.Students.SingleOrDefault(x=>x.Name == Model.Name && x.Surname == Model.Surname);
           if(student is not null)
              throw new InvalidOperationException("Bu ad-soyad ile bir ogrenci kaydi zaten mevcut!");
           
            student = _mapper.Map<Student>(Model);
           _context.Students.Add(student);
           _context.SaveChanges();
        }
    }
    public class CreateStudentModel
    {
       public string Name { get; set; } 
       public string Surname { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public int CurrentGrade { get; set; } //guncel olarak ogrencinin kacinci sinifta old. bilgisi.
       public double GPA { get; set; } //ogrencinin genel ortalamasi.
    }
}
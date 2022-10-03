using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.DepartmentOperations.Commands.CreateDepartment
{
    public class CreateDepartmentCommand
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public CreateDepartmentModel Model {get;set;}
        public CreateDepartmentCommand(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public void Handle()
        {
           var dept = _context.Departments.SingleOrDefault(x => x.DeptName == Model.DeptName);
           if(dept is not null)  
             throw new InvalidOperationException("Bu departman ismi ile bir kayit zaten mevcut!");
           
           Department department = _mapper.Map<Department>(Model);
           _context.Departments.Add(department);
           _context.SaveChanges();
        }
    }

    public class CreateDepartmentModel
    {
        public string DeptName { get; set;}
    }
}
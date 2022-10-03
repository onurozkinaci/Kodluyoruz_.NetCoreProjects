using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.DepartmentOperations.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public int DeptId { get; set; }
        public UpdateDepartmentModel Model {get;set;}
        public UpdateDepartmentCommand(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public void Handle()
        {
           var dept = _context.Departments.SingleOrDefault(x => x.Id == DeptId);
           if(dept is null)  
             throw new InvalidOperationException("Guncellenecek departman bulunamadi!");
           
           _mapper.Map(Model,dept);
           _context.SaveChanges();
        }
    }
    public class UpdateDepartmentModel
    {
        public string DeptName { get; set;}
    }
}
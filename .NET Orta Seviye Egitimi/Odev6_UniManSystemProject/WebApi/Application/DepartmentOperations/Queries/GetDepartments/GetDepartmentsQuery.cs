using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.DepartmentOperations.Queries
{
    public class GetDepartmentsQuery
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public GetDepartmentsQuery(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public List<DepartmentVM> Handle()
        {
           var departments = _context.Departments.OrderBy(x=>x.Id).ToList<Department>();  
           List<DepartmentVM> vm = _mapper.Map<List<DepartmentVM>>(departments);
           return vm;
        }
    }

    public class DepartmentVM
    {
       public string DeptName { get; set; }
    }
}
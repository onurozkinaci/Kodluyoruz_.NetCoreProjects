using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.DepartmentOperations.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand
    {
        private readonly IUniManSystemDbContext _context;
        public int DepartmentId {get; set;}
        public DeleteDepartmentCommand(IUniManSystemDbContext context)
        {
           _context = context;
        }
        public void Handle()
        {
           var dept = _context.Departments.SingleOrDefault(x => x.Id == DepartmentId);
           if(dept is null)  
             throw new InvalidOperationException("Silinecek departman bulunamadi!");

           _context.Departments.Remove(dept);
           _context.SaveChanges();
        }
    }
}
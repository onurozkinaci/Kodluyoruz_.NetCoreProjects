using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.Application.SelectedCourseOperations.Queries.GetSelectedCourses
{
    public class GetSelectedCoursesQuery
    {
        private readonly IUniManSystemDbContext _context;
        private readonly IMapper _mapper;
        public GetSelectedCoursesQuery(IUniManSystemDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
        public List<SelectedCourseVM> Handle()
        {
           var selectedCourses = _context.SelectedCourses.Include(x=>x.Student).Include(x=>x.Course)
                                 .OrderBy(x=>x.StudentId).ToList<SelectedCourse>();  
           List<SelectedCourseVM> vm = _mapper.Map<List<SelectedCourseVM>>(selectedCourses);
           return vm;
        }
    }

    public class SelectedCourseVM
    {
       public string Course {get;set;}
       public string Student {get;set;}
    }
}
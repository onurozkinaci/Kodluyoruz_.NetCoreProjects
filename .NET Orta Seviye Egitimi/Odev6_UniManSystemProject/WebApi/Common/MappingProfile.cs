using AutoMapper;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.Application.DepartmentOperations.Commands.CreateDepartment;
using WebApi.Application.DepartmentOperations.Commands.UpdateDepartment;
using WebApi.Application.DepartmentOperations.Queries;
using WebApi.Application.Queries.GetTeachers;
using WebApi.Application.SelectedCourseOperations.Commands.CreateSelectedCourse;
using WebApi.Application.SelectedCourseOperations.Queries.GetSelectedCourses;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.Application.StudentOperations.Queries.GetStudents;
using WebApi.Application.TeacherOperations.Command.CreateTeacher;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using WebApi.CourseOperations.Queries.GetCourses;
using WebApi.Entites;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
       public MappingProfile()
       {
          //--Department--;
          CreateMap<Department,DepartmentVM>();
          CreateMap<CreateDepartmentModel,Department>();
          CreateMap<UpdateDepartmentModel,Department>();

          //--Teacher--;
          CreateMap<Teacher, TeacherVM>()
          .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname))
          .ForMember(dst => dst.Department, opt => opt.MapFrom(src => src.Department.DeptName));
          CreateMap<CreateTeacherModel, Teacher>();
          CreateMap<UpdateTeacherModel, Teacher>();

          //--Course--;
          CreateMap<Course, CourseVM>()
          .ForMember(dst => dst.Teacher, opt => opt.MapFrom(src => src.Teacher.Name + " " + src.Teacher.Surname))
          .ForMember(dst => dst.Department, opt => opt.MapFrom(src => src.Department.DeptName));
          CreateMap<CreateCourseModel, Course>();
          CreateMap<UpdateCourseModel, Course>();

          //--Student--;
          CreateMap<Student, StudentVM>()
          .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname));
          CreateMap<CreateStudentModel, Student>();
          CreateMap<UpdateStudentModel, Student>();

          //--Selected Course--;
          CreateMap<SelectedCourse, SelectedCourseVM>()
          .ForMember(dst => dst.Student, opt => opt.MapFrom(src => src.Student.Name + " " + src.Student.Surname))
          .ForMember(dst => dst.Course, opt => opt.MapFrom(src => src.Course.CourseName));
          CreateMap<CreateSelectedCourseModel, SelectedCourse>();
       } 
    }
}
using AutoMapper;
using Web_API_DAY2.DTOs.CourseDTO;
using Web_API_DAY2.DTOs.DepartmentDTO;
using Web_API_DAY2.DTOs.StudentDTO;

namespace Web_API_DAY2.MappingConfig
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {


            // Student Mapping 
            // if there are two properties with diff names
            //  USE AFTERMAP

            CreateMap<Student2, ReadStudentDto>().AfterMap((src, des) =>
            {
                des.DepartmentName = src.Dept?.DeptName;
                des.FullName = src.StFname + " " + src.StLname;
                des.Supervisorname = src.StSuperNavigation?.StFname;
            }).ReverseMap();

            CreateMap<AddStudentDto, Student2>();
            CreateMap<UpdateStudentDto, Student2>();

            //Course Mapping

            CreateMap<Course, ReadCourseDto>(); // the des : dto

            CreateMap<AddCourseDTO, Course>();  // the des : course 

            CreateMap<UpdateCourseDto, Course>();//the des : course


            // Department 

            CreateMap<Department, GetDeptDTO>().AfterMap((src, des) =>
            {
                des.studentcount = src.Student2s.Count;
                des.studentnames = src.Student2s.Select(s => $"{s.StFname} {s.StLname}").ToList();
            });
                
                //the des : dto
            CreateMap<UpdateDepartmentDTO, Department>();//des = dept
            CreateMap<AddDepartmentDTO, Department>();




        }

    }
}

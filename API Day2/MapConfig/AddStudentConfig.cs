using API_Day2.DTOs.StudentDTOs;
using API_Day2.Models;
using AutoMapper;

namespace API_Day2.MapConfig
{
    public class AddStudentConfig : Profile
    {

        public AddStudentConfig()
        {
            CreateMap<AddStudent, Student>().AfterMap((src, dist) =>
            {
                dist.St_Fname = src.Student_Fname;
                dist.St_Lname = src.Student_Lname;
                dist.St_Address = src.Student_Address;
                dist.St_Age = src.Student_Age;
                dist.Dept_Id = src.Department_Id;
                dist.St_super = src.Supervisor_Id;
            });
        }
    }
}

using API_Day2.DTOs.StudentDTOs;
using API_Day2.Models;
using AutoMapper;

namespace API_Day2.MapConfig
{
    public class StudentGetAllConfig : Profile
    {
        public StudentGetAllConfig()
        {
            CreateMap<Student, GetAllWithNames>().AfterMap((src, dist) =>
            {
                dist.Student_Id = src.St_Id;
                dist.Student_Fname = src.St_Fname;
                dist.Student_Lname = src.St_Lname;
                dist.Student_Address = src.St_Address;
                dist.Student_Age = src.St_Age;
                dist.Department_Name = src.Dept?.Dept_Name;
                dist.Supervisor_Name = src.St_superNavigation?.St_Fname;
            }).ReverseMap();
        }
    }
}

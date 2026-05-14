using API_Day2.DTOs.DepartmentDTOs;
using API_Day2.Models;
using AutoMapper;

namespace API_Day2.MapConfig
{
    public class EditDeparmentConfig : Profile
    {
        public EditDeparmentConfig()
        {
            CreateMap<EditDeparrtmentDTO, Department>().AfterMap((src, dist) =>
            {
                dist.Dept_Name = src.Department_Name;
                dist.Dept_Desc = src.Department_Description;
                dist.Dept_Location = src.Department_Location;
                dist.Dept_Manager = src.Department_Manager_ID;

            });
        }
    }
}

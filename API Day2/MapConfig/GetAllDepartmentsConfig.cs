using API_Day2.DTOs.DepartmentDTOs;
using API_Day2.Models;
using AutoMapper;

namespace API_Day2.MapConfig
{
    public class GetAllDepartmentsConfig : Profile
    {

        public GetAllDepartmentsConfig()
        {
            CreateMap<Department, GetAllDepartmentsDTO>().AfterMap((src, dist) =>
            {
                dist.Department_ID = src.Dept_Id;
                dist.Department_Name = src.Dept_Name;
                dist.Department_Description = src.Dept_Desc;
                dist.Department_Location = src.Dept_Location;
                dist.Department_Manager_ID = src.Dept_Manager;
                dist.Department_Manager_Name = src.Dept_ManagerNavigation != null ? src.Dept_ManagerNavigation.Ins_Name : null;
                dist.Manager_hiredate = src.Manager_hiredate;
                dist.Students_Count = src.Students.Count;

            });
        }
    }
}

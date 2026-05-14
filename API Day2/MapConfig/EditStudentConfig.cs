using API_Day2.DTOs.StudentDTOs;
using API_Day2.Models;
using AutoMapper;

namespace API_Day2.MapConfig
{
    public class EditStudentConfig : Profile
    {
        public EditStudentConfig()
        {
            CreateMap<EditDto, Student>();
        }
    }
}

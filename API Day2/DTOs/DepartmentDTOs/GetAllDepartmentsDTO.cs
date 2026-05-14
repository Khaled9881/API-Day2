using API_Day2.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Day2.DTOs.DepartmentDTOs
{
    public class GetAllDepartmentsDTO
    {
        //[DisplayName("Department ID")]
        public int Department_ID { get; set; }

        public string Department_Name { get; set; }

        public string Department_Description { get; set; }

        public string Department_Location { get; set; }

        public int? Department_Manager_ID { get; set; }
        public string? Department_Manager_Name { get; set; }

        public DateOnly? Manager_hiredate { get; set; }

        public int? Students_Count { get; set; }
    }
}

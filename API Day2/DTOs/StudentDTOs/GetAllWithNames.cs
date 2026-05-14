using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API_Day2.DTOs.StudentDTOs
{
    public class GetAllWithNames
    {
        public int Student_Id { get; set; }

        public string Student_Fname { get; set; }

        public string Student_Lname { get; set; }

        public string Student_Address { get; set; }

        public int? Student_Age { get; set; }

        public string? Department_Name { get; set; }

        public string? Supervisor_Name { get; set; }
    }
}

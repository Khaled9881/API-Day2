namespace API_Day2.DTOs.DepartmentDTOs
{
    public class EditDeparrtmentDTO
    {
        public string Department_Name { get; set; }

        public string Department_Description { get; set; }

        public string Department_Location { get; set; }

        public int? Department_Manager_ID { get; set; }
    }
}

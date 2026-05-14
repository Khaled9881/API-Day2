namespace API_Day2.DTOs.StudentDTOs
{
    public class AddStudent
    {

        public int St_Id { get; set; }
        public string Student_Fname { get; set; }

        public string Student_Lname { get; set; }

        public string Student_Address { get; set; }

        public int? Student_Age { get; set; }

        public int? Department_Id { get; set; }

        public int? Supervisor_Id { get; set; }
    }
}

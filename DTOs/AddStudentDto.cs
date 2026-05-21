namespace Web_API_DAY2.DTOs.StudentDTO
{
    public class AddStudentDto
    {

       
        public int DeptId { get; set; } 
        public string StFname { get; set; }

        public string StLname { get; set; }

        public int? StAge { get; set; }
        public string StAddress { get; set; }
    }
}

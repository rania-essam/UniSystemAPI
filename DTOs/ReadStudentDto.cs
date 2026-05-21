namespace Web_API_DAY2.DTOs.StudentDTO
{
    public class ReadStudentDto
    {
        public String FullName { get; set; }

        public string StAddress { get; set; }

         public int? StAge { get; set; }
         public string DepartmentName { get; set; }

        public int DeptId { get; set; }
        public string? Supervisorname { get; set; }
    

    }
}

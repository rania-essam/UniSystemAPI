using System.ComponentModel.DataAnnotations;

namespace Web_API_DAY2.DTOs.StudentDTO
{
    public class UpdateStudentDto
    {
        public int StId { get; set; }

        [Required]
        public string StFname { get; set; }

        [Required]
        public string StLname { get; set; }

        public string? StAddress { get; set; }

        [Required]
        public int StAge { get; set; }

        public int? DeptId { get; set; }

        public int? StSuper { get; set; }
    }
}

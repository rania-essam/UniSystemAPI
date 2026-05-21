namespace Web_API_DAY2.DTOs.DepartmentDTO
{
    public class GetDeptDTO
    {
        public int DeptId { get; set; }

        public string? DeptName { get; set; }

        public string? DeptDesc { get; set; }

        public string? DeptLocation { get; set; }
        public int studentcount { get; set; }
        public List<string> studentnames { get; set; }

    }
}

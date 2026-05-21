using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_DAY2.DTOs.StudentDTO;

namespace Web_API_DAY2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ItiContext _context;
        public IMapper _map;
        public StudentController(ItiContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        [HttpGet]
        public IActionResult GetAllStds()
        {
            var stds = _context.Student2s.ToList();
         //  List<ReadStudentDto> stds_dto = new List<ReadStudentDto>();
            //foreach (var std in stds)
            //{
            //    ReadStudentDto std_dto = new ReadStudentDto();
            //    std_dto.FullName = std.StFname + " " + std.StLname;
            //    std_dto.StAddress = std.StAddress;
            //    std_dto.StAge = std.StAge;
            //    std_dto.DepartmentName = std.Dept?.DeptName;
            //    std_dto.Supervisorname = std.StSuperNavigation?.StFname;
            //    std_dto.DeptId= std.DeptId ?? 0;

            //    stds_dto.Add(std_dto);
            //}
          

            return Ok(_map.Map<List<ReadStudentDto>>(stds));
        }

   //     [Consumes("application/json")]

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var std = _context.Student2s.Find(id);

            if(std==null)
            {
                return NotFound($"No Student with id {id}");
            }
          //  ReadStudentDto std_dto = new ReadStudentDto();

            //std_dto.FullName = std.StFname + " " + std.StLname;
            //std_dto.Address = std.StAddress;
            //std_dto.Age = std.StAge;
            //std_dto.DepartmentName = std.Dept?.DeptName;
            //std_dto.Supervisorname = std.StSuperNavigation?.StFname;

            return Ok(_map.Map<ReadStudentDto>(std));

        }


        // add
        [Consumes("application/json")]

        [HttpPost]
        public IActionResult Addstd(int id , AddStudentDto newstudent)
        {
            if (newstudent == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest(ModelState);
           //Student std = new Student();
            //  std.StFname = newstudent.Fname;
            //  std.StLname = newstudent.Lname;
            //  std.StAge = newstudent.Age;
            //  std.StAddress = newstudent.Address;
            //  std.DeptId = newstudent.Dept_id;

            //std.StId = id;

             var std = _map.Map<Student2>(newstudent);
            _context.Student2s.Add(std);
            _context.SaveChanges();
           // return Ok("Created Successfully");
          return CreatedAtAction("GetById", new { id = std.StId } , _map.Map<ReadStudentDto>(std));
        }


        // pagination and searching 

        // GET: api/students?page=1&pageSize=10&search=ahmed

        [HttpGet("/api/students/page")]
        public IActionResult GetStudents(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null)
        {
            // Get student data
            var query = _context.Students.AsQueryable();

            // Searching
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(s =>
                    s.StFname.Contains(search)
                    );
            }

            // Total count before pagination
            var totalCount = query.Count();

            // Total pages
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // Pagination + Select DTO
            var students = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new GetStudentDto
                {
                    Id = s.StId,
                    Name = s.StFname + " " + s.StLname,
                    Address = s.StAddress
                })
                .ToList();

            // Response
            return Ok(new
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Data = students
            });
        }

        //update

        [HttpPut]
        public IActionResult Update_Student(int id , UpdateStudentDto addstd )
        {
            if (id != addstd.StId) return BadRequest("id is not valid");

            var std = _context.Student2s.Find(id);

            //   Student2 updateStudent =  _map.Map<Student2>(addstd);
            //    _context.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _map.Map(addstd, std);
            _context.SaveChanges();
            return Ok("Updated Successfully ");
        }

        //Delete 

        [HttpDelete]
        public IActionResult Delete_Student(int id)
        {
            _context.Student2s.Remove(_context.Student2s.Find(id));
            _context.SaveChanges();
            return Ok("Deleted Successfully ");
        }
    }
}

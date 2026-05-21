using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_DAY2;
using Web_API_DAY2.DTOs.CourseDTO;

namespace WebApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        ItiContext _context;
        IMapper _map;
        public CourseController(ItiContext context,IMapper map)
        {
            _context = context;
            _map = map;

        }
        // routing is based on ( url + verb )

        //get all
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ReadCourseDto> courses = new List<ReadCourseDto>();
            return Ok(_map.Map(_context.Courses.ToList(), courses));
        }
        //get by id

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id)
        {
            Course c = _context.Courses.Find(id);
            if (c == null) return NotFound();//404
            return Ok(_map.Map<ReadCourseDto>(c));//200
        }
        //get by name
        [HttpGet("/api/GetByName/{name}")]

        public IActionResult GetByName(string name)
        {
            Course c = _context.Courses.FirstOrDefault(c => c.CrsName == name);
            if (c == null) return NotFound();//404
            return Ok(_map.Map<ReadCourseDto>(c));//200
        }
        //add
        [HttpPost]
        public IActionResult AddCourse (AddCourseDTO c)
        {
                if (c == null) return BadRequest();
                
                _context.Courses.Add(_map.Map<Course>(c));
                _context.SaveChanges();
                return CreatedAtAction("GetByID", new { id = c.CrsId}, c);
            
        }
        //update
        [HttpPut]
        public IActionResult UpdateCourse(int id,UpdateCourseDto c)
        {
            if(id != c.CrsId || c == null) return BadRequest();
           _context.Entry(_map.Map<Course>(c)).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //delete
        [HttpDelete]

        public IActionResult DeleteCourse(int id)
        {
            Course c = _context.Courses.Find(id);
            if (c == null) return BadRequest();

            _context.Courses.Remove(c);
            _context.SaveChanges();

            return Ok("Deleted Successfully ");
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_DAY2.DTOs.DepartmentDTO;

namespace Web_API_DAY2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        ItiContext _context;

        IMapper _map;
        public DepartmentController(ItiContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var depts= _context.Departments.ToList();
            if(depts.Any() == false)
                return NotFound();
           // List<GetDeptDTO> deptDTOs = new List<GetDeptDTO>();
            //foreach (Department d in depts)
            //{
            //    GetDeptDTO deptdto  = new GetDeptDTO();
            //    deptdto.id = d.DeptId;
            //    deptdto.name = d.DeptName;
            //    deptdto.location = d.DeptLocation;
            //    deptdto.studentnames=d.Students.Select(s => $"{s.StFname} {s.StFname}").ToList();

            //    deptdto.studentcount = deptdto.studentnames.Count();
            //    deptDTOs.Add(deptdto);
            //}
            return Ok(_map.Map<List<GetDeptDTO>>(depts));
        }

        [HttpGet("{id:int}")]
        public IActionResult getbyid(int id)
        {
            var dept = _context.Departments.Find(id);
            if (dept == null)
                return NotFound();

            //GetDeptDTO deptdto = new GetDeptDTO();

            //deptdto.id = dept.DeptId;
            //deptdto.name = dept.DeptName;
            //deptdto.location = dept.DeptLocation;
            //deptdto.studentnames = dept.Students?.Select(s => $"{s.StFname} {s.StFname}").ToList();
            return Ok(_map.Map<GetDeptDTO>(dept));

        }


        //update
        [HttpPut]
        public IActionResult UpdateDepartment(int id , [FromBody]UpdateDepartmentDTO dept_dto)
        {
            if (id != dept_dto.DeptId)
                return BadRequest();

                _map.Map<Department>(dept_dto);
                _context.SaveChanges();
                 return CreatedAtAction("getbyid", new { id = dept_dto.DeptId }, dept_dto);

        }

        // add
        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDTO departmentDTO)
        {
            if(departmentDTO==null)
                return BadRequest();
            _context.Departments.Add(_map.Map<Department>(departmentDTO));
            _context.SaveChanges();
            return CreatedAtAction("getbyid",new { id=departmentDTO.DeptId} , departmentDTO);
             
        }

        //delete
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            var d = _context.Departments.Find(id);
            if(d==null) return NotFound();

            _context.Departments.Remove(d);
            _context.SaveChanges();
            return Ok("Deleted Successfully ");
        }
    }
}

using API_Day2.DTOs.DepartmentDTOs;
using API_Day2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ITIContext iTIContext;
        private readonly IMapper mapper;

        public DepartmentController(ITIContext iTIContext, IMapper mapper)
        {
            this.iTIContext = iTIContext;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var department = iTIContext.Departments
        .Select(d => new GetAllDepartmentsDTO
        {
            Department_ID = d.Dept_Id,
            Department_Name = d.Dept_Name,
            Department_Description = d.Dept_Desc,
            Department_Location = d.Dept_Location,
            Department_Manager_ID = d.Dept_Manager,
            Department_Manager_Name = d.Dept_ManagerNavigation != null
                ? d.Dept_ManagerNavigation.Ins_Name
                : null,
            Manager_hiredate = d.Manager_hiredate,

            Students_Count = d.Students.Count()
        })
        .ToList();


            return Ok(mapper.Map<List<GetAllDepartmentsDTO>>(department));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDepartmentById(int id)
        {
            Department? department = iTIContext.Departments
                .Where(s => s.Dept_Id == id)
                .Include(d => d.Dept_ManagerNavigation)
                .FirstOrDefault();
            if (department == null)
                return NotFound();


            return Ok(mapper.Map<GetAllDepartmentsDTO>(department));
        }

        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDto deptDto)
        {
            Department? department = iTIContext.Departments.Find(deptDto.Department_ID);

            if (department != null || !ModelState.IsValid)
                return BadRequest(ModelState);


            iTIContext.Departments.Add(mapper.Map<Department>(deptDto));
            iTIContext.SaveChanges();

            return Created();
        }

        [HttpPut("{id:int}")]
        public IActionResult EditDepartment(int id, EditDeparrtmentDTO deptDto)
        {
            Department? dept = iTIContext.Departments.Find(id);

            if (dept == null || !ModelState.IsValid)
                return NotFound();

            mapper.Map(deptDto, dept);

            iTIContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            Department? department = iTIContext.Departments.Find(id);
            if (department == null)
                return NotFound();

            iTIContext.Departments.Remove(department);
            iTIContext.SaveChanges();

            return NoContent();
        }


    }
}

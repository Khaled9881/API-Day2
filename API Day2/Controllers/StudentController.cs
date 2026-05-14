using API_Day2.DTOs.StudentDTOs;
using API_Day2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ITIContext iTIContext;
        public IMapper mapper;

        public StudentController(ITIContext iTIContext, IMapper mapper)
        {
            this.iTIContext = iTIContext;
            this.mapper = mapper;
        }

        [HttpGet("page/{pageNumber:int}")]
        public IActionResult GetAllStudent(int pageNumber = 1)
        {
            var students = iTIContext.Students
            .Include(s => s.Dept)
            .Include(s => s.St_superNavigation);
            //.ToList();

            decimal count = students.Count();
            int StudentsPerPage = 2;
            int pages = (int)Math.Ceiling(count / StudentsPerPage);


            if (pageNumber > pages || pageNumber <= 0)
                return NotFound();

            var page = students
                .Skip((pageNumber - 1) * StudentsPerPage)
                .Take(StudentsPerPage)
                .ToList();

            var res = mapper.Map<List<GetAllWithNames>>(page);
            return Ok(res);

            //return Ok(mapper.Map<List<GetAllWithNames>>(students));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            return Ok(iTIContext.Students.Find(id));
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudent studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            Student? newStudent = mapper.Map<Student>(studentDto);

            iTIContext.Students.Add(newStudent);
            iTIContext.SaveChanges();
            return Created();
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchByName(string name)
        {
            List<Student>? students = iTIContext.Students.Where(s => s.St_Fname.ToLower() == name.ToLower()).ToList();

            if (students == null)
                return NotFound();

            return Ok(mapper.Map<List<GetAllWithNames>>(students));
        }

        [HttpPut]
        public IActionResult EditStudent(EditDto studentDto)
        {
            if (studentDto == null)
                return BadRequest();

            Student? st = iTIContext.Students.Find(studentDto.St_Id);
            if (st == null)
                return NotFound();

            mapper.Map(studentDto, st);

            iTIContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = iTIContext.Students.Find(id);

            if (student == null)
                return NotFound();

            iTIContext.Students.Remove(student);
            iTIContext.SaveChanges();

            return Ok(student);

        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllStudents();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetStudent(id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _service.AddStudent(student);
            return Ok(new
            {
                message = "Student created successfully",
                data = student
            });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            await _service.UpdateStudent(id, student);
            return Ok(new
            {
                message = "Student updated successfully",
                data = student
            });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteStudent(id);
            return Ok("Student Deleted successfully");
        }
    }
}

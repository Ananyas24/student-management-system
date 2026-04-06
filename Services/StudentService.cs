using Microsoft.Extensions.Logging;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repo, ILogger<StudentService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            _logger.LogInformation("Fetching all students");

            var students = await _repo.GetAllAsync();

            _logger.LogInformation("Fetched {Count} students", students.Count);

            return students;
        }

        public async Task<Student?> GetStudent(int id)
        {
            _logger.LogInformation("Fetching student with ID: {Id}", id);

            var student = await _repo.GetByIdAsync(id);

            if (student == null)
            {
                _logger.LogWarning("Student not found with ID: {Id}", id);
            }

            return student;
        }

        public async Task AddStudent(Student student)
        {
            _logger.LogInformation("Adding new student: {Name}", student.Name);

            await _repo.AddAsync(student);

            _logger.LogInformation("Student added successfully: {Name}", student.Name);
        }

        public async Task UpdateStudent(int id, Student student)
        {
            _logger.LogInformation("Updating student with ID: {Id}", id);

            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
            {
                _logger.LogWarning("Update failed. Student not found with ID: {Id}", id);
                throw new Exception("Student not found");
            }

            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Age = student.Age;
            existing.Course = student.Course;

            await _repo.UpdateAsync(existing);

            _logger.LogInformation("Student updated successfully with ID: {Id}", id);
        }

        public async Task DeleteStudent(int id)
        {
            _logger.LogInformation("Deleting student with ID: {Id}", id);

            await _repo.DeleteAsync(id);

            _logger.LogInformation("Student deleted successfully with ID: {Id}", id);
        }
    }
}

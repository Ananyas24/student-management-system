using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetStudent(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(int id, Student student);
        Task DeleteStudent(int id);
    }
}

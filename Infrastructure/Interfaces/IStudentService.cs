using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Task<List<GetStudentDto>> GetStudents();
    Task<GetStudentDto> GetStudentById(int id);
    Task<GetStudentDto> AddStudent(AddStudentDto addStudent);
    Task<GetStudentDto> UpdateStudent(AddStudentDto addStudent);
    Task<bool> DeleteStudent(int id);
    Task<int> CountStudent();
}
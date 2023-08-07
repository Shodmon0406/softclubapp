using Domain.Dtos;

namespace Infrastructure.Interfaces;

public interface ITeacherService
{
    Task<List<GetTeacherDto>> GetTeachers();
    Task<GetTeacherDto> GetTeacherById(int id);
    Task<GetTeacherDto> AddTeacher(AddTeacherDto addTeacher);
    Task<GetTeacherDto> UpdateTeacher(AddTeacherDto addTeacher);
    Task<bool> DeleteTeacher(int id);
    Task<int> CountTeacher();
}
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<List<GetCourseDto>> GetCourses();
    Task<GetCourseDto> GetCourseById(int id);
    Task<GetCourseDto> AddCourse(AddCourseDto addCourse);
    Task<GetCourseDto> UpdateCourse(AddCourseDto addCourse);
    Task<bool> DeleteCourse(int id);
    Task<int> CountCourse();
}
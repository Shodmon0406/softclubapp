using Domain.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CourseController
{
    private ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("get-courses")]
    public async Task<List<GetCourseDto>> GetCourses()
    {
        return await _courseService.GetCourses();
    }

    [HttpGet("get-course-by-id")]
    public async Task<GetCourseDto> GetCourseById(int id)
    {
        return await _courseService.GetCourseById(id);
    }

    [HttpPost("add-course")]
    public async Task<GetCourseDto> AddCourse([FromForm]AddCourseDto addCourse)
    {
        return await _courseService.AddCourse(addCourse);
    }

    [HttpPut("update-course")]
    public async Task<GetCourseDto> UpdateCourse([FromForm]AddCourseDto addCourse)
    {
        return await _courseService.UpdateCourse(addCourse);
    }

    [HttpDelete("delete-course")]
    public async Task<bool> DeleteCourse(int id)
    {
        return await _courseService.DeleteCourse(id);
    }

    [HttpGet("count-course")]
    public async Task<int> CountCourse()
    {
        return await _courseService.CountCourse();
    }
}
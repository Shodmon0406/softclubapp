using Domain.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class TeacherController : ControllerBase
{
    private ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("get-teachers")]
    public async Task<List<GetTeacherDto>> GetTeachers()
    {
        return await _teacherService.GetTeachers();
    }

    [HttpGet("get-teacher-by-id")]
    public async Task<GetTeacherDto> GetTeacherById(int id)
    {
        return await _teacherService.GetTeacherById(id);
    }

    [HttpPost("add-teacher")]
    public async Task<GetTeacherDto> AddTeacher([FromForm]AddTeacherDto addTeacher)
    {
        return await _teacherService.AddTeacher(addTeacher);
    }

    [HttpPut("update-teacher")]
    public async Task<GetTeacherDto> UpdateTeacher([FromForm]AddTeacherDto addTeacher)
    {
        return await _teacherService.UpdateTeacher(addTeacher);
    }

    [HttpDelete("delete-teacher")]
    public async Task<bool> DeleteTeacher(int id)
    {
        return await _teacherService.DeleteTeacher(id);
    }

    [HttpGet("count-teacher")]
    public async Task<int> GetCount()
    {
        return await _teacherService.CountTeacher();
    }
}
using Domain.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class StudentController : ControllerBase
{
    private IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("get-students")]
    public async Task<List<GetStudentDto>> GetStudents()
    {
        return await _studentService.GetStudents();
    }

    [HttpGet("get-student-by-id")]
    public async Task<GetStudentDto> GetStudentById(int id)
    {
        return await _studentService.GetStudentById(id);
    }

    [HttpPost("add-student")]
    public async Task<GetStudentDto> AddStudent([FromForm]AddStudentDto addStudent)
    {
        return await _studentService.AddStudent(addStudent);
    }

    [HttpPut("update-student")]
    public async Task<GetStudentDto> UpdateStudent([FromForm]AddStudentDto addStudent)
    {
        return await _studentService.UpdateStudent(addStudent);
    }

    [HttpDelete("delete-student")]
    public async Task<bool> DeleteStudent(int id)
    {
        return await _studentService.DeleteStudent(id);
    }

    [HttpGet("get-count-from-student")]
    public async Task<int> GetCount()
    {
        return await _studentService.CountStudent();
    }
}
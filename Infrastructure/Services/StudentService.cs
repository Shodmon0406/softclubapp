using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private DataContext _context;

    public StudentService(DataContext context)
    {
        _context = context;
    }
    

    public async Task<List<GetStudentDto>> GetStudents()
    {
        return await _context.Students.Select(s => new GetStudentDto()
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            FatherName = s.FatherName,
            BirthDate = s.BirthDate,
            Address = s.Address,
            Phone = s.Phone
        }).ToListAsync();
    }

    public async Task<GetStudentDto> GetStudentById(int id)
    {
        return await _context.Students.Select(s => new GetStudentDto()
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            FatherName = s.FatherName,
            BirthDate = s.BirthDate,
            Address = s.Address,
            Phone = s.Phone
        }).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<GetStudentDto> AddStudent(AddStudentDto addStudent)
    {
        var student = new Student()
        {
            Id = addStudent.Id,
            FirstName = addStudent.FirstName,
            LastName = addStudent.LastName,
            FatherName = addStudent.FatherName,
            BirthDate = addStudent.BirthDate,
            Address = addStudent.Address,
            Phone = addStudent.Phone
        };
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return new GetStudentDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            FatherName = student.FatherName,
            BirthDate = student.BirthDate,
            Address = student.Address,
            Phone = student.Phone
        };
    }

    public async Task<GetStudentDto> UpdateStudent(AddStudentDto addStudent)
    {
        var student = new Student()
        {
            Id = addStudent.Id,
            FirstName = addStudent.FirstName,
            LastName = addStudent.LastName,
            FatherName = addStudent.FatherName,
            BirthDate = addStudent.BirthDate,
            Address = addStudent.Address,
            Phone = addStudent.Phone
        };
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return new GetStudentDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            FatherName = student.FatherName,
            BirthDate = student.BirthDate,
            Address = student.Address,
            Phone = student.Phone
        };
    }

    public async Task<bool> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return false;
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<int> CountStudent()
    {
        return await _context.Students.CountAsync();
    }
}
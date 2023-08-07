using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeacherService : ITeacherService
{
    private DataContext _context;

    public TeacherService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTeacherDto>> GetTeachers()
    {
        return await _context.Teachers.Select(t => new GetTeacherDto()
        {
            Id = t.Id,
            Name = t.Name,
            Surname = t.Surname,
            Position = t.Position,
            Experience = t.Experience
        }).ToListAsync();
    }

    public async Task<GetTeacherDto> GetTeacherById(int id)
    {
        return await _context.Teachers.Select(t => new GetTeacherDto()
        {
            Id = t.Id,
            Name = t.Name,
            Surname = t.Surname,
            Position = t.Position,
            Experience = t.Experience
        }).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<GetTeacherDto> AddTeacher(AddTeacherDto addTeacher)
    {
        var teacher = new Teacher()
        {
            Id = addTeacher.Id,
            Name = addTeacher.Name,
            Surname = addTeacher.Surname,
            Position = addTeacher.Position,
            Experience = addTeacher.Experience
        };
        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();
        return new GetTeacherDto()
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Surname = teacher.Surname,
            Position = teacher.Position,
            Experience = teacher.Experience
        };
    }

    public async Task<GetTeacherDto> UpdateTeacher(AddTeacherDto addTeacher)
    {
        var teacher = new Teacher()
        {
            Id = addTeacher.Id,
            Name = addTeacher.Name,
            Surname = addTeacher.Surname,
            Position = addTeacher.Position,
            Experience = addTeacher.Experience
        };
        _context.Teachers.Update(teacher);
        await _context.SaveChangesAsync();
        return new GetTeacherDto()
        {
            Id = teacher.Id,
            Name = teacher.Name,
            Surname = teacher.Surname,
            Position = teacher.Position,
            Experience = teacher.Experience
        };
    }

    public async Task<bool> DeleteTeacher(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null) return false;
        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<int> CountTeacher()
    {
        return await _context.Teachers.CountAsync();
    }
}
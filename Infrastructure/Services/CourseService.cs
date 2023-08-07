using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService : ICourseService
{
    private DataContext _context;

    public CourseService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetCourseDto>> GetCourses()
    {
        return await _context.Courses.Select(c => new GetCourseDto()
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Fee = c.Fee,
            HasDiscount = c.HasDiscount
        }).ToListAsync();
    }

    public async Task<GetCourseDto> GetCourseById(int id)
    {
        return await _context.Courses.Select(c => new GetCourseDto()
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Fee = c.Fee,
            HasDiscount = c.HasDiscount
        }).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<GetCourseDto> AddCourse(AddCourseDto addCourse)
    {
        var course = new Course()
        {
            Id = addCourse.Id,
            Title = addCourse.Title,
            Description = addCourse.Description,
            Fee = addCourse.Fee,
            HasDiscount = addCourse.HasDiscount
        };
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
        return new GetCourseDto()
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            Fee = course.Fee,
            HasDiscount = course.HasDiscount
        };
    }

    public async Task<GetCourseDto> UpdateCourse(AddCourseDto addCourse)
    {
        var course = new Course()
        {
            Id = addCourse.Id,
            Title = addCourse.Title,
            Description = addCourse.Description,
            Fee = addCourse.Fee,
            HasDiscount = addCourse.HasDiscount
        };
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
        return new GetCourseDto()
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            Fee = course.Fee,
            HasDiscount = course.HasDiscount
        };
    }

    public async Task<bool> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return false;
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<int> CountCourse()
    {
        return await _context.Courses.CountAsync();
    }
}
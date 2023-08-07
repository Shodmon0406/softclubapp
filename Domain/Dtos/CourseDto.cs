namespace Domain.Dtos;

public class CourseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Fee { get; set; }
    public bool HasDiscount { get; set; }
}
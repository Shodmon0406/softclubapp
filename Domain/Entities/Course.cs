using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Title { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public decimal Fee { get; set; }
    public bool HasDiscount { get; set; }
}
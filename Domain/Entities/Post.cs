using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Post
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Title { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public int Vote { get; set; }
    public DateTime CreatedAt { get; set; }
}
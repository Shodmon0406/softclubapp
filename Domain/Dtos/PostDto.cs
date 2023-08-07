namespace Domain.Dtos;

public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int Vote { get; set; }
    public DateTime CreatedAt { get; set; }
}
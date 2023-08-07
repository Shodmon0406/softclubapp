using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Teacher
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(30)]
    public string Surname { get; set; }
    [MaxLength(30)]
    public string Position { get; set; }
    public int Experience { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Student
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [MaxLength(30)]
    public string? FatherName { get; set; }
    public DateTime BirthDate { get; set; }
    [MaxLength(150)]
    public string Address { get; set; }
    [MaxLength(20)]
    public string Phone { get; set; }
}
namespace Domain.Dtos;

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? FatherName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTOs;

public class DoctorDto
{
    [Required]
    [Range(0,Int32.MaxValue)]
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
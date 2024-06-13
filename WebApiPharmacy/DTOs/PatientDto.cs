using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTOs;

public class PatientDto
{
    [Required]
    public int IdPatients { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    
}

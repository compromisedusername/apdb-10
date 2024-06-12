using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;

namespace WebApplication3.DTOs;

public class RequestPrescriptionDto
{
    [Required]
    public PatientDto Patient { get; set; } 
    [Required]
    public List<MedicamentDto> Medicaments { get; set; }
    [Timestamp]
    public DateTime Date { get; set; }
    [Timestamp]
    public DateTime DueDate { get; set; }
}

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Type { get; set; }
}

public class PatientDto
{
    [Required]
    public int IdPatients { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string BirthDate { get; set; }
    
}
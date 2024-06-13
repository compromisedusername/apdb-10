using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;

namespace WebApplication3.DTOs;

public class RequestPrescriptionDto
{
    [Required]
    public PatientDto Patient { get; set; } 
    [Required]
    public List<MedicamentDto> Medicaments { get; set; }

    public int IdDoctor { get; set; }
    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }
}






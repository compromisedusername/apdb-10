using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTOs;

public class MedicamentDto
{
    [Required]
    public int IdMedicament { get; set; }
    [Required]
    public int? Dose { get; set; } 
    [Required] 
    public string Details { get; set; }
    [Required]
    public string Description { get; set; }
    
}